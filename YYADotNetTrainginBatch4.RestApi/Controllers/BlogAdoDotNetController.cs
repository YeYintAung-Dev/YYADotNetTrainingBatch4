﻿using System.Data.Common;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YYADotNetTrainingBatch4.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogAdoDotNetController : ControllerBase
{
    [HttpGet]
    public IActionResult GetBlogs()
    {
        string query = "select * from Tbl_Blog";

        SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);

        connection.Close();

        //List<BlogModel> lst = new List<BlogModel>();
        //foreach (DataRow dr in dt.Rows)
        //{
        //    //    BlogModel blog = new BlogModel();
        //    //    blog.BlogId = Convert.ToInt32(dr["BlogId"]);
        //    //    blog.BlogTitle = dr["BlogTitle"].ToString();
        //    //    blog.BlogAuthor = dr["BlogAuthor"].ToString();
        //    //    blog.BlogContent = dr["BlogContent"].ToString();
        //    BlogModel blog = new BlogModel
        //    {
        //        BlogId = Convert.ToInt32(dr["BlogId"]),
        //        BlogTitle = Convert.ToString(dr["BlogTitle"]),
        //        BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
        //        BlogContent = Convert.ToString(dr["BlogContent"])
        //    };

        //    lst.Add(blog);
        //}

        List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
        {
            BlogId = Convert.ToInt32(dr["BlogId"]),
            BlogTitle = Convert.ToString(dr["BlogTitle"]),
            BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            BlogContent = Convert.ToString(dr["BlogContent"])
        }).ToList();

        return Ok(lst);
    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(int id)
    {
        //string query = "select * from Tbl_Blog where BlogId = @BlogId";

        //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //connection.Open();

        //SqlCommand cmd = new SqlCommand(query, connection);
        //cmd.Parameters.AddWithValue("@BlogId", id);
        //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //sqlDataAdapter.Fill(dt);
        //connection.Close();

        //if (dt.Rows.Count == 0)
        //{
        //    return NotFound("No data found");
        //}

        //DataRow dr = dt.Rows[0];
        //var item = new BlogModel
        //{
        //    BlogId = Convert.ToInt32(dr["BlogId"]),
        //    BlogTitle = Convert.ToString(dr["BlogTitle"]),
        //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
        //    BlogContent = Convert.ToString(dr["BlogContent"])
        //};

        var item = FindById(id);
        if (item is null)
        {
            return NotFound("No data found");
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
           (@BlogTitle,
           @BlogAuthor,
		   @BlogContent)";

        SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
        cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
        cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Create success" : "Create fail";
        return Ok(message);
        //return StatusCode(500,message);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBlog(int id, BlogModel blog)
    {
        var item = FindById(id);
        if (item is null)
        {
            return NotFound("No data found");
        }

        string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

        SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
        cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
        cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Update Successful" : "Update Failed";
        return Ok(message);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchBlog(int id, BlogModel blog)
    {
        var item = FindById(id);
        if(item is null)
        {
            return NotFound("No data found");
        }

        string conditions = string.Empty;

        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            conditions += " [BlogTitle] = @BlogTitle, ";
        }

        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            conditions += " [BlogAuthor] = @BlogAuthor, ";
        }

        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            conditions += " [BlogContent] = @BlogContent, ";
        }

        if(conditions.Length > 0)
        {
            conditions = conditions.Substring(0, conditions.Length - 2);
        }

        string query = $@"UPDATE [dbo].[Tbl_Blog]
                        SET {conditions}
                        WHERE BlogId = @BlogId";

        SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
        cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
        cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Update Successful" : "Update Failed";
        return Ok(message);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(int id)
    {
        var item = FindById(id);
        if(item is null)
        {
            return NotFound("No data found");
        }

        SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Delete Successful" : "Delete Failed";
        return Ok(message);
    }

    private BlogModel FindById(int id)
    {
        string query = "select * from Tbl_Blog where BlogId = @BlogId";

        SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);
        connection.Close();
        if (dt.Rows.Count == 0)
        {
            return null!;
        }
        DataRow dr = dt.Rows[0];
        var item = new BlogModel
        {
            BlogId = Convert.ToInt32(dr["BlogId"]),
            BlogTitle = Convert.ToString(dr["BlogTitle"]),
            BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            BlogContent = Convert.ToString(dr["BlogContent"])
        };
        return item;
    }
}
