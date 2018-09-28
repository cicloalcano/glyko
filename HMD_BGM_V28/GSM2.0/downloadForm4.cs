using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32; // For Registry Access
using System.IO;
using System.IO.Ports;
using Newtonsoft.Json; // 2015.12.10 denny for JSON
using System.Net; // 2015.12.10 denny for WebRequest
using System.Threading;// 2015.12.15 denny for WebRequest

namespace GSM2._0
{
    public partial class downloadForm4 : Form
    {
        public int METER_ID, mid_1, mid_2, mid_3, mid_c_1, mid_c_2;//  '當下讀取METER的總資料筆數
        public string meter_id_all;
        public int M_BufYR;//機器預設年度
        private static comm_list[] send_comm;

        private int reader_delay_t1;
        private int reader_delay_t2;
        int try_times = 0;
        int Readingmode;
        int Y;
        int Z;
        int m;
        int n;
        int s;
        int receTotal;
        //bool MeterToPCUploadEnd;
        private string model_num;

        private string UserID, Birthday, Gender, UserName;
        bool AddUserSaved = false;

        enum CheckResult
        {
            RESULT_FAILED = 0,
            RESULT_OK = 1,
            RESULT_NONE = 2,
        }
        //Enumeration of Read Result
        enum ReadResult
        {
            READ_FAILED = 0,
            READ_COMPARE_ERROR = 1,
            READ_OK = 2,
            PORT_OPEN_FAILED = 3,
            SETTING_FAILED = 4,
        }
        //Enumeration of Write Result
        enum WriteResult
        {
            WRITE_FAILED = 0,
            WRITE_ERROR = 1,
            WRITE_OK = 2,
            PORT_OPEN_FAILED = 3,
        }
     
        byte[] Buffer_Receive_one = new byte[20];
        byte[] Buffer_Receive_two = new byte[2];

        const int WRITE_DELAY_MS = 50;
        const int DEFAULT_DELAYTIME = 20;

        const int FIA_Presisa = 300;
        const int Brasil = 301;


        public downloadForm4()
            : base()
        {
            InitializeComponent();
        }

