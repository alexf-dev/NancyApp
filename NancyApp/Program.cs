using Nancy;
using Nancy.Hosting.Self;
using System;
using Topshelf;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var host = new NancyHost(new Uri("http://localhost:1234")))
            //{
            //    host.Start();

            //    Console.WriteLine("NancyFX Stand alone test application.");
            //    Console.WriteLine("Press enter to exit the application");
            //    Console.ReadLine();
            //}

            HostFactory.Run(x => x.Service<NancyRESTService>());
        }
    }    
}
