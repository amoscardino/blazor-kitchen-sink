using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorKitchenSink.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorKitchenSink.Pages
{
    public partial class JavaScript
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private string Message;

        public async Task ShowMessageAsync()
            => await JSRuntime.InvokeVoidAsync("showMessage", Message ?? string.Empty);
    }
}