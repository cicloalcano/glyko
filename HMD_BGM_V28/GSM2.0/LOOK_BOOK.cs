using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace GSM2._0
{
    public partial class LOOK_BOOK : Form
    {
        bool PAINTON = false;
        bool FirstShowForm = true;
        public LOOK_BOOK()
        {
            InitializeComponent();
        }
        private void comMeterid_Click(object sender, EventArgs e)
        {
            FirstShowForm = false;
        }
        private void getcomMeterid(){
            comMeterid.Items.Clear();
            comMeterid.DataSource = MainModule.GetMeteridWithUser();
            comMeterid.DisplayMember = "miduid";
            comMeterid.ValueMember = "mid";

            comMeterid.SelectedValue = alu_tp.main_1.MeterIDNo;
        }
        private void comMeterid_SelectedValueChanged(object sender, EventArgs e)
        {
            if(FirstShowForm==false)
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
            //* 2015.01.21 denny
            this.dataGridView1.Columns[0].HeaderText = "Date"; 

            //DataView dv = MainModule.SetGlucoseToTimeSet(); 2015.01.21 denny
            DataView dv = MainModule.AccessDatabasesel("SELECT * FROM glucose where MeterID='" + alu_tp.main_1.MeterIDNo + "' ORDER BY  TestTime DESC");
            //this.dataGridView1.DataSource = dv; // 2015.01.21 denny
            

            //*/
            //*/ 2015.01.21 denny
            if (alu_tp.timgp.Length > 0)
            {
                for (int jj = 0; jj < alu_tp.timgp.Length; jj++)
                {
                    int colindex;
                    //Label LB1 = new Label();// 2015.01.22 denny
                    //LB1.Text = alu_tp.timgp[jj].time_on + "\n" + alu_tp.timgp[jj].time_off;// 2015.01.22 denny
                    colindex = jj + 2;

                    //((GridView)sender).HeaderRow.Cells[2].Text = LB1.Text;
                    //((GridView)sender).HeaderRow.Cells[jj + 2].Controls.Add(LB1);
                    this.dataGridView1.ColumnCount = colindex + 1 ;
                    this.dataGridView1.Columns[colindex].HeaderText = alu_tp.timgp[jj].time_on + "\n" + alu_tp.timgp[jj].time_off;// 2015.01.22 denny
                    //  e.Row.Cells.Item(17).Controls.Add(LB1)
                }

            }
            //*/
            this.dataGridView1.Location = new Point(this.dataGridView1.Location.X, 25);

            for (int rowindex = 0; rowindex < dv.Count; rowindex++)
            {
                this.dataGridView1.RowCount = rowindex + 1;
                this.dataGridView1.Rows[rowindex].Cells[0].Value = Convert.ToDateTime(dv.Table.Rows[rowindex].ItemArray[dv.Table.Columns.IndexOf("TestTime")]).DayOfWeek;
                this.dataGridView1.Rows[rowindex].Cells[1].Value = DateTime.Parse(dv.Table.Rows[rowindex].ItemArray[dv.Table.Columns.IndexOf("TestTime")].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                this.dataGridView1.Rows[rowindex].Cells[((int)dv.Table.Rows[rowindex].ItemArray[dv.Table.Columns.IndexOf("TIME_IDX")] - 1) + 2].Value = (int)dv.Table.Rows[rowindex].ItemArray[dv.Table.Columns.IndexOf("GlucoseData")];               
            }

        }
        #endregion
        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_DayList");
            label3.Text = alu_tp.main_1.rm_txt.GetString("UserID");
        }
        #endregion

        private void LOOK_BOOK_Load(object sender, EventArgs e)
        {
            InitControls();
            getcomMeterid();
            
            //comMeterid_SelectedValueChanged(null, null);
            //   DataView dv1
            // TODO: 這行程式碼會將資料載入 'lookbook.DataTable1' 資料表。您可以視需要進行移動或移除。
            //this.dataTable1TableAdapter.Fill(this.lookbook.DataTable1);           
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //this.dataGridView1.Columns[0].HeaderText = alu_tp.main_1.rm_txt.GetString("TestT"); // 2015.01.21 denny
            //this.dataGridView1.Columns[0].HeaderText = alu_tp.main_1.rm_txt.GetString("Dayofweek"); // 2015.01.21 denny
            //this.dataGridView1.Columns[1].HeaderText = alu_tp.main_1.rm_txt.GetString("TestT"); // 2015.01.21 denny
            //  this.dataGridView1.Columns[0].DataPropertyName = "aaa";
            //  this.dataGridView1.Columns[1].DataPropertyName = "bbb";
            //   this.dataGridView1.DataSource = sourceds.Tables[0];
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
           /* 2015.01.21 denny
            if (PAINTON == true) return;
            if (e.RowIndex != -1)
            {
                DataGridViewRow datagridview = dataGridView1.Rows[e.RowIndex];
                if (datagridview.DataBoundItem != null)
                {   
                    //datagridview.Cells[1].Value = Convert.ToDateTime(datagridview.Cells[1].Value.ToString());
                    //datagridview.Cells[0].Value = Convert.ToDateTime(datagridview.Cells[1].Value.ToString()).DayOfWeek;
                    
                    string weekstring = Convert.ToDateTime(datagridview.Cells[1].Value.ToString()).DayOfWeek.ToString();
                    if (weekstring.ToLower() == "sunday")
                        weekstring = alu_tp.main_1.rm_txt.GetString("sunday");
                    if (weekstring.ToLower() == "monday")
                        weekstring = alu_tp.main_1.rm_txt.GetString("monday");
                    if (weekstring.ToLower() == "tuesday")
                        weekstring = alu_tp.main_1.rm_txt.GetString("tuesday");
                    if (weekstring.ToLower() == "wednesday")
                        weekstring = alu_tp.main_1.rm_txt.GetString("wednesday");
                    if (weekstring.ToLower() == "thursday")
                        weekstring = alu_tp.main_1.rm_txt.GetString("thursday");
                    if (weekstring.ToLower() == "friday")
                        weekstring = alu_tp.main_1.rm_txt.GetString("friday");
                    if (weekstring.ToLower() == "saturday")
                        weekstring = alu_tp.main_1.rm_txt.GetString("saturday");
            
                    datagridview.Cells[0].Value = weekstring;
                    
                }
            }
            */ 
            //if (e.RowIndex + 1 == this.lookbook.DataTable1.Rows.Count) PAINTON = true;
        }
    }
}
