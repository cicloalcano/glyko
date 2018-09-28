namespace GSM2._0
{
    partial class referenceForm3
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(referenceForm3));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maxPBox = new System.Windows.Forms.TextBox();
            this.maxBox = new System.Windows.Forms.TextBox();
            this.minBox = new System.Windows.Forms.TextBox();
            this.minpBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdSaveBtn = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Limite Superior:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Normal Superior:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Normal Inferior:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Limite Inferior:";
            // 
            // maxPBox
            // 
            this.maxPBox.Location = new System.Drawing.Point(256, 75);
            this.maxPBox.MaxLength = 3;
            this.maxPBox.Name = "maxPBox";
            this.maxPBox.Size = new System.Drawing.Size(49, 22);
            this.maxPBox.TabIndex = 10;
            this.maxPBox.Text = "126";
            this.maxPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxPBox.TextChanged += new System.EventHandler(this.maxBox_TextChanged);
            // 
            // maxBox
            // 
            this.maxBox.Location = new System.Drawing.Point(256, 100);
            this.maxBox.MaxLength = 3;
            this.maxBox.Name = "maxBox";
            this.maxBox.Size = new System.Drawing.Size(49, 22);
            this.maxBox.TabIndex = 11;
            this.maxBox.Text = "70";
            this.maxBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minBox
            // 
            this.minBox.Location = new System.Drawing.Point(256, 125);
            this.minBox.MaxLength = 3;
            this.minBox.Name = "minBox";
            this.minBox.Size = new System.Drawing.Size(49, 22);
            this.minBox.TabIndex = 12;
            this.minBox.Text = "126";
            this.minBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minpBox
            // 
            this.minpBox.Location = new System.Drawing.Point(256, 150);
            this.minpBox.MaxLength = 3;
            this.minpBox.Name = "minpBox";
            this.minpBox.Size = new System.Drawing.Size(49, 22);
            this.minpBox.TabIndex = 13;
            this.minpBox.Text = "70";
            this.minpBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "mg/dL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "mg/dL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(318, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "mg/dL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(318, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "mg/dL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(60, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 128);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valor de Glicemia   Normal   E  Configuração de Limite";
            // 
            // cmdSaveBtn
            // 
            this.cmdSaveBtn.Location = new System.Drawing.Point(149, 188);
            this.cmdSaveBtn.Name = "cmdSaveBtn";
            this.cmdSaveBtn.Size = new System.Drawing.Size(103, 23);
            this.cmdSaveBtn.TabIndex = 19;
            this.cmdSaveBtn.Text = "SALVAR";
            this.cmdSaveBtn.UseVisualStyleBackColor = true;
            this.cmdSaveBtn.Click += new System.EventHandler(this.cmdSaveBtn_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(270, 189);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(103, 23);
            this.cmdOK.TabIndex = 20;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(495, 31);
            this.label9.TabIndex = 21;
            this.label9.Text = "Escolha a unidade de glicemia e o valor de glicemia antes de pressionar SALVAR.";
            // 
            // referenceForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(496, 231);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdSaveBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.minpBox);
            this.Controls.Add(this.minBox);
            this.Controls.Add(this.maxBox);
            this.Controls.Add(this.maxPBox);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "referenceForm3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Parameters";
            this.Load += new System.EventHandler(this.referenceForm3_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maxPBox;
        private System.Windows.Forms.TextBox maxBox;
        private System.Windows.Forms.TextBox minBox;
        private System.Windows.Forms.TextBox minpBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdSaveBtn;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label9;
    }
}