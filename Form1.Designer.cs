using System.Drawing;
using System.Windows.Forms;

namespace FirewallAppGuard
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        // ---- palet monokrom (dipakai Form1.cs & InfoForm.cs) ----
        public static readonly Color ColBg = Color.FromArgb(24, 24, 26);
        public static readonly Color ColPanel = Color.FromArgb(32, 32, 35);
        public static readonly Color ColPanel2 = Color.FromArgb(44, 44, 48);
        public static readonly Color ColBorder = Color.FromArgb(62, 62, 68);
        public static readonly Color ColAccent = Color.FromArgb(240, 240, 245);
        public static readonly Color ColAccentDk = Color.FromArgb(228, 228, 234);
        public static readonly Color ColText = Color.FromArgb(232, 232, 236);
        public static readonly Color ColTextDim = Color.FromArgb(142, 142, 150);
        public static readonly Color ColSection = Color.FromArgb(170, 170, 178);
        public static readonly Color ColMark = Color.FromArgb(110, 110, 118);
        public static readonly Color ColDanger = Color.FromArgb(200, 92, 92);
        public static readonly Color ColBlocked = Color.FromArgb(210, 120, 120);
        public static readonly Color ColAllowed = Color.FromArgb(150, 190, 150);

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.lnkSite = new System.Windows.Forms.LinkLabel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBlock = new System.Windows.Forms.Button();
            this.btnAllow = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstApps = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatusDot = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblTagline);
            this.pnlHeader.Controls.Add(this.lnkSite);
            this.pnlHeader.Controls.Add(this.btnHelp);
            this.pnlHeader.Controls.Add(this.btnAbout);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1013, 91);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(263, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Firewall App Guard";
            // 
            // lblTagline
            // 
            this.lblTagline.AutoSize = true;
            this.lblTagline.BackColor = System.Drawing.Color.Transparent;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.lblTagline.Location = new System.Drawing.Point(31, 54);
            this.lblTagline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(220, 19);
            this.lblTagline.TabIndex = 1;
            this.lblTagline.Text = "Block apps from the internet  •  by";
            // 
            // lnkSite
            // 
            this.lnkSite.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkSite.AutoSize = true;
            this.lnkSite.BackColor = System.Drawing.Color.Transparent;
            this.lnkSite.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lnkSite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.lnkSite.Location = new System.Drawing.Point(344, 54);
            this.lnkSite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkSite.Name = "lnkSite";
            this.lnkSite.Size = new System.Drawing.Size(119, 19);
            this.lnkSite.TabIndex = 2;
            this.lnkSite.TabStop = true;
            this.lnkSite.Text = "minanatech.com";
            this.lnkSite.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.lnkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSite_LinkClicked);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(68)))));
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(61)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.btnHelp.Location = new System.Drawing.Point(771, 30);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(101, 34);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "How to use";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(68)))));
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(61)))));
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.btnAbout.Location = new System.Drawing.Point(883, 30);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(101, 34);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.pnlToolbar.Controls.Add(this.btnAdd);
            this.pnlToolbar.Controls.Add(this.btnBlock);
            this.pnlToolbar.Controls.Add(this.btnAllow);
            this.pnlToolbar.Controls.Add(this.btnRemove);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Location = new System.Drawing.Point(21, 106);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(971, 57);
            this.pnlToolbar.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(22)))));
            this.btnAdd.Location = new System.Drawing.Point(0, 7);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 42);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add App…";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBlock
            // 
            this.btnBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btnBlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(68)))));
            this.btnBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(61)))));
            this.btnBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBlock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.btnBlock.Location = new System.Drawing.Point(176, 7);
            this.btnBlock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(160, 42);
            this.btnBlock.TabIndex = 1;
            this.btnBlock.Text = "Block Internet";
            this.btnBlock.UseVisualStyleBackColor = false;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // btnAllow
            // 
            this.btnAllow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btnAllow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(68)))));
            this.btnAllow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(61)))));
            this.btnAllow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAllow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.btnAllow.Location = new System.Drawing.Point(352, 7);
            this.btnAllow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAllow.Name = "btnAllow";
            this.btnAllow.Size = new System.Drawing.Size(160, 42);
            this.btnAllow.TabIndex = 2;
            this.btnAllow.Text = "Allow Internet";
            this.btnAllow.UseVisualStyleBackColor = false;
            this.btnAllow.Click += new System.EventHandler(this.btnAllow_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(68)))));
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(61)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.btnRemove.Location = new System.Drawing.Point(528, 7);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(160, 42);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(68)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(61)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.btnRefresh.Location = new System.Drawing.Point(837, 7);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(133, 42);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstApps
            // 
            this.lstApps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.lstApps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colStatus,
            this.colPath});
            this.lstApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.lstApps.FullRowSelect = true;
            this.lstApps.HideSelection = false;
            this.lstApps.Location = new System.Drawing.Point(21, 172);
            this.lstApps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstApps.Name = "lstApps";
            this.lstApps.Size = new System.Drawing.Size(970, 393);
            this.lstApps.TabIndex = 2;
            this.lstApps.UseCompatibleStateImageBehavior = false;
            this.lstApps.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Application";
            this.colName.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 110;
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 400;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.pnlStatus.Controls.Add(this.lblStatusDot);
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Location = new System.Drawing.Point(0, 583);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1013, 37);
            this.pnlStatus.TabIndex = 3;
            // 
            // lblStatusDot
            // 
            this.lblStatusDot.AutoSize = true;
            this.lblStatusDot.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusDot.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatusDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.lblStatusDot.Location = new System.Drawing.Point(19, 4);
            this.lblStatusDot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusDot.Name = "lblStatusDot";
            this.lblStatusDot.Size = new System.Drawing.Size(20, 28);
            this.lblStatusDot.TabIndex = 0;
            this.lblStatusDot.Text = "•";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.lblStatus.Location = new System.Drawing.Point(40, 10);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 19);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Ready";
            // 
            // ofd
            // 
            this.ofd.Filter = "Programs (*.exe)|*.exe|All files (*.*)|*.*";
            this.ofd.Title = "Choose an application to add";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1013, 620);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.lstApps);
            this.Controls.Add(this.pnlStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firewall App Guard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.LinkLabel lnkSite;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.Button btnAllow;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lstApps;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatusDot;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.OpenFileDialog ofd;
    }
}