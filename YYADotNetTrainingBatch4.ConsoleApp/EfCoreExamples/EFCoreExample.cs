
using Dumpify;
using YYADotNetCore.ConsoleApp.Dtos;

namespace YYADotNetCore.ConsoleApp.EfCoreExamples;

public class EFCoreExample
{
    private readonly AppDbContext db = new();

    public void Run()
    {
        Read();
        //Edit(8);
        //Create("New Title", "New Author", "New Content");
        //Update(12, "Update Title", "Update Author", "Update Content");
        Delete(12);
    }

    private void Read()
    {
        var lst = db.Blogs.ToList();

        foreach (BlogDto blog in lst)
        {
            blog.Dump();
        }

        lst.Dump();
    }

    private void Edit(int id)
    {
        var blog = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (blog is null)
        {
            Console.WriteLine("Data Not Found");
            return;
        }

        blog.Dump();
    }

    private void Create(string BlogTitle, string BlogAuthor, string BlogContent)
    {
        var item = new BlogDto
        {
            BlogTitle = BlogTitle,
            BlogAuthor = BlogAuthor,
            BlogContent = BlogContent
        };

        db.Blogs.Add(item);
        int result = db.SaveChanges();

        string message = result > 0 ? "Saving success" : "Fail to save";
        Console.WriteLine(message);
    }

    private void Update(int id, string title, string author, string content)
    {
        var blog = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (blog is null)
        {
            Console.WriteLine("Data Not Found");
            return;
        }

        blog.BlogTitle = title;
        blog.BlogAuthor = author;
        blog.BlogContent = content;

        int result = db.SaveChanges();
        string message = result > 0 ? "Update successful" : "Fail to update";
        Console.WriteLine(message);
    }

    private void Delete(int id)
    {
        var blog = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (blog is null)
        {
            Console.WriteLine("Data Not Found");
            return;
        }

        db.Blogs.Remove(blog);
        int result = db.SaveChanges();
        string message = result > 0 ? "Delete successful" : "Fail to delete";
        Console.WriteLine(message);
    }
}
