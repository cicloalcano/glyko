using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

using System.IO.Ports;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Resources;
using System.Globalization;
using System.Data.OleDb;

namespace GSM2._0
{
    public class main_type
    {
        public string LanguageString = "";
        public string DBSERVER { get; set; }
        public string DSN { get; set; }
        public string uID { get; set; }  //使用者ip add mac
        public string PWD { get; set; }
        public string NsNo { get; set; }               //部門代號
        public string LoginPWD { get; set; }
        public string MAIN_PATH { get; set; }     //本機_路徑 
        public string accdb_PATH { get; set; }     //本機db_路徑 
        public string xUserNo { get; set; }       //部門名稱
        public string nUserName { get; set; }        //護理人員群組
        public string GroupName { get; set; }        //院區名稱
        public string def_BuildName { get; set; }        //院區idx
        public string def_Buildno { get; set; }
        public string Lang_set { get; set; }   //語言
       // public bool Lang_set { get; set; }   //語言
        public bool sqldb_link { get; set; }  // 是否與遠端db連線中
        public bool accdb_link { get; set; }  // 是否與本機db連線中
        public int accdb_Total { get; set; }// 本機db單台血糖機資料數
        public int max_user_count; //   '工作站血糖機數量
        public int max_meter_count; //   '工作站血糖機數量
        public string  meterid; //   '工作站血糖機id共用變數
        public string la_meterid; //   '工作站血糖機最後id
        public string service_url; //   '工作站血糖機數量
        public int oldtotal;   //'oldtotal是目前User資料總筆數

        public  string FileName;  //'帳號 存檔名     
        public string MeterIDNo;  //'血糖機編碼    
        public  string ReportName;    //'報表名=FileName
        public int CPortOption; // '設定RS232 PORT 之連接阜位置
        public int UnitOption;   //'設定2種單位值
        public int TimeOption;   //'設定時間格式
        public int TargetMaxOption; //'設定正常血糖預設最大值
        public int TargetMinOption;   //'設定正常血糖預設最小值
        public int TargetMaxOptionp;  // '設定正常血糖預設最大值
        public int TargetMinOptionp;  //'設定正常血糖預設最小值
        //public AccessDataSource lo_con;// clinet access 資料庫connection

        //public  string[] DataName = new string[10000];   //  '定義帳號資料能容納10000筆
        //public  string[] DataPswd = new string[10000];  //  '定義帳號之密碼資料
        //public  string[] DataPortType = new string[10000];  //  '定義帳號之連接阜設定
        //public  string[] DataUnitType = new string[10000];   //'定義帳號之單位設定
        //public  string[] DataTimeType = new string[10000];   //'定義帳號之時間格式設定
        //public  string[] DataTargetMax = new string[10000];   //'定義帳號之上限血糖值
        //public  string[] DataTargetMin = new string[10000];  // '定義帳號之下限血糖值
        //public  string[] DataTargetMaxp = new string[10000];  // '定義帳號之上限血糖值
        //public  string[] DataTargetMinp = new string[10000];  // '定義帳號之下限血糖值


        //'****************Data全資料讀取*****************
        public  int Total;           //  '當下讀取METER的總資料數
        public  int[] DataMO = new int[1000]; //  '當下讀取METER的MO資料
        public  int[] DataDA = new int[1000]; //  '當下讀取METER的DA資料
        public  int[] DataHR = new int[1000]; //  '當下讀取METER的HR資料
        public  int[] DataMI = new int[1000]; //  '當下讀取METER的MI資料
        public int[] DataSE  = new int[1000]; //  '當下讀取METER的SE資料
        public  int[] DataGL = new int[1000]; //  '當下讀取METER的GL資料
        public  int[] DataYR = new int[1000]; //  '當下讀取METER的YR資料
        public  string[] DataACPC = new string[1000]; //  '當下讀取METER的AC&PC資料
        public  int[] DataTAMP = new int[1000]; //  '當下讀取METER的相關資料交換機制

