using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YYADotNetTrainingBatch4.WinForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YYADotNetTrainginBatch4.WinForm
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }
     
        private void newBlogTSMenu_Click(object sender, EventArgs e)
        {
            FrmBlog frmBlog = new FrmBlog();
            frmBlog.ShowDialog();
        }

        private void blogListTSMenu_Click(object sender, EventArgs e)
        {
            FrmBlogList frmBlogList = new FrmBlogList();
            frmBlogList.ShowDialog();
        }
    }
}
