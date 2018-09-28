using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GSM2._0
{
    public partial class SettingUser : Form
    {
        string HmdRegister_idx = "0"; 
        public SettingUser()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            DataView dv1 = null;
            dv1 = MainModule.AccessDatabasesel("SELECT  idx,mid,id,Max1,Min1,Maxp,Minp  FROM  HmdRegister order by id,mid");
            dataGridView1.DataSource = dv1;
        }

        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_SettingUser");
            lblMeterid1.Text = alu_tp.main_1.rm_txt.GetString("MeterID");
            lblUserID.Text = alu_tp.main_1.rm_txt.GetString("UserID");
            label9.Text = alu_tp.main_1.rm_txt.GetString("SettingUserComm");
            groupBox2.Text = alu_tp.main_1.rm_txt.GetString("SettingUserGroupComm");
            label1.Text = alu_tp.main_1.rm_txt.GetString("Uperlimit");
            label2.Text = alu_tp.main_1.rm_txt.GetString("UperNormal");
            label3.Text = alu_tp.main_1.rm_txt.GetString("LowerNormal");
            label4.Text = alu_tp.main_1.rm_txt.GetString("LimiteInferior");
            cmdSaveBtn.Text = alu_tp.main_1.rm_txt.GetString("btnSave");
        }
        #endregion
        
        private void SettingUser_Load(object sender, EventArgs e)
        {
            InitControls();
            loadData();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = alu_tp.main_1.rm_txt.GetString("MeterID");
            dataGridView1.Columns[3].HeaderText = alu_tp.main_1.rm_txt.GetString("UserID");
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            //dataGridView1.Columns[2].DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleCenter;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                    lblMeterid2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtUserID.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    HmdRegister_idx = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                    if (alu_tp.main_1.UnitOption == 1)
                    {
                        maxPBox.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        maxBox.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        minBox.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        minpBox.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    }
                    else if (alu_tp.main_1.UnitOption == 2)
                    {
                        maxPBox.Text = (Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()) / 18).ToString();
                        maxBox.Text = (Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) / 18).ToString();
                        minBox.Text = (Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) / 18).ToString();
                        minpBox.Text = (Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()) / 18).ToString();
                    }
                }
                else
                {
                    HmdRegister_idx = "0";
                }
            }
        }       
        
        private void cmdSaveBtn_Click(object sender, EventArgs e)
        {
            if(lblMeterid2.Text.ToLower()=="no")
            { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORMustSelect"), lblMeterid1.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if(maxPBox.Text=="")
            { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORMustInput"), label1.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (maxBox.Text == "")
            { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORMustInput"), label2.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (minBox.Text == "")
            { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORMustInput"), label3.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (minpBox.Text == "")
            { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORMustInput"), label4.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (MainModule.IsNumber(maxPBox.Text) == false)
            { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORMustIsNumber"), label1.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (MainModule.IsNumber(maxBox.Text) == false)
            { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORMustIsNumber"), label2.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (MainModule.IsNumber(minBox.Text) == false)
            { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORMustIsNumber"), label3.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (MainModule.IsNumber(minpBox.Text) == false)
            { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORMustIsNumber"), label4.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            maxPBox.Text = MainModule.ConvertToFullwidthNumber2(maxPBox.Text);
            maxBox.Text = MainModule.ConvertToFullwidthNumber2(maxBox.Text);
            minBox.Text = MainModule.ConvertToFullwidthNumber2(minBox.Text);
            minpBox.Text = MainModule.ConvertToFullwidthNumber2(minpBox.Text);

            if (HmdRegister_idx != "0")
            {
                int MaxOption = 0;
                int MinOption = 0;
                int MaxOptionp = 0;
                int MinOptionp = 0;
                if (alu_tp.main_1.UnitOption == 1)//mg/dL
                {
                    if (int.Parse(maxPBox.Text) > 600 || int.Parse(maxPBox.Text) < 30)
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueRanges"), label1.Text,"30","600"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else if (int.Parse(maxBox.Text) > 600 || int.Parse(maxBox.Text) < 30)
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueRanges"), label2.Text,"30","600"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else if (int.Parse(maxBox.Text) > int.Parse(maxPBox.Text))
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueGreaterThan"), label2.Text, label1.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    else if (int.Parse(minBox.Text) > 600 || int.Parse(minBox.Text) < 30)
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueRanges"), label3.Text,"30","600"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else if (int.Parse(minpBox.Text) > 600 || int.Parse(minpBox.Text) < 30)
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueRanges"), label4.Text,"30","600"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else if (int.Parse(minpBox.Text) > int.Parse(minBox.Text))
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueGreaterThan"), label4.Text, label3.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else
                    {
                        MaxOptionp = int.Parse(maxPBox.Text);   //將現在之血糖最大值寫入
                        MaxOption = int.Parse(maxBox.Text);   //將現在之血糖最小值寫入
                        MinOption = int.Parse(minBox.Text); //將現在之血糖最大值寫入
                        MinOptionp = int.Parse(minpBox.Text); //將現在之血糖最小值寫入   
                    }
                }
                else if (alu_tp.main_1.UnitOption == 2)  //'(mmol/L)
                {
                    if (int.Parse(maxPBox.Text) > 33.3 || int.Parse(maxPBox.Text) < 1.7)
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueRanges"), label1.Text,"33.3","1.7"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else if (int.Parse(maxBox.Text) > 33.3 || int.Parse(maxBox.Text) < 1.7)
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueRanges"), label2.Text,"33.3","1.7"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else if (int.Parse(maxBox.Text) > int.Parse(maxPBox.Text))
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueGreaterThan"), label2.Text, label1.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    else if (int.Parse(minBox.Text) > 33.3 || int.Parse(minBox.Text) < 1.7)
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueRanges"), label3.Text,"33.3","1.7"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else if (int.Parse(minpBox.Text) > 33.3 || int.Parse(minpBox.Text) < 1.7)
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueRanges"), label4.Text,"33.3","1.7"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else if (int.Parse(minpBox.Text) > int.Parse(minBox.Text))
                    { MessageBox.Show(string.Format(alu_tp.main_1.msg_txt.GetString("ERRORSettingOfGlucoseValueGreaterThan"), label4.Text, label3.Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    else
                    {
                        MaxOptionp = int.Parse(maxPBox.Text) * 18; //'將現在之血糖最大值寫入
                        MaxOption = int.Parse(maxBox.Text) * 18; //'將現在之血糖最小值寫入
                        MinOption= int.Parse(minBox.Text) * 18; //'將現在之血糖最大值寫入
                        MinOptionp= int.Parse(minpBox.Text) * 18; //'將現在之血糖最小值寫入                        
                    }
                }
                MainModule.updateDatabasesel("UPDATE HmdRegister SET Max1='" + MaxOption + "', Maxp='" + MaxOptionp + "', Min1='" + MinOption + "', Minp='" + MinOptionp + "',id='" + txtUserID.Text+ "' where idx=" + HmdRegister_idx + " ");
                loadData();
            }
        }      
    }
}
