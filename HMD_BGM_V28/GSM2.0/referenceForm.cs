using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Microsoft.Win32; // For Registry Access
using System.IO;

namespace GSM2._0
{
    public partial class referenceForm3 : Form
    {
       

        const int DEFAULT_DELAYTIME = 20;

        public referenceForm3()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //string FILE_NAME = alu_tp.main_1.MAIN_PATH + "\\HMDregister.txt";

            //for (int i = 0; i < alu_tp.main_1.oldtotal; i++)
            //{
            //    if (alu_tp.main_1.DataName[i] == alu_tp.main_1.FileName)    // '帳號比對
            //    {
            //      alu_tp.main_1.DataPortType[i] = alu_tp.main_1.CPortOption.ToString();   // '帳號更新寫入5種設定
            //        alu_tp.main_1.DataUnitType[i] = alu_tp.main_1.UnitOption.ToString();
            //        alu_tp.main_1.DataTimeType[i] = alu_tp.main_1.TimeOption.ToString();
            //        alu_tp.main_1.DataTargetMax[i] = alu_tp.main_1.TargetMaxOption.ToString();
            //        alu_tp.main_1.DataTargetMin[i] = alu_tp.main_1.TargetMinOption.ToString();
            //        alu_tp.main_1.DataTargetMaxp[i] = alu_tp.main_1.TargetMaxOptionp.ToString();
            //        alu_tp.main_1.DataTargetMinp[i] = alu_tp.main_1.TargetMinOptionp.ToString();
            //    }
    
            //}

            //FileInfo f = new FileInfo(FILE_NAME);
            //StreamWriter sw = f.CreateText();

            //sw.WriteLine("ID,Passwd,RS-232port,Unit,Time,Max,Min,Maxp,Minp");            // 寫入文字  
            //for (int j = 0; j < alu_tp.main_1.oldtotal; j++)
            //{
            //    sw.WriteLine(alu_tp.main_1.DataName[j] + "," + alu_tp.main_1.DataPswd[j] + "," + alu_tp.main_1.DataPortType[j]
            //        + "," + alu_tp.main_1.DataUnitType[j] + "," + alu_tp.main_1.DataTimeType[j] + "," + alu_tp.main_1.DataTargetMax[j]
            //        + "," + alu_tp.main_1.DataTargetMin[j] + "," + alu_tp.main_1.DataTargetMaxp[j] + "," + alu_tp.main_1.DataTargetMinp[j]);
            //}
          //  sw.Flush();
          //  sw.Close(); 

            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Save Com Port Number to Registry
        //    Registry.CurrentUser.SetValue("Key_GMS_ComPort", 1);
            //Save Com Port Number to Registry
         //   Registry.CurrentUser.SetValue("Key_GMS_DelayTime", DEFAULT_DELAYTIME);
            alu_tp.main_1.CPortOption = 1;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Save Com Port Number to Registry
       //     Registry.CurrentUser.SetValue("Key_GMS_ComPort", 2);
            //Save Com Port Number to Registry
          //  Registry.CurrentUser.SetValue("Key_GMS_DelayTime", DEFAULT_DELAYTIME);
            alu_tp.main_1.CPortOption = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //Save Com Port Number to Registry
          //  Registry.CurrentUser.SetValue("Key_GMS_ComPort", 3);
            //Save Com Port Number to Registry
        //    Registry.CurrentUser.SetValue("Key_GMS_DelayTime", DEFAULT_DELAYTIME);
            alu_tp.main_1.CPortOption = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //Save Com Port Number to Registry
         //   Registry.CurrentUser.SetValue("Key_GMS_ComPort", 4);
            //Save Com Port Number to Registry
        //    Registry.CurrentUser.SetValue("Key_GMS_DelayTime", DEFAULT_DELAYTIME);
            alu_tp.main_1.CPortOption = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //Save Com Port Number to Registry
         //   Registry.CurrentUser.SetValue("Key_GMS_ComPort", 5);
            //Save Com Port Number to Registry
         //   Registry.CurrentUser.SetValue("Key_GMS_DelayTime", DEFAULT_DELAYTIME);
            alu_tp.main_1.CPortOption = 5;
        }

        private void referenceForm3_Load(object sender, EventArgs e)
        {
            //Save Com Port Number to Registry
         //   Registry.CurrentUser.SetValue("Key_GMS_DelayTime", 20);

            cmdOK.Enabled = false;

          

            if (alu_tp.main_1.UnitOption == 1)
            {
                maxPBox.Text = alu_tp.main_1.TargetMaxOptionp.ToString();
                maxBox.Text = alu_tp.main_1.TargetMaxOption.ToString();
                minBox.Text = alu_tp.main_1.TargetMinOption.ToString();
                minpBox.Text = alu_tp.main_1.TargetMinOptionp.ToString();
            }
            else if (alu_tp.main_1.UnitOption == 2)
            {
                maxPBox.Text = (alu_tp.main_1.TargetMaxOptionp / 18).ToString();
                maxBox.Text = (alu_tp.main_1.TargetMaxOption/18).ToString();
                minBox.Text = (alu_tp.main_1.TargetMinOption / 18).ToString();
                minpBox.Text = (alu_tp.main_1.TargetMinOptionp/18).ToString();
            }
        }

