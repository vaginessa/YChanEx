﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YChanEx {
    public partial class frmMain : Form {
        List<Form> Threads = new List<Form>();
        List<frmDownloader> FCThreads = new List<frmDownloader>();
        List<string> ThreadURLS = new List<string>();
        List<int> ThreadType = new List<int>();
        public frmMain() {
            InitializeComponent();
            niTray.Icon = Properties.Resources.YChanEx;
            this.Icon = Properties.Resources.YChanEx;
        }
        public void Announce404(string URL) {
            Thread Call404 = new Thread(() => {
                this.BeginInvoke(new MethodInvoker(() => {
                    int ThreadIndex = ThreadURLS.IndexOf(URL);
                    niTray.Icon = Properties.Resources.YChanEx404;
                    niTray.BalloonTipText = URL + " has 404";
                    niTray.ShowBalloonTip(5000);
                    Thread.Sleep(5000);
                    niTray.Icon = Properties.Resources.YChanEx;
                }));
            });
            Call404.Start();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            
        }


        private void btnAdd_Click(object sender, EventArgs e) {
            frmDownloader newThread = new frmDownloader();
            newThread.ThreadURL = txtThreadURL.Text;
            newThread.ChanType = 0;
            newThread.DownloadPath = "";
            newThread.StartDownload();
            Threads.Add(newThread);
            lbThreads.Items.Add(txtThreadURL.Text);
            ThreadURLS.Add(txtThreadURL.Text);
            newThread.Show();
            newThread.Hide();
        }

        private void lbThreads_MouseDoubleClick(object sender, MouseEventArgs e) {
            int ClickedIndex = lbThreads.IndexFromPoint(e.Location);
            if (ClickedIndex != ListBox.NoMatches) {
                Threads[ClickedIndex].Show();
            }
        }
    }
}
