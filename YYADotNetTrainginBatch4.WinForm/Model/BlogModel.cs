﻿namespace YYADotNetTrainingBatch4.WinForm.Model;

public class BlogModel
{
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}

//public record BlogEntity(int BlogId,string BlogTitle,string BlogAuthor,string BlogContent);
