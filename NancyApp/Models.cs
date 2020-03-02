using Nancy;
using Nancy.Hosting.Self;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace NancyApp
{
    public class Dinosaur
    {
        public string Name { get; set; }
        public int HeightInFeet { get; set; }
        public string Status { get; set; }
    }

    public class DinosaurModule : NancyModule
    {
        private static Dinosaur dinosaur = new Dinosaur()
        {
            Name = "Tirex",
            HeightInFeet = 117,
            Status = "Hungry"
        };

        private static List<Dinosaur> dinosaurs = new List<Dinosaur>()
        {
            new Dinosaur() {
                Name = "Tirex",
                HeightInFeet = 117,
                Status = "Hungry"
            },
            new Dinosaur() {
                Name = "Kierkegaard",
                HeightInFeet = 6,
                Status = "Inflated"
            }
        };

        public DinosaurModule()
        {
            Get("/dinosaurs", parameters =>
            {
                return dinosaurs;
            });

            Get("/dinosaurs/{id}", parameters =>
            {
                return dinosaurs[parameters.id - 1];
            });

            Post("/dinosaurs", parameters =>
            {
                var model = this.Bind<Dinosaur>();
                dinosaurs.Add(model);
                return dinosaurs.Count.ToString();
            });
        }
    }

    public class NancyRESTService : Topshelf.ServiceControl
    {
        public static NancyHost NHost = null;
        public NancyRESTService()
        {
            NHost = new NancyHost(new Uri("http://localhost:1234"));
        }

        //public void Start()
        //{
        //    NHost.Start();            
        //}

        public bool Start(HostControl hostControl)
        {
            NHost.Start();
            return true;
        }

        //public void Stop()
        //{
        //    NHost.Stop();
        //}

        public bool Stop(HostControl hostControl)
        {
            NHost.Stop();
            return true;
        }
    }
}
