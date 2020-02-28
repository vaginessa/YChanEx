﻿namespace YChanEx {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtThreadURL = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mSettings = new System.Windows.Forms.MenuItem();
            this.mAbout = new System.Windows.Forms.MenuItem();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.lvThreads = new YChanEx.VistaListView();
            this.clThread = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(282, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtThreadURL
            // 
            this.txtThreadURL.Location = new System.Drawing.Point(12, 5);
            this.txtThreadURL.Name = "txtThreadURL";
            this.txtThreadURL.Size = new System.Drawing.Size(264, 20);
            this.txtThreadURL.TabIndex = 2;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mSettings,
            this.mAbout});
            // 
            // mSettings
            // 
            this.mSettings.Index = 0;
            this.mSettings.Text = "Settings";
            this.mSettings.Click += new System.EventHandler(this.mSettings_Click);
            // 
            // mAbout
            // 
            this.mAbout.Index = 1;
            this.mAbout.Text = "About";
            // 
            // niTray
            // 
            this.niTray.Text = "YChanEx";
            this.niTray.Visible = true;
            // 
            // lvThreads
            // 
            this.lvThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clThread});
            this.lvThreads.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvThreads.EnableVistaView = true;
            this.lvThreads.FullRowSelect = true;
            this.lvThreads.Location = new System.Drawing.Point(0, 49);
            this.lvThreads.Name = "lvThreads";
            this.lvThreads.Size = new System.Drawing.Size(342, 171);
            this.lvThreads.TabIndex = 3;
            this.lvThreads.UseCompatibleStateImageBehavior = false;
            this.lvThreads.View = System.Windows.Forms.View.Details;
            // 
            // clThread
            // 
            this.clThread.Text = "Threads";
            this.clThread.Width = 310;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 220);
            this.Controls.Add(this.lvThreads);
            this.Controls.Add(this.txtThreadURL);
            this.Controls.Add(this.btnAdd);
            this.MaximumSize = new System.Drawing.Size(350, 250);
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(350, 250);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YChanEx";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtThreadURL;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mSettings;
        private System.Windows.Forms.MenuItem mAbout;
        private System.Windows.Forms.NotifyIcon niTray;
        private VistaListView lvThreads;
        private System.Windows.Forms.ColumnHeader clThread;
    }
}

