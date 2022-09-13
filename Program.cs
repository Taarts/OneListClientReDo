using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OneListClientReDo
{
    class Program
    {
        // static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseBodyAsString = await client.GetStringAsync("https://one-list-api.herokuapp.com/items?access_token=cohort24");

            Console.WriteLine(responseBodyAsString);
        }
    }
}
