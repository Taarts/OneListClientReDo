using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConsoleTables;

namespace OneListClientReDo
{
    class Program
    {   
        static async Task GetOneItem(string token, int id)
        {
            try{

            var client = new HttpClient();
             var responseBodyAsStream = await client.GetStreamAsync($"https://one-list-api.herokuapp.com/items/{id}?access_token={token}");
            var item = await JsonSerializer.DeserializeAsync<Item>(responseBodyAsStream);

            var table = new ConsoleTable("Description", "Created At", "Completed");
            table.AddRow(
                    item.Text, 
                    item.CreatedAt, 
                    item.CompletedStatus
                    );
                    table.Write();
        }
        catch(HttpRequestException)
        {
            Console.WriteLine("I could not find that item");
            
        }
            }
        static async Task ShowAllItems(string token)
        {
            var client = new HttpClient(); /* make a client */

         // this code will happen at the SAME TIME our network request is going.
            // add await and the "static" environment changes 
            // var responseBodyAsString = await client.GetStringAsync("https://one-list-api.herokuapp.com/items?access_token=cohort24"); /* get a string */
            
            // adjust the format of the statement to accommodate "args".
            var responseBodyAsStream = await client.GetStreamAsync($"https://one-list-api.herokuapp.com/items?access_token={token}");

            // Console.WriteLine(responseBodyAsString); <-- no longer a string that we are retrieving -->

            // Mapping to item.cs
            // make the data De/Serialized
              var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseBodyAsStream);
            
            var table = new ConsoleTable("Description", "Created At", "Completed");

            foreach (var item in items)
            {
                // Console.WriteLine($"The task {item.Text} was created on {item.CreatedAt} and has a completion status of {item.CompletedStatus}");
                table.AddRow(
                    item.Text, 
                    item.CreatedAt, 
                    item.CompletedStatus
                    );
                    table.Write();
            }
    }
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
            // using a switch statement to create a menu
            var keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Console.Write("Get (A)ll todo, (O)ne todo, or (Q)uit: ");
                var choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "Q":
                        keepGoing = false;
                        break;
                    case "O":
                        Console.Write("Enter the ID ");
                        var id = int.Parse(Console.ReadLine());

                        await GetOneItem(token, id);

                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        break;
                        
                    case "A":
                        await ShowAllItems(token);
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }           
        }
    }
}