namespace GSM2._0
{
    partial class LOOK_BOOK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOOK_BOOK));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comMeterid = new System.Windows.Forms.ComboBox();
            this.Dayofweek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dayofweek,
            this.TestTime});
            this.dataGridView1.Location = new System.Drawing.Point(2, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1013, 601);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(5, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "nome do paciente:";
            // 
            // comMeterid
            // 
            this.comMeterid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMeterid.FormattingEnabled = true;
            this.comMeterid.Location = new System.Drawing.Point(154, 2);
            this.comMeterid.Name = "comMeterid";
            this.comMeterid.Size = new System.Drawing.Size(195, 20);
            this.comMeterid.TabIndex = 25;
            this.comMeterid.SelectedValueChanged += new System.EventHandler(this.comMeterid_SelectedValueChanged);
            this.comMeterid.Click += new System.EventHandler(this.comMeterid_Click);
            // 
            // Dayofweek
            // 
            this.Dayofweek.HeaderText = "Dia da Semana";
            this.Dayofweek.Name = "Dayofweek";
            this.Dayofweek.ReadOnly = true;
            this.Dayofweek.Width = 105;
            // 
            // TestTime
            // 
            this.TestTime.DataPropertyName = "TestTime";
            this.TestTime.HeaderText = "TestTime";
            this.TestTime.Name = "TestTime";
            // 
            // LOOK_BOOK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1015, 702);
            this.Controls.Add(this.comMeterid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOOK_BOOK";
            this.Text = "Lista Diária";
            this.Load += new System.EventHandler(this.LOOK_BOOK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comMeterid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dayofweek;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTime;
    }
}