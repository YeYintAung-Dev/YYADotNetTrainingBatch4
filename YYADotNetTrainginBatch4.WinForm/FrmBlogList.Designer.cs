namespace YYADotNetTrainginBatch4.WinForm
{
    partial class FrmBlogList
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGrid = new DataGridView();
            Edit = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            groupBox1 = new GroupBox();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.SpringGreen;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(192, 64, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGrid.ColumnHeadersHeight = 40;
            dataGrid.Columns.AddRange(new DataGridViewColumn[] { Edit, Delete });
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.GridColor = Color.FromArgb(192, 64, 0);
            dataGrid.Location = new Point(3, 28);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersVisible = false;
            dataGrid.RowHeadersWidth = 51;
            dataGrid.RowTemplate.Height = 29;
            dataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGrid.Size = new Size(1078, 395);
            dataGrid.TabIndex = 0;
            dataGrid.CellContentClick += dataGrid_CellContentClick;
            dataGrid.CellFormatting += dataGrid_CellFormatting;
            // 
            // Edit
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle2.ForeColor = Color.Green;
            Edit.DefaultCellStyle = dataGridViewCellStyle2;
            Edit.HeaderText = "Edit";
            Edit.MinimumWidth = 6;
            Edit.Name = "Edit";
            Edit.Text = "Edit";
            Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.ForeColor = Color.Red;
            Delete.DefaultCellStyle = dataGridViewCellStyle3;
            Delete.HeaderText = "Delete";
            Delete.MinimumWidth = 6;
            Delete.Name = "Delete";
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(dataGrid);
            groupBox1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.FromArgb(192, 0, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1084, 426);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Blog List";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(980, 455);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(116, 41);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FrmBlogList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1108, 505);
            Controls.Add(btnClose);
            Controls.Add(groupBox1);
            Name = "FrmBlogList";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Blog List";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGrid;
        private GroupBox groupBox1;
        private Button btnClose;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Delete;
    }
}