        public int MTotal;
        //'****************Meter新資料讀取*****************
        public  string[] MDataYRDA = new string[1000];
        public  int[] MDataMO = new int[1000]; //  '當下讀取METER的MO資料
        public  int[] MDataDA = new int[1000]; //  '當下讀取METER的DA資料
        public  int[] MDataHR = new int[1000]; //  '當下讀取METER的HR資料
        public  int[] MDataMI = new int[1000]; //  '當下讀取METER的MI資料
        public  int[] MDataSE = new int[1000]; //  '當下讀取METER的SE資料
        public  int[] MDataGL = new int[1000]; //  '當下讀取METER的GL資料
        public  int[] MDataYR = new int[1000]; //  '當下讀取METER的GL資料
        public  string[] MDataACPC = new string[1000]; //  '當下讀取METER的AC&PC資料
        
        public ResourceManager rm_txt = new ResourceManager("GSM2._0.Properties.txt", Assembly.GetExecutingAssembly());
        public ResourceManager msg_txt = new ResourceManager("GSM2._0.Properties.msg", Assembly.GetExecutingAssembly());
    
        //rs232    
    
        //public SerialPort serialPort1 = new SerialPort("COM1", 19200);
        public SerialPort serialPort1 = new SerialPort();
        public bool meter_online=false;
        public bool meter_4port = true;
        public int port_usb = 1;//1 :port 2 :usb
        //rs232 
        //usb
        public  string MyV_ID = "040b";
        public  string MyP_ID = "2200";
        public bool max255 = true;
        public downloadForm4 FrmMy;
        public bool bWarnedUSB; //'是否已警示過USB連線中斷\
     
     
        public Boolean myDeviceDetected;
        public SafeFileHandle hidHandle;
        public Hid MyHid = new Hid();
        public DeviceManagement MyDeviceManagement = new DeviceManagement();
        public String myDevicePathName;
        public SafeFileHandle readHandle;
        public SafeFileHandle writeHandle;
        //usb
       
        public main_type()
        {
            this.MAIN_PATH = System.IO.Directory.GetCurrentDirectory();
        }

        public const int CHART_SIZE = 4; //'"123457"
        public bool Timeout ;
        public bool bRTCsync;
        //public  String sMeterID;
        public bool ManualTrans ;
        public const int SQLTimeOut = 7;

        public bool bHasTrans;   //預設Local Access DataBase尚未與SQL Database同步
        public int ReadCycleTime = 10;
        public bool bWarnedSQL ; //'是否已警示過SQL連線中斷
        
     }

    public class time_gp
    {
        public string time_name;
        public string time_on;
        public string time_off;
        public string on_off;
    }  

 
    public class MainModule
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public const int WM_CLOSE = 0x10;  

     //   enum DealType { NONE, WaterImage, WaterFont, DoubleDo }; //枚举命令
     //   public DealType dealtype;
     //   public static readonly string conString = ConfigurationManager.ConnectionStrings["book"].ConnectionString;
        //    public ADODB.Connection CN = new ADODB.Connection();
        //      public ADODB.Connection CNServer = new ADODB.Connection();

        
        public const string MAIN_PATH = "";        //部門代號

        public const string MyVendorID = "040b";
       // public const string MyProductID = "2200";
        public const string MyProductID = "2200";
      //  public const string MyProductID = "0a67";
      //  public main_type main_1 = new main_type();
        public int aas;



        
  
   public static bool OpenAccessDatabase(string DB_name,string tb_name ) 
    {
       
      //  alu_tp.main_1.accdb_PATH = alu_tp.main_1.MAIN_PATH + "\\" + DB_name;
       try
       {
         //   alu_tp.main_1.lo_con = new AccessDataSource(alu_tp.main_1.accdb_PATH, "select top 1 * from " + tb_name + " order by idx");
         //   System.Data.DataView dv = (System.Data.DataView)alu_tp.main_1.lo_con.Select(new DataSourceSelectArguments());

            System.Data.DataView dv = AccessDatabasesel("select top 1 * from " + tb_name + " order by idx");

        //alu_tp.main_1.serialPort1.BaudRate = 19200;
            //   alu_tp.main_1.serialPort1.PortName = dv[0].Row["RS-232port"].ToString();
         //   alu_tp.main_1.max_user_count =  Convert.ToInt16( dv[0].Row["max_user_count"].ToString());
         //   alu_tp.main_1.max_meter_count = Convert.ToInt16(dv[0].Row["max_meter_count"].ToString());
         //   alu_tp.main_1.service_url = dv[0].Row["service_url"].ToString();
        ////    alu_tp.main_1.meterid = "";
        //    alu_tp.main_1.la_meterid = dv[0].Row["last_meter_id"].ToString();
        //    alu_tp.main_1.port_usb = Convert.ToInt16(dv[0].Row["ser_usb"].ToString());
        }
        catch (Exception E)
       {
           return false;
       }
        return true;

    }

