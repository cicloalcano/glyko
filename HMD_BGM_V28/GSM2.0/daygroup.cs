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
    public partial class daygroup : Form
    {
        bool FirstShowForm = true;
        public class comm_list
        {
            public byte[] send_str;
            public double[] yValues = new double[12];
        }

        public daygroup()
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
        #region loadData
        private void loadData()
        {
            comm_list[] send_comm = new comm_list[9];
            Series[] DataSeries = new Series[9];
            Series[] series3 = new Series[9];
            Series BoxPlotSeries = new Series();

            System.Data.DataView dv, dv1;

            dv = MainModule.SetGlucoseToTimeSet(); // 2015.01.30 denny
            dv1 = MainModule.AccessDatabasesel("SELECT  format(TestTime, 'YYYY-MM-DD') AS TestT, GlucoseData,m_Event,time_IDX    FROM  glucose  where  MeterID='" + alu_tp.main_1.MeterIDNo + "' ORDER BY TestTime DESC"); // 2015.01.30 denny
            //dv = MainModule.AccessDatabasesel("SELECT * FROM glucose where MeterID='" + alu_tp.main_1.MeterIDNo + "' ORDER BY  TestTime DESC"); // 2015.01.30 denny

            int[] count1 = new int[9];
            for (int ii = 0; ii < 9; ii++)
            {
                DataSeries[ii] = new Series();
                send_comm[ii] = new comm_list();
                series3[ii] = new Series();
                count1[ii] = 0;
            }



            // 2015.01.30 denny
            for (int jj = 0; jj < dv.Count; jj++)
            {
                for (int ii = 0; ii < 9; ii++)
                {
                    string eestr = "Expr" + (ii + 1);
                    if (Convert.ToInt16(dv[jj].Row[eestr]) == 0)
                    {
                    }
                    else
                    {
                        count1[ii]++;
                    }
                    dv1.RowFilter = "TestT= '" + Convert.ToString(dv[jj].Row[0]) + "' and time_IDX='" + Convert.ToString(ii + 1) + "' and GlucoseData <> '" + Convert.ToInt16(dv[jj].Row[eestr]) + "' and GlucoseData <> '0'";
                    if (dv1.Count > 0)
                    {
                        for (int t1 = 0; t1 < dv1.Count; t1++)
                        {
                            count1[ii]++;
                        }
                    }
                }
            }

            for (int jj = 0; jj < 9; jj++)
            {
                send_comm[jj].yValues = new double[count1[jj]];
            }
            int[] count2 = new int[9];
            for (int jj = 0; jj < dv.Count; jj++)
            {
                for (int ii = 0; ii < 9; ii++)
                {
                    string eestr = "Expr" + (ii + 1);
                    if (Convert.ToInt16(dv[jj].Row[eestr]) == 0)
                    {
                    }
                    else
                    {
                        send_comm[ii].yValues[count2[ii]] = Convert.ToInt16(dv[jj].Row[eestr]);
                        count2[ii]++;
                    }

                    dv1.RowFilter = "TestT= '" + Convert.ToString(dv[jj].Row[0]) + "' and time_IDX='" + Convert.ToString(ii + 1) + "' and GlucoseData <> '" + Convert.ToInt16(dv[jj].Row[eestr]) + "' and GlucoseData <> '0'";
                    if (dv1.Count > 0)
                    {
                        for (int t1 = 0; t1 < dv1.Count; t1++)
                        {
                            send_comm[ii].yValues[count2[ii]] = Convert.ToUInt16(dv1[t1].Row["GlucoseData"]);
                            count2[ii]++;
                        }
                    }
                }
            }
            // 2015.01.30 denny
            ChartArea ChartArea2 = new ChartArea();
            ChartArea ChartArea3 = new ChartArea();
            ChartArea bx1 = new ChartArea();
            //Add the charting areas to the chart
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(ChartArea2);
            chart1.ChartAreas.Add(ChartArea3);

            ChartArea2.Name = "Data Chart Area";
            ChartArea3.Name = "Box Plot Area";
            //ChartArea3.AlignWithChartArea = "Data Chart Area"
            ChartArea2.Position.X = 0;
            ChartArea2.Position.Y = 0;

            ChartArea3.Position.X = 0;
            ChartArea3.Position.Y = 0;


            ChartArea2.Position.Height = 82f;
            ChartArea2.Position.Width = 0f;
            ChartArea3.Position.Height = 92f;
            ChartArea3.Position.Width = 90f;

            // ChartArea3.AxisX.IsLabelAutoFit = False
            //   ChartArea3.AxisX.MajorGrid.Enabled = False
            //   ChartArea3.AxisX.MajorTickMark.Enabled = False
            ChartArea3.AxisX.ScaleBreakStyle.Spacing = .5;
            //    ChartArea3.AxisX.ScaleBreakStyle.StartFromZero = StartFromZero.No
            ChartArea3.AxisX.Minimum = 0.5;
            ChartArea3.AxisX.Maximum = 9.5;

            //  BackGradientStyle = "VerticalCenter"
            //   ChartArea3.ShadowColor = Drawing.Color.Cyan
            //  ChartArea3.BackSecondaryColor = Drawing.Color.FromArgb(128, 255, 255)
            //  ChartArea3.BorderColor = Drawing.Color.Black

            for (int jj = 0; jj < 9; jj++)
            {
                series3[jj].Name = "BoxPlotLabels" + jj;
                series3[jj].ChartArea = "Box Plot Area";
                series3[jj].ChartType = SeriesChartType.Point;
                series3[jj].CustomProperties = "LabelStyle=Center"; // 2015.02.02 denny
                series3[jj].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F); // 2015.02.02 denny
                series3[jj].Legend = "Default";
            }
            for (int jj = 0; jj < 9; jj++)
            {
                DataPoint dataPoint1 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint2 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint3 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint4 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint5 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint6 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint7 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint8 = new DataPoint(1 + jj, 0);
                dataPoint1.Color = System.Drawing.Color.Transparent;
                dataPoint2.Color = System.Drawing.Color.Transparent;
                dataPoint3.Color = System.Drawing.Color.Transparent;
                dataPoint4.Color = System.Drawing.Color.Transparent;
                dataPoint5.Color = System.Drawing.Color.Transparent;
                dataPoint6.Color = System.Drawing.Color.Transparent;
                dataPoint7.Color = System.Drawing.Color.Transparent;
                dataPoint8.Color = System.Drawing.Color.Transparent;

                series3[jj].Points.Add(dataPoint1);
                series3[jj].Points.Add(dataPoint2);
                series3[jj].Points.Add(dataPoint3);
                series3[jj].Points.Add(dataPoint4);
                series3[jj].Points.Add(dataPoint5);
                series3[jj].Points.Add(dataPoint6);
                series3[jj].Points.Add(dataPoint7);
                series3[jj].Points.Add(dataPoint8);
                series3[jj].SmartLabelStyle.Enabled = false;
            }

            for (int jj = 0; jj < 9; jj++)
            {
                DataSeries[jj].Name = "DataSeries" + jj;
                DataSeries[jj].ChartType = SeriesChartType.Point;
                DataSeries[jj].ChartArea = "Data Chart Area";
                DataSeries[jj].IsValueShownAsLabel = false;
                DataSeries[jj].IsVisibleInLegend = false;
            }

            BoxPlotSeries.Name = "BoxPlotSeries";
            BoxPlotSeries.ChartType = SeriesChartType.BoxPlot; 
            BoxPlotSeries.ChartArea = "Box Plot Area";
            //   BoxPlotSeries.IsValueShownAsLabel = true;
            BoxPlotSeries.IsVisibleInLegend = true;
            BoxPlotSeries.BackGradientStyle = GradientStyle.VerticalCenter;
            BoxPlotSeries.Color = System.Drawing.Color.Cyan;
            BoxPlotSeries.BackSecondaryColor = System.Drawing.Color.FromArgb(128, 255, 255);
            BoxPlotSeries.BorderColor = System.Drawing.Color.Black;

            chart1.Series.Clear();
            chart1.Series.Add(BoxPlotSeries);

            // Add data to Box Plot Source series.
            string datastr = "";
            for (int jj = 0; jj < 9; jj++)
            {
                chart1.Series.Add(series3[jj]);
                chart1.Series.Add(DataSeries[jj]);
                chart1.Series[DataSeries[jj].Name].Points.DataBindY(send_comm[jj].yValues);
                if (jj > 0) { datastr = datastr + ";" + DataSeries[jj].Name; } else { datastr = DataSeries[jj].Name; }
            }
            chart1.Series["BoxPlotSeries"]["BoxPlotWhiskerPercentile"] = "0";

            chart1.Series["BoxPlotSeries"]["BoxPlotSeries"] = datastr;

            // Set whiskers 15th percentile.
            //chart1.Series["BoxPlotSeries"]["BoxPlotWhiskerPerc entile"] = "10";// 2015.02.04 denny
            // Show/Hide Average line.
            chart1.Series["BoxPlotSeries"]["BoxPlotShowAverage "] = "true";
            // Show/Hide Median line.
            chart1.Series["BoxPlotSeries"]["BoxPlotShowMedian"] = "true";

            // Show/Hide Unusual points.
            chart1.Series["BoxPlotSeries"]["BoxPlotShowUnusual Values"] = "true";
            //  chart1.Series("BoxPlotSeries")("PointWidth") = "0.25"
            chart1.Series["BoxPlotSeries"]["PointWidth"] = "0.50";//"0.25"; 2015.02.02 denny
            chart1.Series["BoxPlotSeries"].XValueMember = "day of week";
     
            for (int jj = 0; jj < 9; jj++)
            {
                ChartArea3.AxisX.CustomLabels.Add(0, 2 * (jj + 1), alu_tp.timgp[jj].time_on + "-" + alu_tp.timgp[jj].time_off); // 2015.01.30 denny
            }
            ChartArea3.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            ChartArea3.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            StripLine s01;

            if (alu_tp.main_1.TargetMaxOptionp.ToString().Length > 0 || alu_tp.main_1.TargetMinOptionp.ToString().Length > 0)
            {
                s01 = new StripLine();
                s01.BackColor = Color.FromArgb(248, 199, 213);
                s01.IntervalOffset = 0;

                s01.StripWidth = 700;
                //     chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(s01);
                ChartArea3.AxisY.StripLines.Add(s01);

                s01 = new StripLine();

                s01.BackColor = Color.FromArgb(245, 250, 189);
                s01.IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOptionp);

                s01.StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOptionp) - s01.IntervalOffset;
                //  chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(s01);
                ChartArea3.AxisY.StripLines.Add(s01);
            }

            if (alu_tp.main_1.TargetMaxOption.ToString().Length > 0 || alu_tp.main_1.TargetMinOption.ToString().Length > 0)
            {
                s01 = new StripLine();

                s01.BackColor = Color.FromArgb(190, 251, 210);
                s01.IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOption);

                s01.StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOption) - s01.IntervalOffset;
                //  chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(s01);
                ChartArea3.AxisY.StripLines.Add(s01);
            }

            for (int jj = 0; jj < 9; jj++)
            {
                chart1.Series[DataSeries[jj].Name].Enabled = false;
            }
        }
        private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement.ToString() == "ChartArea-Data Chart Area")
            {                
                for (int jj = 0; jj < 9; jj++)
                {
                    string bxname = "BoxPlotLabels" + jj;
                    // Position point chart type series on the points of the box plot to display labels        
                    chart1.Series[bxname].Points[0].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[0];
                    chart1.Series[bxname].Points[1].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[1];
                    chart1.Series[bxname].Points[2].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[2];
                    chart1.Series[bxname].Points[3].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[3];
                    chart1.Series[bxname].Points[4].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[4];
                    chart1.Series[bxname].Points[5].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[5];

                    chart1.Series[bxname].Points[0].Label = string.Format("{0:F2}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[0]);
                    if (chart1.Series["BoxPlotSeries"].Points[jj].YValues[0] != 0)
                    {
                        chart1.Series[bxname].Points[0].CustomProperties = "LabelStyle=Left"; // 2015.02.09 denny
                        chart1.Series[bxname].Points[0].LabelAngle = -45; // 2015.02.09 denny
                    }
                    chart1.Series[bxname].Points[1].Label = string.Format("{0:F2}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[1]);
                    if (chart1.Series["BoxPlotSeries"].Points[jj].YValues[1] != 0)
                    {
                        chart1.Series[bxname].Points[1].CustomProperties = "LabelStyle=Left"; // 2015.02.09 denny
                        chart1.Series[bxname].Points[1].LabelAngle = 45; // 2015.02.09 denny
                    }
                    chart1.Series[bxname].Points[2].Label = string.Format("{0:F2}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[2]);
                    if (chart1.Series["BoxPlotSeries"].Points[jj].YValues[2] != 0)
                    {
                        chart1.Series[bxname].Points[2].CustomProperties = "LabelStyle=Right"; // 2015.02.09 denny
                        chart1.Series[bxname].Points[2].LabelAngle = 45; // 2015.02.09 denny
                    }
                    chart1.Series[bxname].Points[3].Label = string.Format("{0:F2}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[3]);
                    if (chart1.Series["BoxPlotSeries"].Points[jj].YValues[3] != 0)
                    {
                        chart1.Series[bxname].Points[3].CustomProperties = "LabelStyle=Right"; // 2015.02.09 denny
                        chart1.Series[bxname].Points[3].LabelAngle = -45; // 2015.02.09 denny
                    }
                    chart1.Series[bxname].Points[4].Label = string.Format("{0:F2}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[4]);
                    if (chart1.Series["BoxPlotSeries"].Points[jj].YValues[4] != 0)
                    {
                        chart1.Series[bxname].Points[4].CustomProperties = "LabelStyle=Left"; // 2015.02.09 denny
                        chart1.Series[bxname].Points[4].LabelAngle = 0; // 2015.02.09 denny
                    }
                    chart1.Series[bxname].Points[5].Label = string.Format("{0:F2}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[5]);
                    if (chart1.Series["BoxPlotSeries"].Points[jj].YValues[5] != 0)
                    {
                        chart1.Series[bxname].Points[5].CustomProperties = "LabelStyle=Right"; // 2015.02.09 denny
                        chart1.Series[bxname].Points[5].LabelAngle = 0; // 2015.02.09 denny
                    }

                }

            }
        }
        #endregion
        
        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_DayGroup");
            label3.Text = alu_tp.main_1.rm_txt.GetString("UserID");
        }
        #endregion

        private void daygroup_Load(object sender, EventArgs e)
        {
            InitControls();
            getcomMeterid();
            //comMeterid_SelectedValueChanged(null, null);
        }
    }
}