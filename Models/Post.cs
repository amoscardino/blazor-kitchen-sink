using System;

namespace BlazorKitchenSink.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Path { get; set; }
    }
}