        //public static DataView AccessDatabasesel(string select_str)
        //{
        //    System.Data.DataView dv;

        //    try
        //    {
        //        alu_tp.main_1.lo_con = new AccessDataSource(alu_tp.main_1.accdb_PATH, select_str);
        //        dv = (System.Data.DataView)alu_tp.main_1.lo_con.Select(new DataSourceSelectArguments());
        //        //      alu_tp.main_1.serialPort1.PortName = dv[0].Row["RS-232port"].ToString();
        //    }
        //    catch (Exception E)
        //    {
        //        return null;
        //    }
        //    return dv;

        //}
        public static DataView GetMeteridWithUser(){
            DataView dv1 = new DataView();
            dv1 = MainModule.AccessDatabasesel("SELECT  mid,mid&'[' &id&']' as miduid FROM  HmdRegister order by mid desc,id asc");
            return dv1;
        }

        public static void SettingInitUserData()
        {
            System.Data.DataView dv1;
            dv1 = MainModule.AccessDatabasesel("SELECT  *  FROM  HmdRegister where mid='" + alu_tp.main_1.MeterIDNo + "'");
            if (dv1 != null)
            {
                if (dv1.Count > 0)
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
            }
        }

        ///  <summary>
        ///  判斷是否為數字
        ///  </summary>
        ///  <param name="Num_String"> 輸入的數字 </param>
        public static bool IsNumber(String Num_String)
        {
            bool Result;
            Result = false;
            string pattern = @"^\d+(\.\d)?$";
            if (Num_String.Trim() != "")
            {
                Num_String = Num_String + "00";
                if (!Regex.IsMatch(Num_String.Trim(), pattern))
                    Result = false;
                else
                    Result = true;
            }
            return Result;
        }