        private void cmdSaveBtn_Click(object sender, EventArgs e)
        {
            if (alu_tp.main_1.UnitOption == 1)//mg/dL
                if (int.Parse(maxPBox.Text) > 600 || int.Parse(maxPBox.Text) < 30)
                   {  MessageBox.Show("ERROR: The normal Uper limit Setting of Glucose Value ranges between 30mg/dL and 600mg/dL !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}
                else if (int.Parse(maxBox.Text) > 600 || int.Parse(maxBox.Text) < 30)
                  {   MessageBox.Show("ERROR: The normal Uper limit Setting of Glucose Value ranges between 30mg/dL and 600mg/dL !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}
                else if (int.Parse(maxBox.Text) >int.Parse(maxPBox.Text))
                 {    MessageBox.Show("ERROR: The lower limit Setting of Glucose Value > The Uper limit Setting of Glucose Value!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}

                else if (int.Parse(minBox.Text) > 600 || int.Parse(minBox.Text) < 30)
                  {   MessageBox.Show("ERROR: The normal Uper limit Setting of Glucose Value ranges between 30mg/dL and 600mg/dL !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}
                else if (int.Parse(minpBox.Text) > 600 || int.Parse(minpBox.Text) < 30)
                 {    MessageBox.Show("ERROR: The normal Uper limit Setting of Glucose Value ranges between 30mg/dL and 600mg/dL !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}
                else if (int.Parse(minpBox.Text) > int.Parse(minBox.Text))
                { MessageBox.Show("ERROR: The lower limit Setting of Glucose Value > The Uper limit Setting of Glucose Value!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return;}

                else
                {
                    alu_tp.main_1.TargetMaxOption = int.Parse(maxPBox.Text);   //將現在之血糖最大值寫入
                    alu_tp.main_1.TargetMinOption = int.Parse(maxBox.Text);   //將現在之血糖最小值寫入
                    alu_tp.main_1.TargetMaxOptionp = int.Parse(minBox.Text); //將現在之血糖最大值寫入
                    alu_tp.main_1.TargetMinOptionp = int.Parse(minpBox.Text); //將現在之血糖最小值寫入
                    cmdOK.Enabled = true;
                }           
            else if (alu_tp.main_1.UnitOption == 2)  //'(mmol/L)
                if (int.Parse(maxPBox.Text) > 33.3 || int.Parse(maxPBox.Text) < 1.7)
                  {  MessageBox.Show("ERROR: The normal Uper limit Setting of Glucose Value ranges between 30mg/dL and 600mg/dL !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}
                else if (int.Parse(maxBox.Text) > 33.3 || int.Parse(maxBox.Text) < 1.7)
                  {  MessageBox.Show("ERROR: The normal Uper limit Setting of Glucose Value ranges between 30mg/dL and 600mg/dL !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}
                else if (int.Parse(maxBox.Text) > int.Parse(maxPBox.Text))
                  {  MessageBox.Show("ERROR: The lower limit Setting of Glucose Value > The Uper limit Setting of Glucose Value!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}

                else if (int.Parse(minBox.Text) > 33.3 || int.Parse(minBox.Text) < 1.7)
                  {  MessageBox.Show("ERROR: The normal Uper limit Setting of Glucose Value ranges between 30mg/dL and 600mg/dL !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}
                else if (int.Parse(minpBox.Text) > 33.3 || int.Parse(minpBox.Text) < 1.7)
                 {   MessageBox.Show("ERROR: The normal Uper limit Setting of Glucose Value ranges between 30mg/dL and 600mg/dL !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}
                else if (int.Parse(minpBox.Text) > int.Parse(minBox.Text))
                  {  MessageBox.Show("ERROR: The lower limit Setting of Glucose Value > The Uper limit Setting of Glucose Value!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);return;}
      
                else
                {
                    alu_tp.main_1.TargetMaxOption = int.Parse(maxPBox.Text) * 18; //'將現在之血糖最大值寫入
                    alu_tp.main_1.TargetMinOption = int.Parse(maxBox.Text) * 18; //'將現在之血糖最小值寫入
                    alu_tp.main_1.TargetMaxOptionp = int.Parse(minBox.Text) * 18; //'將現在之血糖最大值寫入
                    alu_tp.main_1.TargetMinOptionp = int.Parse(minpBox.Text) * 18; //'將現在之血糖最小值寫入
                    cmdOK.Enabled = true;
                }

            alu_tp.main_1.TargetMaxOptionp = Convert.ToInt16(maxPBox.Text);
            alu_tp.main_1.TargetMaxOption = Convert.ToInt16(maxBox.Text);
            alu_tp.main_1.TargetMinOption = Convert.ToInt16(minBox.Text);
            alu_tp.main_1.TargetMinOptionp = Convert.ToInt16(minpBox.Text);
            if (  alu_tp.main_1.FileName != "guest")
            {
             
                MainModule.updateDatabasesel("UPDATE HmdRegister SET Max1='" + maxBox.Text + "', Maxp='" + maxPBox.Text + "', Min1='" + minBox.Text + "', Minp='" + minpBox.Text + "' where idx=" + alu_tp.main_1.FileName + " ");
            }
        }

        private void maxBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
