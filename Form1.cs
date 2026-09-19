using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FirewallAppGuard
{
    public partial class Form1 : Form
    {
        // Prefix untuk semua rule buatan tool ini. Jangan diubah setelah rilis,
        // karena rule lama tidak akan dikenali lagi kalau prefix berubah.
        private const string RulePrefix = "FirewallAppGuard - ";

        private class AppEntry
        {
            public string Name;
            public string Path;
            public bool Blocked;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadExistingRules();
        }

        // ---------- Muat rule yang sudah ada ----------

        private void LoadExistingRules()
        {
            lstApps.Items.Clear();

            // Simpan path yang sudah ada di list supaya tidak dobel
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            try
            {
                string output = RunNetshCapture("advfirewall firewall show rule name=all verbose");

                // Parse output: cari blok rule yang namanya diawali prefix kita
                string currentName = null;
                string currentPath = null;

                foreach (var raw in output.Split('\n'))
                {
                    string line = raw.Trim();

                    if (line.StartsWith("Rule Name:", StringComparison.OrdinalIgnoreCase))
                    {
                        // blok rule baru dimulai; proses yang sebelumnya kalau lengkap
                        AddParsedRule(currentName, currentPath, seen);
                        currentName = line.Substring("Rule Name:".Length).Trim();
                        currentPath = null;
                    }
                    else if (line.StartsWith("Program:", StringComparison.OrdinalIgnoreCase))
                    {
                        currentPath = line.Substring("Program:".Length).Trim();
                    }
                }
                // rule terakhir
                AddParsedRule(currentName, currentPath, seen);

                SetStatus(lstApps.Items.Count + " blocked app(s) loaded.");
            }
            catch (Exception ex)
            {
                SetStatus("Could not read firewall rules: " + ex.Message);
            }
        }

        private void AddParsedRule(string ruleName, string programPath, HashSet<string> seen)
        {
            if (string.IsNullOrEmpty(ruleName)) return;
            if (!ruleName.StartsWith(RulePrefix, StringComparison.OrdinalIgnoreCase)) return;
            if (string.IsNullOrEmpty(programPath)) return;
            if (programPath.Equals("Any", StringComparison.OrdinalIgnoreCase)) return;
            if (seen.Contains(programPath)) return;

            seen.Add(programPath);

            string name = ruleName.Substring(RulePrefix.Length).Trim();
            AddRow(new AppEntry { Name = name, Path = programPath, Blocked = true });
        }

        // ---------- Tampilan list ----------

        private void AddRow(AppEntry app)
        {
            var item = new ListViewItem(app.Name);
            item.SubItems.Add(app.Blocked ? "Blocked" : "Allowed");
            item.SubItems.Add(app.Path);
            item.Tag = app;
            item.ForeColor = app.Blocked ? ColBlocked : ColAllowed;
            lstApps.Items.Add(item);
        }

        private AppEntry SelectedApp()
        {
            if (lstApps.SelectedItems.Count == 0) return null;
            return lstApps.SelectedItems[0].Tag as AppEntry;
        }

        private void RefreshRow(ListViewItem item)
        {
            var app = item.Tag as AppEntry;
            if (app == null) return;
            item.SubItems[1].Text = app.Blocked ? "Blocked" : "Allowed";
            item.ForeColor = app.Blocked ? ColBlocked : ColAllowed;
        }

        // ---------- Add ----------

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) != DialogResult.OK) return;
            AddAppByPath(ofd.FileName);
        }

        private void AddAppByPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return;
            if (!File.Exists(path))
            {
                MessageBox.Show("That file does not exist.", "Firewall App Guard",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // sudah ada di list?
            foreach (ListViewItem it in lstApps.Items)
            {
                var a = it.Tag as AppEntry;
                if (a != null && a.Path.Equals(path, StringComparison.OrdinalIgnoreCase))
                {
                    it.Selected = true;
                    it.EnsureVisible();
                    SetStatus("That app is already in the list.");
                    return;
                }
            }

            var app = new AppEntry
            {
                Name = Path.GetFileNameWithoutExtension(path),
                Path = path,
                Blocked = false
            };
            AddRow(app);
            SetStatus("Added " + app.Name + ". Select it and click Block Internet to block it.");
        }

        // ---------- Block ----------

        private void btnBlock_Click(object sender, EventArgs e)
        {
            var app = SelectedApp();
            if (app == null)
            {
                MessageBox.Show("Select an app first.", "Firewall App Guard",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (app.Blocked)
            {
                SetStatus(app.Name + " is already blocked.");
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                string ruleName = RulePrefix + app.Name;

                // Blokir outbound dan inbound, biar benar-benar terputus
                RunNetsh(string.Format(
                    "advfirewall firewall add rule name=\"{0}\" dir=out action=block program=\"{1}\" enable=yes",
                    ruleName, app.Path));
                RunNetsh(string.Format(
                    "advfirewall firewall add rule name=\"{0}\" dir=in action=block program=\"{1}\" enable=yes",
                    ruleName, app.Path));

                app.Blocked = true;
                RefreshRow(lstApps.SelectedItems[0]);
                SetStatus(app.Name + " is now blocked from the internet.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to block the app:\n" + ex.Message, "Firewall App Guard",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Block failed.");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ---------- Allow (hapus rule blokir tapi tetap di list) ----------

        private void btnAllow_Click(object sender, EventArgs e)
        {
            var app = SelectedApp();
            if (app == null)
            {
                MessageBox.Show("Select an app first.", "Firewall App Guard",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!app.Blocked)
            {
                SetStatus(app.Name + " is not blocked.");
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                DeleteRuleFor(app.Name);
                app.Blocked = false;
                RefreshRow(lstApps.SelectedItems[0]);
                SetStatus(app.Name + " can access the internet again.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to allow the app:\n" + ex.Message, "Firewall App Guard",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Allow failed.");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ---------- Remove (hapus rule + keluarkan dari list) ----------

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var app = SelectedApp();
            if (app == null)
            {
                MessageBox.Show("Select an app first.", "Firewall App Guard",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                if (app.Blocked)
                    DeleteRuleFor(app.Name);

                lstApps.Items.Remove(lstApps.SelectedItems[0]);
                SetStatus(app.Name + " removed from the list.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to remove:\n" + ex.Message, "Firewall App Guard",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Remove failed.");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DeleteRuleFor(string appName)
        {
            string ruleName = RulePrefix + appName;
            // Hapus semua rule dengan nama itu (in dan out sekaligus)
            RunNetsh(string.Format("advfirewall firewall delete rule name=\"{0}\"", ruleName));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadExistingRules();
        }

        // ---------- Header ----------

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            var p = (Panel)sender;
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(70, 70, 76), 1))
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
        }

        private void lnkSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try { Process.Start("https://minanatech.com"); }
            catch { MessageBox.Show("Could not open the browser.", "Firewall App Guard"); }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (var f = new InfoForm(InfoForm.Mode.About)) f.ShowDialog(this);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            using (var f = new InfoForm(InfoForm.Mode.Help)) f.ShowDialog(this);
        }

        // ---------- netsh helper ----------

        private void RunNetsh(string arguments)
        {
            RunProcess("netsh", arguments, false);
        }

        private string RunNetshCapture(string arguments)
        {
            return RunProcess("netsh", arguments, true);
        }

        private string RunProcess(string fileName, string arguments, bool capture)
        {
            var psi = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (var p = Process.Start(psi))
            {
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();

                if (p.ExitCode != 0)
                {
                    string msg = !string.IsNullOrWhiteSpace(error) ? error : output;
                    throw new Exception(string.IsNullOrWhiteSpace(msg)
                        ? fileName + " exited with code " + p.ExitCode
                        : msg.Trim());
                }
                return output;
            }
        }

        private void SetStatus(string text)
        {
            lblStatus.Text = text;
            bool bad = text.IndexOf("fail", StringComparison.OrdinalIgnoreCase) >= 0
                    || text.IndexOf("could not", StringComparison.OrdinalIgnoreCase) >= 0;
            lblStatusDot.ForeColor = bad ? ColDanger : ColText;
        }
    }
}