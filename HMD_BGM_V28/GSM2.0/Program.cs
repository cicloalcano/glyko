using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;

namespace GSM2._0
{
    public class alu_tp
    {
        public static main_type main_1 = new main_type();
        public static time_gp[] timgp;
    }
    public class comm_list
    {
        public byte[] send_str;
    }

    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashForm gg = new SplashForm();
            gg.Show();

            System.Threading.Thread.Sleep(1000);

            gg.Hide();

            //Application.Run(new loginForm());
            try
            {
                MainModule.OpenAccessDatabase("HMDgms.mdb", "HmdRegister");
                MainModule.get_time_set();
            }
            catch (Exception err)
            {

            }

            System.Data.DataView dv1;
            dv1 = MainModule.AccessDatabasesel("SELECT  top 1 *  FROM  HmdRegister");
            if (dv1 != null)
            {   /********************2015.01.20 denny for no meter ID********************/
                if (dv1.Count >= 0)
                {
                    if (dv1.Count == 0)
                    {
                        alu_tp.main_1.FileName = "";
                        alu_tp.main_1.ReportName = "";
                        alu_tp.main_1.MeterIDNo = "";
                        alu_tp.main_1.CPortOption = 0;
                        alu_tp.main_1.serialPort1 = new SerialPort();
                        alu_tp.main_1.serialPort1.PortName = "0";
                        alu_tp.main_1.UnitOption = 1;
                        alu_tp.main_1.TimeOption = 1;
                        alu_tp.main_1.TargetMaxOption = 999;
                        alu_tp.main_1.TargetMinOption = 0;
                        alu_tp.main_1.TargetMaxOptionp = 999;
                        alu_tp.main_1.TargetMinOptionp = 0;
                    }
                    else 
                    {
                        alu_tp.main_1.FileName = dv1[0].Row["idx"].ToString();
                        alu_tp.main_1.ReportName = dv1[0].Row["id"].ToString();
                        alu_tp.main_1.MeterIDNo = dv1[0].Row["mid"].ToString();
                        alu_tp.main_1.CPortOption = 1;
                        alu_tp.main_1.serialPort1 = new SerialPort();
                        alu_tp.main_1.serialPort1.PortName = Convert.ToString(dv1[0].Row["RS_232"]);
                        alu_tp.main_1.UnitOption = Convert.ToInt16(dv1[0].Row["Unit1"]);
                        alu_tp.main_1.TimeOption = Convert.ToInt16(dv1[0].Row["Time1"]);
                        alu_tp.main_1.TargetMaxOption = Convert.ToInt16(dv1[0].Row["Max1"]);
                        alu_tp.main_1.TargetMinOption = Convert.ToInt16(dv1[0].Row["Min1"]);
                        alu_tp.main_1.TargetMaxOptionp = Convert.ToInt16(dv1[0].Row["Maxp"]);
                        alu_tp.main_1.TargetMinOptionp = Convert.ToInt16(dv1[0].Row["Minp"]);
                    
                    }
                    /********************2015.01.20 denny for no meter ID********************/
                    Application.Run(new mainForm());
                }
                else
                {
                    MessageBox.Show("Sem conta padrão", "Programa de Monitoramento de Glicemia V2.4 [Bem vindo!]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }
    }
}