﻿using Newtonsoft.Json;
using RestSharp;

namespace YYADotNetTrainingBatch4.ConsoleAppRestClientExamples;

public class RestClientExamples
{
    private readonly RestClient _client = new RestClient(new Uri("https://localhost:7287"));
    private readonly string _blogEndpoint = "api/blog";
    public async Task RunAsync()
    {
        await ReadAsync();
        //await EditAsync(1);
        //await EditAsync(100);
        //await EditAsync(6002);

        //await CreateAsync("title", "author 2", "content 3");
        //await UpdateAsync(6002, "title 1", "author 2", "content 3");
        //await EditAsync(6002);
    }
    private async Task ReadAsync()
    {
        //RestRequest restRequest = new RestRequest(_blogEndpoint);
        //var response = await _client.GetAsync(restRequest);

        RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Get);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
            foreach (var item in lst)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
            }
        }
    }

    private async Task EditAsync(int id)
    {
        RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = response.Content!;
            var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
            Console.WriteLine(JsonConvert.SerializeObject(item));
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        BlogModel blogModel = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        }; // C# Object

        var restRequest = new RestRequest(_blogEndpoint, Method.Post);
        restRequest.AddJsonBody(blogModel);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        BlogModel blogModel = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        }; // C# Object


        var restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
        restRequest.AddJsonBody(blogModel);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
            // other process
            // continue...
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
            // error message
            // break
        }
    }
}
