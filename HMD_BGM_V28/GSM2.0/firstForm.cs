using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GSM2._0
{
    public partial class firstForm : Form
    {
        public firstForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menuFrom f = new menuFrom();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            downloadForm4 f = new downloadForm4();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.FileName = "mailto:info@glucoplus.ca?subject=Hello HMDd";
            proc.StartInfo.FileName = "mailto:" + alu_tp.main_1.rm_txt.GetString("firstFormComm6") + "?subject=Hello HMDd";
            proc.Start();
        }

        #region InitControl
        private void InitControl()
        {
            label1.Text = alu_tp.main_1.rm_txt.GetString("firstFormToptic");
            button1.Text = alu_tp.main_1.rm_txt.GetString("btnMeterReadings");
            button2.Text = alu_tp.main_1.rm_txt.GetString("btnReports");
            label3.Text = alu_tp.main_1.rm_txt.GetString("firstFormComm1");
            label2.Text = alu_tp.main_1.rm_txt.GetString("firstFormComm2");
            label5.Text = alu_tp.main_1.rm_txt.GetString("firstFormComm3");
            label6.Text = alu_tp.main_1.rm_txt.GetString("firstFormComm4");
            label4.Text = alu_tp.main_1.rm_txt.GetString("firstFormComm5");
            linkLabel1.Text = alu_tp.main_1.rm_txt.GetString("firstFormComm6");
        }
        #endregion

        private void firstForm_Load(object sender, EventArgs e)
        {
            InitControl();
        }
    }
}