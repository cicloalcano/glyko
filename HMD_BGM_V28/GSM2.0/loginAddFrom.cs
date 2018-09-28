using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GSM2._0
{
    public partial class loginAddFrom : Form
    {
      
        bool old_user;
        public loginAddFrom()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm f = new loginForm();
            f.ShowDialog();
        }
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("AddNewUser");
            label1.Text = alu_tp.main_1.rm_txt.GetString("UserID");
            label2.Text = alu_tp.main_1.rm_txt.GetString("Password");
            label3.Text = alu_tp.main_1.rm_txt.GetString("CheckingPassword");
            cmdOK.Text = alu_tp.main_1.rm_txt.GetString("OK");
            button2.Text = alu_tp.main_1.rm_txt.GetString("Cancel");
        }
        private void loginAddFrom_Load(object sender, EventArgs e)
        {
            InitControls();
            textName.Text = "";
            textPassword.Text = "";
            textCheck.Text = "";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.textName.Text == "")
            {
                MainModule.set_MessageBox(alu_tp.main_1.msg_txt.GetString("NotID"), 3000);
                return;
            }
            if (this.textCheck.Text == "")
            {
                MainModule.set_MessageBox(alu_tp.main_1.msg_txt.GetString("NotCheckingPassword"), 3000);
                return;
            }

            if (this.textCheck.Text != this.textPassword.Text)
            {
                MainModule.set_MessageBox(alu_tp.main_1.msg_txt.GetString("CheckingPassworderror"), 3000);
                return;
            }          
            
      //      con3 = new AccessDataSource(alu_tp.main_1.accdb_PATH, "");


            MainModule.insertDatabasesel(" INSERT INTO [ho_user] (UserNo,UserName) VALUES ( '" + this.textName.Text + "','" + this.textName.Text + "')");

            MainModule.insertDatabasesel(" INSERT INTO [HmdRegister] (id,Passwd,RS_232,Unit1,Time1,Max1,Min1,Maxp,Minp) VALUES ( '" + this.textName.Text + "','" + this.textPassword.Text + "','COM1','1','1','180','50','300','30')");
               

                //con3.InsertParameters.Clear();
                //con3.InsertCommand = "INSERT INTO [sta_data] (starNo,staemail,staName,sta_phone,user_address,CreateDate,IsExport) VALUES ( @starNo,@staemail,@staName,@sta_phone,@user_address,@CreateDate,@IsExport)";

                //con3.InsertParameters.Add(new Parameter("starNo", TypeCode.String, id.Text));
                //con3.InsertParameters.Add(new Parameter("staemail", TypeCode.String, Convert.ToString(textBox5.Text)));
                //con3.InsertParameters.Add(new Parameter("staName", TypeCode.String, textBox1.Text));
                //con3.InsertParameters.Add(new Parameter("sta_phone", TypeCode.String, textBox4.Text));
                //con3.InsertParameters.Add(new Parameter("user_address", TypeCode.String, textBox6.Text));
                //con3.InsertParameters.Add(new Parameter("CreateDate", TypeCode.DateTime, DateTime.Now.ToString()));
                //con3.InsertParameters.Add(new Parameter("IsExport", TypeCode.Boolean, Convert.ToString(false)));
                //con3.Insert();

                //con3.UpdateParameters.Clear();
                //con3.UpdateCommand = "UPDATE [HmdRegister] SET id=@id,Passwd=@Passwd";
                //con3.UpdateParameters.Add(new Parameter("id", TypeCode.String, Convert.ToString(id.Text)));
                //con3.UpdateParameters.Add(new Parameter("Passwd", TypeCode.String, textBox2.Text));
                //con3.Update();

            //}
            MessageBox.Show("NEW paciente [" + textName.Text + "] Registration OK !!", "Glucose Management Software", MessageBoxButtons.OK);

            

            this.Close();
            loginForm f = new loginForm();
            f.addCountButton3.Enabled = false;
            f.ShowDialog();
        aendsub: ;
        }
    }
}
