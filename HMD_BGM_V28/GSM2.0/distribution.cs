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
    public partial class distribution : Form
    {
        bool FirstShowForm = true;
        private class range1
        {
            public int below;
            public int within;
            public int above;

        }
        range1[] drange = new range1[9];
        public distribution()
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
            System.Data.DataView dv;
            chart1.Series.Clear();
            chart1.Series.Add(alu_tp.main_1.rm_txt.GetString("ChartNormal"));
            chart1.Series.Add(alu_tp.main_1.rm_txt.GetString("OutTheNormal"));
            chart1.Series.Add(alu_tp.main_1.rm_txt.GetString("OutTheLimit"));

            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartNormal")].ChartType = SeriesChartType.StackedColumn100;
            chart1.Series[alu_tp.main_1.rm_txt.GetString("OutTheNormal")].ChartType = SeriesChartType.StackedColumn100;
            chart1.Series[alu_tp.main_1.rm_txt.GetString("OutTheLimit")].ChartType = SeriesChartType.StackedColumn100;

            //dv = MainModule.SetGlucoseToTimeSet(); 2015.01.29 denny
            //DataView dv1 = MainModule.AccessDatabasesel("SELECT  format(TestTime, 'YYYY-MM-DD') AS TestT, GlucoseData,m_Event,time_IDX    FROM  glucose where  MeterID='" + alu_tp.main_1.MeterIDNo + "' ORDER BY TestTime DESC"); 2015.01.29 denny
            dv = MainModule.AccessDatabasesel("SELECT * FROM glucose where MeterID='" + alu_tp.main_1.MeterIDNo + "' ORDER BY  TestTime DESC"); // 2015.01.29 denny

            for (int jj = 0; jj < 9; jj++)
            {
                drange[jj] = new range1();
                drange[jj].below = 0;
                drange[jj].within = 0;
                drange[jj].above = 0;
            }

            for (int data_count = 0; data_count < dv.Count; data_count++ )
            {

                if ((int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("GlucoseData")] == 0) { }
                else if ((int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("GlucoseData")] < alu_tp.main_1.TargetMinOptionp) drange[(int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("TIME_IDX")] - 1].below++;
                else if ((int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("GlucoseData")] < alu_tp.main_1.TargetMinOption) drange[(int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("TIME_IDX")] - 1].above++;
                else if ((int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("GlucoseData")] > alu_tp.main_1.TargetMaxOptionp) drange[(int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("TIME_IDX")] - 1].below++;
                else if ((int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("GlucoseData")] > alu_tp.main_1.TargetMaxOption) drange[(int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("TIME_IDX")] - 1].above++;
                else drange[(int)dv.Table.Rows[data_count].ItemArray[dv.Table.Columns.IndexOf("TIME_IDX")] - 1].within++;

            }


            /*// 2015.01.29 denny  
            for (int jj = 0; jj < dv.Count; jj++)
            {
                for (int ii = 0; ii < 9; ii++)
                {
                    string eestr = "Expr" + (ii + 1);
                    if (Convert.ToInt16(dv[jj].Row[eestr]) == 0) { }
                    else if (Convert.ToInt16(dv[jj].Row[eestr]) < alu_tp.main_1.TargetMinOptionp) drange[ii].below++;
                    else if (Convert.ToInt16(dv[jj].Row[eestr]) < alu_tp.main_1.TargetMinOption) drange[ii].above++;
                    else if (Convert.ToInt16(dv[jj].Row[eestr]) > alu_tp.main_1.TargetMaxOptionp) drange[ii].below++;
                    else if (Convert.ToInt16(dv[jj].Row[eestr]) > alu_tp.main_1.TargetMaxOption) drange[ii].above++;
                    else drange[ii].within++;


                    dv1.RowFilter = "TestT= '" + Convert.ToString(dv[jj].Row[0]) + "' and time_IDX='" + Convert.ToString(ii + 1) + "' and GlucoseData <> '" + Convert.ToInt16(dv[jj].Row[eestr]) + "' and GlucoseData <> '0'";

                    if (dv1.Count > 0)
                    {
                        for (int t1 = 0; t1 < dv1.Count; t1++)
                        {
                            if (dv1[t1].Row["GlucoseData"].ToString().Length == 0) { }
                            else if (Convert.ToInt16(dv1[t1].Row["GlucoseData"]) < alu_tp.main_1.TargetMinOptionp) drange[ii].below++;
                            else if (Convert.ToInt16(dv1[t1].Row["GlucoseData"]) < alu_tp.main_1.TargetMinOption) drange[ii].above++;
                            else if (Convert.ToInt16(dv1[t1].Row["GlucoseData"]) > alu_tp.main_1.TargetMaxOptionp) drange[ii].below++;
                            else if (Convert.ToInt16(dv1[t1].Row["GlucoseData"]) > alu_tp.main_1.TargetMaxOption) drange[ii].above++;
                            else drange[ii].within++;
                        }
                    }
                }
            }
            *///2015.01.29 denny

            for (int jj = 0; jj < 9; jj++)
            {
                chart1.Series[alu_tp.main_1.rm_txt.GetString("OutTheLimit")].Points.AddY((double)drange[jj].below);
                chart1.Series[alu_tp.main_1.rm_txt.GetString("OutTheNormal")].Points.AddY((double)drange[jj].above);
                chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartNormal")].Points.AddY((double)drange[jj].within);

            }

            for (int jj = 0; jj < 9; jj++)
            {
                this.chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 2 * (jj + 1), alu_tp.timgp[jj].time_on + "-" + alu_tp.timgp[jj].time_off);
            }
            chart1.Series[alu_tp.main_1.rm_txt.GetString("OutTheLimit")].IsValueShownAsLabel = true;
            chart1.Series[alu_tp.main_1.rm_txt.GetString("OutTheNormal")].IsValueShownAsLabel = true;
            chart1.Series[alu_tp.main_1.rm_txt.GetString("ChartNormal")].IsValueShownAsLabel = true;
        }
        #endregion

        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_DistributionGroup");
            label3.Text = alu_tp.main_1.rm_txt.GetString("UserID");
        }
        #endregion

        private void distribution_Load(object sender, EventArgs e)
        {
            InitControls();
            getcomMeterid();
            //comMeterid_SelectedValueChanged(null, null);
        }        
    }
}