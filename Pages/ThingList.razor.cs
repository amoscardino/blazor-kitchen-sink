using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorKitchenSink.Models;
using BlazorKitchenSink.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorKitchenSink.Pages
{
    public partial class ThingList
    {
        private List<Thing> Things;

        [Inject] public ThingsData ThingsData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var things = await ThingsData.GetThingsAsync();

            Things = things
                .OrderByDescending(thing => thing.IsActive)
                .ThenBy(thing => thing.Name)
                .ToList();
        }
    }
}