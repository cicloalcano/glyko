namespace GSM2._0
{
    partial class AddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMeterid1 = new System.Windows.Forms.Label();
            this.lblMeterid2 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.txtBirthday = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(63, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "SALVAR";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // lblMeterid1
            // 
            this.lblMeterid1.AutoSize = true;
            this.lblMeterid1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMeterid1.Location = new System.Drawing.Point(12, 9);
            this.lblMeterid1.Name = "lblMeterid1";
            this.lblMeterid1.Size = new System.Drawing.Size(88, 16);
            this.lblMeterid1.TabIndex = 13;
            this.lblMeterid1.Text = "Glicosimetro";
            // 
            // lblMeterid2
            // 
            this.lblMeterid2.AutoSize = true;
            this.lblMeterid2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMeterid2.Location = new System.Drawing.Point(162, 9);
            this.lblMeterid2.Name = "lblMeterid2";
            this.lblMeterid2.Size = new System.Drawing.Size(27, 16);
            this.lblMeterid2.TabIndex = 12;
            this.lblMeterid2.Text = "No";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserID.Location = new System.Drawing.Point(12, 37);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(119, 16);
            this.lblUserID.TabIndex = 11;
            this.lblUserID.Text = "nome do paciente";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(165, 37);
            this.txtUserID.MaxLength = 50;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(133, 22);
            this.txtUserID.TabIndex = 10;
            this.txtUserID.Text = "127.053.618-47";
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblBirthday.Location = new System.Drawing.Point(12, 78);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(91, 16);
            this.lblBirthday.TabIndex = 14;
            this.lblBirthday.Text = "UserBirthday";
            // 
            // txtBirthday
            // 
            this.txtBirthday.Location = new System.Drawing.Point(165, 78);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(133, 22);
            this.txtBirthday.TabIndex = 15;
            this.txtBirthday.Text = "1955.12.23";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblGender.Location = new System.Drawing.Point(12, 120);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(166, 16);
            this.lblGender.TabIndex = 16;
            this.lblGender.Text = "UserGender (M : 1, F : 0)";
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(184, 120);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(114, 22);
            this.txtGender.TabIndex = 17;
            this.txtGender.Text = "1";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.lblName.Location = new System.Drawing.Point(12, 159);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 16);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "UserName";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 159);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 22);
            this.txtName.TabIndex = 19;
            this.txtName.Text = "Obama Lin";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(184, 251);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(82, 29);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 292);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtBirthday);
            this.Controls.Add(this.lblBirthday);
            this.Controls.Add(this.lblMeterid1);
            this.Controls.Add(this.lblMeterid2);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.btnSave);
            this.Name = "AddUser";
            this.Text = "Adicionar Novo patient";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMeterid1;
        private System.Windows.Forms.Label lblMeterid2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.TextBox txtBirthday;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnClear;
    }
}