using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace GSM2._0
{
    public partial class menuFrom : Form
    {
        public menuFrom()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           databaseFrom f = new databaseFrom();
           // database2From f = new database2From();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            curveAllACFrom f = new curveAllACFrom();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            curveAllPCForm f = new curveAllPCForm();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            curveAllForm f = new curveAllForm();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Close();
        }

        private void menuFrom_Load(object sender, EventArgs e)
        {
            label4.Text = alu_tp.main_1.ReportName;
        }
    }
}
