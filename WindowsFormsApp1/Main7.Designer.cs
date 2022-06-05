
namespace WindowsFormsApp1
{
    partial class Main7
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dentityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAndTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userOperationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysLog1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xsxxDataSet2 = new WindowsFormsApp1.xsxxDataSet2();
            this.sysLog1TableAdapter = new WindowsFormsApp1.xsxxDataSet2TableAdapters.SysLog1TableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysLog1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsxxDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.dentityDataGridViewTextBoxColumn,
            this.dateAndTimeDataGridViewTextBoxColumn,
            this.userOperationDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sysLog1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(174, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(451, 335);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            // 
            // dentityDataGridViewTextBoxColumn
            // 
            this.dentityDataGridViewTextBoxColumn.DataPropertyName = "dentity";
            this.dentityDataGridViewTextBoxColumn.HeaderText = "dentity";
            this.dentityDataGridViewTextBoxColumn.Name = "dentityDataGridViewTextBoxColumn";
            // 
            // dateAndTimeDataGridViewTextBoxColumn
            // 
            this.dateAndTimeDataGridViewTextBoxColumn.DataPropertyName = "DateAndTime";
            this.dateAndTimeDataGridViewTextBoxColumn.HeaderText = "DateAndTime";
            this.dateAndTimeDataGridViewTextBoxColumn.Name = "dateAndTimeDataGridViewTextBoxColumn";
            // 
            // userOperationDataGridViewTextBoxColumn
            // 
            this.userOperationDataGridViewTextBoxColumn.DataPropertyName = "UserOperation";
            this.userOperationDataGridViewTextBoxColumn.HeaderText = "UserOperation";
            this.userOperationDataGridViewTextBoxColumn.Name = "userOperationDataGridViewTextBoxColumn";
            // 
            // sysLog1BindingSource
            // 
            this.sysLog1BindingSource.DataMember = "SysLog1";
            this.sysLog1BindingSource.DataSource = this.xsxxDataSet2;
            // 
            // xsxxDataSet2
            // 
            this.xsxxDataSet2.DataSetName = "xsxxDataSet2";
            this.xsxxDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sysLog1TableAdapter
            // 
            this.sysLog1TableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(609, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Main7";
            this.Text = "登录日志";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main7_FormClosing);
            this.Load += new System.EventHandler(this.Main7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysLog1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsxxDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private xsxxDataSet2 xsxxDataSet2;
        private System.Windows.Forms.BindingSource sysLog1BindingSource;
        private xsxxDataSet2TableAdapters.SysLog1TableAdapter sysLog1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dentityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAndTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userOperationDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}