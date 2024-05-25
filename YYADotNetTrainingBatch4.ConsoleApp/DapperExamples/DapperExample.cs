using Dapper;
using Dumpify;
using YYADotNetCore.ConsoleApp.Dtos;
using YYADotNetCore.ConsoleApp.Services;

namespace YYADotNetCore.ConsoleApp.DapperExamples;

public class DapperExample
{
    public void Run()
    {
        //Read();
        //Edit(1);
        //Create("Title Test", "Author Test", "Content Test");
        //Read();
        //Edit(10);
        //Update(10, "Update Tile", "Update Author", "Update Content");
        Delete(10);
        Edit(10);
    }

    private void Read()
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        List<BlogDto> lst = db.Query<BlogDto>("select * from Tbl_Blog").ToList();

        foreach (BlogDto blog in lst)
        {
            //Console.WriteLine(blog.BlogId); 
            //Console.WriteLine(blog.BlogTitle); 
            //Console.WriteLine(blog.BlogAuthor); 
            //Console.WriteLine(blog.BlogContent);
            //Console.WriteLine("=====================");
            blog.Dump();
        }

        lst.Dump();

        //using (IDbConnection db1 = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
        //{
        //}
    }

    private void Edit(int BlogId)
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //BlogDto? blog = db.Query<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = BlogId }).FirstOrDefault();
        var blog = db.Query<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = BlogId }).FirstOrDefault();

        if (blog is null)
        {
            Console.WriteLine("No Data found");
            return;
        }
        new { blog.BlogId, blog.BlogTitle, blog.BlogAuthor, blog.BlogContent }.Dump();
        blog.Dump();
    }

    private void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Saving Success" : "Fail to save";
        Console.WriteLine(message);
    }

    private void Update(int BlogId, string BlogTitle, string BlogAuthor, string BlogContent)
    {
        var item = new BlogDto { BlogId = BlogId, BlogTitle = BlogTitle, BlogAuthor = BlogAuthor, BlogContent = BlogContent };

        string query = @"UPDATE [dbo].[Tbl_Blog]
                        SET [BlogTitle] = @BlogTitle
                        ,[BlogAuthor] = @BlogAuthor
                        ,[BlogContent] = @BlogContent
                        WHERE BlogId = @BlogId";

        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        int result = db.Execute(query, item);

        string message = result > 0 ? "Update successful" : "Fail to Update";
        Console.WriteLine(message);
    }

    private void Delete(int BlogId)
    {
        var item = new BlogDto { BlogId = BlogId };
        string query = @"DELETE FROM [dbo].[Tbl_Blog]
                        WHERE BlogId = @BlogId";

        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        int result = db.Execute(query, item);

        string message = result > 0 ? "Delete succesful" : "Fail to delete";
        Console.WriteLine(message);
    }
}