using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.ModelBinding;
using Topshelf;

namespace NancyApp
{
    public class UserInfoModule : NancyModule
    {
        private static List<UserInfo> users = new List<UserInfo>()
        {
            new UserInfo() {
                Login = "user1",
                Password = "qwerty1",
                RecDateText = new DateTime(2020, 3, 5, 11, 30, 22).ToString()
            },
            new UserInfo() {
                Login = "user2",
                Password = "qwerty2",
                RecDateText = new DateTime(2020, 3, 5, 12, 30, 22).ToString()
            }
        };

        public UserInfoModule()
        {
            Get("/users", parameters =>
            {
                return users;
            });

            Get("/users/{id}", parameters =>
            {
                if (users.Count > 0)
                    return users[parameters.id - 1];
                else
                    return "";
            });

            Post("/users", parameters =>
            {
                var model = this.Bind<UserInfo>();
                users.Add(model);
                return users.Count.ToString();
            });
        }
    }

    public class FileInfoModule : NancyModule
    {
        public FileInfoModule()
        {
            //Get("/users", parameters =>
            //{
            //    return users;
            //});

            //Get("/users/{id}", parameters =>
            //{
            //    if (users.Count > 0)
            //        return users[parameters.id - 1];
            //    else
            //        return "";
            //});

            Post("/files", parameters =>
            {
                string request = "";

                if (this.Request.Files != null)
                {
                    foreach (var model in this.Request.Files)
                    {
                        var filename = Path.Combine(Environment.CurrentDirectory + @"\", model.Name);

                        using (var fileStream = new FileStream(filename, FileMode.Create))
                        {
                            model.Value.CopyTo(fileStream);
                        }

                        request += "Saving " + model.Name + " is success.\r\n";                     
                    }
                }
                return !string.IsNullOrWhiteSpace(request) ? request : "";
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

        public bool Start(HostControl hostControl)
        {
            NHost.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            NHost.Stop();
            return true;
        }

        //public void Start()
        //{
        //    NHost.Start();            
        //}

        //public void Stop()
        //{
        //    NHost.Stop();
        //}       
    }
}
