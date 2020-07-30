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
        private string Message;

        [Inject] public IJSRuntime JSRuntime { get; set; }

        public async Task ShowMessageAsync() => await JSRuntime.InvokeVoidAsync("showMessage", Message ?? string.Empty);
    }
}