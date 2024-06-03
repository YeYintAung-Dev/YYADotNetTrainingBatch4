namespace YYADotNetTrainginBatch4.WinForm
{
    partial class FrmMainMenu
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
            menuStrip1 = new MenuStrip();
            blogToolStripMenuItem = new ToolStripMenuItem();
            newBlogTSMenu = new ToolStripMenuItem();
            blogListTSMenu = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.FromArgb(128, 255, 128);
            menuStrip1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { blogToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // blogToolStripMenuItem
            // 
            blogToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newBlogTSMenu, blogListTSMenu });
            blogToolStripMenuItem.ForeColor = Color.Maroon;
            blogToolStripMenuItem.Name = "blogToolStripMenuItem";
            blogToolStripMenuItem.Size = new Size(59, 36);
            blogToolStripMenuItem.Text = "Blog";
            // 
            // newBlogTSMenu
            // 
            newBlogTSMenu.BackColor = Color.FromArgb(255, 192, 192);
            newBlogTSMenu.Name = "newBlogTSMenu";
            newBlogTSMenu.Size = new Size(171, 26);
            newBlogTSMenu.Text = "New Blog";
            newBlogTSMenu.Click += newBlogTSMenu_Click;
            // 
            // blogListTSMenu
            // 
            blogListTSMenu.Name = "blogListTSMenu";
            blogListTSMenu.Size = new Size(171, 26);
            blogListTSMenu.Text = "Blogs";
            blogListTSMenu.Click += blogListTSMenu_Click;
            // 
            // FrmMainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimizeBox = false;
            Name = "FrmMainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog Management System";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem blogToolStripMenuItem;
        private ToolStripMenuItem newBlogTSMenu;
        private ToolStripMenuItem blogListTSMenu;
    }
}