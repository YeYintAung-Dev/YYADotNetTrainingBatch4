using DotNetTrainingBatch4.RestApi.Db;
using System.Reflection.Metadata;

namespace DotNetTrainingBatch4.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly AppDbContext _context;

    public BlogController()
    {
        _context = new AppDbContext();
    }

    [HttpGet]
    public IActionResult Read()
    {
        var lst = _context.Blogs.ToList();
        return Ok(lst);
    }

    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
        var blog = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (blog is null)
        {
            return NotFound("No Data Found");
        }
        return Ok(blog);
    }

    [HttpPost]
    public IActionResult Create(BlogModel blog)
    {
        _context.Blogs.Add(blog);
        int result = _context.SaveChanges();
        string message = result > 0 ? "Success to Save" : "Fail To Save";
        return Ok(message);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, BlogModel blog)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        int result = _context.SaveChanges();
        string message = result > 0 ? "Success to Update" : "Fail To Update";
        return Ok(message);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, BlogModel blog)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }

        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            item.BlogTitle = blog.BlogTitle;
        }

        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            item.BlogAuthor = blog.BlogAuthor;
        }

        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            item.BlogContent = blog.BlogContent;
        }

        int result = _context.SaveChanges();
        string message = result > 0 ? "Success to Update" : "Fail To Update";
        return Ok(message);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }

        _context.Blogs.Remove(item);

        int result = _context.SaveChanges();
        string message = result > 0 ? "Success to Delete" : "Fail To Delete";
        return Ok(message);
    }
}
