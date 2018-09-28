namespace GSM2._0
{
    partial class SettingUser
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
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblMeterid2 = new System.Windows.Forms.Label();
            this.lblMeterid1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSaveBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.minpBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.minBox = new System.Windows.Forms.TextBox();
            this.maxBox = new System.Windows.Forms.TextBox();
            this.maxPBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserID.Location = new System.Drawing.Point(532, 41);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(119, 16);
            this.lblUserID.TabIndex = 6;
            this.lblUserID.Text = "nome do paciente";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(684, 41);
            this.txtUserID.MaxLength = 50;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(133, 22);
            this.txtUserID.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(419, 429);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // lblMeterid2
            // 
            this.lblMeterid2.AutoSize = true;
            this.lblMeterid2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMeterid2.Location = new System.Drawing.Point(682, 13);
            this.lblMeterid2.Name = "lblMeterid2";
            this.lblMeterid2.Size = new System.Drawing.Size(27, 16);
            this.lblMeterid2.TabIndex = 8;
            this.lblMeterid2.Text = "No";
            // 
            // lblMeterid1
            // 
            this.lblMeterid1.AutoSize = true;
            this.lblMeterid1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMeterid1.Location = new System.Drawing.Point(532, 13);
            this.lblMeterid1.Name = "lblMeterid1";
            this.lblMeterid1.Size = new System.Drawing.Size(88, 16);
            this.lblMeterid1.TabIndex = 9;
            this.lblMeterid1.Text = "Glicosimetro";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(450, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(387, 21);
            this.label9.TabIndex = 33;
            this.label9.Text = "Escolha a unidade de glicemia e o valor de glicemia antes de pressionar SALVAR.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Limite Inferior:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Normal Inferior:";
            // 
            // cmdSaveBtn
            // 
            this.cmdSaveBtn.Location = new System.Drawing.Point(608, 231);
            this.cmdSaveBtn.Name = "cmdSaveBtn";
            this.cmdSaveBtn.Size = new System.Drawing.Size(103, 23);
            this.cmdSaveBtn.TabIndex = 31;
            this.cmdSaveBtn.Text = "SALVAR";
            this.cmdSaveBtn.UseVisualStyleBackColor = true;
            this.cmdSaveBtn.Click += new System.EventHandler(this.cmdSaveBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(730, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "mg/dL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(730, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "mg/dL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(730, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "mg/dL";
            // 
            // minpBox
            // 
            this.minpBox.Location = new System.Drawing.Point(668, 201);
            this.minpBox.MaxLength = 3;
            this.minpBox.Name = "minpBox";
            this.minpBox.Size = new System.Drawing.Size(49, 22);
            this.minpBox.TabIndex = 25;
            this.minpBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Normal Superior:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(730, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "mg/dL";
            // 
            // minBox
            // 
            this.minBox.Location = new System.Drawing.Point(668, 176);
            this.minBox.MaxLength = 3;
            this.minBox.Name = "minBox";
            this.minBox.Size = new System.Drawing.Size(49, 22);
            this.minBox.TabIndex = 24;
            this.minBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maxBox
            // 
            this.maxBox.Location = new System.Drawing.Point(668, 151);
            this.maxBox.MaxLength = 3;
            this.maxBox.Name = "maxBox";
            this.maxBox.Size = new System.Drawing.Size(49, 22);
            this.maxBox.TabIndex = 23;
            this.maxBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maxPBox
            // 
            this.maxPBox.Location = new System.Drawing.Point(668, 126);
            this.maxPBox.MaxLength = 3;
            this.maxPBox.Name = "maxPBox";
            this.maxPBox.Size = new System.Drawing.Size(49, 22);
            this.maxPBox.TabIndex = 22;
            this.maxPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(472, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 128);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valor de Glicemia   Normal   E  Configuração de Limite";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Limite Superior:";
            // 
            // SettingUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 435);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmdSaveBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.minpBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.minBox);
            this.Controls.Add(this.maxBox);
            this.Controls.Add(this.maxPBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblMeterid1);
            this.Controls.Add(this.lblMeterid2);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SettingUser";
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.SettingUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblMeterid2;
        private System.Windows.Forms.Label lblMeterid1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSaveBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox minpBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox minBox;
        private System.Windows.Forms.TextBox maxBox;
        private System.Windows.Forms.TextBox maxPBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}