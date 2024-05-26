using Newtonsoft.Json;

namespace YYADotNetTrainingBatch4.RestApiWithNLayer.Features.Birds;

[Route("api/[controller]")]
[ApiController]
public class BirdController : ControllerBase
{
    private async Task<BirdModel> GetDataAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("Birds.json");
        var model = JsonConvert.DeserializeObject<BirdModel>(jsonStr);
        return model!;
    }

    [HttpGet("birds")]
    public async Task<IActionResult> Birds()
    {
        var model = await GetDataAsync();
        return Ok(model.Tbl_Bird);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var model = await GetDataAsync();
        var item = model.Tbl_Bird.FirstOrDefault(x => x.Id == id);
        return Ok(item);
    }
}

public class BirdModel
{
    public Tbl_Bird[] Tbl_Bird { get; set; }
}

public class Tbl_Bird
{
    public int Id { get; set; }
    public string BirdMyanmarName { get; set; }
    public string BirdEnglishName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}
