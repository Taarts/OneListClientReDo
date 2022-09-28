using System;
using System.Text.Json.Serialization;

namespace OneListClientReDo
{
    public class Item
    {
        // not in Pascal case - ruby convention not C#
        // If you trust the api then let the information be converted by the method
        // Annotations convert the API format to something C# is comfortable with

        [JsonPropertyName ("id")]
        public int Id { get; set; }

        [JsonPropertyName ("text")]
        public string Text { get; set; }

        [JsonPropertyName ("complete")]
        public bool Complete { get; set; }

        [JsonPropertyName ("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName ("update_at")]
        public DateTime UpdatedAt { get; set; }

        public string CompletedStatus 
        {
            // custom "get" for a property about to be a turnery.
            get {
                // TURNERY statement
                // return Boolean expression ? value when true : value when false; <-- inline if/else
                return Complete ? "Completed" : "Not Completed";
            //     if (complete == true)
            //     {
            //         return "Completed";
            //     }
            //     else
            //     {
            //         return "Not completed";
            //     }
            }
        }
    }
}