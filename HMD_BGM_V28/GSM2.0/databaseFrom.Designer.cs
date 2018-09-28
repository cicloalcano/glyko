namespace GSM2._0
{
    partial class databaseFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(databaseFrom));
            this.dataGridViewMenu = new System.Windows.Forms.DataGridView();
            this.comMeterid = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMenu
            // 
            this.dataGridViewMenu.AllowUserToAddRows = false;
            this.dataGridViewMenu.AllowUserToDeleteRows = false;
            this.dataGridViewMenu.Location = new System.Drawing.Point(0, 30);
            this.dataGridViewMenu.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewMenu.Name = "dataGridViewMenu";
            this.dataGridViewMenu.RowHeadersWidth = 50;
            this.dataGridViewMenu.RowTemplate.Height = 27;
            this.dataGridViewMenu.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMenu.Size = new System.Drawing.Size(988, 538);
            this.dataGridViewMenu.TabIndex = 0;
            this.dataGridViewMenu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewMenu_CellFormatting);
            this.dataGridViewMenu.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewMenu_DataBindingComplete);
            // 
            // comMeterid
            // 
            this.comMeterid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMeterid.FormattingEnabled = true;
            this.comMeterid.Location = new System.Drawing.Point(154, 5);
            this.comMeterid.Name = "comMeterid";
            this.comMeterid.Size = new System.Drawing.Size(195, 20);
            this.comMeterid.TabIndex = 47;
            this.comMeterid.SelectedValueChanged += new System.EventHandler(this.comMeterid_SelectedValueChanged);
            this.comMeterid.Click += new System.EventHandler(this.comMeterid_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 18);
            this.label3.TabIndex = 46;
            this.label3.Text = "nome do paciente:";
            // 
            // databaseFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 600);
            this.Controls.Add(this.comMeterid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "databaseFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de dados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.databaseFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMenu;
        private System.Windows.Forms.ComboBox comMeterid;
        private System.Windows.Forms.Label label3;
    }
}