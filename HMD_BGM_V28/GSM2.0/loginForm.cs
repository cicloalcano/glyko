using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;



namespace GSM2._0
{
    
    public partial class loginForm : Form
    {
      



        public loginForm()
        {
            InitializeComponent();
        }

        private void loginButton1_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("1");
            //string FileName;
            string CheckName = comboBox1.Text;
            string CheckPassword = TextPasswd.Text;
         //   string FILE_NAME = alu_tp.main_1.MAIN_PATH + "\\HMDregister.txt";

        
       
            System.Data.DataView dv1;
            if (CheckName == "guest")
            {
                alu_tp.main_1.FileName = "guest";
                alu_tp.main_1.ReportName = alu_tp.main_1.FileName;
                TextPasswd.Text = "";
                dv1 = MainModule.AccessDatabasesel("SELECT  *   FROM  HmdRegister where id='" + CheckName + "'");
                if (dv1.Count > 0)
                {
                    alu_tp.main_1.FileName = dv1[0].Row["idx"].ToString();
                    alu_tp.main_1.CPortOption = 1;
                    alu_tp.main_1.serialPort1.PortName = Convert.ToString(dv1[0].Row["RS_232"]);
                    alu_tp.main_1.UnitOption = Convert.ToInt16(dv1[0].Row["Unit1"]);
                    alu_tp.main_1.TimeOption = Convert.ToInt16(dv1[0].Row["Time1"]);
                    alu_tp.main_1.TargetMaxOption = Convert.ToInt16(dv1[0].Row["Max1"]);
                    alu_tp.main_1.TargetMinOption = Convert.ToInt16(dv1[0].Row["Min1"]);
                    alu_tp.main_1.TargetMaxOptionp = Convert.ToInt16(dv1[0].Row["Maxp"]);
                    alu_tp.main_1.TargetMinOptionp = Convert.ToInt16(dv1[0].Row["Minp"]);
                }
                else
                {
                    alu_tp.main_1.serialPort1.PortName = "COM1";
                    alu_tp.main_1.UnitOption = 1;
                    alu_tp.main_1.TimeOption =1;
                    alu_tp.main_1.TargetMaxOption = 180;
                    alu_tp.main_1.TargetMinOption =50;
                    alu_tp.main_1.TargetMaxOptionp = 300;
                    alu_tp.main_1.TargetMinOptionp = 30;
                }

            }
          else
            {
                if (CheckPassword == "")
                {
                    MessageBox.Show("ID OR PASSWORD ERROR!!", "LOGIN ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto EndAndAgain;
                }
             
                dv1 = MainModule.AccessDatabasesel("SELECT  *   FROM  HmdRegister where id='" + CheckName + "' and  Passwd='" + CheckPassword + "'");

                if (dv1.Count == 0)
                {
                    MessageBox.Show("ID  [" + CheckName + "] ! PASSWORD ERROR !", "Glucose Management Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextPasswd.Text = "";
                    goto EndAndAgain;
                }
                else
                {
                    alu_tp.main_1.FileName = dv1[0].Row["idx"].ToString();
                    alu_tp.main_1.ReportName = CheckName;

                    alu_tp.main_1.CPortOption = 1;
                    alu_tp.main_1.serialPort1.PortName =  Convert.ToString(dv1[0].Row["RS_232"]);
                    alu_tp.main_1.UnitOption = Convert.ToInt16(dv1[0].Row["Unit1"]);
                    alu_tp.main_1.TimeOption = Convert.ToInt16(dv1[0].Row["Time1"]);
                    alu_tp.main_1.TargetMaxOption = Convert.ToInt16(dv1[0].Row["Max1"]);
                    alu_tp.main_1.TargetMinOption = Convert.ToInt16(dv1[0].Row["Min1"]);
                    alu_tp.main_1.TargetMaxOptionp = Convert.ToInt16(dv1[0].Row["Maxp"]);
                    alu_tp.main_1.TargetMinOptionp = Convert.ToInt16(dv1[0].Row["Minp"]);
                }

        //    MessageBox.Show("4");
            //for (int i = 1; i < alu_tp.main_1.oldtotal; i++)
            //{
            //    if (alu_tp.main_1.DataName[i] == CheckName)
            //    {
            //        if (alu_tp.main_1.DataPswd[i] == CheckPassword)
            //        {
            //            alu_tp.main_1.FileName = alu_tp.main_1.DataName[i];
            //            alu_tp.main_1.ReportName = alu_tp.main_1.FileName;

            //            //if (!File.Exists(alu_tp.main_1.MAIN_PATH + "\\" + alu_tp.main_1.FileName + ".txt"))
            //            //{
            //            //    FileInfo f = new FileInfo(alu_tp.main_1.MAIN_PATH + "\\" + alu_tp.main_1.FileName + ".txt");
            //            //    StreamWriter sw = f.CreateText();

            //            //    sw.WriteLine("Test_No,Glucose,Month,Day,Hour,Minute,Event,Glucose_mmol,Year,Date & Time");            // 寫入文字  
            //            //    sw.WriteLine("T0000,00000,00,00,00,00,0000,00000,0000,000000000000000000");
            //            //    sw.Flush();
            //            //    sw.Close();
            //            //}
            //        }
            //        else
            //        {
                       
                    //}
                //}
            }

          //  MessageBox.Show("5");
            ////for (int i = 0; i < alu_tp.main_1.oldtotal; i++)
            ////{
            ////    if (alu_tp.main_1.DataName[i] == CheckName)
            ////    {
            ////      alu_tp.main_1.CPortOption = int.Parse(alu_tp.main_1.DataPortType[i]);
            ////        alu_tp.main_1.serialPort1.PortName ="COM"+ Convert.ToString( int.Parse(alu_tp.main_1.DataPortType[i]));
            ////        alu_tp.main_1.UnitOption = int.Parse(alu_tp.main_1.DataUnitType[i]);
            ////        alu_tp.main_1.TimeOption = int.Parse(alu_tp.main_1.DataTimeType[i]);
            ////        //alu_tp.main_1.TargetMaxOption = int.Parse(alu_tp.main_1.DataTargetMax[i]);
            ////        //alu_tp.main_1.TargetMinOption = int.Parse(alu_tp.main_1.DataTargetMin[i]);
            ////        //alu_tp.main_1.TargetMaxOptionp = int.Parse(alu_tp.main_1.DataTargetMaxp[i]);
            ////        //alu_tp.main_1.TargetMinOptionp = int.Parse(alu_tp.main_1.DataTargetMinp[i]);
            ////    }
            ////}


            //{
            //    FileName = "c:\\guest.txt";

            //    if (!File.Exists(FileName))
            //    {
            //        FileInfo f = new FileInfo(FileName);
            //        StreamWriter sw = f.CreateText();

            //        sw.WriteLine("Test_No,Glucose,Month,Day,Hour,Minute,Event,Glucose_mmol,Year,Date & Time");            // 寫入文字  
            //        sw.WriteLine("T0000,00000,00,00,00,00,0000,00000,0000,000000000000000000");
            //        sw.Flush();
            //        sw.Close();
            //    }

            //}
           // MessageBox.Show("1");

        //   readOldDataFrom fg1 = new readOldDataFrom();
          // fg1.Show();
           MainModule.readOldData();
       //    this.Hide();

            mainForm fg = new mainForm();
            fg.Show();
            this.Hide();

          

            
            EndAndAgain:;
        }

        private void cancelButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addCountButton3_Click(object sender, EventArgs e)
        {           
            this.Hide();
            loginAddFrom f = new loginAddFrom();
            f.ShowDialog();         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextPasswd.Text = "";
            TextPasswd.Enabled = true;
            if (comboBox1.Text == "guest")
                TextPasswd.Enabled = false;
        }


        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("UserLogin");
            loginButton1.Text = alu_tp.main_1.rm_txt.GetString("Login");
            cancelButton2.Text = alu_tp.main_1.rm_txt.GetString("Exit");
            addCountButton3.Text = alu_tp.main_1.rm_txt.GetString("AddNewUser");
            label1.Text = alu_tp.main_1.rm_txt.GetString("UserID");
            label2.Text = alu_tp.main_1.rm_txt.GetString("Password");
        }
        private void loginForm_Load(object sender, EventArgs e)
        {
            InitControls();
            //this.skinEngine1.SkinFile = @System.AppDomain.CurrentDomain.BaseDirectory.Replace('\\', '/') + "Skins/Calmness.ssk";
            try
            {
                MainModule.OpenAccessDatabase("HMDgms.mdb", "HmdRegister");
                MainModule.get_time_set();
            }
            catch (Exception err)
            {

            }

        //    string FILE_NAME = alu_tp.main_1.MAIN_PATH + "\\HMDregister.txt";

            System.Data.DataView dv1;
            dv1 = MainModule.AccessDatabasesel("SELECT  UserNo   FROM  ho_user ");
            comboBox1.Items.Add("guest");
            if (dv1.Count > 0)
            {
                for (int i = 0; i < dv1.Count; i++)
                {
                    comboBox1.Items.Add(dv1[i].Row["UserNo"]);
                }
            }
           

            timerLoad.Enabled = true;

        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
           // string FILE_NAME = alu_tp.main_1.MAIN_PATH + "\\HMDregister.txt";


            comboBox1.Text = "guest" ;
            timerLoad.Enabled = false;
            RS232_PORT setport = new RS232_PORT();
            setport.scan_Port();
        }

