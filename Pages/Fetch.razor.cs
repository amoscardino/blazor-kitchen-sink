using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorKitchenSink.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorKitchenSink.Pages
{
    public partial class Fetch
    {
        private const string POST_URL = "https://moscardino-cors.azurewebsites.net/api/proxy?url=https://moscardino.net/posts.json";
        private List<Post> Posts;

        [Inject]
        public HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Posts = await Http.GetFromJsonAsync<List<Post>>(POST_URL);

            for (int i = 0; i < Posts.Count; i++)
                Posts[i].Id = i;
        }
    }
}