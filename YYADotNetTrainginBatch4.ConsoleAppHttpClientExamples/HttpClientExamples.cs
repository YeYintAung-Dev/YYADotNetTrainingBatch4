using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace YYADotNetTrainingBatch4.ConsoleAppHttpClientExamples;

public class HttpClientExamples
{
    private readonly HttpClient client = new HttpClient()
    {
        BaseAddress = new Uri("https://localhost:7287/")
    };
    private readonly string _blogEndPoint = "api/blog";

    public async Task Run()
    {
        await Read();
        //await Edit(1);
        //await Edit(100);
        //await Delete(18);
        // await Create("New BLOG", "New Author", "New Content");
        //await Update(19,"Update BLOG", "Update Author", "Update Content");
    }

    private async Task Read()
    {
        //var task = client.GetAsync("https://localhost:7244/api/blog");
        //task.RunSynchronously();

        var response = await client.GetAsync(_blogEndPoint);

        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonStr);

            List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
            foreach (var blog in lst)
            {
                Console.WriteLine(JsonConvert.SerializeObject(blog));
                Console.WriteLine($"Title => {blog.BlogTitle}");
                Console.WriteLine($"Author => {blog.BlogAuthor}");
                Console.WriteLine($"Content => {blog.BlogContent}");
            }
        }
    }

    private async Task Edit(int id)
    {
        var response = await client.GetAsync($"{_blogEndPoint}/{id}");
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;

            Console.WriteLine(JsonConvert.SerializeObject(jsonStr));
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
        }
        else
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }

    private async Task Delete(int id)
    {
        var response = await client.DeleteAsync($"{_blogEndPoint}/{id}");
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
        else
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }

    private async Task Create(string title, string author, string content)
    {
        BlogModel blog = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };  // C# Object

        // To Json
        string blogJson = JsonConvert.SerializeObject(blog);

        HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
        var response = await client.PostAsync(_blogEndPoint, httpContent);
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }

    private async Task Update(int id, string title, string author, string content)
    {
        BlogModel blog = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };  // C# Object

        // To Json
        string blogJson = JsonConvert.SerializeObject(blog);

        HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
        var response = await client.PutAsync($"{_blogEndPoint}/{id}", httpContent);
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
        else
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
    }
}
