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

            //HostFactory.Run(x =>                               //1
            //{

            //    x.Service<NancyRESTService>(s =>                      //2
            //    {
            //        s.ConstructUsing(name => new NancyRESTService()); //3
            //        s.WhenStarted(tc => tc.Start());           //4 
            //        s.WhenStopped(tc => tc.Stop());            //5
            //    });
            //    x.RunAsLocalSystem();                          //6

            //    x.SetDescription("Alex_F Sample Topshelf Host");      //7
            //    x.SetDisplayName("Alex_F Stuff");                     //8
            //    x.SetServiceName("Alex_F Stuff");                     //9
            //});
        }
    }    
}
