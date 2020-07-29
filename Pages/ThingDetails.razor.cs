using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorKitchenSink.Models;
using BlazorKitchenSink.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorKitchenSink.Pages
{
    public partial class ThingDetails
    {
        private Thing Thing = new Thing();

        [Parameter] public string Id { get; set; }
        [Inject] public ThingsData ThingsData { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Id != "new")
                Thing = await ThingsData.GetThingAsync(Id);
        }

        private async Task SaveThingAsync()
        {
            if (Thing.ThingId == null)
            {
                var newThing = await ThingsData.CreateThingAsync(Thing);

                NavigationManager.NavigateTo($"things/{newThing.ThingId}");
            }
            else
                await ThingsData.UpdateThingAsync(Thing);
        }
    }
}