        /// 轉換為全形數字        
        public static string ConvertToFullwidthNumber2(string input)
        {
            string temp = string.Empty;
            if (new Regex(@"\d+").IsMatch(input))
            {
                foreach (char element in input.ToCharArray())
                {
                    if (element.ToString() == "０" || element.ToString() == "0")
                        temp += "0";
                    if (element.ToString() == "１" || element.ToString() == "1")
                        temp += "1";
                    if (element.ToString() == "２" || element.ToString() == "2")
                        temp += "2";
                    if (element.ToString() == "３" || element.ToString() == "3")
                        temp += "3";
                    if (element.ToString() == "４" || element.ToString() == "4")
                        temp += "4";
                    if (element.ToString() == "５" || element.ToString() == "5")
                        temp += "5";
                    if (element.ToString() == "６" || element.ToString() == "6")
                        temp += "6";
                    if (element.ToString() == "７" || element.ToString() == "7")
                        temp += "7";
                    if (element.ToString() == "８" || element.ToString() == "8")
                        temp += "8";
                    if (element.ToString() == "９" || element.ToString() == "9")
                        temp += "9";
                }
            }
            return Convert.ToString(temp);
        }
        public static DataView AccessDatabasesel(string select_str)
        {
            System.Data.DataView dav;
            try
            {
                string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=HMDgms.mdb";
                OleDbConnection myConnection = new OleDbConnection(myConnectionString);
                OleDbDataAdapter dascore = new OleDbDataAdapter(select_str, myConnection);
                DataSet ds = new DataSet();
                dascore.Fill(ds);
                dav = ds.Tables[0].DefaultView;
            }
            catch (Exception E)
            {
                return null;
            }
            return dav;
        }
        public static DataView SetGlucoseToTimeSet()
        {
            DataView dvglucose = MainModule.AccessDatabasesel("SELECT * FROM glucose where MeterID='" + alu_tp.main_1.MeterIDNo + "' ORDER BY  TestTime DESC");
            DataTable dt = new DataTable();
            dt.Columns.Add("TestT", typeof(string));
            dt.Columns.Add("TestTime", typeof(DateTime));
            dt.Columns.Add("Expr1", typeof(string));
            dt.Columns.Add("Expr2", typeof(string));
            dt.Columns.Add("Expr3", typeof(string));
            dt.Columns.Add("Expr4", typeof(string));
            dt.Columns.Add("Expr5", typeof(string));
            dt.Columns.Add("Expr6", typeof(string));
            dt.Columns.Add("Expr7", typeof(string));
            dt.Columns.Add("Expr8", typeof(string));
            dt.Columns.Add("Expr9", typeof(string));

            DataView dv = dt.DefaultView;
            dv.Sort = "TestTime";
            string _timeTmp = string.Empty;
            string columnName = "";
            bool _addData = false;
            foreach (DataRowView item in dvglucose)
            {
                DateTime _date = Convert.ToDateTime(item["TestTime"]);
                string _testTime = _date.ToString("yyyy/MM/dd");       
                string _time_idx = item["time_idx"].ToString();
                string _glucoseData = item["glucoseData"].ToString();

                int rowIndex = dv.Find(_testTime);
                columnName = "Expr" + _time_idx;

                _addData = (rowIndex < 0);

                if (_addData)
                {
                    DataRow _drNew = dt.NewRow();
                    DataRow _newRow = dt.NewRow();
                    _newRow["TestT"] = string.Format("{0}-{1}-{2}", _date.Year, _date.Month.ToString().PadLeft(2,'0'), _date.Day.ToString().PadLeft(2,'0'));
                    _newRow["TestTime"] = _testTime;
                    _newRow["Expr1"] = 0;
                    _newRow["Expr2"] = 0;
                    _newRow["Expr3"] = 0;
                    _newRow["Expr4"] = 0;
                    _newRow["Expr5"] = 0;
                    _newRow["Expr6"] = 0;
                    _newRow["Expr7"] = 0;
                    _newRow["Expr8"] = 0;
                    _newRow["Expr9"] = 0;
                    _newRow[columnName] = _glucoseData;

                    dt.Rows.Add(_newRow);
                }
                else
                {
                    if (dv[rowIndex][columnName].ToString().Length > 0)
                    {
                        string _value = dv[rowIndex][columnName].ToString();
                        if (Convert.ToInt16(_glucoseData) < Convert.ToInt16(_value))
                            _glucoseData = _value.ToString();
                    }
                    dv[rowIndex][columnName] = _glucoseData;
                }
            }
            return dv;
        }        

