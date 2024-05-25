using Dapper;
using System.Data;

namespace YYADotNetTrainingBatch4.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogDapperController : ControllerBase
{
    [HttpGet]
    public IActionResult GetBlogs()
    {
        string query = "select * from Tbl_Blog";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
        return Ok(lst);
    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(int id)
    {
        var item = FindById(id);
        if (item is null)
        {
            Console.WriteLine("No data found");
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateBlog(BlogModel blog)
    {
        string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        int result = db.Execute(query, blog);
        string message = result > 0 ? "Create success" : "Create fail";
        return Ok(message);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBlog(int id, BlogModel blog)
    {
        var item = FindById(id);
        if (item is null)
        {
            return NotFound();
        }

        string query = @"UPDATE [dbo].[Tbl_Blog]
                        SET [BlogTitle] = @BlogTitle
                        ,[BlogAuthor] = @BlogAuthor
                        ,[BlogContent] = @BlogContent
                        WHERE BlogId = @BlogId";
        blog.BlogId = id;
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, blog);

        string message = result > 0 ? "Update success" : "Update fail";
        return Ok(message);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchBlog(int id, BlogModel blog)
    {
        var item = FindById(id);
        if (item is null)
        {
            return NotFound("Data Not Found");
        }

        string conditions = string.Empty;

        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            conditions += "[BlogTitle] = @BlogTitle ,";
        }

        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            conditions += "[BlogAuthor] = @BlogAuthor ,";
        }

        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            conditions += "[BlogContent] = @BlogContent ";
        }

        if (conditions.Length == 0)
        {
            return NotFound("No Data to update");
        }

        conditions = conditions.Substring(0, conditions.Length - 1);
        blog.BlogId = id;
        string query = $@"UPDATE [dbo].[Tbl_Blog]
                        SET
                        {conditions}
                        WHERE BlogId = @BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, blog);

        string message = result > 0 ? "Update success" : "Update fail";
        return Ok(message);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(int id)
    {
        var item = FindById(id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }

        string query = "delete from Tbl_Blog WHERE BlogId = @BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        int result = db.Execute(query, new BlogModel { BlogId = id });
        string message = result > 0 ? "Delete success" : "Delete fail";
        return Ok(message);
    }

    private BlogModel? FindById(int id)
    {
        string query = "select * from Tbl_Blog where blogId = @BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
        return item;
    }
}
