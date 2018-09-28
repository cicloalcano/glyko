using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
namespace GSM2._0
{
    public partial class mainForm : Form
    {
        PrintPreviewDialog p = new PrintPreviewDialog();
        Bitmap img;
        public mainForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == DeviceManagement.WM_DEVICECHANGE)
                {
                    usb.FindTheHid();
                    usb.OnDeviceChange(m);
                    if (alu_tp.main_1.myDeviceDetected) alu_tp.main_1.port_usb = 2;else alu_tp.main_1.port_usb = 1;
                }

                base.WndProc(ref m);
            }
            catch (Exception ex)
            {
            }
        }        

        public static void ClearAllForm()
        {
            columnGluFrom f = new columnGluFrom();
            f.Close();
            curveAllACFrom f1 = new curveAllACFrom();
            f1.Close();
            downloadForm4 f2 = new downloadForm4();
            f2.Close();
        }
        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("BloodGlucoseManagementProgramVer");
            mainMToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_Main");
            glicosimetroConfiguraçõesToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_SettingUser");            
            exitEToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_Exit");
            ddMToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_Meter");
            ddDToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_DownloadMeterReadings");
            readRToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_Report");
            datalistLToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_DataList");
            gacpcToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_CurveGraphACPC");
            lineHToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_GlucoseAnalysisColumnGraph");
            allgTToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_ALLGraph");
            gbac1ToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_DayList");
            gbpc2ToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_DistributionGroup");
            glac3ToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_DayGroup");
            glpc4ToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_WeekGroup");
            gdac5ToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_TrendGroup");
            ppPToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_Print");
            psetupSToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_PrintSetup");
            pviewRToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_PrintPreview");
            meHToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_Help");
            meAToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Menu_About");
            toolStripButton1.ToolTipText = alu_tp.main_1.rm_txt.GetString("ToolTip_Home");
            toolStripButton2.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_SettingUser");
            toolStripButton4.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_DownloadMeterReadings");
            toolStripButton6.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_DataList");
            toolStripButton7.ToolTipText = alu_tp.main_1.rm_txt.GetString("ToolTip_CurveGraphAC");
            toolStripButton8.ToolTipText = alu_tp.main_1.rm_txt.GetString("ToolTip_CurveGraphPC");
            toolStripButton9.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_CurveGraphACPC");
            toolStripButton10.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_GlucoseAnalysisColumnGraph");
            toolStripButton11.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_ALLGraph");
            toolStripButton12.ToolTipText = alu_tp.main_1.rm_txt.GetString("ToolTip_CurveGraphBreakfastAC");
            toolStripButton13.ToolTipText = alu_tp.main_1.rm_txt.GetString("ToolTip_CurveGraphBreakfastPC");
            toolStripButton14.ToolTipText = alu_tp.main_1.rm_txt.GetString("ToolTip_CurveGraphLunchAC");
            toolStripButton15.ToolTipText = alu_tp.main_1.rm_txt.GetString("ToolTip_CurveGraphLunchPC");
            toolStripButton16.ToolTipText = alu_tp.main_1.rm_txt.GetString("ToolTip_CurveGraphDinnerAC");
            toolStripButton17.ToolTipText = alu_tp.main_1.rm_txt.GetString("ToolTip_CurveGraphDinnerPC");
            toolStripButton19.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_DayList");
            toolStripButton20.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_DistributionGroup");
            toolStripButton22.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_DayGroup");
            toolStripButton21.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_WeekGroup");
            toolStripButton23.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_TrendGroup");
            toolStripButton18.ToolTipText = alu_tp.main_1.rm_txt.GetString("Menu_Print");
            languagesToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("Languages");
            englishToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("langEnglish");
            traditionalChineseToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("langTraditionalChinese");
            portugueseToolStripMenuItem.Text = alu_tp.main_1.rm_txt.GetString("langPortuguese");
        }
        #endregion

        private void mainForm_Load(object sender, EventArgs e)
        {
            InitControls();
            statusStrip1.Items[1].Text = "DATE :" + DateTime.Now.ToString();
            this.printDocument1.DefaultPageSettings.Landscape = true;

            firstForm g = new firstForm();

            g.MdiParent = this;
            g.Show();
        }

        #region Button Click
        private void setSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            referenceForm3 f = new referenceForm3();
            //            f.MdiParent = this;
            f.Show();
            //            f.Resize += new EventHandler(f_Resize);
        }
        /*
                void f_Resize(object sender, EventArgs e)
                {
                       downloadForm4 f = (downloadForm4)sender;
                       ToolStripMenuItem item = new ToolStripMenuItem();
                       for (int i = 0; i < f.ContextMenuStrip.Items.Count; )
                       {
                           item.DropDownItems.Add(contextMenuStrip1.Items[i]);
                      }
                      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { item });
                }
        */
        private void exitEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ddDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            downloadForm4 g = new downloadForm4();
            g.MdiParent = this;
            g.Show();
            //            f.Resize += new EventHandler(f_Resize);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            firstForm g = new firstForm();
            g.MdiParent = this;
            g.Show();
        }

        private void meAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm g = new aboutForm();
            g.Show();
        }

        private void datalistLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            databaseFrom f = new databaseFrom();
            f.MdiParent = this;
            f.Show();
        }

        private void gacAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curveAllACFrom f = new curveAllACFrom();
            f.MdiParent = this;
            f.Show();
        }

        private void gpcPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curveAllPCForm f = new curveAllPCForm();
            f.MdiParent = this;
            f.Show();
        }

        private void gacpcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curveAllACPCFrom f = new curveAllACPCFrom();
            f.MdiParent = this;
            f.Show();
        }

        private void lineHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            columnGluFrom f = new columnGluFrom();
            f.MdiParent = this;
            f.Show();
        }

        private void gbac1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOOK_BOOK f = new LOOK_BOOK();
            f.MdiParent = this;
            f.Show();
        }

        private void gbpc2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            distribution f = new distribution();
            f.MdiParent = this;
            f.Show();
        }

        private void gdac5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trendgroup f = new trendgroup();
            f.MdiParent = this;
            f.Show();
        }

        //private void gdpc6ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    curveDPCFrom f = new curveDPCFrom();
        //    f.MdiParent = this;
        //    f.Show();
        //}

        private void glac3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            daygroup f = new daygroup();
            f.MdiParent = this;
            f.Show();
        }

        private void glpc4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            weekgroup f = new weekgroup();
            f.MdiParent = this;
            f.Show();
        }

        private void allgTToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            curveAllForm f = new curveAllForm();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //ClearAllForm();            
            //referenceForm3 f = new referenceForm3();
            SettingUser f = new SettingUser();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //  MainForm.ActiveForm.Controls            
            downloadForm4 f = new downloadForm4();
            f.MdiParent = this;
            f.Show();
            //this.MdiChildren = new Form();            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            databaseFrom f = new databaseFrom();
          f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            curveAllACFrom f = new curveAllACFrom();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            curveAllPCForm f = new curveAllPCForm();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            curveAllACPCFrom f = new curveAllACPCFrom();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            columnGluFrom f = new columnGluFrom();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            curveAllForm f = new curveAllForm();
            f.MdiParent = this;
            f.Show();
        }

        //private void toolStripButton12_Click(object sender, EventArgs e)
        //{
        //    curveBACFrom f = new curveBACFrom();
        //   f.MdiParent = this;
        //    f.Show();
        //}

        //private void toolStripButton13_Click(object sender, EventArgs e)
        //{
        //    curveBPCFrom f = new curveBPCFrom();
        //  f.MdiParent = this;
        //    f.Show();
        //}

        //private void toolStripButton14_Click(object sender, EventArgs e)
        //{
        //    curveLACFrom f = new curveLACFrom();
        //    f.MdiParent = this;
        //    f.Show();
        //}

        //private void toolStripButton15_Click(object sender, EventArgs e)
        //{
        //    curveLPCFrom f = new curveLPCFrom();
        //   f.MdiParent = this;
        //    f.Show();
        //}

        //private void toolStripButton16_Click(object sender, EventArgs e)
        //{
        //    curveDACFrom f = new curveDACFrom();
        //   f.MdiParent = this;
        //    f.Show();
        //}

        //private void toolStripButton17_Click(object sender, EventArgs e)
        //{
        //    curveDPCFrom f = new curveDPCFrom();
        //   f.MdiParent = this;
        //    f.Show();
        //}

        private void psetupSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                printimg();
                if (DialogResult.OK == printDialog1.ShowDialog())
                {
                    printDocument1.Print();
                }
            }
        }

        private void pviewRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                printimg();
                p.Document = this.printDocument1;
                if (DialogResult.OK == p.ShowDialog())
                {
                    printDocument1.Print();
                }
            }
        }

        private void printRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (this.MdiChildren.Length > 0)
            //{
            //    printForm1.Form = this.MdiChildren[0].FindForm();
            //    //    printDocument1.Print();
            //    printForm1.Print();
            //}
            //else
            //{
            //    MessageBox.Show("no page for print");

            //}
            if (this.MdiChildren.Length > 0)
            {
                printimg();
                p.Document = this.printDocument1;
                if (DialogResult.OK == p.ShowDialog())
                {
                    printDocument1.Print();
                }
            }
        }
       
        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                printimg();
                p.Document = this.printDocument1;
                if (DialogResult.OK == p.ShowDialog())
                {
                    printDocument1.Print();
                }
            }
            //if (this.MdiChildren.Length > 0)
            //{
            //    printForm1.Form = this.MdiChildren[0].FindForm();
            //    printForm1.Print();
            //}
            //else
            //{
            //    MessageBox.Show("no page for print");

            //}
         //   printForm1.Form = this.MdiChildren[0].FindForm();
         //printForm1.Print();
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {          
            LOOK_BOOK f = new LOOK_BOOK();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            distribution f = new distribution();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            weekgroup f = new weekgroup();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            daygroup f = new daygroup();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            trendgroup f = new trendgroup();
            f.MdiParent = this;
            f.Show();
        }
        #endregion

        private void mainForm_MdiChildActivate(object sender, EventArgs e)//更換子視窗時關閉不必要視窗
        {
            if (this.MdiChildren.Length > 1)
            {
                this.MdiChildren[0].Close();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(img, 0, 0);// 2015.02.04 denny
            /* // 2015.02.04 denny
            //e.HasMorePages = false;
            Form a = this.MdiChildren[0].FindForm();
            e.Graphics.DrawImage(img, a.Location.X, a.Location.Y, a.Width, a.Height);
            //a.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            img.Dispose();
            //IntPtr dc1 = e.Graphics.GetHdc();
            //e.Graphics.ReleaseHdc(dc1);
            //e.Graphics.CopyFromScreen(new Point(this.Location.X / 2 - a.Location.X, this.Location.Y - a.Location.Y * 4), new Point(0, 0), a.Size);
            */ // 2015.02.04 denny
        }
        /// <summary>
        /// 預覽之前就先繪製圖片存檔給預覽列印用
        /// </summary>
        private void printimg()
        {
            Form a = this.MdiChildren[0].FindForm();
            //img = new Bitmap(a.Width, a.Height); // 2015.05.22 denny for multi pages print
            img = new Bitmap(a.Size.Width, a.Size.Height); // 2015.05.22 denny for multi pages print           
            Graphics g = Graphics.FromImage(img);

            if (a.Name == "LOOK_BOOK" || a.Name == "databaseFrom")// 2015.05.12 denny for multi pages print
            {
                g.CopyFromScreen(new Point(this.Location.X, this.Location.Y), new Point(a.Location.X, a.Location.Y), new Size(a.ClientSize.Width, a.ClientSize.Height));// 2015.05.12 denny for multi pages print
            }
            else
            {
                g.CopyFromScreen(new Point(this.Location.X + 10, this.Location.Y + a.Location.Y + 92), new Point(0, 0), new Size(this.ClientSize.Width - 25, this.ClientSize.Height - 90));// 2015.05.12 denny for multi pages print
            }

            IntPtr dc = g.GetHdc();
            g.ReleaseHdc(dc);            
            g.Dispose();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void glicosimetroConfiguraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingUser f = new SettingUser();
            f.MdiParent = this;
            f.Show();
        }
        private void ShowDefaultLangeIndex()
        {
         firstForm g = new firstForm();
         g.MdiParent = this;
         g.Show();
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language.Apply(this, "en-us");
            alu_tp.main_1.LanguageString = "en-us";
            InitControls();
            ShowDefaultLangeIndex();
        }

        private void traditionalChineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language.Apply(this, "zh-tw");
            alu_tp.main_1.LanguageString = "zh-tw";
            InitControls();
            ShowDefaultLangeIndex();
        }

        private void portugueseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language.Apply(this, "pt-BR");
            alu_tp.main_1.LanguageString = "pt-BR";
            InitControls();
            ShowDefaultLangeIndex();
        }
    }
}
