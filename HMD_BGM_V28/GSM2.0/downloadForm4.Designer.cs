namespace GSM2._0
{
    partial class downloadForm4
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(downloadForm4));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textUserID_3 = new System.Windows.Forms.TextBox();
            this.textUserID_2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textUserID_1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textUserID_0 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPersonDataSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPersonDataClear = new System.Windows.Forms.Button();
            this.labelUserID = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.labelBirthday = new System.Windows.Forms.Label();
            this.textGender = new System.Windows.Forms.TextBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.textBirthday = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.btnReadMeter = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OtherReportButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BarReading = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelRead = new System.Windows.Forms.Label();
            this.timerRt = new System.Windows.Forms.Timer(this.components);
            this.timerOP = new System.Windows.Forms.Timer(this.components);
            this.timeusb = new System.Windows.Forms.Timer(this.components);
            this.BarUpToWeb = new System.Windows.Forms.ProgressBar();
            this.btnPCToWeb = new System.Windows.Forms.Button();
            this.labelUpload = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(35, 130);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(162, 229);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Passo 1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(10, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 80);
            this.label3.TabIndex = 0;
            this.label3.Text = "Conecte o glicosímetro em seu computador através da interface do cabo.";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.textUserID_3);
            this.groupBox2.Controls.Add(this.textUserID_2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textUserID_1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textUserID_0);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnPersonDataSave);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnPersonDataClear);
            this.groupBox2.Controls.Add(this.labelUserID);
            this.groupBox2.Controls.Add(this.textUserName);
            this.groupBox2.Controls.Add(this.labelBirthday);
            this.groupBox2.Controls.Add(this.textGender);
            this.groupBox2.Controls.Add(this.labelGender);
            this.groupBox2.Controls.Add(this.textBirthday);
            this.groupBox2.Controls.Add(this.labelUserName);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(201, 130);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(315, 229);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Passo 2";
            // 
            // textUserID_3
            // 
            this.textUserID_3.Font = new System.Drawing.Font("Arial", 10F);
            this.textUserID_3.Location = new System.Drawing.Point(212, 102);
            this.textUserID_3.Name = "textUserID_3";
            this.textUserID_3.Size = new System.Drawing.Size(27, 23);
            this.textUserID_3.TabIndex = 30;
            this.textUserID_3.Text = "61";
            // 
            // textUserID_2
            // 
            this.textUserID_2.Font = new System.Drawing.Font("Arial", 10F);
            this.textUserID_2.Location = new System.Drawing.Point(169, 102);
            this.textUserID_2.Name = "textUserID_2";
            this.textUserID_2.Size = new System.Drawing.Size(35, 23);
            this.textUserID_2.TabIndex = 27;
            this.textUserID_2.Text = "618";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(203, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "-";
            // 
            // textUserID_1
            // 
            this.textUserID_1.Font = new System.Drawing.Font("Arial", 10F);
            this.textUserID_1.Location = new System.Drawing.Point(126, 102);
            this.textUserID_1.Name = "textUserID_1";
            this.textUserID_1.Size = new System.Drawing.Size(35, 23);
            this.textUserID_1.TabIndex = 26;
            this.textUserID_1.Text = "053";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(160, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = ".";
            // 
            // textUserID_0
            // 
            this.textUserID_0.Font = new System.Drawing.Font("Arial", 10F);
            this.textUserID_0.Location = new System.Drawing.Point(83, 102);
            this.textUserID_0.Name = "textUserID_0";
            this.textUserID_0.Size = new System.Drawing.Size(35, 23);
            this.textUserID_0.TabIndex = 19;
            this.textUserID_0.Text = "127";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(117, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = ".";
            // 
            // btnPersonDataSave
            // 
            this.btnPersonDataSave.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.btnPersonDataSave.Location = new System.Drawing.Point(240, 142);
            this.btnPersonDataSave.Name = "btnPersonDataSave";
            this.btnPersonDataSave.Size = new System.Drawing.Size(70, 27);
            this.btnPersonDataSave.TabIndex = 24;
            this.btnPersonDataSave.Text = "Salvar";
            this.btnPersonDataSave.UseVisualStyleBackColor = true;
            this.btnPersonDataSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(4, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(307, 48);
            this.label4.TabIndex = 1;
            this.label4.Text = "Seu glicosímetro irá ligar e mostrar [PC] antes de iniciar o download.";
            // 
            // btnPersonDataClear
            // 
            this.btnPersonDataClear.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.btnPersonDataClear.Location = new System.Drawing.Point(240, 113);
            this.btnPersonDataClear.Name = "btnPersonDataClear";
            this.btnPersonDataClear.Size = new System.Drawing.Size(70, 27);
            this.btnPersonDataClear.TabIndex = 23;
            this.btnPersonDataClear.Text = "Limpar";
            this.btnPersonDataClear.UseVisualStyleBackColor = true;
            this.btnPersonDataClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.labelUserID.Location = new System.Drawing.Point(5, 106);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(45, 15);
            this.labelUserID.TabIndex = 15;
            this.labelUserID.Text = "UserID";
            // 
            // textUserName
            // 
            this.textUserName.Font = new System.Drawing.Font("Arial", 10F);
            this.textUserName.Location = new System.Drawing.Point(83, 175);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(227, 23);
            this.textUserName.TabIndex = 22;
            this.textUserName.Text = "Obama Lin";
            // 
            // labelBirthday
            // 
            this.labelBirthday.AutoSize = true;
            this.labelBirthday.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.labelBirthday.Location = new System.Drawing.Point(5, 130);
            this.labelBirthday.Name = "labelBirthday";
            this.labelBirthday.Size = new System.Drawing.Size(54, 15);
            this.labelBirthday.TabIndex = 16;
            this.labelBirthday.Text = "Birthday";
            // 
            // textGender
            // 
            this.textGender.Font = new System.Drawing.Font("Arial", 10F);
            this.textGender.Location = new System.Drawing.Point(101, 151);
            this.textGender.Name = "textGender";
            this.textGender.Size = new System.Drawing.Size(120, 23);
            this.textGender.TabIndex = 21;
            this.textGender.Text = "1";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.labelGender.Location = new System.Drawing.Point(5, 154);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(48, 15);
            this.labelGender.TabIndex = 17;
            this.labelGender.Text = "Gender";
            // 
            // textBirthday
            // 
            this.textBirthday.Font = new System.Drawing.Font("Arial", 10F);
            this.textBirthday.Location = new System.Drawing.Point(101, 127);
            this.textBirthday.Name = "textBirthday";
            this.textBirthday.Size = new System.Drawing.Size(120, 23);
            this.textBirthday.TabIndex = 20;
            this.textBirthday.Text = "1955.12.23";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.labelUserName.Location = new System.Drawing.Point(5, 178);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(67, 15);
            this.labelUserName.TabIndex = 18;
            this.labelUserName.Text = "UserName";
            // 
            // btnReadMeter
            // 
            this.btnReadMeter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReadMeter.Location = new System.Drawing.Point(520, 412);
            this.btnReadMeter.Margin = new System.Windows.Forms.Padding(2);
            this.btnReadMeter.Name = "btnReadMeter";
            this.btnReadMeter.Size = new System.Drawing.Size(162, 27);
            this.btnReadMeter.TabIndex = 0;
            this.btnReadMeter.Text = "Começar Leitura";
            this.btnReadMeter.UseVisualStyleBackColor = true;
            this.btnReadMeter.Click += new System.EventHandler(this.btnReadMeter_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.OtherReportButton);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(520, 130);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(162, 229);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Passo 3";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.Location = new System.Drawing.Point(12, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 48);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ver relatórios após o download.";
            // 
            // OtherReportButton
            // 
            this.OtherReportButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OtherReportButton.Location = new System.Drawing.Point(4, 125);
            this.OtherReportButton.Margin = new System.Windows.Forms.Padding(2);
            this.OtherReportButton.Name = "OtherReportButton";
            this.OtherReportButton.Size = new System.Drawing.Size(154, 27);
            this.OtherReportButton.TabIndex = 2;
            this.OtherReportButton.Text = "Ver Relatórios ...";
            this.OtherReportButton.UseVisualStyleBackColor = true;
            this.OtherReportButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(4, 80);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Gráfico de Linha";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(98, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 42);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(505, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Esta operação permitirá o download das leituras armazenadas no seu Sistema de Mon" +
                "itoramento de Glicemia e a sua inserção na base de dados.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(196, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "Baixar Leituras do Glicosímetro";
            // 
            // BarReading
            // 
            this.BarReading.Location = new System.Drawing.Point(8, 32);
            this.BarReading.Margin = new System.Windows.Forms.Padding(2);
            this.BarReading.Name = "BarReading";
            this.BarReading.Size = new System.Drawing.Size(434, 18);
            this.BarReading.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelRead);
            this.panel2.Controls.Add(this.BarReading);
            this.panel2.Location = new System.Drawing.Point(35, 365);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 56);
            this.panel2.TabIndex = 11;
            // 
            // labelRead
            // 
            this.labelRead.AutoSize = true;
            this.labelRead.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelRead.Location = new System.Drawing.Point(88, 5);
            this.labelRead.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRead.Name = "labelRead";
            this.labelRead.Size = new System.Drawing.Size(148, 16);
            this.labelRead.TabIndex = 11;
            this.labelRead.Text = "Lendo mensagem...";
            // 
            // timerRt
            // 
            this.timerRt.Interval = 20;
            this.timerRt.Tick += new System.EventHandler(this.timerRt_Tick);
            // 
            // timerOP
            // 
            this.timerOP.Interval = 120;
            this.timerOP.Tick += new System.EventHandler(this.timerOP_Tick);
            // 
            // timeusb
            // 
            this.timeusb.Enabled = true;
            this.timeusb.Interval = 6000;
            this.timeusb.Tick += new System.EventHandler(this.timeusb_Tick);
            // 
            // BarUpToWeb
            // 
            this.BarUpToWeb.Location = new System.Drawing.Point(43, 444);
            this.BarUpToWeb.Name = "BarUpToWeb";
            this.BarUpToWeb.Size = new System.Drawing.Size(434, 18);
            this.BarUpToWeb.TabIndex = 12;
            // 
            // btnPCToWeb
            // 
            this.btnPCToWeb.Enabled = false;
            this.btnPCToWeb.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.btnPCToWeb.Location = new System.Drawing.Point(520, 442);
            this.btnPCToWeb.Name = "btnPCToWeb";
            this.btnPCToWeb.Size = new System.Drawing.Size(162, 27);
            this.btnPCToWeb.TabIndex = 13;
            this.btnPCToWeb.Text = "PC Upload Web";
            this.btnPCToWeb.UseVisualStyleBackColor = true;
            this.btnPCToWeb.Visible = false;
            this.btnPCToWeb.Click += new System.EventHandler(this.btnPCToWeb_Click);
            // 
            // labelUpload
            // 
            this.labelUpload.AutoSize = true;
            this.labelUpload.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold);
            this.labelUpload.Location = new System.Drawing.Point(124, 423);
            this.labelUpload.Name = "labelUpload";
            this.labelUpload.Size = new System.Drawing.Size(60, 16);
            this.labelUpload.TabIndex = 14;
            this.labelUpload.Text = "Upload";
            // 
            // downloadForm4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(761, 568);
            this.Controls.Add(this.labelUpload);
            this.Controls.Add(this.btnPCToWeb);
            this.Controls.Add(this.BarUpToWeb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReadMeter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "downloadForm4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baixar Leituras do Glicosímetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.downloadForm4_FormClosing);
            this.Load += new System.EventHandler(this.downloadForm4_Load);
            this.Shown += new System.EventHandler(this.downloadForm4_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReadMeter;
        private System.Windows.Forms.Button OtherReportButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar BarReading;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelRead;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timerRt;
        private System.Windows.Forms.Timer timerOP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timeusb;
        private System.Windows.Forms.ProgressBar BarUpToWeb;
        private System.Windows.Forms.Button btnPCToWeb;
        private System.Windows.Forms.Label labelUpload;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textUserID_0;
        private System.Windows.Forms.TextBox textBirthday;
        private System.Windows.Forms.TextBox textGender;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.Button btnPersonDataClear;
        private System.Windows.Forms.Button btnPersonDataSave;
        private System.Windows.Forms.TextBox textUserID_3;
        private System.Windows.Forms.TextBox textUserID_2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textUserID_1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        
    }
}