        public static void updateDatabasesel(string update_str)
        {
            string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=HMDgms.mdb";

            try
            {
                using (OleDbConnection db = new OleDbConnection(myConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(update_str, db) { CommandType = CommandType.Text };
                    db.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "METER MANAGER V2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void insertDatabasesel(string insert_str)
        {
            string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=HMDgms.mdb";

            try
            {
                using (OleDbConnection db = new OleDbConnection(myConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(insert_str, db) { CommandType = CommandType.Text };
                    db.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception E)
            {

            }
        }
        public static void deleteDatabasesel(string delete_str)
        {
            string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=HMDgms.mdb";
            try
            {
                using (OleDbConnection db = new OleDbConnection(myConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand(delete_str, db) { CommandType = CommandType.Text };
                    db.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch (Exception E)
            {

            }
        }
        public static void readOldData()
        {
            System.Data.DataView dv0;
            dv0 = MainModule.AccessDatabasesel("SELECT MeterID,TestTime,GlucoseData,m_Event,format(TestTime, 'YYYY') AS  yy ,format(TestTime, 'MM') AS  mm ,format(TestTime, 'DD') AS  dd ,format(TestTime, 'HH') AS  hh,format(TestTime, 'mm') AS  mi,format(TestTime, 'ss') AS  se  FROM glucose where MeterID='" + alu_tp.main_1.MeterIDNo + "' order by TestTime");

            if (dv0 != null)
            {
                if (dv0.Count > 0)
                {
                    for (int s = 1; s <= dv0.Count; s++)
                    {
                        alu_tp.main_1.DataGL[s] = Convert.ToInt16(dv0[s - 1].Row["GlucoseData"].ToString());
                        alu_tp.main_1.DataMO[s] = Convert.ToInt16(dv0[s - 1].Row["mm"].ToString());
                        alu_tp.main_1.DataDA[s] = Convert.ToInt16(dv0[s - 1].Row["dd"].ToString());
                        alu_tp.main_1.DataHR[s] = Convert.ToInt16(dv0[s - 1].Row["hh"].ToString());
                        alu_tp.main_1.DataMI[s] = Convert.ToInt16(dv0[s - 1].Row["mi"].ToString());
                        alu_tp.main_1.DataYR[s] = Convert.ToInt16(dv0[s - 1].Row["yy"].ToString());
                        alu_tp.main_1.DataSE[s] = Convert.ToInt16(dv0[s - 1].Row["se"].ToString());
                        alu_tp.main_1.DataACPC[s] = dv0[s - 1].Row["m_Event"].ToString();

                        alu_tp.main_1.MDataGL[s] = Convert.ToInt16(dv0[s - 1].Row["GlucoseData"].ToString());
                        alu_tp.main_1.MDataMO[s] = Convert.ToInt16(dv0[s - 1].Row["mm"].ToString());
                        alu_tp.main_1.MDataDA[s] = Convert.ToInt16(dv0[s - 1].Row["dd"].ToString());
                        alu_tp.main_1.MDataHR[s] = Convert.ToInt16(dv0[s - 1].Row["hh"].ToString());
                        alu_tp.main_1.MDataMI[s] = Convert.ToInt16(dv0[s - 1].Row["mi"].ToString());
                        alu_tp.main_1.MDataYR[s] = Convert.ToInt16(dv0[s - 1].Row["yy"].ToString());
                        alu_tp.main_1.MDataSE[s] = Convert.ToInt16(dv0[s - 1].Row["se"].ToString());
                        alu_tp.main_1.MDataACPC[s] = dv0[s - 1].Row["m_Event"].ToString();
                        alu_tp.main_1.MDataYRDA[s] = dv0[s - 1].Row["TestTime"].ToString();
                    }
                }
            }
            alu_tp.main_1.Total = dv0.Count;
        }
       
   public static void set_MessageBox(string msg, int delay)
   {
      StartKiller(delay);
      MessageBox.Show( msg, "METER MANAGER V2",  MessageBoxButtons.OK, MessageBoxIcon.Information);
     //  MessageBox.Show(msg, "血糖機通訊軟體");
   }


   public static void get_time_set()
   {
       System.Data.DataView dv1;
       dv1 = MainModule.AccessDatabasesel("SELECT * FROM time_set where user_idx=0 order by idx");
       alu_tp.timgp = new time_gp[dv1.Count];
       int t1;

       for (t1 = 0; t1 < dv1.Count; t1++)
       {
           alu_tp.timgp[t1] = new time_gp();
           alu_tp.timgp[t1].time_name = dv1[t1].Row["time_name"].ToString();
           alu_tp.timgp[t1].time_on = dv1[t1].Row["time_on"].ToString();
           alu_tp.timgp[t1].time_off = dv1[t1].Row["time_off"].ToString();
           alu_tp.timgp[t1].on_off = dv1[t1].Row["on_off"].ToString();
           alu_tp.timgp[t1].time_name = dv1[t1].Row["time_name"].ToString();
       }
       //  return "OK";
   }

   static void StartKiller(int delay)
   {
       System.Windows.Forms.Timer timer0 = new System.Windows.Forms.Timer();
       timer0.Interval = delay; //3秒啓動  
       timer0.Tick += new EventHandler(Timer_Tick);
       timer0.Start();
   }

   static void Timer_Tick(object sender, EventArgs e)
   {
       KillMessageBox();
       //停止Timer  
       ((System.Windows.Forms.Timer)sender).Stop();
       ((System.Windows.Forms.Timer)sender).Dispose();
   }
   static void KillMessageBox()
   {
       //依MessageBox的標題,找出MessageBox的視窗  
       IntPtr ptr = FindWindow(null, "METER MANAGER V2");
       if (ptr != IntPtr.Zero)
       {
           //找到則關閉MessageBox視窗  
           PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
       }
      }
    }

    public class WorkerSet
    {
        public string CurBackPicPath;
        public int CurPicMode;
        public int CurMenuMode;
    }
    struct Customer
    {
        public string FirstName;
        public string LastName;
        public int Id;
    }
}