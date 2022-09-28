using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;

namespace OneListClientReDo
{
    class Program
    {   
        // previously "static void..."
        static async Task Main(string [] args)
        {
            var token = ""; /* <-- using args to shape our responses for the first time in Dotnet*/

            if (args.Length == 0)
            {
                Console.WriteLine("What list would you like?");
                token = Console.ReadLine();
            }
            else 
            {
                token = args[0];
            }
            var client = new HttpClient(); /* make a client */

            // this code will happen at the SAME TIME our network request is going.
            // add await and the "static" environment changes 
            // var responseBodyAsString = await client.GetStringAsync("https://one-list-api.herokuapp.com/items?access_token=cohort24"); /* get a string */
            
            // adjust the format of the statement to accommodate "args".
            var responseBodyAsStream = await client.GetStreamAsync($"https://one-list-api.herokuapp.com/items?access_token={token}");

            // Console.WriteLine(responseBodyAsString); <-- no longer a string that we are retrieving -->

            // Mapping to item.cs
            // make the data De/Serialized
            var items = JsonSerializer.Deserialize<List<Item>>(responseBodyAsStream);
            
            var table = new ConsoleTable("Description", "Created At", "Completed");

            foreach (var item in items)
            {
                // Console.WriteLine($"The task {item.Text} was created on {item.CreatedAt} and has a completion status of {item.CompletedStatus}");
                table.AddRow(
                    item.Text, 
                    item.CreatedAt, 
                    item.CompletedStatus
                    );
            }
            table.Write();
        }
    }
}