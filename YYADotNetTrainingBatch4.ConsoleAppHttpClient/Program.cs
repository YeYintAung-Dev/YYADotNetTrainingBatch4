using Newtonsoft.Json;

Console.WriteLine("Hello, World!");


string json = await File.ReadAllTextAsync("data.json");
//Console.WriteLine(json);

// JSON to C#
// C# to JSON

var model = JsonConvert.DeserializeObject<MainDto>(json);
foreach (var question in model.questions)
{
    Console.WriteLine(question.questionNo);
}

Console.ReadLine();

static string ToNumber(string num)
{
    num = num.Replace("၁", "1");
    num = num.Replace("၂", "2");
    num = num.Replace("၃", "3");
    num = num.Replace("၄", "4");
    num = num.Replace("၅", "5");
    num = num.Replace("၆", "6");
    num = num.Replace("၇", "7");
    num = num.Replace("၈", "8");
    num = num.Replace("၉", "9");
    num = num.Replace("၀", "0");

    return num;
}

public class MainDto
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
