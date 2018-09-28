using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace GSM2._0
{
    public partial class curveAllPCForm : Form
    {
        int GLMax;   //    '宣告最大值參數
        int GLMin;   //    '宣告最小值參數
        int GLAvg;   //    '宣告平均值參數
        int TotalR;   //  '當下讀取METER的總資料數
        long GLAdd;   //    '宣告加總參數
        int ShowRange; //, q, qq, xxx, kkk, XtoX;
        int Total_Rup;   //
        int hand;

        //int Total_R;   //  '當下讀取METER的總資料數
        int[] DataMO_R = new int[10000]; //  '當下讀取METER的MO資料
        int[] DataDA_R = new int[10000]; //  '當下讀取METER的DA資料
        int[] DataHR_R = new int[10000]; //  '當下讀取METER的HR資料
        int[] DataMI_R = new int[10000]; //  '當下讀取METER的MI資料
        int[] DataGL_R = new int[10000]; //  '當下讀取METER的GL資料
        int[] DataYR_R = new int[10000]; //  '當下讀取METER的YR資料

        int[] RangeTmp = new int[1000];
        int I, s, nnn, ggg;   //


        private void Check_Zero()
        {
            //if ("0/0" == X26.Text)
            //    X26.Text = "";
            //if ("0/0" == X25.Text)
            //    X25.Text = "";
            //if ("0/0" == X24.Text)
            //    X24.Text = "";
            //if ("0/0" == X23.Text)
            //    X23.Text = "";
            //if ("0/0" == X22.Text)
            //    X22.Text = "";
            //if ("0/0" == X21.Text)
            //    X21.Text = "";
            //if ("0/0" == X20.Text)
            //    X20.Text = "";
            //if ("0/0" == X19.Text)
            //    X19.Text = "";
            //if ("0/0" == X18.Text)
            //    X18.Text = "";
            //if ("0/0" == X17.Text)
            //    X17.Text = "";
            //if ("0/0" == X16.Text)
            //    X16.Text = "";
            //if ("0/0" == X15.Text)
            //    X15.Text = "";
            //if ("0/0" == X14.Text)
            //    X14.Text = "";
            //if ("0/0" == X13.Text)
            //    X13.Text = "";
            //if ("0/0" == X12.Text)
            //    X12.Text = "";
            //if ("0/0" == X11.Text)
            //    X11.Text = "";
            //if ("0/0" == X10.Text)
            //    X10.Text = "";
            //if ("0/0" == X9.Text)
            //    X9.Text = "";
            //if ("0/0" == X8.Text)
            //    X8.Text = "";
            //if ("0/0" == X7.Text)
            //    X7.Text = "";
            //if ("0/0" == X6.Text)
            //    X6.Text = "";
            //if ("0/0" == X5.Text)
            //    X5.Text = "";
            //if ("0/0" == X4.Text)
            //    X4.Text = "";
            //if ("0/0" == X3.Text)
            //    X3.Text = "";
            //if ("0/0" == X2.Text)
            //    X2.Text = "";
            //if ("0/0" == X1.Text)
            //    X1.Text = "";
            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Clear();
            chart1.Series["PC Value"].Points.Clear();
            chart1.Series["AC High Limit"].Points.Clear();
            chart1.Series["PC High Limit"].Points.Clear();
        }

        private void Gat_MaxMinAvg()        //'將X軸沒資料的部分顯示空白
        {   
            nnn = 0;
            ggg = 0;
            GLMax = 0;
            GLMin = 0;
            GLAvg = 0;
            GLAdd = 0;

            for (s = 1; s <=TotalR; s++)
            {
                nnn = nnn + 1;  //  'nnn設定為計數器
                ggg = DataGL_R[s];  //  '將 GL 資料抓回
                GLAdd = GLAdd + ggg;
        
                if (nnn == 1)   //    '以第1筆為基礎
                {
                    GLMax = ggg;
                    GLMin = ggg;
                }                
       
                if (ggg > GLMax)
                    GLMax = ggg;    //  '比大
                     
                if (ggg < GLMin)
                    GLMin = ggg;     //  '比小                
            }
            
    
            if (nnn == 0)
                GLAvg = 0;
            else
                GLAvg = (int) (GLAdd / nnn);    //  '取平均
                
            if (nnn == 1 && ggg == 0)
                nnn = 0;
                
            label2.Text = nnn.ToString();
    
            label10.Text = GLMax.ToString();
            label11.Text = GLMin.ToString();
            label12.Text = GLAvg.ToString();            
            //label10.Text = string.Format("{0.0000}", GLMax);
            //label11.Text = string.Format("{0.0000}",GLMin);
            //label12.Text = string.Format("{0.###0}",GLAvg);            
        }

        private void Gat_MapMap()
        {
            if (TotalR <= 150)
                hScrollBar1.Visible = false;   //     '滾動軸控制、顯現、最大值、初值

            if (TotalR <= 150)
            {
                //Select Case Total_R
                //Case 126 To 150   '****************第一張圖資料格數150筆
                if (TotalR >= 126 && TotalR <= 150)
                {   // }}}                
                    ShowRange = 150;
                    //Dim Data150(1 To 150, 1 To 4)
                    //string[,] Data = new string[150, 4];
                    ////Dim Data(1 To 150, 1 To 4)   //'勢必要單獨定義陣列
                    //for (I = 0; I < 150; I++)
                    //{
                    //    //Data[I, 2] = "";    //    'y資料
                    //    //Data[I, 1] = "o";   //   'x軸
                    //    //Data[I, 3] = alu_tp.main_1.TargetMaxOptionp.ToString();
                    //    //Data[I, 4] = alu_tp.main_1.TargetMinOptionp.ToString();
                    //}
                    
                    //For I = 1 To 150
                    //Data150(I, 2) = ""
                    //Data150(I, 1) = "o"
                    //Data150(I, 3) = TargetMaxOptionp
                    //Data150(I, 4) = TargetMinOptionp
                    //Next
            
                    //For I = 1 To Total_R
                    //Data150(I, 2) = DataGL_R(I)
                    //Next
                    Check_Zero();
                    if (alu_tp.main_1.TimeOption == 1)
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 6 + 1] + "/" + DataDA_R[jj * 6 + 1]);
                        }
                      
                        //X25.Text = DataMO_R[143] + "/" + DataDA_R[143];
                        //X26.Text = DataMO_R[149] + "/" + DataDA_R[149];
                    }
                    else if (alu_tp.main_1.TimeOption == 2) 
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 6 + 1] + "/" + DataMO_R[jj * 6 + 1]);
                        }
                   
                        //X26.Text = DataDA_R[149] + "/" + DataMO_R[149];                
                    }            
                    
                    //MSChart1.ChartData = Data150
                    for (int pointInde = 1; pointInde <= 150; pointInde++)
                    {
                        chart1.Series["PC Value"].Points.AddY(DataGL_R[pointInde]);
                        chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                        chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

                    }
                }
                else if (TotalR >= 101 && TotalR <= 125)    //第一張圖資料格數125筆
                {
                    ShowRange = 125;
                    //Dim Data125(1 To 125, 1 To 4)
                    //For I = 1 To 125
                    //Data125(I, 2) = ""
                    //Data125(I, 1) = "o"
                    //Data125(I, 3) = TargetMaxOptionp
                    //Data125(I, 4) = TargetMinOptionp
                    //Next
            
                    //For I = 1 To Total_R
                    //Data125(I, 2) = DataGL_R(I)
                    //Next
                    Check_Zero();
                    if (alu_tp.main_1.TimeOption == 1)
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 5 + 1] + "/" + DataDA_R[jj * 5 + 1]);
                        }
                     
                        //X26.Text = DataMO_R[125] + "/" + DataDA_R[125];
                    }
                    else if (alu_tp.main_1.TimeOption == 2) 
                    {

                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 5 + 1] + "/" + DataMO_R[jj * 5 + 1]);
                        }
                        //X26.Text = DataDA_R[125] + "/" + DataMO_R[125];                
                    }            
                    
                    //MSChart1.ChartData = Data150
                    for (int pointInde = 1; pointInde <= 125; pointInde++)
                    {
                        chart1.Series["PC Value"].Points.AddY(DataGL_R[pointInde]);
                        chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                        chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

                    }
                }
                else if (TotalR >= 76 && TotalR <= 100)    //第一張圖資料格數100筆
                {
                    ShowRange = 100;
                    //Dim Data125(1 To 125, 1 To 4)
                    //For I = 1 To 125
                    //Data125(I, 2) = ""
                    //Data125(I, 1) = "o"
                    //Data125(I, 3) = TargetMaxOptionp
                    //Data125(I, 4) = TargetMinOptionp
                    //Next
            
                    //For I = 1 To Total_R
                    //Data125(I, 2) = DataGL_R(I)
                    //Next
                    Check_Zero();
                    if (alu_tp.main_1.TimeOption == 1)
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 4 + 1] + "/" + DataDA_R[jj * 4 + 1]);
                        }
                     
                    //    X26.Text = DataMO_R[100] + "/" + DataDA_R[100];
                    }
                    else if (alu_tp.main_1.TimeOption == 2) 
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 4 + 1] + "/" + DataMO_R[jj * 4 + 1]);
                        }
                      
                      //  X26.Text = DataDA_R[100] + "/" + DataMO_R[100];                
                    }            
                    
                    //MSChart1.ChartData = Data150
                    for (int pointInde = 1; pointInde <= 100; pointInde++)
                    {
                        chart1.Series["PC Value"].Points.AddY(DataGL_R[pointInde]);
                        chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                        chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

                    }
                }
                else if (TotalR >= 51 && TotalR <= 75)    //第一張圖資料格數75筆
                {
                    ShowRange = 75;
                    //Dim Data125(1 To 125, 1 To 4)
                    //For I = 1 To 125
                    //Data125(I, 2) = ""
                    //Data125(I, 1) = "o"
                    //Data125(I, 3) = TargetMaxOptionp
                    //Data125(I, 4) = TargetMinOptionp
                    //Next
            
                    //For I = 1 To Total_R
                    //Data125(I, 2) = DataGL_R(I)
                    //Next
                    Check_Zero();
                    if (alu_tp.main_1.TimeOption == 1)
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 3 + 1] + "/" + DataDA_R[jj * 3 + 1]);
                        }
                      
                    //    X26.Text = DataMO_R[75] + "/" + DataDA_R[75];
                    }
                    else if (alu_tp.main_1.TimeOption == 2) 
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 3 + 1] + "/" + DataMO_R[jj * 3 + 1]);
                        }
                    
                       // X26.Text = DataDA_R[75] + "/" + DataMO_R[75];                
                    }            
                    
                    //MSChart1.ChartData = Data150
                    for (int pointInde = 1; pointInde <= 75; pointInde++)
                    {
                        chart1.Series["PC Value"].Points.AddY(DataGL_R[pointInde]);
                        chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                        chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

                    }
                }
                else if (TotalR >= 26 && TotalR <= 50)    //第一張圖資料格數50
                {
                    ShowRange = 50;
                    //Dim Data125(1 To 125, 1 To 4)
                    //For I = 1 To 125
                    //Data125(I, 2) = ""
                    //Data125(I, 1) = "o"
                    //Data125(I, 3) = TargetMaxOptionp
                    //Data125(I, 4) = TargetMinOptionp
                    //Next
            
                    //For I = 1 To Total_R
                    //Data125(I, 2) = DataGL_R(I)
                    //Next
                    Check_Zero();
                    if (alu_tp.main_1.TimeOption == 1)
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 2 + 1] + "/" + DataDA_R[jj * 2 + 1]);
                        }
                       
                       // X26.Text = DataMO_R[50] + "/" + DataDA_R[50];
                    }
                    else if (alu_tp.main_1.TimeOption == 2) 
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 2 + 1] + "/" + DataMO_R[jj * 2 + 1]);
                        }
                      
                    //    X26.Text = DataDA_R[50] + "/" + DataMO_R[50];                
                    }            
                    
                    //MSChart1.ChartData = Data150
                    for (int pointInde = 1; pointInde <= 50; pointInde++)
                    {
                        chart1.Series["PC Value"].Points.AddY(DataGL_R[pointInde]);
                        chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                        chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

                    }
                }
                else if (TotalR >= 1 && TotalR <= 25)    //第一張圖資料格數25
                {
                    ShowRange = 25;
                    //Dim Data125(1 To 125, 1 To 4)
                    //For I = 1 To 125
                    //Data125(I, 2) = ""
                    //Data125(I, 1) = "o"
                    //Data125(I, 3) = TargetMaxOptionp
                    //Data125(I, 4) = TargetMinOptionp
                    //Next
            
                    //For I = 1 To Total_R
                    //Data125(I, 2) = DataGL_R(I)
                    //Next
                    Check_Zero();
                    if (alu_tp.main_1.TimeOption == 1)
                    {
                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 1 + 1] + "/" + DataDA_R[jj * 1 + 1]);
                        }
                      
                      //  X26.Text = 0 + "/" + 0;
                    }
                    else if (alu_tp.main_1.TimeOption == 2) 
                    {

                        for (int jj = 0; jj < 26; jj++)
                        {
                            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 1 + 1] + "/" + DataMO_R[jj * 1 + 1]);
                        }
                       
                      //  X25.Text = DataDA_R[25] + "/" + DataMO_R[25];
                      //  X26.Text = 0 + "/" + 0;                
                    }            
                    
                    //MSChart1.ChartData = Data150
                    for (int pointInde = 1; pointInde <= 25; pointInde++)
                    {
                        chart1.Series["PC Value"].Points.AddY(DataGL_R[pointInde]);
                        chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                        chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

                    }
                }

            }
