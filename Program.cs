using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OneListClientReDo
{
    class Program
    {   
        // previously "static void..."
        static async Task Main(string [] args)
        {
            var client = new HttpClient(); /* make a client */

            var responseBodyAsString = await client.GetStringAsync("https://one-list-api.herokuapp.com/items?access_token=cohort24"); /* get a string */

            // this code will happen at the SAME TIME our network request is going.
            // add await and the "static" environment changes 

            Console.WriteLine(responseBodyAsString);
            
        }
    }
}