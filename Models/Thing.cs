using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using AirtableApiClient;
using Newtonsoft.Json;

namespace BlazorKitchenSink.Models
{
    public class Thing
    {
        public string ThingId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The Name field must be under 50 characters.")]
        public string Name { get; set; }

        [MinLength(20, ErrorMessage = "The Description field must be at least 50 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        [EmailAddress, DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public Thing() { }

        public Thing(AirtableRecord record)
        {
            ThingId = record.Id;

            Name = record.Fields.GetValueOrDefault("Name") as string;
            Description = record.Fields.GetValueOrDefault("Description") as string;
            IsActive = (record.Fields.GetValueOrDefault("Is Active") as bool?) ?? false;
            CreatedDate = DateTime.ParseExact(record.Fields["Created Date"] as string, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            EmailAddress = record.Fields.GetValueOrDefault("Email Address") as string;
        }

        public Fields GetFields()
        {
            var fields = new Fields();

            fields.AddField("Name", Name);
            fields.AddField("Description", Description);
            fields.AddField("Is Active", IsActive);
            fields.AddField("Email Address", EmailAddress);

            return fields;
        }
    }
}