using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneListClientReDo
{
    class Program
    {   
        // previously "static void..."
        static async Task Main(string [] args)
        {
            var client = new HttpClient(); /* make a client */

            // this code will happen at the SAME TIME our network request is going.
            // add await and the "static" environment changes 
            // var responseBodyAsString = await client.GetStringAsync("https://one-list-api.herokuapp.com/items?access_token=cohort24"); /* get a string */
            var responseBodyAsStream = await client.GetStreamAsync("https://one-list-api.herokuapp.com/items?access_token=cohort24"); /* get a string */

            // Console.WriteLine(responseBodyAsString); <-- no longer a string that we are retrieving -->

            // Mapping to item.cs
            // make the data De/Serialized
            var items = JsonSerializer.Deserialize<List<Item>>(responseBodyAsStream);
            
            foreach (var item in items)
            {
                Console.WriteLine($"The task {item.text} was created on {item.created_at} and has a completion of {item.complete}");
                
            }
            
        }
    }
}