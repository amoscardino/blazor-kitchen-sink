using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorKitchenSink.Pages
{
    public partial class JavaScript
    {
        private string Message;

        [Inject] public IJSRuntime JSRuntime { get; set; }

        public async Task ShowMessageAsync()
            => await JSRuntime.InvokeVoidAsync("showMessage", Message ?? string.Empty);
    }
}
