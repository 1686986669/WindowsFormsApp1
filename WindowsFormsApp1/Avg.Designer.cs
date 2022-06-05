
namespace WindowsFormsApp1
{
    partial class Avg
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
            this.cnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xsxxDataSet6 = new WindowsFormsApp1.xsxxDataSet6();
            this.aVGTableAdapter = new WindowsFormsApp1.xsxxDataSet6TableAdapters.AVGTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aVGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsxxDataSet6)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnameDataGridViewTextBoxColumn,
            this.avgDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.aVGBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(37, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(556, 282);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cnameDataGridViewTextBoxColumn
            // 
            this.cnameDataGridViewTextBoxColumn.DataPropertyName = "Cname";
            this.cnameDataGridViewTextBoxColumn.HeaderText = "Cname";
            this.cnameDataGridViewTextBoxColumn.Name = "cnameDataGridViewTextBoxColumn";
            // 
            // avgDataGridViewTextBoxColumn
            // 
            this.avgDataGridViewTextBoxColumn.DataPropertyName = "avg";
            this.avgDataGridViewTextBoxColumn.HeaderText = "avg";
            this.avgDataGridViewTextBoxColumn.Name = "avgDataGridViewTextBoxColumn";
            // 
            // aVGBindingSource
            // 
            this.aVGBindingSource.DataMember = "AVG";
            this.aVGBindingSource.DataSource = this.xsxxDataSet6;
            // 
            // xsxxDataSet6
            // 
            this.xsxxDataSet6.DataSetName = "xsxxDataSet6";
            this.xsxxDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aVGTableAdapter
            // 
            this.aVGTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Avg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Avg";
            this.Text = "成绩统计";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Avg_FormClosing);
            this.Load += new System.EventHandler(this.Avg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aVGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xsxxDataSet6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private xsxxDataSet6 xsxxDataSet6;
        private System.Windows.Forms.BindingSource aVGBindingSource;
        private xsxxDataSet6TableAdapters.AVGTableAdapter aVGTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}