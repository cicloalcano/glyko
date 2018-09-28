using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace GSM2._0
{
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
//            aboutForm g = new aboutForm();
//            g.Close();
            this.Close();
        }
        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_About");
            button1.Text = alu_tp.main_1.rm_txt.GetString("OK");
            label1.Text = alu_tp.main_1.rm_txt.GetString("aboutFormToptic");
        }
        #endregion

        private void aboutForm_Load(object sender, EventArgs e)
        {
            InitControls();
            linkLabel1.Links.Remove(linkLabel1.Links[0]);
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, "http://www.hmdbio.com");
            //label1.Text += "\n" + "Date：" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString(); 2015.01.08 denny
            label2.Text = "Date：" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);

        }

      
    }
}
