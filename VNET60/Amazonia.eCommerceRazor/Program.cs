using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Amazonia.eCommerceRazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


            var teste = "";



            if (true)
            {

            }
        }


        public string exemplo(string a, string b, string b2, string b3, string b4, string b5, string b6, string b7, string b8, string b9, string b10, string b11)
        {
            return a + b + b3 + b2 + b4 + b6 + b5;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        

    }
}


