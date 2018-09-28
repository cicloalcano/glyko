using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace GSM2._0
{
    public partial class databaseFrom : Form
    {
        bool FirstShowForm = true;
        public databaseFrom()
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
            DataView dv1 = new DataView();
            dv1 = MainModule.AccessDatabasesel("SELECT '' as snno,glucosedata,m_event,TestTime  FROM glucose where MeterID='" + alu_tp.main_1.MeterIDNo + "' order by TestTime");

            DataTable dt1 = new DataTable();
            dt1 = dv1.Table;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i].BeginEdit();
                dt1.Rows[i]["snno"] = i + 1;
                dt1.Rows[i].EndEdit();
                dt1.AcceptChanges();
            }
   
            dataGridViewMenu.DataSource = dt1;

            /*if (alu_tp.main_1.Total >= 1 && alu_tp.main_1.MDataDA[1] != 0)
            {
                for (int i = 1; i <= alu_tp.main_1.Total; i++)
                {
                    DataGridViewRowCollection rows = dataGridViewMenu.Rows;
                    rows.Add(new Object[] { i, alu_tp.main_1.MDataGL[i], alu_tp.main_1.MDataACPC[i], alu_tp.main_1.MDataYRDA[i] });
                    //rows.Add(new Object[] { "綠茶", 25, 55, 789 });
                }
            }*/

        }
        #endregion
        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_DataList");
            label3.Text = alu_tp.main_1.rm_txt.GetString("UserID");
        }
        #endregion
       
        private void databaseFrom_Load(object sender, EventArgs e)
        {
            InitControls();
            getcomMeterid();
            //comMeterid_SelectedValueChanged(null, null);            
        }

        private void dataGridViewMenu_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridViewMenu.Columns[0].HeaderText = alu_tp.main_1.rm_txt.GetString("TestNo");
            this.dataGridViewMenu.Columns[1].HeaderText = alu_tp.main_1.rm_txt.GetString("TheBloodGlucoseUnit");
            this.dataGridViewMenu.Columns[2].HeaderText = alu_tp.main_1.rm_txt.GetString("ACorPC");
            this.dataGridViewMenu.Columns[3].HeaderText = alu_tp.main_1.rm_txt.GetString("DateTime");
            this.dataGridViewMenu.Columns[0].Width = 100;
            this.dataGridViewMenu.Columns[1].Width = 100;
            this.dataGridViewMenu.Columns[2].Width = 100;
            this.dataGridViewMenu.Columns[3].Width = 200;
        }

        private void dataGridViewMenu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }
            DataGridView dgv = (DataGridView)sender;
            object originalValue = e.Value;

            if (e.ColumnIndex == dgv.Columns["TestTime"].Index)   //格式化日期
            {
                if (e.Value != null)
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }
    }
}
