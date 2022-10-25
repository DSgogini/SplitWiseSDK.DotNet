using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseSDK.DotNet.Entity
{
    public class Notifications
    {
        public bool Added_As_Friend { get; set; }
    }

    public class Picture
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Registration_Status { get; set; }
        public Picture Picture { get; set; }
        public DateTime Notifications_Read { get; set; }
        public int Notifications_Count { get; set; }
        public Notifications Notifications { get; set; }
        public string Default_Currency { get; set; }
        public string Locale { get; set; }
    }

    internal class UserApiRespose
    {
        public User User { get; set; }
    }
}
