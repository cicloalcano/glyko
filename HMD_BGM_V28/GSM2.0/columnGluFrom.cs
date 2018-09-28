using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace GSM2._0
{
    public partial class columnGluFrom : Form
    {
        bool FirstShowForm = true;
        int BlankCell;      //    '宣告一整數作 記錄空白方格位置
        int tmp;      //          '宣告一整數
        int GLMax;      //    '宣告一整數作 記錄空白方格位置
        int GLMin;      //   '宣告一整數作 記錄空白方格位置
        int GLAvg;      //    '宣告一整數作 記錄空白方格位置
        long GLAdd;      //    '宣告一整數作 記錄空白方格位置

        int tmpac;      //          '宣告一整數
        int GLMaxac;      //    '宣告一整數作 記錄空白方格位置
        int GLMinac;      //    '宣告一整數作 記錄空白方格位置
        int GLAvgac;      //    '宣告一整數作 記錄空白方格位置
        long GLAddac;      //    '宣告一整數作 記錄空白方格位置

        int tmppc;      //          '宣告一整數
        int GLMaxpc;      //    '宣告一整數作 記錄空白方格位置
        int GLMinpc;      //    '宣告一整數作 記錄空白方格位置
        int GLAvgpc;      //    '宣告一整數作 記錄空白方格位置
        long GLAddpc;      //    '宣告一整數作 記錄空白方格位置
        int P0, P1, P2, P3, P4, P5, P6, P7;
        int Pn0, Pn1, Pn2, Pn3, Pn4, Pn5, Pn6, Pn7;
        int A0, A1, A2, A3, A4, A5, A6, A7;
        int An0, An1, An2, An3, An4, An5, An6, An7;

        int Total_R;      //  '當下讀取METER的總資料數
        int[] DataMO_R = new int[10000]; //  '當下讀取METER的MO資料
        int[] DataDA_R = new int[10000]; //  '當下讀取METER的DA資料
        int[] DataHR_R = new int[10000]; //  '當下讀取METER的HR資料
        int[] DataMI_R = new int[10000]; //  '當下讀取METER的MI資料
        int[] DataGL_R = new int[10000]; //  '當下讀取METER的GL資料
        int[] DataYR_R = new int[10000]; //  '當下讀取METER的YR資料

        int Total_acR;      //  'AC當下讀取METER的總資料數
        int[] DataMO_acR = new int[10000]; //  '當下讀取METER的MO資料
        int[] DataDA_acR = new int[10000]; //  '當下讀取METER的DA資料
        int[] DataHR_acR = new int[10000]; //  '當下讀取METER的HR資料
        int[] DataMI_acR = new int[10000]; //  '當下讀取METER的MI資料
        int[] DataGL_acR = new int[10000]; //  '當下讀取METER的GL資料
        int[] DataYR_acR = new int[10000]; //  '當下讀取METER的YR資料

        int Total_pcR;      //  'PC當下讀取METER的總資料數
        int[] DataMO_pcR = new int[10000]; //  '當下讀取METER的MO資料
        int[] DataDA_pcR = new int[10000]; //  '當下讀取METER的DA資料
        int[] DataHR_pcR = new int[10000]; //  '當下讀取METER的HR資料
        int[] DataMI_pcR = new int[10000]; //  '當下讀取METER的MI資料
        int[] DataGL_pcR = new int[10000]; //  '當下讀取METER的GL資料
        int[] DataYR_pcR = new int[10000]; //  '當下讀取METER的YR資料

        int I, s, nnn, ggg, nnnac, gggac;

        public columnGluFrom()
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
            //if(alu_tp.main_1.MeterIDNo != "")
               //comMeterid.SelectedIndex = comMeterid.FindStringExact(alu_tp.main_1.MeterIDNo);            
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
        #region loadData
        private void loadData()
        {
            MainModule.readOldData();
            if (alu_tp.main_1.Total == 1 && alu_tp.main_1.DataDA[1] == 0)
                MessageBox.Show("nenhum dado !! faça o download!!", "gerente metros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else            
            {  
            GLMax = 0;  //                 '歸零
            GLMin = 0;
            GLAvg = 0;
            GLAdd = 0;

            GLMaxac = 0;    //               '歸零
            GLMinac = 0;
            GLAvgac = 0;
            GLAddac = 0;

            GLMaxpc = 0;    //               '歸零
            GLMinpc = 0;
            GLAvgpc = 0;
            GLAddpc = 0;

            nnn = 0;
            nnnac = 0;

            Total_pcR = 0;
            Total_acR = 0;

            //For I = 1 To 7             '設定啟始統計次數陣列各列為0
            //    Data(I, 2) = 0
            //    Data(I, 3) = 0
            //Next

            GLAdd = 0;
            GLAddac = 0;
            GLAddpc = 0;


            //'判斷此血糖值為ac or pc----------------------------------------------
            for (I = 1; I <= alu_tp.main_1.Total; I++)
            {
                if (alu_tp.main_1.DataACPC[I] == "PC" || alu_tp.main_1.DataACPC[I] == "1")
                {
                    Total_pcR++;

                    DataMO_pcR[Total_pcR] = alu_tp.main_1.DataMO[I];
                    DataDA_pcR[Total_pcR] = alu_tp.main_1.DataDA[I];
                    DataHR_pcR[Total_pcR] = alu_tp.main_1.DataHR[I];
                    DataMI_pcR[Total_pcR] = alu_tp.main_1.DataMI[I];
                    DataGL_pcR[Total_pcR] = alu_tp.main_1.DataGL[I];
                    DataYR_pcR[Total_pcR] = alu_tp.main_1.DataYR[I];
                }
                else
                {
                    Total_acR++;

                    DataMO_acR[Total_acR] = alu_tp.main_1.DataMO[I];
                    DataDA_acR[Total_acR] = alu_tp.main_1.DataDA[I];
                    DataHR_acR[Total_acR] = alu_tp.main_1.DataHR[I];
                    DataMI_acR[Total_acR] = alu_tp.main_1.DataMI[I];
                    DataGL_acR[Total_acR] = alu_tp.main_1.DataGL[I];
                    DataYR_acR[Total_acR] = alu_tp.main_1.DataYR[I];
                }
            }

            #region 算pc
            //'--------------------------------------------------------------------     
            P0 = 0;
            P1 = 0;
            P2 = 0;
            P3 = 0;
            P4 = 0;
            P5 = 0;
            P6 = 0;
            for (I = 1; I <= Total_pcR; I++)    //                '隨著PC總筆數的增加
            {
                tmppc = DataGL_pcR[I];      //               '將每一筆血糖值
                //switch (tmppc)
                //Select Case tmppc
                if (tmppc < 70)
                    P0 = P0 + 1;    //     '統計該值區段的人數
                else if (tmppc >= 70 && tmppc < 100)
                    P1 = P1 + 1;    //     '統計該值區段的人數
                else if (tmppc >= 100 && tmppc < 140)
                    P2 = P2 + 1;    //     '統計該值區段的人數
                else if (tmppc >= 140 && tmppc < 180)
                    P3 = P3 + 1;    //     '統計該值區段的人數
                else if (tmppc >= 180 && tmppc < 220)
                    P4 = P4 + 1;    //     '統計該值區段的人數
                else if (tmppc >= 220 & tmppc < 280)
                    P5 = P5 + 1;    //     '統計該值區段的人數
                else
                    P6 = P6 + 1;    //     '統計該值區段的人數


                nnn++;
                int rrr = DataHR_pcR[I];    //         '將HR GL 資料抓回
                int minmin = DataMI_pcR[I];
                ggg = DataGL_pcR[I];
                GLAddpc = GLAddpc + ggg;

                if (nnn == 1)
                {
                    GLMaxpc = ggg;
                    GLMinpc = ggg;
                }

                if (ggg > GLMaxpc)
                    GLMaxpc = ggg;

                if (ggg < GLMinpc)
                    GLMinpc = ggg;
            }
            #endregion

            #region 算AC
            // '--------------------------------------------------------------------------------------------------
            A0 = 0;
            A1 = 0;
            A2 = 0;
            A3 = 0;
            A4 = 0;
            A5 = 0;
            A6 = 0;
            for (I = 1; I <= Total_acR; I++)    //                 '隨著AC總筆數的增加
            {
                tmpac = DataGL_acR[I];  //                '將每一筆血糖值
                //Select Case tmpac
                if (tmpac < 70)
                    A0 = A0 + 1;    //     '統計該值區段的人數
                else if (tmpac >= 70 && tmpac < 100)
                    A1 = A1 + 1;    //     '統計該值區段的人數
                else if (tmpac >= 100 && tmpac < 140)
                    A2 = A2 + 1;    //     '統計該值區段的人數
                else if (tmpac >= 140 && tmpac < 180)
                    A3 = A3 + 1;    //     '統計該值區段的人數
                else if (tmpac >= 180 && tmpac < 220)
                    A4 = A4 + 1;    //     '統計該值區段的人數
                else if (tmpac >= 220 && tmpac < 280)
                    A5 = A5 + 1;    //     '統計該值區段的人數
                else
                    A6 = A6 + 1;    //     '統計該值區段的人數            

                nnnac = nnnac + 1;
                int rrr = DataHR_acR[I];     //         '將HR GL 資料抓回
                int minmin = DataMI_acR[I];
                gggac = DataGL_acR[I];
                GLAddac = GLAddac + gggac;

                if (nnnac == 1)
                {
                    GLMaxac = gggac;
                    GLMinac = gggac;
                }

                if (gggac > GLMaxac)
                    GLMaxac = gggac;

                if (gggac < GLMinac)
                    GLMinac = gggac;
            }
            #endregion
            //'--------------------------------------------------------------------------------------------------
            if (P0 != 0)
                Pn0 = (P0 * 100) / nnn;     //      '計算PC-血糖值 小於70  該區段的百分比                    
            else
                Pn0 = 0;

            if (P1 != 0)
                Pn1 = (P1 * 100) / nnn; //      '計算PC-血糖值 70-100  該區段的百分比
            else
                Pn1 = 0;

            if (P2 != 0)
                Pn2 = (P2 * 100) / nnn;     //      '計算PC-血糖值 100-140 該區段的百分比
            else
                Pn2 = 0;

            if (P3 != 0)
                Pn3 = (P3 * 100) / nnn;     //      '計算PC-血糖值 100-140 該區段的百分比
            else
                Pn3 = 0;

            if (P4 != 0)
                Pn4 = (P4 * 100) / nnn;     //      '計算PC-血糖值 100-140 該區段的百分比
            else
                Pn4 = 0;

            if (P5 != 0)
                Pn5 = (P5 * 100) / nnn;     //      '計算PC-血糖值 100-140 該區段的百分比
            else
                Pn5 = 0;

            if (P6 != 0)
                Pn6 = (P6 * 100) / nnn;     //      '計算PC-血糖值 100-140 該區段的百分比
            else
                Pn6 = 0;          

            if (A0 != 0)
                An0 = (A0 * 100) / nnnac;     //      '計算PC-血糖值 小於70  該區段的百分比
            else
                An0 = 0;

            if (A1 != 0)
                An1 = (A1 * 100) / nnnac;     //      '計算PC-血糖值 小於70  該區段的百分比
            else
                An1 = 0;

            if (A2 != 0)
                An2 = (A2 * 100) / nnnac;     //      '計算PC-血糖值 小於70  該區段的百分比
            else
                An2 = 0;

            if (A3 != 0)
                An3 = (A3 * 100) / nnnac;     //      '計算PC-血糖值 小於70  該區段的百分比
            else
                An3 = 0;

            if (A4 != 0)
                An4 = (A4 * 100) / nnnac;     //      '計算PC-血糖值 小於70  該區段的百分比
            else
                An4 = 0;

            if (A5 != 0)
                An5 = (A5 * 100) / nnnac;     //      '計算PC-血糖值 小於70  該區段的百分比
            else
                An5 = 0;

            if (A6 != 0)
                An6 = (A6 * 100) / nnnac;     //      '計算PC-血糖值 小於70  該區段的百分比
            else
                An6 = 0;


            if (nnn != 0)
                GLAvgpc = (int)(GLAddpc / nnn);    //     '計算PC的平均值
            else
                GLAvgpc = 0;

            if (nnnac != 0)
                GLAvgac = (int)(GLAddac / nnnac);  //   '計算AC的平均值
            else
                GLAvgac = 0;

            //MsgBox "總筆數為：" & nnn & "這些資料的血糖值總和為：" & GLAdd & "平均值為：" & GLAvg & "最大值為：" & GLMax & "最小值為：" & GLMin

            label11.Text = nnn.ToString();
            label12.Text = nnnac.ToString();
            //'If TimeOption = 1 Then
            label7.Text = DataYR_pcR[1] + "/" + DataMO_pcR[1] + "/" + DataDA_pcR[1] + " ~ " + DataYR_pcR[nnn] + "/" + DataMO_pcR[nnn] + "/" + DataDA_pcR[nnn];
            label2.Text = DataYR_acR[1] + "/" + DataMO_acR[1] + "/" + DataDA_acR[1] + " ~ " + DataYR_acR[nnnac] + "/" + DataMO_acR[nnnac] + "/" + DataDA_acR[nnnac];
            //'ElseIf TimeOption = 2 Then
            //'Label15.Caption = DataDA(1) & "/" & DataMO(1) & "/" & DataYR(1) & " ~ " & DataDA(nnn) & "/" & DataMO(nnn) & "/" & DataYR(nnn)
            //'End If

            //'If UnitOption = 1 Then
            //    'MsgBox "目前的單位為mg/dL"
            label18.Text = GLMaxac.ToString();
            label17.Text = GLMinac.ToString();
            label16.Text = GLAvgac.ToString();

            label27.Text = GLMaxpc.ToString();
            label26.Text = GLMinpc.ToString();
            label25.Text = GLAvgpc.ToString();

            //Data(1, 1) = "<70"                  '填寫X軸標籤名
            //Data(2, 1) = "70-100"
            //Data(3, 1) = "100-140"
            //Data(4, 1) = "140-180"
            //Data(5, 1) = "180-220"
            //Data(6, 1) = "220-280"
            //Data(7, 1) = ">=280"
            //MSChart1.ChartData = Data     '將Data陣列中的資料載入圖形的資料方格
            //for (int pointInde = 1; pointInde <= 7; pointInde++)
            //{
            chart1.ChartAreas["ChartArea1"].Axes[0].Title = alu_tp.main_1.rm_txt.GetString("ChartXaxis2");
            //chart1.Titles.Clear();
            //chart1.Titles.Add("NewTitle");
            chart1.Titles["title1"].Text = alu_tp.main_1.rm_txt.GetString("ChartTitle2");

            chart1.Series.Clear();
            chart1.Series.Add("AC");
            chart1.Series.Add("PC");

            chart1.Series["AC"].Points.AddY(Pn0);
            chart1.Series["PC"].Points.AddY(An0);

            chart1.Series["AC"].Points.AddY(Pn1);
            chart1.Series["PC"].Points.AddY(An1);

            chart1.Series["AC"].Points.AddY(Pn2);
            chart1.Series["PC"].Points.AddY(An2);

            chart1.Series["AC"].Points.AddY(Pn3);
            chart1.Series["PC"].Points.AddY(An3);

            chart1.Series["AC"].Points.AddY(Pn4);
            chart1.Series["PC"].Points.AddY(An4);

            chart1.Series["AC"].Points.AddY(Pn5);
            chart1.Series["PC"].Points.AddY(An5);

            chart1.Series["AC"].Points.AddY(Pn6);
            chart1.Series["PC"].Points.AddY(An6);
            chart1.Series["AC"].IsValueShownAsLabel = true;
            chart1.Series["PC"].IsValueShownAsLabel = true;

            chart1.Series["AC"]["LabelStyle"] = "Top";
            chart1.Series["PC"]["LabelStyle"] = "Top";
            
            }
        }
        #endregion
        
        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_GlucoseAnalysisColumnGraph");
            label3.Text = alu_tp.main_1.rm_txt.GetString("UserID");
            label1.Text = alu_tp.main_1.rm_txt.GetString("lblReportDate");
            label8.Text = alu_tp.main_1.rm_txt.GetString("ChartTestTotal");
            label21.Text = alu_tp.main_1.rm_txt.GetString("ChartHighestValue");
            label20.Text = alu_tp.main_1.rm_txt.GetString("ChartLowestValue");
            label19.Text = alu_tp.main_1.rm_txt.GetString("ChartAverageValue");
        }
        #endregion

        private void columnGluFrom_Load(object sender, EventArgs e)
        {
            InitControls();
            getcomMeterid();
            //comMeterid_SelectedValueChanged(null, null);
        }       
    }
}
