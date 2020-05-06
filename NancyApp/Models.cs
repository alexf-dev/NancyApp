using System;

namespace NancyApp
{
    public class Dinosaur
    {
        public string Name { get; set; }
        public int HeightInFeet { get; set; }
        public string Status { get; set; }
    }

    public class UserInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RecDateText { get; set; }
        public DateTime RecDate { get { return DateTime.Parse(RecDateText); } }
    }    
}
