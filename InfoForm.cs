using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FirewallAppGuard
{
    public class InfoForm : Form
    {
        public enum Mode { About, Help }

        public InfoForm(Mode mode)
        {
            BackColor = Form1.ColBg;
            ForeColor = Form1.ColText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(520, mode == Mode.About ? 320 : 470);
            Text = mode == Mode.About ? "About Firewall App Guard" : "How to use Firewall App Guard";

            var header = new Panel
            {
                BackColor = Form1.ColPanel,
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 56)
            };
            header.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(70, 70, 76), 1))
                    e.Graphics.DrawLine(pen, 0, header.Height - 1, header.Width, header.Height - 1);
            };
            Controls.Add(header);

            header.Controls.Add(new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(18, 14),
                Text = mode == Mode.About ? "Firewall App Guard" : "How to use"
            });

            var body = new Label
            {
                BackColor = Color.Transparent,
                ForeColor = Form1.ColText,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, 72),
                Size = new Size(480, ClientSize.Height - 72 - 92),
                Text = mode == Mode.About ? AboutText() : HelpText()
            };
            Controls.Add(body);

            var link = new LinkLabel
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                LinkColor = Form1.ColText,
                ActiveLinkColor = Color.White,
                LinkBehavior = LinkBehavior.HoverUnderline,
                Location = new Point(20, ClientSize.Height - 78),
                Text = "minanatech.com"
            };
            link.LinkClicked += (s, e) =>
            {
                try { Process.Start("https://minanatech.com"); } catch { }
            };
            Controls.Add(link);

            var btnClose = new Button
            {
                FlatStyle = FlatStyle.Flat,
                BackColor = Form1.ColAccentDk,
                ForeColor = Color.FromArgb(20, 20, 22),
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Size = new Size(110, 32),
                Location = new Point(ClientSize.Width - 130, ClientSize.Height - 46),
                Text = "Close",
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => Close();
            Controls.Add(btnClose);
            AcceptButton = btnClose;
        }

        private string AboutText()
        {
            return
                "Version 1.0\r\n\r\n" +
                "Firewall App Guard blocks or allows individual programs from " +
                "accessing the internet, using the Windows Firewall that is already " +
                "built into your system. It does not install a driver or a background " +
                "service, and it only ever touches the rules it creates itself.\r\n\r\n" +
                "It is free software. No cost, no ads, no data collection. Developed and " +
                "published by minanatech.com. Always download it from the official website " +
                "to make sure you get an unmodified copy.";
        }

        private string HelpText()
        {
            return
                "1.  Add an app\r\n" +
                "     Click Add App and pick the program's .exe file. It appears in the\r\n" +
                "     list as Allowed, meaning nothing has been blocked yet.\r\n\r\n" +
                "2.  Block it\r\n" +
                "     Select the app in the list and click Block Internet. Firewall App\r\n" +
                "     Guard adds rules to the Windows Firewall that stop it reaching the\r\n" +
                "     network, both incoming and outgoing.\r\n\r\n" +
                "3.  Allow it again\r\n" +
                "     Select a blocked app and click Allow Internet. The rules are removed\r\n" +
                "     and the app can connect normally, but it stays in the list.\r\n\r\n" +
                "4.  Remove\r\n" +
                "     Takes the app out of the list entirely. If it was blocked, the rules\r\n" +
                "     are removed too, so the app is no longer restricted.\r\n\r\n" +
                "Refresh re-reads the firewall and shows every app currently blocked by\r\n" +
                "this program, including ones blocked in an earlier session.\r\n\r\n" +
                "Administrator rights are required, because changing firewall rules needs them.";
        }
    }
}