        private static downloadForm4 transDefaultFormFrmMain = null;
        internal static downloadForm4 TransDefaultFormFrmMain
        {
            get
            {
                if (transDefaultFormFrmMain == null)
                {
                    transDefaultFormFrmMain = new downloadForm4();
                }
                return transDefaultFormFrmMain;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            LOOK_BOOK g = new LOOK_BOOK();
            g.MdiParent = this.MdiParent;
            g.Show();
            this.Close();
        }
        private void bind_comm()
        {
            send_comm = new comm_list[19];
            for (int jj = 0; jj < 19; jj++)    //   '使meter資料先暫存
            {
                send_comm[jj] = new comm_list();
            }
            send_comm[0].send_str = new byte[1] { 0x00 };//COMMAND_ZERO
            send_comm[1].send_str = new byte[1] { 0x55 };//COMMAND_FIVE
            send_comm[2].send_str = new byte[3] { 0xba, 0xa5, 0xa9 };//COMMAND_ON_LINE
            send_comm[3].send_str = new byte[3] { 0xab, 0xfd, 0xa9 };//COMMAND_READ_METER_ID
            send_comm[4].send_str = new byte[3] { 0xab, 0xfe, 0xa9 };//COMMAND_READ_METER_ID
            send_comm[5].send_str = new byte[3] { 0xab, 0xff, 0xa9 };//COMMAND_READ_METER_ID
            send_comm[6].send_str = new byte[3] { 0xab, 0xf9, 0xa9 }; // 249 =ID_L
            send_comm[7].send_str = new byte[3] { 0xab, 0xfa, 0xa9 };  //250 =ID_H
            //   send_comm[7].send_str = new byte[3] { 0xba, 0xa5, 0xa9 };//COMMAND_ON_LINE
            send_comm[8].send_str = new byte[3] { 0xae, 0xa5, 0xa9 };//COMMAND_READ_TOTAL_EEPROM
            send_comm[9].send_str = new byte[3] { 0xab, 0x2a, 0xa9 };//COMMAND_READ_PRODUCT_YEAR  
            send_comm[10].send_str = new byte[3] { 0xac, 0x00, 0xa9 };//COMMAND_READ_RECORD1
            send_comm[11].send_str = new byte[3] { 0xad, 0x00, 0xa9 };//COMMAND_READ_RECORD2
            send_comm[12].send_str = new byte[3] { 0xaf, 0x00, 0x00 };//COMMAND_READ_RECORD_DATA 
            send_comm[13].send_str = new byte[3] { 0xb5, 0xa5, 0xa9 };//COMMAND_OFF
            send_comm[14].send_str = new byte[9] { 0xb1, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };//同步時間
            send_comm[15].send_str = new byte[3] { 0xac, 0xb5, 0xb9 };//COMMAND_READ_PRODUCT_YEAR 新機器
            send_comm[16].send_str = new byte[4] { 0xa8, 0x02,0x01, 0xab };//讀取血糖新款
            send_comm[17].send_str = new byte[6] { 0xa8, 0x03,0x01,0x00,0x00,0xab };//17byte 讀取
            send_comm[18].send_str = new byte[3] { 0xad, 0xb5, 0xb9 };//讀取機型           
            //   send_comm[16].send_str = new byte[3] { 0xa8, 0xb5, 0xb9 };//COMMAND_READ_PRODUCT_YEAR 新機器
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            curveAllACPCFrom f = new curveAllACPCFrom();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Close();
        }

        private void btnReadMeter_Click(object sender, EventArgs e)//'開機
        {
            timeusb.Enabled = false;
            Array.Clear(alu_tp.main_1.MDataDA, 0, 1000);
            Array.Clear(alu_tp.main_1.MDataHR, 0, 1000);
            Array.Clear(alu_tp.main_1.MDataMI, 0, 1000);
            Array.Clear(alu_tp.main_1.MDataMO, 0, 1000);
            Array.Clear(alu_tp.main_1.MDataGL, 0, 1000);
            Array.Clear(alu_tp.main_1.MDataSE, 0, 1000);
            Array.Clear(alu_tp.main_1.MDataACPC, 0, 1000);
            Array.Clear(alu_tp.main_1.MDataYR, 0, 1000);
            Array.Clear(alu_tp.main_1.MDataYRDA, 0, 1000);

            alu_tp.main_1.Total = 0;

            if (alu_tp.main_1.meter_online != true)
            {
               CHECK_ONLINE();
            }

            Readingmode = 2;    //  '設定為check階段

            Y = 0;

            if (alu_tp.main_1.port_usb == 2)//判斷 usb 或 rs232
            {
                timerOP.Interval = 140;
                timerOP.Start();
                reader_delay_t1 = 50;
                timerRt.Interval = 20;
                reader_delay_t2 = 130;
            }
            else
            {
            reader_delay_t1 = 50;
                reader_delay_t2 = 95;
            }

            timerOP.Enabled = true;
        }

        private void timerOP_Tick(object sender, EventArgs e)// '開機指令發送timer*
        {
            timerOP.Stop();
            timerRt.Stop();
            timerRt.Enabled = false;       

            if (Readingmode == 15)
            {
                string a = string.Empty;
            }
            switch (Readingmode)
            {
                case 0:
                    break;
                case 1:
                    Y++;                    
                    if (Y > 30)         //'使link 循環5次沒反應後 重新開機指令
                    {
                        timerOP.Enabled = false;
                        MainModule.set_MessageBox(alu_tp.main_1.msg_txt.GetString("CONNECTIONFAILED"), 1500);
                        closeform();
                    }
                    else
                    {
                        if (Y % 2 == 1)
                        {
                            if (alu_tp.main_1.port_usb == 2)
                            {
                                System.Threading.Thread.Sleep(50);
                                write_meter(send_comm[13].send_str, 0, 1);
                                System.Threading.Thread.Sleep(50);
                                usb.read_usb();                         
                            }
                            Readingmode = 0;
                        }
                    }
                    break;
                case 2:
                    Z ++;  //  '每送出一次增加1 為了使check link 循環20次沒反應後 重新開機指令            

                    if (Z >20)  //  'check link 循環20次沒反應後 重新開機指令
                    {
                        labelRead.Text = alu_tp.main_1.msg_txt.GetString("ConnectionTest");
                        Z = 0;
                        Y = 0;
                      
                        Readingmode = 0;
                    }
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    break;
                case 8:
                case 9:
                    break;
                case 10:
                    send_comm[Readingmode].send_str[1] = ((byte)m);//Index
                    BarReading.Value = m;
                    break;
                case 11:
                    send_comm[Readingmode].send_str[1] = ((byte)n);//Index
                    BarReading.Value = alu_tp.main_1.MTotal + n;
                    if (n == alu_tp.main_1.MTotal)
                    {
                        s = 0;                      
                    }
                    break;
                case 12:
                    if (alu_tp.main_1.max255 == true)
                    {
                        send_comm[12].send_str = new byte[3] { 0xaf, 0x00, 0x00 };//COMMAND_READ_RECORD_DATA 
                        send_comm[Readingmode].send_str[1] = (byte)(Convert.ToInt16(m));//Index
                        send_comm[Readingmode].send_str[2] = (byte)(0xaf + send_comm[Readingmode].send_str[1]);//CheckSum
                    }
                    else
                    {
                        send_comm[12].send_str = new byte[4] { 0xaf, 0x00, 0x00, 0x00 };//COMMAND_READ_RECORD_DATA 
                        send_comm[Readingmode].send_str[1] = (byte)(Convert.ToInt16(m) >> 8);//Index
                        send_comm[Readingmode].send_str[2] = (byte)(Convert.ToInt16(m));//Index
                        send_comm[Readingmode].send_str[3] = (byte)(0xaf + send_comm[Readingmode].send_str[1] + send_comm[Readingmode].send_str[2]);//CheckSum
                    }

                    BarReading.Value = m;
                    if (m == alu_tp.main_1.MTotal)
                    {
                        s = 0;
                    }
                    break;
                case 13:
                    timerOP.Enabled = false;
                    break;
                case 14:
                    int Year1 = DateTime.Now.Year;
                    int Month1 = DateTime.Now.Month;
                    int Date1 = DateTime.Now.Day;
                    int Hour1 = DateTime.Now.Hour;
                    int Minute1 = DateTime.Now.Minute;
                    int Second1 = DateTime.Now.Second;

                    send_comm[Readingmode].send_str[1] = (byte)(Year1 - 2000);//Index
                    send_comm[Readingmode].send_str[2] = (byte)(Month1);//Index
                    send_comm[Readingmode].send_str[3] = (byte)(Date1);//Index
                    send_comm[Readingmode].send_str[4] = (byte)(Hour1);//Index
                    send_comm[Readingmode].send_str[5] = (byte)(Minute1);//Index
                    send_comm[Readingmode].send_str[6] = (byte)(Second1);//Index
                    send_comm[Readingmode].send_str[7] = (byte)((0xb1 + send_comm[Readingmode].send_str[1] + send_comm[Readingmode].send_str[2] + send_comm[Readingmode].send_str[3] + send_comm[Readingmode].send_str[4] + send_comm[Readingmode].send_str[5] + send_comm[Readingmode].send_str[6]) >> 8);//Index
                    send_comm[Readingmode].send_str[8] = (byte)(0xb1 + send_comm[Readingmode].send_str[1] + send_comm[Readingmode].send_str[2] + send_comm[Readingmode].send_str[3] + send_comm[Readingmode].send_str[4] + send_comm[Readingmode].send_str[5] + send_comm[Readingmode].send_str[6]);//Index
                    //send_comm[Readingmode].send_str[9] = (byte)(0xb1 + send_comm[Readingmode].send_str[1] + send_comm[Readingmode].send_str[2]);//CheckSum
                    break;
                case 15://
                case 16://新款讀取
                    break;
                case 17://
                    timerOP.Interval = 110;
                    reader_delay_t1 = 90;
                 
                    send_comm[Readingmode].send_str[3] = (byte)(Convert.ToInt16(m) >> 8);//Index
                    send_comm[Readingmode].send_str[4] = (byte)(Convert.ToInt16(m));//Index
                    send_comm[Readingmode].send_str[5] = (byte)(0xa8 + send_comm[Readingmode].send_str[1] + send_comm[Readingmode].send_str[2] + send_comm[Readingmode].send_str[3] + send_comm[Readingmode].send_str[4]);//CheckSum
                    BarReading.Value = m;
                    if (m == alu_tp.main_1.MTotal)
                    {
                        s = 0;
                    }
                    break;
                case 18:
                    break;
            }        
            write_meter(send_comm[Readingmode].send_str, 0, send_comm[Readingmode].send_str.Length);
          
            reader_delay();
            if (Y < 31)
            {
                timerRt.Enabled = true;
                timerRt.Start();
                timerOP.Start();
            }
        }

        private void timerRt_Tick(object sender, EventArgs e)
        {
            timerRt.Enabled = false;
            int i;
            int BufACPC;
            int BufMO = 0;
            int BufDA = 0;
            int BufHR = 0;
            int BufMI = 0;
            int BufGL = 0;
            int BufSE = 0;
            int BufYR = 0;
            if (alu_tp.main_1.port_usb == 2)//判斷 usb 或 rs232
            {
                Buffer_Receive_one = usb.read_usb();
                i = Buffer_Receive_one.Length;
                if (alu_tp.main_1.myDeviceDetected == false)
                {
                    timerRt.Enabled = false;
                    timerOP.Enabled = false;
                    MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("DATARECEIVEERROR"),i+1));
                    BarReading.Value = 0;
                    MainModule.set_MessageBox(alu_tp.main_1.msg_txt.GetString("CONNECTIONFAILED"), 1500);
                    closeform();
                }
            }
            else
            {
                i = alu_tp.main_1.serialPort1.BytesToRead;    //收到幾筆資料?
                if (alu_tp.main_1.serialPort1.BytesToRead > -1 && alu_tp.main_1.serialPort1.BytesToRead < 19)
                    alu_tp.main_1.serialPort1.Read(Buffer_Receive_one, 0, i);
                if (Readingmode == 17 && i < 18)
                {
                  System.Threading.Thread.Sleep(80);
                  byte[] Buffer_Receive_one1 = new byte[20];
                  int  i0 = alu_tp.main_1.serialPort1.BytesToRead;  
                  alu_tp.main_1.serialPort1.Read(Buffer_Receive_one1, 0, i0);
                  for (int j0 = i; j0 <= 18; j0++)
                  {
                      Buffer_Receive_one[j0] = Buffer_Receive_one1[j0 - i];
                  }
                  i = i + i0;
                }
            }
            if (m == 299)
            {
            }
            switch (i)  //
            {
                case 0:
                    if (alu_tp.main_1.meter_online)
                    {
                        try_times++;

                        if (try_times > 150 && Readingmode >= 9)
                        {
                            try_times = 0;
                            timerRt.Enabled = false;
                            timerOP.Enabled = false;

                            MainModule.set_MessageBox(string.Format(alu_tp.main_1.msg_txt.GetString("DATARECEIVEERROR"), i + 1), 3200);
                            BarReading.Value = 0;

                            MainModule.set_MessageBox(alu_tp.main_1.msg_txt.GetString("CONNECTIONFAILED"), 1500);

                            closeform();
                        }
                        else if (Readingmode == 15  )
                        {
                            Readingmode = 9;
                        }
                        else if (Readingmode == 18)  // 'read model
                        {
                            model_num = "P137_199";
                            Readingmode = 8;
                        }
                        else if (Readingmode == 16)
                        {                           
                            Readingmode = 8;
                        }
                    }
                    break;
                case 9:
                    if (Buffer_Receive_one[0] == 178 && Buffer_Receive_one[1] == 94 && Buffer_Receive_one[2] == 187 && Readingmode == 14)  // '同步時間
                    {
                        Readingmode = 13;
                    }
                    else
                    {
                        BufMO = Convert.ToInt16((Buffer_Receive_one[0] >> 4).ToString());         //'利用AND OR * / 進行16位元壓縮碼解碼
                        BufGL = Convert.ToInt16((((Buffer_Receive_one[0] & 0x03) * 256) + Buffer_Receive_one[1]).ToString());
                        BufACPC = Convert.ToInt16(((Buffer_Receive_one[0] >> 2) & 0x03).ToString());
                       
                        BufDA = Convert.ToInt16((Buffer_Receive_one[2] >> 3).ToString());
                        BufHR = Convert.ToInt16((((Buffer_Receive_one[2] & 0x07) << 2) + (Buffer_Receive_one[3] >> 6)).ToString());
                        BufMI = Convert.ToInt16((Buffer_Receive_one[3] & 0x3f).ToString());
                        BufSE = Convert.ToInt16((((Buffer_Receive_one[6] >> 6) & 0x03)*15 ).ToString()); 

                        alu_tp.main_1.MDataDA[m] = BufDA;     //  '******************************************MDataDA........值
                        alu_tp.main_1.MDataHR[m] = BufHR;     //  '******************************************MDataHR........值
                        alu_tp.main_1.MDataMI[m] = BufMI;     //  '
                        alu_tp.main_1.MDataMO[m] = BufMO;     //  '******************************************MDataMO........值
                        alu_tp.main_1.MDataGL[m] = BufGL;     //  '******************************************MDataGL........值
                        alu_tp.main_1.MDataSE[m] = BufSE;     //  '******************************************MDataSE(秒)......值
                      
                        alu_tp.main_1.MDataACPC[m] = BufACPC.ToString();
                        BufYR = Convert.ToInt16((Convert.ToInt32(M_BufYR) + (Buffer_Receive_one[4] & 0x0f)).ToString());
                        alu_tp.main_1.MDataYR[m] = BufYR;

                        if (m < alu_tp.main_1.MTotal)
                            m = m + 1;
                        else if (m == alu_tp.main_1.MTotal)
                            m = 0;
                        if (m == 0)
                        { Readingmode = 14; }
                    }
                    break;
                case 17:
                    if (Buffer_Receive_one[0] == 168 && Buffer_Receive_one[1] == 0x02 && Readingmode == 16)  // '新機
                    {
                        M_BufYR = 2000;
                        alu_tp.main_1.max255 = true;
                        alu_tp.main_1.MTotal = Buffer_Receive_one[9] * 256 + Buffer_Receive_one[10];    //   '******************************************MTotal........值

                        if (alu_tp.main_1.MTotal > 0)//
                        {
                            labelRead.Text = alu_tp.main_1.MTotal + alu_tp.main_1.rm_txt.GetString("DATADOWNLOADING");
                            m = 1;
                        }
                        else if (alu_tp.main_1.MTotal == 0)
                        {
                            labelRead.Text = alu_tp.main_1.rm_txt.GetString("DATADOWNLOADING2");
                            closeform();
                        }
                        BarReading.Maximum = alu_tp.main_1.MTotal;
                        alu_tp.main_1.max255 = false;
                        Readingmode = 17;
                    }
                    break;
                case 18:
                    if (Buffer_Receive_one[0] == 168 && Buffer_Receive_one[1] == 0x03 && Readingmode == 17)  // '讀取血糖資料18byte
                    {
                        /* 2014.12.09 support 8 byte command
                         BufYR  = Convert.ToInt16((((Buffer_Receive_one[2] & 0x0f) << 3) + (Buffer_Receive_one[3] >> 5)).ToString());
                         BufMO = Convert.ToInt16(((Buffer_Receive_one[3] >> 1) & 0x0f).ToString());
                         BufDA = Convert.ToInt16((((Buffer_Receive_one[3] & 0x1) << 4) + (Buffer_Receive_one[4] >> 4)).ToString());
                         BufHR = Convert.ToInt16((((Buffer_Receive_one[4] & 0x0f) << 1) + (Buffer_Receive_one[5] >> 7)).ToString());
                         BufMI = Convert.ToInt16(((Buffer_Receive_one[5] >> 1) & 0x3f).ToString());
                         BufSE = Convert.ToInt16((((Buffer_Receive_one[5] & 0x01) << 5) + (Buffer_Receive_one[6] >> 3)).ToString());        
                         BufACPC = Convert.ToInt16((Buffer_Receive_one[11] & 0x7f).ToString());
                         BufGL = Convert.ToInt16((((Buffer_Receive_one[14] ) * 256) + Buffer_Receive_one[15]).ToString());                    
                        */
                         /* 2014.12.09 support 8 byte command*/
                         BufYR = Convert.ToInt16((Buffer_Receive_one[2] >> 1).ToString());
                         BufMO = Convert.ToInt16((((Buffer_Receive_one[2] & 0x01) << 3) + (Buffer_Receive_one[3] >> 5)).ToString());
                         BufDA = Convert.ToInt16((Buffer_Receive_one[3] & 0x1f).ToString());
                         BufHR = Convert.ToInt16((Buffer_Receive_one[4] >> 3).ToString());
                         BufMI = Convert.ToInt16((((Buffer_Receive_one[4] & 0x07) << 3) + (Buffer_Receive_one[5] >> 5)).ToString());
                         BufSE = Convert.ToInt16((((Buffer_Receive_one[5] & 0x18) >> 3) * 15).ToString());
                         BufACPC = Convert.ToInt16((((Buffer_Receive_one[7] & 0x03) << 1)+ (Buffer_Receive_one[8] >> 7)).ToString());
                         BufGL = Convert.ToInt16((((Buffer_Receive_one[8] & 0x03) << 8) + Buffer_Receive_one[9]).ToString());            

                         alu_tp.main_1.MDataDA[m] = BufDA;     //  '******************************************MDataDA........值
                         alu_tp.main_1.MDataHR[m] = BufHR;     //  '******************************************MDataHR........值
                         alu_tp.main_1.MDataMI[m] = BufMI;     //  '
                         alu_tp.main_1.MDataMO[m] = BufMO;     //  '******************************************MDataMO........值
                         alu_tp.main_1.MDataGL[m] = BufGL;     //  '******************************************MDataGL........值
                         alu_tp.main_1.MDataSE[m] = BufSE;     //  '******************************************MDataSE(秒)......值

                         alu_tp.main_1.MDataACPC[m] = BufACPC.ToString();
                        
                         alu_tp.main_1.MDataYR[m] = BufYR+2000;

                         if (m < alu_tp.main_1.MTotal)
                            m = m + 1;
                         else if (m == alu_tp.main_1.MTotal)
                            m = 0;
                         if (m == 0)
                         { Readingmode = 14; }
                    }
                    break;
                case 1:
                        if (Buffer_Receive_one[0] == 0x00  && Readingmode ==0)    //  'FOR ENHANCE check階段
                    {
                        labelRead.Text = alu_tp.main_1.rm_txt.GetString("ConnectionTest");
                        Readingmode = 1;
                    }
                  
                    break;
                case 2:
                    if (Buffer_Receive_one[0] == 0x54 && Buffer_Receive_one[1] == 0xF1 && Readingmode == 1)    //  'FOR ENHANCE check階段
                    {
                        labelRead.Text = alu_tp.main_1.rm_txt.GetString("ConnectionIn");

                        Readingmode = 2;
                    }
                    break;
                case 3:         //'****比對接收陣列1*3
                    if (Buffer_Receive_one[0] == 0xAA && Buffer_Receive_one[1] == 0x5A && Buffer_Receive_one[2] == 0xAA && Readingmode == 2)
                    {
                        labelRead.Text = alu_tp.main_1.rm_txt.GetString("Connection");

                        Readingmode = 3;//2        //  '開啟可讀取總合階段    
                    }
                    else if (Buffer_Receive_one[1] == 91 && Buffer_Receive_one[2] == 170 && Readingmode == 3)  // 'meter_id
                    {
                        mid_1 = Buffer_Receive_one[0];

                        Readingmode = 4;//2        //  '開啟可讀取總合階段   
                    }
                    else if (Buffer_Receive_one[1] == 91 && Buffer_Receive_one[2] == 170 && Readingmode == 4)  // 'meter_id
                    {
                        mid_2 = Buffer_Receive_one[0];

                        Readingmode = 5;//2    
                    }
                    else if (Buffer_Receive_one[1] == 91 && Buffer_Receive_one[2] == 170 && Readingmode == 5)  // 'meter_id
                    {
                        mid_3 = Buffer_Receive_one[0];
                        Readingmode = 6;//2        //  '開啟可讀取總合階段  
                    }
                    else if (Buffer_Receive_one[1] == 91 && Buffer_Receive_one[2] == 170 && Readingmode == 6)  // 'meter_id
                    {
                        mid_c_1 = Buffer_Receive_one[0];
                        Readingmode = 7;//2    
                    }
                    else if (Buffer_Receive_one[1] == 91 && Buffer_Receive_one[2] == 170 && Readingmode == 7)  // 'meter_id
                    {
                        mid_c_2 = Buffer_Receive_one[0];
                        METER_ID = mid_3 + mid_2 * 256 + mid_1 * 256 * 256;
                        //meter_id_all = Convert.ToString(mid_c_2 * 256 + mid_c_1).PadLeft(5, '0') + Convert.ToString(METER_ID).PadLeft(7, '0');
                        meter_id_all = METER_ID.ToString().PadLeft(7, '0');
                        alu_tp.main_1.MeterIDNo = meter_id_all;
                        MainModule.SettingInitUserData();
                        if (true) // 2015.12.23 denny for Upload to web
                        //if (chkRegisterMeterid(meter_id_all) == false) // 2015.12.23 denny for Upload to web
                        {
                            MainModule.insertDatabasesel(" INSERT INTO [HmdRegister] (mid,uid,RS_232,Unit1,Time1,Max1,Min1,Maxp,Minp,service_url) VALUES ( '" + meter_id_all + "','1','COM1','1','1','180','50','300','30','http://new.glucoleader.a2hosted.com//api')");// 2015.12.14 denny for URL service
                            //MainModule.insertDatabasesel(" INSERT INTO [ho_user] (UserNo,UserName) VALUES ( '" + meter_id_all + "','" + meter_id_all + "')");                  
                            //AddUser f = new AddUser();
                            //AddUser f = new AddUser("downloadForm4", this);
                            //f.Show();
                        }
                        Readingmode = 18;
                    }
                    else if (Buffer_Receive_one[1] == 90 && Buffer_Receive_one[2] == 170 && Readingmode == 8)//獲得總筆數
                    {
                        alu_tp.main_1.MTotal = Buffer_Receive_one[0];    //   '******************************************MTotal........值

                        if ( alu_tp.main_1.MTotal > 0)//
                        {
                            labelRead.Text = alu_tp.main_1.MTotal + alu_tp.main_1.rm_txt.GetString("DATADOWNLOADING");
                            m = 1;
                        }
                        else if (alu_tp.main_1.MTotal == 0)
                        {
                            labelRead.Text = alu_tp.main_1.rm_txt.GetString("DATADOWNLOADING2");
                            //UploadToWebDB();// 2015.12.22 denny for uploading to web
                            closeform();
                        }
                        alu_tp.main_1.max255 = true;
                        Readingmode = 9;
                    }
                    else if (Buffer_Receive_one[1] == 91 && Buffer_Receive_one[2] == 170 && Readingmode == 9)  // '取得年
                    {
                        M_BufYR = Convert.ToInt16((Buffer_Receive_one[0] + 2000).ToString());

                        Readingmode = 10;//3    // '進入讀取階段
                        if (M_BufYR < 2006 || M_BufYR > DateTime.Today.Year)
                        {
                            alu_tp.main_1.meter_4port = true;
                            BarReading.Maximum = (alu_tp.main_1.MTotal * 2);
                            Readingmode = 10;
                            M_BufYR = DateTime.Today.Year;
                        }
                        else
                        {
                            alu_tp.main_1.meter_4port = false;
                            BarReading.Maximum = alu_tp.main_1.MTotal;
                            Readingmode = 12;
                        }
                    }
                    else if (Buffer_Receive_one[1] == 92 && Buffer_Receive_one[2] == 187 && Readingmode == 15)  // '新機器取得年
                    {
                        M_BufYR = Convert.ToInt16((Buffer_Receive_one[0] + 2000).ToString());
                        alu_tp.main_1.meter_4port = false;
                        BarReading.Maximum = alu_tp.main_1.MTotal;
                        //Readingmode = 12; // 7byte and 8byte command meter use different command for getting meter data 
                        if (model_num == "47" || model_num == "46" || model_num == "135") Readingmode = 17; // 8byte command for getting meter data
                        else Readingmode = 12;// 7byte command for getting meter data
                    }
                    //收到傳送結束
                    else if (Buffer_Receive_one[0] == 170 && Buffer_Receive_one[1] == 90 && Buffer_Receive_one[2] == 170 && Readingmode == 13)  // '結束階段
                    {
                        timerRt.Enabled = false;
                        timerOP.Enabled = false;
                        labelRead.Text = alu_tp.main_1.rm_txt.GetString("DOWNLOADINGOK");

                        MainModule.set_MessageBox(string.Format(alu_tp.main_1.msg_txt.GetString("SENDCOMPLETED"),meter_id_all), 7500);
                        System.Threading.Thread.Sleep(reader_delay_t1);

                        DataSave();
                        if (AddUserSaved)
                        {
                            UploadToWebDB();// 2015.12.21 denny for uploading to web
                        }
                        closeform();
                    }
                    else if (Buffer_Receive_one[0] == 178 && Buffer_Receive_one[1] == 94 && Buffer_Receive_one[2] == 187 && Readingmode == 14)  // '同步時間
                    {
                        Readingmode = 13;
                    }
                    //'進入讀取資料階段    並利用m n 反應MTOTAL值 將解碼資料載入5組暫存陣列
                    else if (m > 0 && m < alu_tp.main_1.MTotal + 1 && Buffer_Receive_one[2] == 170 && Readingmode == 10)
                    {
                        // reader_delay();
                        BufMO = ((Buffer_Receive_one[1] & 240) / 16);         //'利用AND OR * / 進行16位元壓縮碼解碼
                        BufGL = ((Buffer_Receive_one[1] & 3) * 256) | Buffer_Receive_one[0];
                        BufACPC = ((Buffer_Receive_one[1] & 4) / 4);
                        alu_tp.main_1.MDataMO[m] = BufMO;     //  '******************************************MDataMO........值
                        alu_tp.main_1.MDataGL[m] = BufGL;     //  '******************************************MDataGL........值
                        alu_tp.main_1.MDataACPC[m] = BufACPC.ToString(); //  '******************************************MDataACPC........值
                        if (m < alu_tp.main_1.MTotal)
                            m = m + 1;
                        else if (m == alu_tp.main_1.MTotal)
                            m = 0;
                        if (m == 0)
                        {
                            n = 1;
                            Readingmode = 11;
                        }
                    }
                    else if (n > 0 && n < alu_tp.main_1.MTotal + 1 && Buffer_Receive_one[2] == 170 && Readingmode == 11)
                    {
                        BufDA = ((Buffer_Receive_one[1] & 248) / 8);
                        BufHR = ((Buffer_Receive_one[1] & 7) * 4) | ((Buffer_Receive_one[0] & 192) / 64);
                        BufMI = Buffer_Receive_one[0] & 63;
                        alu_tp.main_1.MDataDA[n] = BufDA;     //  '******************************************MDataDA........值
                        alu_tp.main_1.MDataHR[n] = BufHR;     //  '******************************************MDataHR........值
                        alu_tp.main_1.MDataMI[n] = BufMI;     //  '******************************************MDataMI........值
                        alu_tp.main_1.MDataSE[m] = 0;     //  '******************************************MDataSE(秒)......值
                      
                        if (n < alu_tp.main_1.MTotal)
                            n = n + 1;
                        else if (n == alu_tp.main_1.MTotal)
                            n = 0;
                        if (n == 0)
                        { Readingmode = 13; }
                    }
                    else if (Buffer_Receive_one[1] == 92 && Buffer_Receive_one[2] == 187 && Readingmode == 18)  // 'read model
                    {
                        model_num = Convert.ToString(Buffer_Receive_one[0]);
                        //if (model_num == "47" || model_num == "46") Readingmode = 16; else Readingmode = 8; // 7byte and 8byte meter use the same command 
                        Readingmode = 8;// Both 7byte and 8byte meter support this command
                    }
                    break;
                case 4:
                    if (Buffer_Receive_one[2] == 90 && Buffer_Receive_one[3] == 170 && Readingmode == 8)//容量255筆以上獲得總筆數
                    {
                        alu_tp.main_1.MTotal = Buffer_Receive_one[0] * 256 + Buffer_Receive_one[1];    //   '******************************************MTotal........值

                        if (alu_tp.main_1.MTotal > 0)//
                        {
                            labelRead.Text = alu_tp.main_1.MTotal + alu_tp.main_1.rm_txt.GetString("DATADOWNLOADING");
                            m = 1;
                        }
                        else if (alu_tp.main_1.MTotal == 0)
                        {
                            labelRead.Text = alu_tp.main_1.rm_txt.GetString("DATADOWNLOADING2");
                            UploadToWebDB();// 2015.12.22 denny for uploading to web
                            closeform();
                        }
                        alu_tp.main_1.max255 = false;
                        Readingmode = 15;
                    }
                    break;
                case 6:
                    break;
                case 5:
                    break;
                default:        //'****比對接收陣列大於1*3
                  
                        timerRt.Enabled = false;
                        timerOP.Enabled = false;

                        MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("DATARECEIVEERROR"),i+1));
                        BarReading.Value = 0;
                        MainModule.set_MessageBox(alu_tp.main_1.msg_txt.GetString("CONNECTIONFAILED"), 1500);
                        closeform();                 
                    break;
            }
        }

        private bool chkRegisterMeterid(string meterID)
        {
            bool returnRegisterMeterid;
            DataView dv1 = new DataView();
            dv1 = MainModule.AccessDatabasesel("SELECT  *  FROM  HmdRegister where mid='" + meterID + "'");
            if (dv1.Count > 0)
                returnRegisterMeterid = true;
            else
                returnRegisterMeterid = false;

            return returnRegisterMeterid;
        }
        public void closeform()
        {                       
            timerRt.Enabled = false;
            timerOP.Enabled = false;
            timeusb.Enabled = true;
            btnPCToWeb.Enabled = true;
            Readingmode = 0;
        }


        private void DataSave()
        {
            if (alu_tp.main_1.ReportName == "guest")
                alu_tp.main_1.Total = 0;
            NewOldCutCombin();  //       '新舊檔案直接對切結合(利用資料在METER中已排序之前提)
        }

        private void NewOldCutCombin()
        {
            int I, s, ss, ic, sc, t, MSamePoint, oldtotal;
            int[] TGL = new int[1000];
            int[] TMI = new int[1000];
            int[] THR = new int[1000];
            int[] TDA = new int[1000];
            int[] TMO = new int[1000];
            int[] TYE = new int[1000];
            int[] TSE = new int[1000];
            string[] TACPC = new string[1000];

            System.Data.DataView dv1, dv2, dv3;
            dv1 = MainModule.AccessDatabasesel("select m_id,MeterID,TestTime,GlucoseData from glucose where MeterID='" + meter_id_all + "' order by  m_id desc ");
            dv3 = MainModule.AccessDatabasesel("SELECT * FROM time_set where user_idx=0");

            oldtotal = alu_tp.main_1.Total;   // '將目前資料庫總Total值先儲存
            MSamePoint = 0;
            int year2 = 0;
            for (sc = 1; sc <= alu_tp.main_1.MTotal; sc++)    //   '使meter資料先暫存
            {
                TGL[sc] = alu_tp.main_1.MDataGL[sc];
                TMI[sc] = alu_tp.main_1.MDataMI[sc];
                THR[sc] = alu_tp.main_1.MDataHR[sc];
                TDA[sc] = alu_tp.main_1.MDataDA[sc];
                TMO[sc] = alu_tp.main_1.MDataMO[sc];
                TYE[sc] = alu_tp.main_1.MDataYR[sc];
                TSE[sc] = alu_tp.main_1.MDataSE[sc];
                TACPC[sc] = alu_tp.main_1.MDataACPC[sc];
            }

            for (s = 1; s <= alu_tp.main_1.MTotal; s++)    //   '使meter資料反相 (Enhance第一筆為最早讀入之一筆.即最舊之一筆--本Extra第一筆為最新之一筆)
            {
                ic = alu_tp.main_1.MTotal - s + 1;
                alu_tp.main_1.MDataGL[s] = TGL[ic];
                alu_tp.main_1.MDataMI[s] = TMI[ic];
                alu_tp.main_1.MDataHR[s] = THR[ic];
                alu_tp.main_1.MDataDA[s] = TDA[ic];
                alu_tp.main_1.MDataMO[s] = TMO[ic];
                alu_tp.main_1.MDataSE[s] = TSE[ic];
                if (alu_tp.main_1.MDataMO[s-1] > alu_tp.main_1.MDataMO[s]) year2 = s;//有前一年的資料
                alu_tp.main_1.MDataYR[s] = TYE[ic];
                alu_tp.main_1.MDataACPC[s] = TACPC[ic];
            }

            for (ss = 1; ss <= alu_tp.main_1.MTotal; ss++)    //
            {
                //'進行比對...將資料庫最後一筆與meter內所有資料比對...比對血糖值及時間
                I = alu_tp.main_1.MTotal - ss + 1;
                if ((alu_tp.main_1.DataGL[alu_tp.main_1.Total] == alu_tp.main_1.MDataGL[I]) && (alu_tp.main_1.DataMI[alu_tp.main_1.Total] == alu_tp.main_1.MDataMI[I]) && (alu_tp.main_1.DataHR[alu_tp.main_1.Total] == alu_tp.main_1.MDataHR[I]) && (alu_tp.main_1.DataDA[alu_tp.main_1.Total] == alu_tp.main_1.MDataDA[I]) && (alu_tp.main_1.DataMO[alu_tp.main_1.Total] == alu_tp.main_1.MDataMO[I]))
                    MSamePoint = I;     //          '比對結果點        
            }

            // '從MATER中搜尋到相同資料，更新相同點以後的新資料
            if ((MSamePoint == 0 && alu_tp.main_1.Total > 0 && alu_tp.main_1.DataGL[1] != 0)
                || (MSamePoint == 0 && alu_tp.main_1.Total == 1 && alu_tp.main_1.DataGL[1] == 0))
            {
                oldtotal = 0;
            }
            receTotal = (alu_tp.main_1.MTotal - MSamePoint);
            alu_tp.main_1.Total = alu_tp.main_1.Total + receTotal;
            for (t = 1; t <= (alu_tp.main_1.MTotal - MSamePoint); t++)
            {
                alu_tp.main_1.DataMO[oldtotal + t] = alu_tp.main_1.MDataMO[MSamePoint + t];
                alu_tp.main_1.DataDA[oldtotal + t] = alu_tp.main_1.MDataDA[MSamePoint + t];
                alu_tp.main_1.DataHR[oldtotal + t] = alu_tp.main_1.MDataHR[MSamePoint + t];
                alu_tp.main_1.DataMI[oldtotal + t] = alu_tp.main_1.MDataMI[MSamePoint + t];
                alu_tp.main_1.DataGL[oldtotal + t] = alu_tp.main_1.MDataGL[MSamePoint + t];
                alu_tp.main_1.DataSE[oldtotal + t] = alu_tp.main_1.MDataSE[MSamePoint + t];
                alu_tp.main_1.DataACPC[oldtotal + t] = alu_tp.main_1.MDataACPC[MSamePoint + t];

                int SS01 = alu_tp.main_1.MDataYR[MSamePoint + t];
                if (alu_tp.main_1.meter_4port == true)
                {
                    if (t < year2) SS01 = DateTime.Today.Year - 1; else SS01 = DateTime.Today.Year;
                }
                try
                {
                    alu_tp.main_1.MDataYRDA[MSamePoint + t] = SS01 + "/" + alu_tp.main_1.MDataMO[MSamePoint + t] + "/" + alu_tp.main_1.MDataDA[MSamePoint + t] + " " + alu_tp.main_1.MDataHR[MSamePoint + t] + ":" + alu_tp.main_1.MDataMI[MSamePoint + t] + ":" + alu_tp.main_1.MDataSE[MSamePoint + t]+"";
                }
                catch
                {
                    break;
                }
            }

            ////////////////////////////////////////////////
            //Total = Total + (MTotal - MSamePoint);
            //  //for (t = 1; t <= (MTotal - MSamePoint); t++)
            //    Total = Total + (MTotal );
            dv2 = dv1;
            for (t = 1; t <= alu_tp.main_1.MTotal; t++)
            {
                int SS01 = alu_tp.main_1.MDataYR[t];
                if (alu_tp.main_1.meter_4port == true)
                {
                    if (t < year2) SS01 = DateTime.Today.Year - 1; else SS01 = DateTime.Today.Year;
                }
                string testtime1 = SS01 + "/" + alu_tp.main_1.MDataMO[t] + "/" + alu_tp.main_1.MDataDA[t] + " " + alu_tp.main_1.MDataHR[t] + ":" + alu_tp.main_1.MDataMI[t] + ":" + alu_tp.main_1.MDataSE[t]+"";
                string m_id1, timeidx1, DAYOFWEEK1, TestTime1;
                if (dv1 == null)
                    m_id1 = Convert.ToString(t);
                else
                {
                    if (dv1.Count == 0)
                    {
                        m_id1 = Convert.ToString(t);
                    }
                    else
                    {
                       m_id1 = Convert.ToString(Convert.ToInt16(dv1[0].Row["m_id"]) + t);
                    }

                    dv1.RowFilter = "TestTime = '" + testtime1 + "' and MeterID= '" + Convert.ToString(meter_id_all) + "' and GlucoseData ='" + Convert.ToString(alu_tp.main_1.MDataGL[t]) + "'";
                    if (dv1.Count > 0) goto nosave;
                }
                if (Convert.ToInt16(alu_tp.main_1.MDataACPC[t].ToString()) == 2 || Convert.ToInt16(alu_tp.main_1.MDataACPC[t].ToString()) == 3)
                {
                    MainModule.insertDatabasesel("INSERT INTO [QC] (MeterID,TestTime,GlucoseData,txdate,m_Event) VALUES ('" + Convert.ToString(meter_id_all) + "','" + Convert.ToString(Convert.ToDateTime(SS01 + "/" + alu_tp.main_1.MDataMO[t] + "/" + alu_tp.main_1.MDataDA[t] + " " + alu_tp.main_1.MDataHR[t] + ":" + alu_tp.main_1.MDataMI[t])) + ":" + alu_tp.main_1.MDataSE[t]+"'," + Convert.ToString(alu_tp.main_1.MDataGL[t]) + ",'" + Convert.ToString(DateTime.Now) + "','" + alu_tp.main_1.MDataACPC[t] + "')");
                }
                else
                {
                    TestTime1 = Convert.ToString(Convert.ToDateTime(SS01 + "/" + alu_tp.main_1.MDataMO[t] + "/" + alu_tp.main_1.MDataDA[t] + " " + alu_tp.main_1.MDataHR[t] + ":" + alu_tp.main_1.MDataMI[t]+":" + alu_tp.main_1.MDataSE[t]));
                    DAYOFWEEK1 = Convert.ToString(Convert.ToInt32(Convert.ToDateTime(SS01 + "/" + alu_tp.main_1.MDataMO[t] + "/" + alu_tp.main_1.MDataDA[t] + " " + alu_tp.main_1.MDataHR[t] + ":" + alu_tp.main_1.MDataMI[t] + ":" + alu_tp.main_1.MDataSE[t]).DayOfWeek));

                    DateTime d1 = Convert.ToDateTime(alu_tp.main_1.MDataHR[t] + ":" + alu_tp.main_1.MDataMI[t]  );
                    timeidx1 = "";
                    for (int t1 = 0; t1 < dv3.Count; t1++)
                    {
                        DateTime dt2 = Convert.ToDateTime(dv3[t1].Row["time_on"]);
                        DateTime dt3 = Convert.ToDateTime(dv3[t1].Row["time_off"]);
                        if (DateTime.Compare(d1, dt2) >= 0 && DateTime.Compare(d1, dt3) <= 0)
                        {
                            timeidx1 = dv3[t1].Row["idx"].ToString();
                        }
                    }
                    MainModule.AccessDatabasesel("ALTER TABLE glucose ADD Isupload Bit");
                    MainModule.insertDatabasesel("INSERT INTO [glucose] (m_id,MeterID,TestTime,GlucoseData,txdate,m_Event,time_idx,DAYOFWEEK,Isupload) VALUES (" + m_id1 + ",'" + Convert.ToString(meter_id_all) + "','" + TestTime1 + "','" + Convert.ToString(alu_tp.main_1.MDataGL[t]) + "','" + Convert.ToString(DateTime.Now) + "','" + alu_tp.main_1.MDataACPC[t] + "'," + timeidx1 + "," + DAYOFWEEK1 + " ,False)"); // 2015.12.14 denny for URL service
                    
                }
                dv1 = dv2;               
            nosave: ;
            }           
        }

        private void btnPCToWeb_Click(object sender, EventArgs e)
        {
            UploadToWebDB();
        }

        public void CatchData(string txtUserID, string txtBirthday, string txtGender, string txtName, bool Saved)
        {
            UserID = txtUserID;
            Birthday = txtBirthday;
            Gender = txtGender;
            UserName = txtName;
            AddUserSaved = Saved;
        }


        private void UploadToWebDB()
        {
            int UploadCounts = 0;
            DataView GlucoseDV;

            //while (!AddUserSaved) { }

            GlucoseDV = MainModule.AccessDatabasesel("select m_id,MeterID,TestTime,GlucoseData,m_Event,Isupload from glucose where MeterID='" + meter_id_all + "' order by  m_id asc ");
            //UploadCounts = GlucoseDV.Count;
            
            for (int i = 1; i <= GlucoseDV.Count; i++)
            {
                if (GlucoseDV.Table.Rows[i - 1]["Isupload"].ToString() == "False")
                {
                    UploadCounts = i;
                }
            
            }
            BarUpToWeb.Maximum = UploadCounts;

            for (int i = 1; i <= UploadCounts; i++)
            {
                if (GlucoseDV.Table.Rows[i - 1]["Isupload"].ToString() == "False")
                {
                    string Measure_DateString = DateTime.Parse(GlucoseDV.Table.Rows[i - 1]["TestTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                    var postData = new
                    {
                        apikey = "QTfHF4deK9X9CYuUgbm8CymaAFBRJOnQ",
                        request = 4,
                        Measure_Value = GlucoseDV.Table.Rows[i - 1]["GlucoseData"].ToString(),
                        Measure_Date = Measure_DateString,//DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Meter_NO = Brasil.ToString("D5") + GlucoseDV.Table.Rows[i - 1]["MeterID"].ToString(),
                        Measure_Mode ="PJ",
                        Char_No = "",
                        Operator_NO = 1,
                        Lot_NO = 1,
                        Event = GlucoseDV.Table.Rows[i - 1]["m_Event"].ToString(),
                        Blood_Type = 2,

                        IMEI = textUserID_0.Text,
                        Voltage = textBirthday.Text,
                        Temperature = textUserName.Text,
                        People_ID = textGender.Text
                    };
                    string JSON;
                    JSON = JsonConvert.SerializeObject(postData);

                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://new.glucoleader.a2hosted.com//api");
                    httpWebRequest.ContentType = "application/json; charset=utf-8";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(JSON);
                        streamWriter.Flush();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        //{"success_code": "100", "success_description": "Successful update!"} 
                        if (result.Contains("Successful update!"))
                        {
                            //MessageBox.Show( i.ToString() ;
                            BarUpToWeb.Value = i;
                        }
                    }
                }
                labelUpload.Refresh();
                labelUpload.Text = "Uploading";
            }
            labelUpload.Text = "Uploading End";
        }

        private void CHECK_ONLINE()//判斷連線
        {
            timeusb.Enabled = false;
            bool old_bool = alu_tp.main_1.meter_online;
            bool new_bool = alu_tp.main_1.meter_online;    
            if (alu_tp.main_1.port_usb == 2)//判斷 usb 或 rs232
            {
                int k = 0;
            recheck:
                new_bool = false;            
                System.Threading.Thread.Sleep(60);
                usb.write_usb(send_comm[0].send_str);
                System.Threading.Thread.Sleep(60);
                usb.read_usb();
                System.Threading.Thread.Sleep(60);
                write_meter(send_comm[1].send_str, 0, 1);
                System.Threading.Thread.Sleep(60);
                k++;
                Buffer_Receive_one = usb.read_usb();
                if (Buffer_Receive_one.Length < 1 && k < 15)
                {
                    System.Threading.Thread.Sleep(60);
                    write_meter(send_comm[13].send_str, 0, 1);
                    System.Threading.Thread.Sleep(60);
                    usb.read_usb();
                    goto recheck;
                }

                try
                {
                    if (Buffer_Receive_one[0] == 0x54 && Buffer_Receive_one[1] == 0xf1)                  
                    {
                        new_bool = true;
                    }
                    else
                    {                       
                        new_bool = false;
                    }
                }
                catch
                { new_bool = false; }
           
                if (new_bool != old_bool)
                {
                    if (new_bool == true)
                    {
                        alu_tp.main_1.meter_online = new_bool;
                        Readingmode = 0; //'設定為check階段
                        
                        Y = 0;
                        Z = 0;
                        //if (AddUserSaved)
                        //{
                            btnReadMeter.Enabled = true;
                            btnReadMeter.Text = alu_tp.main_1.rm_txt.GetString("StartReading");
                        //}
                    }
                    else
                    {
                        btnReadMeter.Enabled = false;
                        btnReadMeter.Text = alu_tp.main_1.rm_txt.GetString("OFFLINE");
                   }
                }
            }
            else
            {
                RS232_PORT setport = new RS232_PORT();
                string check_string;
                int SCANPORT_TIME = 0;
                if (alu_tp.main_1.serialPort1 == null)
                { check_string = setport.scan_Port(); }
                else
                {
                    if (alu_tp.main_1.serialPort1.PortName == "")
                    { check_string = setport.scan_Port(); }
                    else
                    {
                        check_string = setport.check_Port(alu_tp.main_1.serialPort1.PortName);
                        if (check_string == "" && SCANPORT_TIME < 2)
                        {
                            check_string = setport.scan_Port();
                        }
                    }
                }
                if (check_string != "")
                { new_bool = true; }
                else
                {
                    new_bool = false;
                }
                if (new_bool != old_bool)
                {
                    if (new_bool == true)
                    {                        
                        if (alu_tp.main_1.serialPort1 == null)
                        {
                            alu_tp.main_1.serialPort1 = new SerialPort(check_string);
                        }
                        if (check_string != alu_tp.main_1.serialPort1.PortName)
                        {
                            if (alu_tp.main_1.serialPort1.IsOpen == true) alu_tp.main_1.serialPort1.Close();
                            alu_tp.main_1.serialPort1.Dispose();
                            alu_tp.main_1.serialPort1 = new SerialPort(check_string);
                        }
 
                        alu_tp.main_1.meter_online = new_bool;
                        if (alu_tp.main_1.serialPort1.IsOpen == false)
                        {
                            alu_tp.main_1.serialPort1.Open();
                            alu_tp.main_1.serialPort1.DtrEnable = false;
                        }
                        alu_tp.main_1.serialPort1.DtrEnable = true;
                        Readingmode = 0; //'設定為check階段
                        
                        Y = 0;
                        Z = 0;

                        btnReadMeter.Enabled = true;
                        btnReadMeter.Text = alu_tp.main_1.rm_txt.GetString("StartReading");
                    }
                    else
                    {
                        btnReadMeter.Enabled = false;
                        btnReadMeter.Text = alu_tp.main_1.rm_txt.GetString("OFFLINE");
                    }
                }
            }
            alu_tp.main_1.meter_online = new_bool;
            timeusb.Enabled = true;
        }

        private void write_meter(byte[] cmd, int com1, int com2)
        {
            if (alu_tp.main_1.port_usb == 2)//判斷 usb 或 rs232
            {
                usb.write_usb(cmd);
            }
            else
            {
                alu_tp.main_1.serialPort1.Write(cmd, com1, com2);
            }
        }

        private void reader_delay()
        {
            timerRt.Enabled = false;
            System.Threading.Thread.Sleep(reader_delay_t1);
            timerRt.Enabled = true;
        }
        private void reader_delaylon()
        {
            timerRt.Enabled = false;
            System.Threading.Thread.Sleep(reader_delay_t2);
            timerRt.Enabled = true;
        }

        private void downloadForm4_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerOP.Enabled = false;
            timerRt.Enabled = false;
            timeusb.Enabled = false;

            if (alu_tp.main_1.serialPort1 != null)
            {
                alu_tp.main_1.serialPort1.Close();
                alu_tp.main_1.serialPort1.Dispose();
            }
        }

        private void downloadForm4_Shown(object sender, EventArgs e)
        {
            try_times = 0;
            alu_tp.main_1.port_usb = 1;//預設未偵測
            alu_tp.main_1.FrmMy = this;
            usb.FindTheHid();//尋找HID
            if (alu_tp.main_1.myDeviceDetected) alu_tp.main_1.port_usb = 2; else alu_tp.main_1.port_usb = 1;//偵測結果
            bind_comm();
            reader_delay_t1 = 45;
            reader_delay_t2 = 80;
            alu_tp.main_1.meter_online = false;
            //CHECK_ONLINE();
            timeusb.Enabled = true;
            //是否有連接到機器
            /*if (!alu_tp.main_1.meter_online)
            {
                btnReadMeter.Enabled = false;
                btnReadMeter.Text = "OFFLINE";
                MessageBox.Show("Erro de conexão do glicosímetro");
                goto ending;
            }*/
            btnReadMeter.Enabled = false;
            btnReadMeter.Text = alu_tp.main_1.rm_txt.GetString("OFFLINE");
            BarReading.Value = 0;
        ending: ;
        }

        private void timeusb_Tick(object sender, EventArgs e)
        {
           CHECK_ONLINE();
        }
        
        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_DownloadMeterReadings");
            label1.Text = alu_tp.main_1.rm_txt.GetString("Menu_DownloadMeterReadings");
            label2.Text = alu_tp.main_1.rm_txt.GetString("DownloadMeterReadingsComm");
            groupBox1.Text = alu_tp.main_1.rm_txt.GetString("Step1");
            groupBox2.Text = alu_tp.main_1.rm_txt.GetString("Step2");
            groupBox3.Text = alu_tp.main_1.rm_txt.GetString("Step3");
            label3.Text = alu_tp.main_1.rm_txt.GetString("Step1Comm");
            label4.Text = alu_tp.main_1.rm_txt.GetString("Step2Comm");
            label5.Text = alu_tp.main_1.rm_txt.GetString("Step3Comm");
            button2.Text = alu_tp.main_1.rm_txt.GetString("Menu_CurveGraphACPC");
            OtherReportButton.Text = alu_tp.main_1.rm_txt.GetString("Menu_DayList");
            labelRead.Text = alu_tp.main_1.rm_txt.GetString("ReadingMassage");
            labelUserID.Text = alu_tp.main_1.rm_txt.GetString("UserID");
            labelBirthday.Text = alu_tp.main_1.rm_txt.GetString("UserBirthday");
            labelGender.Text = alu_tp.main_1.rm_txt.GetString("UserGender");
            labelUserName.Text = alu_tp.main_1.rm_txt.GetString("UserName");
            btnPersonDataClear.Text = alu_tp.main_1.rm_txt.GetString("PersonDataClear");
            btnPersonDataSave.Text = alu_tp.main_1.rm_txt.GetString("PersonDataSave");
        }
        #endregion

        private void downloadForm4_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textUserID_0.Text = "";
            textBirthday.Text = "";
            textGender.Text = "";
            textUserName.Text = "";
            AddUserSaved = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textUserID_0.Text != "" && textBirthday.Text != "" && textGender.Text != "" && textUserName.Text != "")
            {          
              AddUserSaved = true;
            }
        }

    }
}
