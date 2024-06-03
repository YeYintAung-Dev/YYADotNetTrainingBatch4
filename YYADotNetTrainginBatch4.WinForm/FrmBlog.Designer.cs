namespace YYADotNetTrainingBatch4.WinForm
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblBlogTitle = new Label();
            txtBlogTitle = new TextBox();
            txtBlogAuthor = new TextBox();
            lblBlogAuthor = new Label();
            txtBlogContent = new TextBox();
            lblBlogContent = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            dataGrid = new DataGridView();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // lblBlogTitle
            // 
            lblBlogTitle.AutoSize = true;
            lblBlogTitle.Location = new Point(42, 46);
            lblBlogTitle.Name = "lblBlogTitle";
            lblBlogTitle.Size = new Size(73, 20);
            lblBlogTitle.TabIndex = 0;
            lblBlogTitle.Text = "Blog Title";
            // 
            // txtBlogTitle
            // 
            txtBlogTitle.Location = new Point(148, 43);
            txtBlogTitle.Name = "txtBlogTitle";
            txtBlogTitle.Size = new Size(303, 27);
            txtBlogTitle.TabIndex = 1;
            // 
            // txtBlogAuthor
            // 
            txtBlogAuthor.Location = new Point(148, 87);
            txtBlogAuthor.Name = "txtBlogAuthor";
            txtBlogAuthor.Size = new Size(303, 27);
            txtBlogAuthor.TabIndex = 3;
            // 
            // lblBlogAuthor
            // 
            lblBlogAuthor.AutoSize = true;
            lblBlogAuthor.Location = new Point(42, 90);
            lblBlogAuthor.Name = "lblBlogAuthor";
            lblBlogAuthor.Size = new Size(89, 20);
            lblBlogAuthor.TabIndex = 2;
            lblBlogAuthor.Text = "Blog Author";
            // 
            // txtBlogContent
            // 
            txtBlogContent.Location = new Point(148, 133);
            txtBlogContent.Multiline = true;
            txtBlogContent.Name = "txtBlogContent";
            txtBlogContent.Size = new Size(303, 95);
            txtBlogContent.TabIndex = 5;
            // 
            // lblBlogContent
            // 
            lblBlogContent.AutoSize = true;
            lblBlogContent.Location = new Point(46, 136);
            lblBlogContent.Name = "lblBlogContent";
            lblBlogContent.Size = new Size(96, 20);
            lblBlogContent.TabIndex = 4;
            lblBlogContent.Text = "Blog Content";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(357, 258);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(257, 258);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // dataGrid
            // 
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.BackgroundColor = SystemColors.ActiveCaption;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(505, 40);
            dataGrid.Name = "dataGrid";
            dataGrid.RowHeadersWidth = 51;
            dataGrid.RowTemplate.Height = 29;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Size = new Size(632, 345);
            dataGrid.TabIndex = 8;
            dataGrid.CellFormatting += dataGrid_CellFormatting;
            dataGrid.Click += dataGrid_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(357, 258);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 426);
            Controls.Add(btnUpdate);
            Controls.Add(dataGrid);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtBlogContent);
            Controls.Add(lblBlogContent);
            Controls.Add(txtBlogAuthor);
            Controls.Add(lblBlogAuthor);
            Controls.Add(txtBlogTitle);
            Controls.Add(lblBlogTitle);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBlogTitle;
        private TextBox txtBlogTitle;
        private TextBox txtBlogAuthor;
        private Label lblBlogAuthor;
        private TextBox txtBlogContent;
        private Label lblBlogContent;
        private Button btnSave;
        private Button btnCancel;
        private DataGridView dataGrid;
        private Button btnUpdate;
    }
}
