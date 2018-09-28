using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace GSM2._0
{
    public partial class curveAllACPCFrom : Form
    {
        bool FirstShowForm = true;
        int GLMax;   //    '宣告最大值參數
        int GLMin;   //    '宣告最小值參數
        int GLAvg;   //    '宣告平均值參數

        long GLAdd;   //    '宣告加總參數
        int ShowRange; //, q, qq, xxx, kkk, XtoX;
        int Total_Rup;   //
        int hand;
        DateTime open_date;
        DateTime end_date;
        int GLMaxac;    //    '宣告AC的最大值參數
        int GLMinac;    //    '宣告AC的最小值參數
        int GLAvgac;    //    '宣告AC的平均值參數
        long GLAddac;   //    '宣告AC的加總參數
        DateTime ontime;

        //int Total_R;   //  '當下讀取METER的總資料數
        int[] DataMO_R = new int[10000]; //  '當下讀取METER的MO資料
        int[] DataDA_R = new int[10000]; //  '當下讀取METER的DA資料
        int[] DataHR_R = new int[10000]; //  '當下讀取METER的HR資料
        int[] DataMI_R = new int[10000]; //  '當下讀取METER的MI資料
        int[] DataGL_R = new int[10000]; //  '當下讀取METER的GL資料
        int[] DataYR_R = new int[10000]; //  '當下讀取METER的YR資料

        int[] DataMO_acR = new int[10000]; //  'AC當下讀取METER的MO資料
        int[] DataDA_acR = new int[10000]; //  'AC當下讀取METER的DA資料
        int[] DataHR_acR = new int[10000]; //  'AC當下讀取METER的HR資料
        int[] DataMI_acR = new int[10000]; //  'AC當下讀取METER的MI資料
        int[] DataGL_acR = new int[10000]; //  'AC當下讀取METER的GL資料
        int[] DataYR_acR = new int[10000]; //  'AC當下讀取METER的YR資料
        int show_total;
        int TotalR = 0;   //  '當下讀取METER的總資料數
        int Total_acR = 0;                      //  'AC當下讀取METER的總資料數


        int[] RangeTmp = new int[1000];
        int I, s, nnn, ggg;   //

        public curveAllACPCFrom()
        {
            InitializeComponent();
        }
        private void comMeterid_Click(object sender, EventArgs e)
        {
            FirstShowForm = false;
        }
        private void getcomMeterid()
        {
            comMeterid.Items.Clear();
            comMeterid.DataSource = MainModule.GetMeteridWithUser();
            comMeterid.DisplayMember = "miduid";
            comMeterid.ValueMember = "mid";
            comMeterid.SelectedValue = alu_tp.main_1.MeterIDNo;
        }
        private void comMeterid_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FirstShowForm == false)
              alu_tp.main_1.MeterIDNo = comMeterid.SelectedValue.ToString();

            if (alu_tp.main_1.MeterIDNo.ToLower() != "system.data.datarowview")
            {
                MainModule.SettingInitUserData();
                loadData();
            }
        }
        #region loadData()
        private void loadData()
        {
            MainModule.readOldData();
            if (alu_tp.main_1.Total != 0)
            {
                dateTimePicker1.Value = DateTime.Parse("#" + alu_tp.main_1.MDataMO[1] + "/" + alu_tp.main_1.MDataDA[1] + "/" + alu_tp.main_1.MDataYR[1] + "#");
                dateTimePicker2.Value = DateTime.Parse("#" + alu_tp.main_1.MDataMO[alu_tp.main_1.Total] + "/" + alu_tp.main_1.MDataDA[alu_tp.main_1.Total] + "/" + alu_tp.main_1.MDataYR[alu_tp.main_1.Total] + "#");
            }   
            print_chart();
        }
        #endregion
        
        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_CurveGraphACPC");
            label8.Text = alu_tp.main_1.rm_txt.GetString("lblAllAC");
            label1.Text = alu_tp.main_1.rm_txt.GetString("lblAllPC");
            label26.Text = alu_tp.main_1.rm_txt.GetString("lblAChighestValue");
            label25.Text = alu_tp.main_1.rm_txt.GetString("lblACLowestValue");
            label24.Text = alu_tp.main_1.rm_txt.GetString("lblACAverageValue");
            label17.Text = alu_tp.main_1.rm_txt.GetString("lblPChighestValue");
            label16.Text = alu_tp.main_1.rm_txt.GetString("lblPCLowestValue");
            label9.Text = alu_tp.main_1.rm_txt.GetString("lblPCAverageValue");
            label3.Text = alu_tp.main_1.rm_txt.GetString("UserID");
            label5.Text = alu_tp.main_1.rm_txt.GetString("lblReportDate");
            label30.Text = alu_tp.main_1.rm_txt.GetString("lblVISIBLE");
            checkBox1.Text = alu_tp.main_1.rm_txt.GetString("chekboxAllAC");
            checkBox2.Text = alu_tp.main_1.rm_txt.GetString("chekboxAllPC");
            checkBox3.Text = alu_tp.main_1.rm_txt.GetString("checkboxBAC");
            checkBox4.Text = alu_tp.main_1.rm_txt.GetString("checkboxBPC");
            checkBox5.Text = alu_tp.main_1.rm_txt.GetString("checkboxLAC");
            checkBox6.Text = alu_tp.main_1.rm_txt.GetString("checkboxLPC");
            checkBox7.Text = alu_tp.main_1.rm_txt.GetString("checkboxDAC");
            checkBox8.Text = alu_tp.main_1.rm_txt.GetString("checkboxDPC");
        }
        #endregion

        private void curveAllACPCFrom_Load(object sender, EventArgs e)
        {
            InitControls();
            getcomMeterid();
            //comMeterid_SelectedValueChanged(null, null);
        }

        private void print_chart()
        {

            Check_Zero();
            GLMax = 0;
            GLMin = 0;
            GLAvg = 0;
            GLAdd = 0;

            GLMaxac = 0;
            GLMinac = 0;
            GLAvgac = 0;
            GLAddac = 0;

            hand = 1;

            TotalR = 0;
            for (int I = 1; I <= alu_tp.main_1.Total; I++)
            {
                DataMO_R[I] = 0;
                DataDA_R[I] = 0;
                DataHR_R[I] = 0;
                DataMI_R[I] = 0;
                DataGL_R[I] = 0;
                DataYR_R[I] = 0;
            }

            Total_acR = 0;
            for (int I = 1; I <= alu_tp.main_1.Total; I++)
            {
                DataMO_acR[I] = 0;
                DataDA_acR[I] = 0;
                DataHR_acR[I] = 0;
                DataMI_acR[I] = 0;
                DataGL_acR[I] = 0;
                DataYR_acR[I] = 0;
            }

            for (int I = 1; I <= alu_tp.main_1.Total; I++)
            {
                DateTime dada1 = DateTime.Parse("#" + alu_tp.main_1.MDataMO[I] + "/" + alu_tp.main_1.MDataDA[I] + "/" + alu_tp.main_1.MDataYR[I] + "#");

                if (dada1 >= dateTimePicker1.Value && dada1 <= dateTimePicker2.Value)
                {
                    if (alu_tp.main_1.MDataACPC[I] == "PC" || alu_tp.main_1.MDataACPC[I] == "1")
                    {
                        TotalR++;

                        DataMO_R[TotalR] = alu_tp.main_1.MDataMO[I];
                        DataDA_R[TotalR] = alu_tp.main_1.MDataDA[I];
                        DataHR_R[TotalR] = alu_tp.main_1.MDataHR[I];
                        DataMI_R[TotalR] = alu_tp.main_1.MDataMI[I];
                        DataGL_R[TotalR] = alu_tp.main_1.MDataGL[I];
                        DataYR_R[TotalR] = alu_tp.main_1.MDataYR[I];
                        if (open_date > DateTime.Parse("#" + DataMO_R[TotalR] + "/" + DataDA_R[TotalR] + "/" + DataYR_R[TotalR] + "#")) open_date = DateTime.Parse("#" + DataMO_R[TotalR] + "/" + DataDA_R[TotalR] + "/" + DataYR_R[TotalR] + "#");
                        if (DateTime.Parse("#" + DataMO_R[TotalR] + "/" + DataDA_R[TotalR] + "/" + DataYR_R[TotalR] + "#") > end_date) end_date = DateTime.Parse("#" + DataMO_R[TotalR] + "/" + DataDA_R[TotalR] + "/" + DataYR_R[TotalR] + "#");
                    }
                    else
                    {
                        Total_acR++;

                        DataMO_acR[Total_acR] = alu_tp.main_1.MDataMO[I];
                        DataDA_acR[Total_acR] = alu_tp.main_1.MDataDA[I];
                        DataHR_acR[Total_acR] = alu_tp.main_1.MDataHR[I];
                        DataMI_acR[Total_acR] = alu_tp.main_1.MDataMI[I];
                        DataGL_acR[Total_acR] = alu_tp.main_1.MDataGL[I];
                        DataYR_acR[Total_acR] = alu_tp.main_1.MDataYR[I];
                        if (open_date > DateTime.Parse("#" + DataMO_acR[Total_acR] + "/" + DataDA_acR[Total_acR] + "/" + DataYR_acR[Total_acR] + "#")) open_date = DateTime.Parse("#" + DataMO_acR[Total_acR] + "/" + DataDA_acR[Total_acR] + "/" + DataYR_acR[Total_acR] + "#");
                        if (DateTime.Parse("#" + DataMO_acR[Total_acR] + "/" + DataDA_acR[Total_acR] + "/" + DataYR_acR[Total_acR] + "#") > end_date) end_date = DateTime.Parse("#" + DataMO_acR[Total_acR] + "/" + DataDA_acR[Total_acR] + "/" + DataYR_acR[Total_acR] + "#");
                    }
                }
            }
           
            chart1.Width = alu_tp.main_1.Total * 20;
            int num = alu_tp.main_1.Total+50;
            int reversedNum = -num;
            chart1.Location = new Point(reversedNum, 4);
            if (chart1.Width < 800)
            {
                chart1.Width = 800;
                chart1.Location = new Point(3, 4);
            }
            if (alu_tp.main_1.Total == 0 && DataDA_R[1] == 0 && DataDA_acR[1] == 0)    //      '沒資料時只好顯示空圖
            {
                labelError.Text = alu_tp.main_1.rm_txt.GetString("NoData");
               
                Check_Zero();
            }
            else
            {
                Gat_MaxMinAvg();    //   '有資料時 計算全部資料的最大、最小、平均值****Design by ㄚ雄
                Gat_MaxMinAvgac();
            }
            ontime = dateTimePicker1.Value;

            Gat_MapMap();    //'共25、50、75、100、125、150六種圖
        }

        private void Gat_MapMap()
        {

            int pcc = 0;
            int acc = 0;
            int pcco = 0;
            int acco = 0;
            int axx = 1;
            int timeadd = 0;
            bool acend = false;
            bool pcend = false;
            bool timeoff = false;
            DateTime chartime = ontime;            

            for (int pointInde = 1; pointInde <= alu_tp.main_1.Total; pointInde++)
            {
                acc++;
                pcc++;

                //   endtime
                if (timeoff == false)
                {
                    //if (DataMO_acR[axx * 1 + 1] != 0)
                    if (DataMO_acR[acco * 1 + 1] != 0 && timeadd == 0)
                        chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (axx), DataMO_acR[acco * 1 + 1] + "/" + DataDA_acR[acco * 1 + 1]);
                    else
                        chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (axx), DataMO_R[pcco * 1 + 1] + "/" + DataDA_R[pcco * 1 + 1]);

                    timeoff = true;
                }
                if (DataMO_acR[acco + 1] != 0)
                {
                    if (chartime.ToString("MM/dd/yyyy") == DateTime.Parse("#" + DataMO_acR[acco * 1 + 1] + "/" + DataDA_acR[acco * 1 + 1] + "/" + DataYR_acR[acco * 1 + 1] + "#").ToString("MM/dd/yyyy"))
                    {
                        if (checkBox3.Checked == true)
                        {
                            if (DataHR_acR[acco + 1] >= 0 && DataHR_acR[acco + 1] <= 11 && DataMO_acR[acco + 1] != 0 && acend == false) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartBAC")].Points.AddXY(axx, DataGL_acR[acco + 1]);

                        }
                        if (checkBox5.Checked == true)
                        {
                            if (DataHR_acR[acco + 1] >= 11 && DataHR_acR[acco + 1] <= 17 && DataMO_acR[acco + 1] != 0 && acend == false) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartLAC")].Points.AddXY(axx, DataGL_acR[acco + 1]);

                        }
                        if (checkBox7.Checked == true)
                        {
                            if (DataHR_acR[acco + 1] >= 17 && DataHR_acR[acco + 1] <= 24 && DataMO_acR[acco + 1] != 0 && acend == false) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartDAC")].Points.AddXY(axx, DataGL_acR[acco + 1]);

                        }
                        if (checkBox1.Checked == true)
                        {

                            if (acco <= Convert.ToInt16(label7.Text) && acend == false) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartAllAC")].Points.AddXY(axx, DataGL_acR[acco + 1]);
                            if (acco + 1 == Convert.ToInt16(label7.Text)) acend = true;

                            //                chart1.Series["AC High Limit"].Points.AddY(TargetMaxOptionp);
                        }

                        if (Convert.ToInt16(label7.Text) > acco) acco++;
                    }
                }
                if (DataMO_R[pcco + 1] != 0)
                {
                    if (chartime.ToString("MM/dd/yyyy") == DateTime.Parse("#" + DataMO_R[pcco * 1 + 1] + "/" + DataDA_R[pcco * 1 + 1] + "/" + DataYR_R[pcco * 1 + 1] + "#").ToString("MM/dd/yyyy"))
                    {
                        if (checkBox4.Checked == true)
                        {
                            if (DataHR_R[pcco + 1] >= 2 && DataHR_R[pcco + 1] <= 12 && DataMO_R[pcco + 1] != 0 && pcend == false) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartBPC")].Points.AddXY(axx, DataGL_R[pcco + 1]);

                        }

                        if (checkBox6.Checked == true)
                        {
                            if (DataHR_R[pcco + 1] >= 12 && DataHR_R[pcco + 1] <= 18 && DataMO_R[pcco + 1] != 0 && pcend == false) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartLPC")].Points.AddXY(axx, DataGL_R[pcco + 1]);

                        }

                        if (checkBox8.Checked == true)
                        {
                            if ((DataHR_R[pcco + 1] >= 18 || DataHR_R[pcco + 1] <= 2) && DataMO_R[pcco + 1] != 0 && pcend == false) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartDPC")].Points.AddXY(axx, DataGL_R[pcco + 1]);

                        }
                        if (checkBox2.Checked == true)
                        {
                            if (pcco <= Convert.ToInt16(label2.Text) && pcend == false) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartAllPC")].Points.AddXY(axx, DataGL_R[pcco + 1]);
                            if (pcco + 1 == Convert.ToInt16(label2.Text)) pcend = true;
                            //              chart1.Series["PC High Limit"].Points.AddY(TargetMinOptionp);
                        }
                        if (Convert.ToInt16(label2.Text) > pcco) pcco++;
                    }
                }
                if (Convert.ToInt16(label7.Text) > acco && Convert.ToInt16(label2.Text) > pcco)
                {
                    if (DataMO_acR[acco + 1] != 0 && DataMO_R[pcco + 1] != 0)
                    {
                        if (chartime < DateTime.Parse("#" + DataMO_acR[acco * 1 + 1] + "/" + DataDA_acR[acco * 1 + 1] + "/" + DataYR_acR[acco * 1 + 1] + "#") && chartime < DateTime.Parse("#" + DataMO_R[pcco * 1 + 1] + "/" + DataDA_R[pcco * 1 + 1] + "/" + DataYR_R[pcco * 1 + 1] + "#"))
                        {
                            timeoff = false;
                            if (DateTime.Parse("#" + DataMO_acR[acco * 1 + 1] + "/" + DataDA_acR[acco * 1 + 1] + "/" + DataYR_acR[acco * 1 + 1] + "#") > DateTime.Parse("#" + DataMO_R[pcco * 1 + 1] + "/" + DataDA_R[pcco * 1 + 1] + "/" + DataYR_R[pcco * 1 + 1] + "#"))
                            {
                                chartime = DateTime.Parse("#" + DataMO_R[pcco * 1 + 1] + "/" + DataDA_R[pcco * 1 + 1] + "/" + DataYR_R[pcco * 1 + 1] + "#");
                                timeadd = 1;
                            }
                            else
                            {
                                chartime = DateTime.Parse("#" + DataMO_acR[acco * 1 + 1] + "/" + DataDA_acR[acco * 1 + 1] + "/" + DataYR_acR[acco * 1 + 1] + "#");
                                timeadd = 0;
                            }

                            //     chartime = chartime.AddDays(1);


                        }
                    }
                }
                else if (Convert.ToInt16(label2.Text) > pcco)
                {
                    if (DataMO_R[pcco + 1] != 0)
                    {
                        if (chartime < DateTime.Parse("#" + DataMO_R[pcco * 1 + 1] + "/" + DataDA_R[pcco * 1 + 1] + "/" + DataYR_R[pcco * 1 + 1] + "#"))
                        {
                            timeoff = false;
                            chartime = DateTime.Parse("#" + DataMO_R[pcco * 1 + 1] + "/" + DataDA_R[pcco * 1 + 1] + "/" + DataYR_R[pcco * 1 + 1] + "#");
                            timeadd = 1;
                            // chartime = chartime.AddDays(1);

                        }

                    }

                }
                else if (Convert.ToInt16(label7.Text) > acco)
                {
                    if (DataMO_acR[acco + 1] != 0)
                    {
                        if (chartime < DateTime.Parse("#" + DataMO_acR[acco * 1 + 1] + "/" + DataDA_acR[acco * 1 + 1] + "/" + DataYR_acR[acco * 1 + 1] + "#"))
                        {
                            timeoff = false;
                            //  chartime = chartime.AddDays(1);
                            chartime = DateTime.Parse("#" + DataMO_acR[acco * 1 + 1] + "/" + DataDA_acR[acco * 1 + 1] + "/" + DataYR_acR[acco * 1 + 1] + "#");
                            timeadd = 0;

                        }
                    }
                }
                axx = axx + 1;
            }


            if (checkBox1.Checked == true)
            {
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartAllAC")].IsValueShownAsLabel = true;
                // chart1.Series["TODOS AC"]["LabelStyle"] = "Top";
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartBAC")].IsValueShownAsLabel = false;
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartLAC")].IsValueShownAsLabel = false;
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartDAC")].IsValueShownAsLabel = false;
            }
            else
            {
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartAllAC")].IsValueShownAsLabel = false;
                if (checkBox3.Checked == true) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartBAC")].IsValueShownAsLabel = true;
                if (checkBox5.Checked == true) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartLAC")].IsValueShownAsLabel = true;
                if (checkBox7.Checked == true) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartDAC")].IsValueShownAsLabel = true;

            }
            if (checkBox2.Checked == true)
            {
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartAllPC")].IsValueShownAsLabel = true;
                // chart1.Series["TODOS PC"]["LabelStyle"] = "Top";
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartBPC")].IsValueShownAsLabel = false;
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartLPC")].IsValueShownAsLabel = false;
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartDPC")].IsValueShownAsLabel = false;
            }
            else
            {
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartAllPC")].IsValueShownAsLabel = false;
                if (checkBox4.Checked == true) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartBPC")].IsValueShownAsLabel = true;
                if (checkBox6.Checked == true) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartLPC")].IsValueShownAsLabel = true;
                if (checkBox8.Checked == true) chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartDPC")].IsValueShownAsLabel = true;
            }

            StripLine s01;

            if (alu_tp.main_1.TargetMaxOptionp.ToString().Length > 0 || alu_tp.main_1.TargetMinOptionp.ToString().Length > 0)
            {
                s01 = new StripLine();
                s01.BackColor = Color.FromArgb(248, 199, 213);
                s01.IntervalOffset = 0;

                s01.StripWidth = 700;

                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 900;// 2015.01.29 denny for showing glucose under 900
                chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(s01);


                s01 = new StripLine();

                s01.BackColor = Color.FromArgb(245, 250, 189);
                s01.IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOptionp);

                s01.StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOptionp) - s01.IntervalOffset;
                chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(s01);
            }

            if (alu_tp.main_1.TargetMaxOption.ToString().Length > 0 || alu_tp.main_1.TargetMinOption.ToString().Length > 0)
            {
                s01 = new StripLine();

                s01.BackColor = Color.FromArgb(190, 251, 210);
                s01.IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOption);

                s01.StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOption) - s01.IntervalOffset;
                chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(s01);
            }
        }

        private void Check_Zero()
        {
            #region InitSeries
            chart1.Series.Clear();
            Series Series1 = new Series();
            Series Series2 = new Series();
            Series Series3 = new Series();
            Series Series4 = new Series();
            Series Series5 = new Series();
            Series Series6 = new Series();
            Series Series7 = new Series();
            Series Series8 = new Series();
            Series1.Name = alu_tp.main_1.rm_txt.GetString("ChartAllAC");
            Series2.Name = alu_tp.main_1.rm_txt.GetString("ChartAllPC");
            Series3.Name = alu_tp.main_1.rm_txt.GetString("ChartBAC");
            Series4.Name = alu_tp.main_1.rm_txt.GetString("ChartBPC");
            Series5.Name = alu_tp.main_1.rm_txt.GetString("ChartLAC");
            Series6.Name = alu_tp.main_1.rm_txt.GetString("ChartLPC");
            Series7.Name = alu_tp.main_1.rm_txt.GetString("ChartDAC");
            Series8.Name = alu_tp.main_1.rm_txt.GetString("ChartDPC");

            Series1.ChartType = SeriesChartType.Line;
            Series2.ChartType = Series1.ChartType;
            Series3.ChartType = Series1.ChartType;
            Series4.ChartType = Series1.ChartType;
            Series5.ChartType = Series1.ChartType;
            Series6.ChartType = Series1.ChartType;
            Series7.ChartType = Series1.ChartType;
            Series8.ChartType = Series1.ChartType;

            Series1.BorderDashStyle = ChartDashStyle.Solid;
            Series2.BorderDashStyle = Series1.BorderDashStyle;
            Series3.BorderDashStyle = Series1.BorderDashStyle;
            Series4.BorderDashStyle = Series1.BorderDashStyle;
            Series5.BorderDashStyle = Series1.BorderDashStyle;
            Series6.BorderDashStyle = Series1.BorderDashStyle;
            Series7.BorderDashStyle = Series1.BorderDashStyle;
            Series8.BorderDashStyle = Series1.BorderDashStyle;

            Series1.BorderWidth = 2;
            Series2.BorderWidth = Series1.BorderWidth;
            Series3.BorderWidth = Series1.BorderWidth;
            Series4.BorderWidth = Series1.BorderWidth;
            Series5.BorderWidth = Series1.BorderWidth;
            Series6.BorderWidth = Series1.BorderWidth;
            Series7.BorderWidth = Series1.BorderWidth;
            Series8.BorderWidth = Series1.BorderWidth;

            Series1.Color = Color.FromArgb(0, 0, 192);
            Series2.Color = Color.FromArgb(255, 192, 128);
            Series3.Color = Color.Cyan;
            Series4.Color = Color.FromArgb(192, 0, 0);
            Series5.Color = Color.Lime;
            Series6.Color = Color.Violet;
            Series7.Color = Color.FromArgb(64, 64, 64);
            Series8.Color = Color.Silver;

            chart1.Series.Add(Series1);
            chart1.Series.Add(Series2);
            chart1.Series.Add(Series3);
            chart1.Series.Add(Series4);
            chart1.Series.Add(Series5);
            chart1.Series.Add(Series6);
            chart1.Series.Add(Series7);
            chart1.Series.Add(Series8);
            #endregion

            chart1.ChartAreas["ChartArea1"].Axes[0].Title = alu_tp.main_1.rm_txt.GetString("ChartXaxis");
            chart1.ChartAreas["ChartArea1"].Axes[1].Title = alu_tp.main_1.rm_txt.GetString("ChartYaxis");
            chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Clear();
            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartAllAC")].Points.Clear();
            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartAllPC")].Points.Clear();
            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartBAC")].Points.Clear();
            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartBPC")].Points.Clear();
            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartDAC")].Points.Clear();
            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartDPC")].Points.Clear();
            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartLAC")].Points.Clear();
            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartLPC")].Points.Clear();
        }

        private void Gat_MaxMinAvg()        //'將X軸沒資料的部分顯示空白
        {
            nnn = 0;
            ggg = 0;
            GLMax = 0;
            GLMin = 0;
            GLAvg = 0;
            GLAdd = 0;

            for (s = 1; s <= TotalR; s++)
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
                GLAvg = (int)(GLAdd / nnn);    //  '取平均

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

        private void Gat_MaxMinAvgac()
        {
            nnn = 0;
            ggg = 0;

            GLMaxac = 0;
            GLMinac = 0;
            GLAvgac = 0;
            GLAddac = 0;

            for (s = 1; s <= Total_acR; s++)
            {
                nnn++;      //  'nnn設定為計數器
                ggg = DataGL_acR[s];    //  '將 GL 資料抓回
                GLAddac = GLAddac + ggg;

                if (nnn == 1)   //    '以第1筆為基礎
                {
                    GLMaxac = ggg;
                    GLMinac = ggg;
                }

                if (ggg > GLMaxac)
                    GLMaxac = ggg;      //  '比大                

                if (ggg < GLMinac)
                    GLMinac = ggg;  //  '比小                
            }
            //Next

            if (nnn == 0)
                GLAvgac = 0;
            else
                GLAvgac = (int)(GLAddac / nnn);    //  '取平均

            if (nnn == 1 && ggg == 0)
                nnn = 0;

            label7.Text = nnn.ToString();

            label23.Text = GLMaxac.ToString();
            label22.Text = GLMinac.ToString();
            label21.Text = GLAvgac.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (hand != 0)
            {
                //dateTimePicker1.Value = dateTimePicker1.Value;
                //dateTimePicker2.Value = dateTimePicker2.Value;
                print_chart();
            }
            hand = 1;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (hand != 0)
            {
                //dateTimePicker1.Value = dateTimePicker1.Value;
                //dateTimePicker2.Value = dateTimePicker2.Value;
                print_chart();
            }
            hand = 1;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            print_chart();

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            print_chart();

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            print_chart();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            print_chart();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            print_chart();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            print_chart();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

            print_chart();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

            print_chart();
        }
    }
}
