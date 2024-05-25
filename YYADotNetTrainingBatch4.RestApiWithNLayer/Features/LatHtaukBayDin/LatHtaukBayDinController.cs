using Newtonsoft.Json;

namespace YYADotNetTrainingBatch4.RestApiWithNLayer.Features.LatHtaukBayDin;

[Route("api/[controller]")]
[ApiController]
public class LatHtaukBayDinController : ControllerBase
{
    private async Task<LatHtaukBayDin> GetData()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
        var model = JsonConvert.DeserializeObject<LatHtaukBayDin>(jsonStr);
        return model!;
    }

    [HttpGet("questions")]
    public async Task<IActionResult> Questions()
    {
        var model = await GetData();
        return Ok(model.questions);
    }

    [HttpGet("numbers")]
    public async Task<IActionResult> NumberList()
    {
        var model = await GetData();
        return Ok(model.numberList);
    }

    [HttpGet("{QuestionNo}/{No}")]
    public async Task<IActionResult> Answers(int QuestionNo, int No)
    {
        var model = await GetData();
        return Ok(model.answers
            .FirstOrDefault(x=>
                x.questionNo == QuestionNo &&
                x.answerNo == No
            ));
    }


    public class LatHtaukBayDin
    {
        public Question[] questions { get; set; }
        public Answer[] answers { get; set; }
        public string[] numberList { get; set; }
    }

    public class Question
    {
        public int questionNo { get; set; }
        public string questionName { get; set; }
    }

    public class Answer
    {
        public int questionNo { get; set; }
        public int answerNo { get; set; }
        public string answerResult { get; set; }
    }

}
