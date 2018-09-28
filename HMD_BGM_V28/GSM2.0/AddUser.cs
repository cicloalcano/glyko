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
    public partial class AddUser : Form
    {
        bool Saved = false;
        string oldtxtUserID = string.Empty;
        downloadForm4 downloadForm4_Ref = null;
        
        public AddUser()
        {
            InitializeComponent();
        }

        public AddUser(string DataFrom_downloadForm4, downloadForm4 Temp)
        {
            
            InitializeComponent();
            //textBox1.Text = DataFrom_downloadForm4;
            downloadForm4_Ref = Temp;
        }


        private void butSave_Click(object sender, EventArgs e)
        {
            Saved = true;
            downloadForm4_Ref.CatchData(txtUserID.Text, txtBirthday.Text, txtGender.Text, txtName.Text, Saved);
            
            /*
            if (oldtxtUserID != txtUserID.Text.Trim())
            {
                MainModule.updateDatabasesel("update HmdRegister set id='" + txtUserID.Text.Trim() + "' where mid='" + lblMeterid2.Text + "'");
                MainModule.updateDatabasesel("update ho_user set UserName='" + txtName.Text.Trim() + "' where UserNo='" + txtUserID.Text + "'");
            }
            */ 
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "0";
            txtBirthday.Text = "";
            txtGender.Text = "";
            txtName.Text = "";
            Saved = false;
        }

          private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("AddNewUser");
            lblMeterid1.Text = alu_tp.main_1.rm_txt.GetString("MeterID");
            lblUserID.Text = alu_tp.main_1.rm_txt.GetString("UserID");
            btnSave.Text = alu_tp.main_1.rm_txt.GetString("btnSave");
            //txtUserID.Text = "";
            lblMeterid2.Text = "No";
            lblBirthday.Text = alu_tp.main_1.rm_txt.GetString("UserBirthday");// 2015.12.23 denny for Upload to web
            lblGender.Text = alu_tp.main_1.rm_txt.GetString("UserGender") + "(M : 1, F : 0)";// 2015.12.23 denny for Upload to web
            lblName.Text = alu_tp.main_1.rm_txt.GetString("UserName");// 2015.12.23 denny for Upload to web

        }

        private void loadData()
        {
            lblMeterid2.Text = alu_tp.main_1.MeterIDNo.ToString();
            MainModule.insertDatabasesel(" INSERT INTO [ho_user] (UserNo,UserName) VALUES ( '" + lblUserID.Text + "','" + lblName.Text + "')");     
            
            /*
            DataView dv1 = new DataView();
            dv1 = MainModule.AccessDatabasesel("SELECT  *  FROM  HmdRegister where mid='" + lblMeterid2.Text + "'");
            //127.053.618-47
            if (dv1 != null)
            {
                if (dv1.Count > 0)
                {
                    txtUserID.Text = dv1[0]["id"].ToString();
                    oldtxtUserID = dv1[0]["id"].ToString();
                }
            }
            */
        }
        private void AddUser_Load(object sender, EventArgs e)
        {
            InitControls();
            loadData();
        }

        protected override void OnShown(EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height)/2;            
        }
     
    }
}