        //void ReadHMDregister()
        //{
        ////    MainModule.insertDatabasesel(" INSERT INTO [HmdRegister] (id,Passwd) VALUES ( 'this.textName.Text','this.textPassword.Text')");
             
            
        //    //Check EE Setting File Path Validation
        //    //if (File.Exists(StrFilePath))
        //    //{
        //    //    //Read File
        //    //    //int i = 0;
        //    //    //int DecData;
        //    //    //char[] delimiterChars = { ' ', ',', '\t' };
        //    //    char[] delimiterChars = { ',', '\t' };
        //    //    string StrFileData;

        //    //    alu_tp.main_1.oldtotal = 0;

        //    //    using (StreamReader FileReader = new StreamReader(StrFilePath))
        //    //    {
        //    //        //Read Title
        //    //        //"ID,Passwd,RS-232port,Unit,Time,Max,Min,Maxp,Minp"
        //    //        FileReader.ReadLine();

        //    //        StrFileData = FileReader.ReadLine();

        //    //        while (StrFileData != null)
        //    //        {
        //    //            //Split String  
        //    //            string[] StrDataArray = StrFileData.Split(delimiterChars);
        //    //            alu_tp.main_1.DataName[alu_tp.main_1.oldtotal] = StrDataArray[0];
        //    //            alu_tp.main_1.DataPswd[alu_tp.main_1.oldtotal] = StrDataArray[1];
        //    //            alu_tp.main_1.DataPortType[alu_tp.main_1.oldtotal] = StrDataArray[2];
        //    //            alu_tp.main_1.DataUnitType[alu_tp.main_1.oldtotal] = StrDataArray[3];
        //    //            alu_tp.main_1.DataTimeType[alu_tp.main_1.oldtotal] = StrDataArray[4];
        //    //            alu_tp.main_1.DataTargetMax[alu_tp.main_1.oldtotal] = StrDataArray[5];
        //    //            alu_tp.main_1.DataTargetMin[alu_tp.main_1.oldtotal] = StrDataArray[6];
        //    //            alu_tp.main_1.DataTargetMaxp[alu_tp.main_1.oldtotal] = StrDataArray[7];
        //    //            alu_tp.main_1.DataTargetMinp[alu_tp.main_1.oldtotal] = StrDataArray[8];
        //    //            //i++;
        //    //            comboBox1.Items.Add(alu_tp.main_1.DataName[alu_tp.main_1.oldtotal]);

        //    //            alu_tp.main_1.oldtotal++;

        //    //            //..
        //    //            StrFileData = FileReader.ReadLine();
        //    //        }
        //    //        //oldtotal = i - 1;//last item
        //    //        //comboBox1.Text = DataName[oldtotal];

        //        }

        //    }
        //}

    }
}
