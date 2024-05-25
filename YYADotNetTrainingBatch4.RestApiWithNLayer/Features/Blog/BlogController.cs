using System.Data;

namespace YYADotNetTrainingBatch4.RestApiWithNLayer.Features.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly BL_Blog _blBlog;

    public BlogController()
    {
        _blBlog =new BL_Blog(); 
    }

    [HttpGet]
    public IActionResult GetBlogs()
    {
        var lst = _blBlog.GetBlogs();
        return Ok(lst);
    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(int id)
    {
        var item = _blBlog.GetBlog(id);
        if (item is null)
        {
            return NotFound("No data found");
        }
        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateBlog(BlogModel reqModel)
    {
        var result = _blBlog.CreateBlog(reqModel);
        string message = result > 0 ? "Create success" : "Create fail";
        return Ok(message);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBlog(int id, BlogModel blog)
    {
        var item = _blBlog.GetBlog(id);
        if (item is null)
        {
            return NotFound("No data found");
        }
        var result = _blBlog.UpdateBlog(id, blog);
        string message = result > 0 ? "Update Successful" : "Update Failed";
        return Ok(message);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchBlog(int id, BlogModel blog)
    {
        var item = _blBlog.GetBlog(id);
        if (item is null)
        {
            return NotFound("No data found");
        }
        var result = _blBlog.PatchBlog(id, blog);
        string message = result > 0 ? "PATCH Successful" : "PATCH Failed";
        return Ok(message);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(int id)
    {
        var item = _blBlog.GetBlog(id);
        if (item is null)
        {
            return NotFound("No data found");
        }

        var result = _blBlog.DeleteBlog(id);
        string message = result > 0 ? "Delete Successful" : "Delete Failed";
        return Ok(message);
    }

}