//'**************大於150筆時之初始資料，以最後150筆為初值，再進行滾動之機制
            else if (TotalR > 150)
            {
                ShowRange = 150;
                Total_Rup = TotalR - 150;   //     '滾動差額
                hScrollBar1.Visible = true;    //     '滾動軸控制、顯現、最大值、初值
                hScrollBar1.Maximum = Total_Rup;
                hScrollBar1.Value = Total_Rup;
                //Dim Data150up(1 To 150, 1 To 4)   '超過150筆之初圖
                //For I = 1 To 150
                //Data150up(I, 2) = ""
                //Data150up(I, 1) = "o"
                //Data150up(I, 3) = TargetMaxOptionp
                //Data150up(I, 4) = TargetMinOptionp
                //Next
                //For I = 1 To 150
                //Data150up(I, 2) = DataGL_R(I + Total_Rup)
                //Next
                Check_Zero();  
                if (alu_tp.main_1.TimeOption == 1)
                {
                    for (int jj = 0; jj < 26; jj++)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 6 + 1 + Total_Rup] + "/" + DataDA_R[jj * 6 + 1 + Total_Rup]);
                    }
                   
                //    X26.Text = DataMO_R[149 + Total_Rup] + "/" + DataDA_R[149 + Total_Rup];
                }
                else if (alu_tp.main_1.TimeOption == 2) 
                {
                    for (int jj = 0; jj < 26; jj++)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 6 + 1 + Total_Rup] + "/" + DataMO_R[jj * 6 + 1 + Total_Rup]);
                    }

                  //  X26.Text = DataDA_R[149 + Total_Rup] + "/" + DataMO_R[149 + Total_Rup];                
                }            
                
                //MSChart1.ChartData = Data150
                for (int pointInde = 1; pointInde <= 150; pointInde++)
                {
                    chart1.Series["PC Value"].Points.AddY(DataGL_R[pointInde + Total_Rup]);
                    chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                    chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

                }
            }
            }

        public curveAllPCForm()
        {
            InitializeComponent();
        }

        private void curveAllPCForm_Load(object sender, EventArgs e)
        {
            GLMax = 0;
            GLMin = 0;
            GLAvg = 0;
            GLAdd = 0;
            hand = 1;
            label4.Text = alu_tp.main_1.ReportName;

            TotalR = 0;

            //'Total_R = Total
            //'Total_R_AC = 0           
        
        
            for (int I = 1; I <= alu_tp.main_1.Total; I++)
                //for (int I = 1; I <= alu_tp.main_1.Total; I++)
            {
                if (alu_tp.main_1.DataACPC[I] == "PC" || alu_tp.main_1.DataACPC[I] == "1")
                {
                    TotalR = TotalR + 1;

                    DataMO_R[TotalR] = alu_tp.main_1.DataMO[I];
                    DataDA_R[TotalR] = alu_tp.main_1.DataDA[I];
                    DataHR_R[TotalR] = alu_tp.main_1.DataHR[I];
                    DataMI_R[TotalR] = alu_tp.main_1.DataMI[I];
                    DataGL_R[TotalR] = alu_tp.main_1.DataGL[I];
                    DataYR_R[TotalR] = alu_tp.main_1.DataYR[I];
                }
            }

            if (TotalR == 0)
                TotalR = 1;

            if (TotalR == 1 && DataDA_R[1] == 0)    //      '沒資料時只好顯示空圖
            {
                labelError.Text = "No data !";
                //'MsgBox TargetMaxOptionp
                //'MsgBox TargetMinOptionp
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;

                string[,] Data = new string[150, 4];
                //Dim Data(1 To 150, 1 To 4)   //'勢必要單獨定義陣列
                for (I = 0; I < 150; I++)
                {
                    //Data[I, 2] = "";    //    'y資料
                    //Data[I, 1] = "o";   //   'x軸
                    //Data[I, 3] = alu_tp.main_1.TargetMaxOptionp.ToString();
                    //Data[I, 4] = alu_tp.main_1.TargetMinOptionp.ToString();
                }
                Check_Zero();
                if (alu_tp.main_1.TimeOption == 1)
                {
                    for (int jj = 0; jj < 26; jj++)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 6 + 1] + "/" + DataDA_R[jj * 6 + 1]);
                    }

                 
               //     X26.Text = DataMO_R[149] + "/" + DataDA_R[149];
                }
                else if (alu_tp.main_1.TimeOption == 2)
                {
                    for (int jj = 0; jj < 26; jj++)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 6 + 1] + "/" + DataMO_R[jj * 6 + 1]);
                    }
                  
                 //   X25.Text = DataDA_R[143] + "/" + DataMO_R[143];
                  //  X26.Text = DataDA_R[149] + "/" + DataMO_R[149];
                }
                
                // Chart1.ChartData = Data;

                for (int pointInde = 1; pointInde <= 150; pointInde++)
                {
                    chart1.Series["PC Value"].Points.AddY("");
                    chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                    chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

                }

            }
            else
            {
                Gat_MaxMinAvg();    //   '有資料時 計算全部資料的最大、最小、平均值****Design by ㄚ雄

                //if (alu_tp.main_1.TimeOption == 1)
                //{
                    hand = 0;
                    //string s = "#5/20/2010#";
                    //string s = "#"+ DataMO_R[1]+"/"+DataDA_R[2]+"/"+DataYR_R[1]+"#";

                    dateTimePicker1.Value = DateTime.Parse("#" + DataMO_R[1] + "/" + DataDA_R[1] + "/" + DataYR_R[1] + "#");
                    //dateTimePicker1.Value = DateTime.Parse(s);

                    //string s1 = "#6/10/2011#";
                    //dateTimePicker2.Value = DateTime.Parse("#" + DataMO_R[TotalR] + "/" + DataDA_R[TotalR] + "/" + DataYR_R[TotalR] + "#");

                    //this.dateTimePicker1.Value.AddYears(DataYR_R[1]); // - this.dateTimePicker1.Value.Year);
                    //this.dateTimePicker1.Value.AddMonths(DataMO_R[1]); // - this.dateTimePicker1.Value.Month);
                    //this.dateTimePicker1.Value.AddDays(DataDA_R[1]); //  - this.dateTimePicker1.Value.Day);

                    //this.dateTimePicker2.Value.AddYears(DataYR_R[TotalR]); // - this.dateTimePicker1.Value.Year);
                    //this.dateTimePicker2.Value.AddMonths(DataMO_R[TotalR]); // - this.dateTimePicker1.Value.Month);
                    //this.dateTimePicker2.Value.AddDays(DataDA_R[TotalR]); // - this.dateTimePicker1.Value.Day);

                    ////dateTimePicker1.Value = Convert.ToDateTime(DataYR_R[1] + "/" + DataMO_R[1] + "/" + DataDA_R[1]);
                    //dateTimePicker1.Value = new DateTime(DataYR_R[1], DataMO_R[1], DataDA_R[1]);
                    //dateTimePicker1.Text = "#5/10/2011#"; //new DateTime(2001, 10, 20);
                    ////dateTimePicker2.Value = Convert.ToDateTime(DataYR_R[TotalR] + "/" + DataMO_R[TotalR] + "/" + DataDA_R[TotalR]);
                    //dateTimePicker2.Value = new DateTime(DataYR_R[TotalR], DataMO_R[TotalR], DataDA_R[TotalR]);
                    hand = 0;
                    dateTimePicker2.Value = DateTime.Parse("#" + DataMO_R[TotalR] + "/" + DataDA_R[TotalR] + "/" + DataYR_R[TotalR] + "#");
                    //dateTimePicker2.Text = "#6/10/2011#"; //new DateTime(2001, 11, 29);
                    //hand = hand * 1;
                //}
                //else if (alu_tp.main_1.TimeOption == 2)
                //{
                //    hand = 0;
                //    dateTimePicker1.Value = Convert.ToDateTime(DataYR_R[1] + "/" + DataMO_R[1] + "/" + DataDA_R[1]);
                //    dateTimePicker2.Value = Convert.ToDateTime(DataYR_R[TotalR] + "/" + DataMO_R[TotalR] + "/" + DataDA_R[TotalR]);
                //}

            }
                Gat_MapMap();    //'共25、50、75、100、125、150六種圖
            //}

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (hand != 0)
            {
                Change_Data();
                Gat_MaxMinAvg();
                Gat_MapMap();
            }
            hand = 1;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (hand != 0)
            {
                Change_Data();
                Gat_MaxMinAvg();
                Gat_MapMap();
            }
            hand = 1;
        }

        private void Change_Data()
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                //'MsgBox "Range of date Error!"
                labelError.Text = "Range of date Error!";
                    if (TotalR != 0)
                    {
                        //dateTimePicker1.Value = DataYR_R[1] + "/" + DataMO_R[1] + "/" + DataDA_R[1];
                        dateTimePicker1.Value = DateTime.Parse("#" + DataMO_R[1] + "/" + DataDA_R[1] + "/" + DataYR_R[1] + "#");
                        //dateTimePicker2.Value = DataYR_R(Total_R) & "/" & DataMO_R(Total_R) & "/" & DataDA_R(Total_R)
                        dateTimePicker2.Value = DateTime.Parse("#" + DataMO_R[TotalR] + "/" + DataDA_R[TotalR] + "/" + DataYR_R[TotalR] + "#");
                        //Delay(1);

                        System.Threading.Thread.Sleep(1000);
                        labelError.Text = "";
                    }                    
                goto EndCgange;
            }             
        
            TotalR = 0;
            for (int I = 1; I<= alu_tp.main_1.Total; I++)
            {
                DataMO_R[I] = 0;
                DataDA_R[I] = 0;
                DataHR_R[I] = 0;
                DataMI_R[I] = 0;
                DataGL_R[I] = 0;
                DataYR_R[I] = 0;
            }
            
            for (int I = 1; I <= alu_tp.main_1.Total; I++)
            {
                //dateTimePicker3.Value = DataYR(I) & "/" & DataMO(I) & "/" & DataDA(I);       
                dateTimePicker3.Value = DateTime.Parse("#" + alu_tp.main_1.DataMO[I] + "/" + alu_tp.main_1.DataDA[I] + "/" + alu_tp.main_1.DataYR[I] + "#");                
    
                if (dateTimePicker3.Value >= dateTimePicker1.Value && dateTimePicker3.Value <= dateTimePicker2.Value)     
                    if (alu_tp.main_1.DataACPC[I] == "PC" || alu_tp.main_1.DataACPC[I] == "1")
                    {
                        
                        TotalR = TotalR + 1;
    
                         DataMO_R[TotalR] = alu_tp.main_1.DataMO[I];
                         DataDA_R[TotalR] = alu_tp.main_1.DataDA[I];
                         DataHR_R[TotalR] = alu_tp.main_1.DataHR[I];
                         DataMI_R[TotalR] = alu_tp.main_1.DataMI[I];
                         DataGL_R[TotalR] = alu_tp.main_1.DataGL[I];
                         DataYR_R[TotalR] = alu_tp.main_1.DataYR[I];
                    }                   
            }
                 
             
            //}
         
            if (TotalR == 0)    //      '沒資料時只好顯示空圖
            {       
                        //Dim Data(1 To 150, 1 To 4)   '勢必要單獨定義陣列
                        //For I = 1 To 150
                        //Data(I, 2) = ""    'y資料
                        //Data(I, 1) = "o"   'x軸
                        //Data(I, 3) = TargetMaxOptionp
                        //Data(I, 4) = TargetMinOptionp
                        //Next
                Check_Zero();

                if (alu_tp.main_1.TimeOption == 1)
                {

                    for (int jj = 0; jj < 26; jj++)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 6 + 1] + "/" + DataDA_R[jj * 6 + 1]);
                    }
                 
                 //   X26.Text = DataMO_R[149] + "/" + DataDA_R[149];
                }
                else if (alu_tp.main_1.TimeOption == 2) 
                {
                    for (int jj = 0; jj < 26; jj++)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 6 + 1] + "/" + DataMO_R[jj * 6 + 1]);
                    }
                   
                //    X26.Text = DataDA_R[149] + "/" + DataMO_R[149];                
                }            

                
                //MSChart1.ChartData = Data
                for (int pointInde = 1; pointInde <= 150; pointInde++)
                {
                    chart1.Series["PC Value"].Points.AddY("");
                    chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                    chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

                }

            }
             EndCgange:;


        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Report_Scroll();
        }

        private void Report_Scroll()
        {
            ShowRange = 150;
            //Dim Data150sc(1 To 150, 1 To 4)  '滾動之圖形
            //For I = 1 To 150
            //Data150sc(I, 2) = ""
            //Data150sc(I, 1) = "o"
            //Data150sc(I, 3) = TargetMaxOptionp
            //Data150sc(I, 4) = TargetMinOptionp
            //Next
            //For I = 1 To 150
            //Data150sc(I, 2) = DataGL_R[I + HScroll1.Value]; //  '滾動時之初值
            //Next
            Check_Zero();
            if (alu_tp.main_1.TimeOption == 1)
            {
                for (int jj = 0; jj < 26; jj++)
                {
                    chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataMO_R[jj * 6 + 1 + hScrollBar1.Value] + "/" + DataDA_R[jj * 6 + 1 + hScrollBar1.Value]);
                }

         //   X1.Text = DataMO_R[1 + hScrollBar1.Value] + "/" + DataDA_R[1 + hScrollBar1.Value];
          
            }
            else if (alu_tp.main_1.TimeOption == 2)
            {
                for (int jj = 0; jj < 26; jj++)
                {
                    chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), DataDA_R[jj * 6 + 1 + hScrollBar1.Value] + "/" + DataMO_R[jj * 6 + 1 + hScrollBar1.Value]);
                }
          
           // X26.Text = DataDA_R[150 + hScrollBar1.Value] + "/" + DataMO_R[150 + hScrollBar1.Value];
            }
           
            //MSChart1.ChartData = Data150sc
            for (int pointInde = 1; pointInde <= 150; pointInde++)
            {
                chart1.Series["PC Value"].Points.AddY(DataGL_R[pointInde + hScrollBar1.Value]);
                chart1.Series["AC High Limit"].Points.AddY(alu_tp.main_1.TargetMaxOptionp);
                chart1.Series["PC High Limit"].Points.AddY(alu_tp.main_1.TargetMinOptionp);

            }

        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {

        }

    }

    
}
