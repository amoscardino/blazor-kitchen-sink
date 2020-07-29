using System.Collections.Generic;
using System.Threading.Tasks;
using AirtableApiClient;
using BlazorKitchenSink.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System;

namespace BlazorKitchenSink.Services
{
    public class ThingsData : IDisposable
    {
        private const string TABLE_NAME = "Things";

        private AirtableBase Airtable;

        public ThingsData(IConfiguration config)
        {
            var baseId = config.GetValue<string>("AirtableBaseId");
            var apiKey = config.GetValue<string>("AirtableApiKey");

            Airtable = new AirtableBase(apiKey, baseId);
        }

        public async Task<List<Thing>> GetThingsAsync()
        {
            var response = await Airtable.ListRecords(TABLE_NAME, maxRecords: int.MaxValue);

            if (response.Success)
                return response.Records.Select(record => new Thing(record)).ToList();

            return new List<Thing>();
        }

        public async Task<Thing> GetThingAsync(string id)
        {
            var response = await Airtable.RetrieveRecord(TABLE_NAME, id);

            if (response.Success)
                return new Thing(response.Record);

            return null;
        }

        public async Task<Thing> CreateThingAsync(Thing thing)
        {
            var response = await Airtable.CreateRecord(TABLE_NAME, thing.GetFields());

            if (response.Success)
                return new Thing(response.Record);

            return null;
        }

        public async Task UpdateThingAsync(Thing thing)
        {
            await Airtable.ReplaceRecord(TABLE_NAME, thing.GetFields(), thing.ThingId);
        }

        public async Task DeleteThingAsync(string id)
        {
            await Airtable.DeleteRecord(TABLE_NAME, id);
        }

        public void Dispose() => Airtable.Dispose();
    }
}