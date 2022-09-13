using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneListClientReDo
{
    class Program
    {

        // static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            //  changed from "responseBodyAsString"
            var responseBodyAsStream = await client.GetStreamAsync("https://one-list-api.herokuapp.com/items?access_token=cohort24");
            //was not working before mis-commit from previous
            // Console.WriteLine(responseBodyAsString); <-- cannot return a "stream" in "Console.WriteLine"

            //                Describe the shape of the data(array in JSON => List, => items)
            //                                          v         v
            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseBodyAsStream);

            foreach (var item in items)
            {
                Console.WriteLine($"The task {item.text} was created {item.created_at} and was completed at {item.complete}");
            }
        }
    }
}
