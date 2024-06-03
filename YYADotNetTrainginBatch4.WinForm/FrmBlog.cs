using YYADotNetTrainingBatch4.Shared;
using YYADotNetTrainingBatch4.WinForm.Model;
using YYADotNetTrainingBatch4.WinForm.Queries;

namespace YYADotNetTrainingBatch4.WinForm;

public partial class FrmBlog : Form
{
    private List<BlogModel> blogList = new();
    private readonly int _blogId;
    DapperService _dapperService;// = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    public FrmBlog()
    {
        InitializeComponent();
        _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        GetBlogs();
    }

    public FrmBlog(int blogId)
    {
        InitializeComponent();
        _blogId = blogId;
        _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        var model = _dapperService.QueryFirstOrDefault<BlogModel>("select * from Tbl_Blog where BlogId = @BlogId",
            new { BlogId = _blogId });

        txtBlogTitle.Text = model.BlogTitle;
        txtBlogAuthor.Text = model.BlogAuthor;
        txtBlogContent.Text = model.BlogContent;
        btnSave.Visible = false;
        btnUpdate.Visible = true;
    }


    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            BlogModel blog = new BlogModel();
            blog.BlogTitle = txtBlogTitle.Text;
            blog.BlogAuthor = txtBlogAuthor.Text;
            blog.BlogContent = txtBlogContent.Text;

            int result = _dapperService.Execute(BlogQuery.BlogCreate, blog);
            string message = result > 0 ? "Saving successful." : "Saving failed.";
            MessageBox.Show(message, "Blog",
                MessageBoxButtons.OK,
                result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result > 0)
            {
                ClearControls();
            }
            GetBlogs();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    private void ClearControls()
    {
        txtBlogTitle.Clear();
        txtBlogAuthor.Clear();
        txtBlogContent.Clear();

        txtBlogTitle.Focus();
    }

    private void GetBlogs()
    {
        blogList = _dapperService.Query<BlogModel>(BlogQuery.GetBlogs);
        dataGrid.DataSource = blogList;
    }

    private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex % 2 != 0)
        {
            dataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            dataGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
        }
    }

    private void dataGrid_Click(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRows.Count > 0)
        {
            DataGridViewRow selectedRow = dataGrid.SelectedRows[0];

            string blogTitle = selectedRow.Cells[1].Value.ToString();
            string blogAuthor = selectedRow.Cells[2].Value.ToString();
            string blogContent = selectedRow.Cells[3].Value.ToString();

            AssignValue(blogTitle, blogAuthor, blogContent);
        }
        else
        {
            MessageBox.Show("No row is selected.");
        }
    }

    private void AssignValue(string title, string author, string content)
    {
        txtBlogTitle.Text = title;
        txtBlogAuthor.Text = author;
        txtBlogContent.Text = content;
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            var item = new BlogModel
            {
                BlogId = _blogId,
                BlogTitle = txtBlogTitle.Text.Trim(),
                BlogAuthor = txtBlogAuthor.Text.Trim(),
                BlogContent = txtBlogContent.Text.Trim()
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
                        SET [BlogTitle] = @BlogTitle
                        ,[BlogAuthor] = @BlogAuthor
                        ,[BlogContent] = @BlogContent
                        WHERE BlogId = @BlogId";
            int result = _dapperService.Execute(query, item);
            string message = result > 0 ? "Updating success" : "Updating failed";
            MessageBox.Show(message);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
}
