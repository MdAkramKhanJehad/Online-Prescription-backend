using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;

namespace Online_Prescription
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Console.WriteLine("Hello ak");
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 5002);
                    })
                    .Build();

                host.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           
        }

    }

}
