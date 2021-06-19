using ProductsServiceNamespace;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductRestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            ProductsServiceClient client = new ProductsServiceClient("https://localhost:5001", httpClient);
            var products = await client.GetAllProductsAsync();
            foreach (var p in products)
            {
                Console.WriteLine(p.Name);
            }


        }
    }
}
