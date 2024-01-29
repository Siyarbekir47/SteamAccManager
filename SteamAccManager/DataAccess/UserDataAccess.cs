using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAccManager.Models;
using Newtonsoft.Json;
using Microsoft.VisualBasic.ApplicationServices;
using SteamAccManager.Models;
using SteamAccManager.DataAccess;



namespace SteamAccManager.DataAccess
{
    public class UserDataAccess
    {
        private readonly string _appFolder;

        public UserDataAccess(string appFolder)
        {
            _appFolder = appFolder;
        }


        public List<user> LoadUsers()
        {
            string usersFilePath = Path.Combine(_appFolder, "sysus.json");
            if (File.Exists(usersFilePath))
            {
                try
                {
                    string json = File.ReadAllText(usersFilePath);
                    return JsonConvert.DeserializeObject<List<user>>(json);
                }
                catch (Exception ex)
                {

                    throw new InvalidOperationException("Could not load users", ex);
                }
            }
            return new List<user>();
        }

        public void SaveUsers(List<user> users)
        {
            try
            {
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(Path.Combine(_appFolder, "sysus.json"), json);

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Could not save users", ex);
            }
        }

        public void AddNewUser(string user, string pass)
        {
            var newUser = new user(user, pass, false, null);
            var users = LoadUsers();
            users.Add(newUser);
            UserEncrypt(users); // This will update the storage with the new user list.
        }

        public void UserEncrypt(List<user> user)
        {
            var userlist = user;
            for (int i = 0; i < userlist.Count; i++)
            {
                if (!userlist[i].isPasswordEncrypted)
                {
                    // Encrypt only if the password isn't already encrypted
                    var encryptedUser = new user(userlist[i].username, CryptoUtility.EncryptString(userlist[i].password), true, null);
                    userlist[i] = encryptedUser; // Replace the old user struct with the new one
                }
            }
            // Now serialize and save the user list
            SaveUsers(userlist);
        }


    }
}
