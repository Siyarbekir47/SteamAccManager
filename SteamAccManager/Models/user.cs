using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccManager.Models
{
    public struct user
    {
        public user(string user, string pass, bool isPasswordEncrypted, string steamid)
        {
            username = user;
            password = pass;
            steamID64 = steamid;
            this.isPasswordEncrypted = isPasswordEncrypted;
        }

        public string username { get; set; }
        public string password { get; set; }
        public string steamID64 { get; set; }
        public bool isPasswordEncrypted { get; set; }
    }
}
