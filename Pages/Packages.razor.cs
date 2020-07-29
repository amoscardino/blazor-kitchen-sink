using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorKitchenSink.Models;
using Microsoft.AspNetCore.Components;
using MarkdownSharp;

namespace BlazorKitchenSink.Pages
{
    public partial class Packages
    {
        [Inject]
        public Markdown Markdown { get; set; }

        private string Text;
        private string Html;

        private void UpdateHtml()
        {
            Text ??= string.Empty;

            Html = Markdown.Transform(Text);
        }
    }
}