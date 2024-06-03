using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YYADotNetTrainingBatch4.Shared;
using YYADotNetTrainingBatch4.WinForm;
using YYADotNetTrainingBatch4.WinForm.Model;
using YYADotNetTrainingBatch4.WinForm.Queries;

namespace YYADotNetTrainginBatch4.WinForm
{
    public partial class FrmBlogList : Form
    {
        private List<BlogModel> blogList = new();
        DapperService _dapperService;// = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        public FrmBlogList()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            GetBlogs();
        }

        private void GetBlogs()
        {
            blogList = _dapperService.Query<BlogModel>(BlogQuery.GetBlogs);
            dataGrid.DataSource = blogList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 != 0)
            {
                //dataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                //dataGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = (int)dataGrid.Rows[e.RowIndex].Cells[2].Value;
            if (e.ColumnIndex == (int)EnumActionType.Edit)
            {
                FrmBlog frmBlog = new FrmBlog(id);
                frmBlog.ShowDialog();

                GetBlogs();
            }
            if (e.ColumnIndex == (int)EnumActionType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult != DialogResult.Yes) return;

                DeleteBlog(id);
                GetBlogs();
            }
        }

        private void DeleteBlog(int id)
        {
            string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            int result = _dapperService.Execute(query, new { BlogId = id });
            string message = result > 0 ? "Deleting Successful" : "Deleting Fail";
            MessageBox.Show(message);
        }
    }
}
