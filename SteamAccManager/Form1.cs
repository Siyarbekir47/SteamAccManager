using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using SteamAccManager.Models;
using SteamAccManager.DataAccess;
using SteamAccManager.Services;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;




/* TODO:
dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false

-add search function for games, (all users)

-add some visuals on the left, like a profile picture, name, etc.
*/


namespace SteamAccManager
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
            );


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();






        private string appLocalFolder;
        private string myAppFolder;
        private string fullPath;
        private string myResourcesFolder;
        private string apiKey = "EDF2C147BDAEAD8453FB0FAA92E657E8";
        private Dictionary<string, List<string>> userGames = new Dictionary<string, List<string>>();
        private GameDataAccess _gameDataAccess;
        private UserDataAccess _userDataAccess;
        private SteamService _steamService;
        private string _appFolder;
        private List<GameInfo> _allGames;





        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            appLocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            myAppFolder = Path.Combine(appLocalFolder, "SM");
            myResourcesFolder = Path.Combine(myAppFolder, "Resources");
            fullPath = Path.Combine(myAppFolder, "syspl");
            _gameDataAccess = new GameDataAccess(myAppFolder);
            _userDataAccess = new UserDataAccess(myAppFolder);
            _steamService = new SteamService(apiKey, myAppFolder, myResourcesFolder);
        }


        public void AddNewUser(string user, string pass)
        {
            _userDataAccess.AddNewUser(user, pass);
            UpdateUserListUI();
            MessageBox.Show("Benutzer erfolgreich hinzugefügt.");
        }

        private void UpdateUserListUI()
        {
            var users = _userDataAccess.LoadUsers();

            if (users != null)
            {
                comboBox1.Items.Clear();
                foreach (var user in users)
                {
                    comboBox1.Items.Add(user.username);
                }
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
        }



        private void LoadGamesFromDataAccess()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string selectedUser = comboBox1.SelectedItem.ToString();
                string steamID64 = null;

                // Find the user
                List<user> userlist = _userDataAccess.LoadUsers();
                foreach (var user in userlist)
                {
                    if (user.username == selectedUser)
                    {
                        steamID64 = user.steamID64;
                        break;
                    }
                }

                if (steamID64 != null)
                {
                    try
                    {
                        List<GameInfo> loadedGames = _gameDataAccess.GetUserGames(steamID64);
                        _allGames = loadedGames;
                        UpdateGamesListUI(loadedGames);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        public void LoadUsersGames(string steamid64)
        {
            var loadedGames = _gameDataAccess.GetUserGames(steamid64);
            if (loadedGames != null)
            {
                // Clear the existing list and add the loaded games to lstGames
                lstvGames.Items.Clear();
                loadedGames.ForEach(loadedGames => lstvGames.Items.Add(loadedGames.Name));
                LoadGamesFromDataAccess();
            }
            else
            {
                MessageBox.Show("The games file is empty or contains invalid data.", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void UpdateGamesListUI(List<GameInfo> loadedGames)
        {
            lstvGames.Items.Clear();
            imgIcons.Images.Clear();

            foreach (var game in loadedGames)
            {
                string iconPath = _gameDataAccess.GetIconPath(game.AppID);
                Image img = Image.FromFile(iconPath);
                imgIcons.Images.Add(img);
                ListViewItem item = new ListViewItem(game.Name, imgIcons.Images.Count - 1);
                item.Tag = game.AppID;
                lstvGames.Items.Add(item);
            }

            lstvGames.ListViewItemSorter = new ListViewItemComparer(0, SortOrder.Ascending);
            lstvGames.Sort();

        }


        private async void CallAPI(string steamid64)
        {
            // Example of calling GetSteamBib
            try
            {
                await _steamService.GetSteamBib(steamid64);
                LoadUsersGames(steamid64);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            if (!Directory.Exists(myAppFolder))
            {
                Directory.CreateDirectory(myAppFolder);
            }
            if (!Directory.Exists(myResourcesFolder))
            {
                Directory.CreateDirectory(myResourcesFolder);
            }
            UpdateUserListUI();
            LoadGamesFromDataAccess();
            PnlNav.Height = panel2.Height;
            PnlNav.Top = panel2.Top;
            PnlNav.Left = panel2.Left;

        }




        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PnlNav.Height = button2.Height;
            PnlNav.Top = button2.Top;
            PnlNav.Left = button2.Left;
            button2.BackColor = Color.FromArgb(46, 51, 73);



            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Wähle erst einen Bentzer!");
                return;
            }


            foreach (var process in Process.GetProcessesByName("steam"))
            {
                process.Kill();
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamExe", "null");
            startInfo.Arguments = " -login " + _userDataAccess.LoadUsers()[comboBox1.SelectedIndex].username + " " + CryptoUtility.DecryptString(_userDataAccess.LoadUsers()[comboBox1.SelectedIndex].password);
            Process.Start(startInfo);



        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            PnlNav.Height = buttonStartGame.Height;
            PnlNav.Top = buttonStartGame.Top;
            PnlNav.Left = buttonStartGame.Left;
            buttonStartGame.BackColor = Color.FromArgb(46, 51, 73);

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Wähle erst einen Benutzer!");
                return;
            }


            string selectedGameAppID = "0";

            if (lstvGames.SelectedItems.Count > 0)
            {
                selectedGameAppID = lstvGames.SelectedItems[0].Tag.ToString(); // Assuming the Tag property holds the AppID
            }

            List<user> userlist = _userDataAccess.LoadUsers();
            string username = userlist[comboBox1.SelectedIndex].username;
            string decryptedPassword = CryptoUtility.DecryptString(userlist[comboBox1.SelectedIndex].password);
            _steamService.startGame(userlist, username, decryptedPassword, selectedGameAppID);


        }

        private void feetchGamesButton_Click(object sender, EventArgs e)
        {
            PnlNav.Height = feetchGamesButton.Height;
            PnlNav.Top = feetchGamesButton.Top;
            PnlNav.Left = feetchGamesButton.Left;
            feetchGamesButton.BackColor = Color.FromArgb(46, 51, 73);


            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Wähle zuerst einen Benutzer aus.");
                return;
            }
            string SteamID64 = GameDataAccess.GetCurrentSteamID64();

            if (SteamID64 != null)
            {
                Clipboard.SetText(SteamID64);
                CallAPI(SteamID64);
                LoadUsersGames(SteamID64);
                List<user> userlist = _userDataAccess.LoadUsers();

                for (int i = 0; i < userlist.Count; i++)
                {

                    if (userlist[i].username == comboBox1.SelectedItem.ToString())
                    {
                        user newUser = userlist[i];
                        newUser.steamID64 = SteamID64;
                        userlist[i] = newUser; // Replace the old struct with the new one
                        _userDataAccess.UserEncrypt(userlist); // This will update the storage with the new user list.
                        break;
                    }
                }

            }
            else
            {
                return;
            }

        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnShowPassword.Height;
            PnlNav.Top = btnShowPassword.Top;
            PnlNav.Left = btnShowPassword.Left;
            btnShowPassword.BackColor = Color.FromArgb(46, 51, 73);

            // Make sure a user is selected
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte wähle zuerst einen Benutzernamen.");
                return;
            }

            string selectedUser = comboBox1.SelectedItem.ToString();

            // Find the user object
            user? userToShow = _userDataAccess.LoadUsers().FirstOrDefault(u => u.username == selectedUser);

            if (userToShow.HasValue)
            {
                // Decrypt the password and show it
                string decryptedPassword = CryptoUtility.DecryptString(userToShow.Value.password);

                MessageBox.Show("Passwort für " + selectedUser + " ist: " + decryptedPassword, "Passwort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User not found.");
                return;
            }
        }

        private void btnCopyPassword_Click_1(object sender, EventArgs e)
        {
            PnlNav.Height = btnCopyPassword.Height;
            PnlNav.Top = btnCopyPassword.Top;
            PnlNav.Left = btnCopyPassword.Left;
            btnCopyPassword.BackColor = Color.FromArgb(46, 51, 73);



            // Make sure a user is selected
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte wähle zuerst einen Benutzernamen.");
                return;
            }

            string selectedUser = comboBox1.SelectedItem.ToString();

            // Find the user object
            user? userToShow = _userDataAccess.LoadUsers().FirstOrDefault(u => u.username == selectedUser);

            if (userToShow.HasValue)
            {
                // Decrypt the password and copy it
                string decryptedPassword = CryptoUtility.DecryptString(userToShow.Value.password);
                Clipboard.SetText(decryptedPassword);
                MessageBox.Show("In den Clipboard kopiert, STRG+V zum einfügen.");
            }
            else
            {
                MessageBox.Show("User not found.");
                return;
            }

        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            PnlNav.Height = addUserButton.Height;
            PnlNav.Top = addUserButton.Top;
            PnlNav.Left = addUserButton.Left;
            addUserButton.BackColor = Color.FromArgb(46, 51, 73);

            using (var addUserForm = new AddUserForm(this))
            {
                addUserForm.ShowDialog();
            }

        }


        private void deleteUser_Click(object sender, EventArgs e)
        {
            PnlNav.Height = deleteUser.Height;
            PnlNav.Top = deleteUser.Top;
            PnlNav.Left = deleteUser.Left;
            deleteUser.BackColor = Color.FromArgb(46, 51, 73);



            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Wähle erst einen benutzer aus.");
                return;

            }

            string selectedUser = comboBox1.SelectedItem.ToString();

            //confirmation dialog to make sure the user wants to delete this
            var confirmResult = MessageBox.Show("Sicher das du den Benutzer löschen willst?", "Löschen bestätigen!", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                //remove user from combobox
                comboBox1.Items.Remove(selectedUser);

                //remove user from userGames dictinoary
                if (userGames.ContainsKey(selectedUser))
                {
                    userGames.Remove(selectedUser);
                }

                //remove user from userlist and update storage
                List<user> userlist = _userDataAccess.LoadUsers();
                user userToRemove = userlist.First(u => u.username == selectedUser);
                if (userToRemove.username != null)
                {
                    userlist.Remove(userToRemove);
                    _userDataAccess.UserEncrypt(userlist);

                }
                if (File.Exists(Path.Combine(myAppFolder, userToRemove.steamID64 + "Gi.json")))
                {
                    File.Delete(Path.Combine(myAppFolder, userToRemove.steamID64 + "Gi.json"));
                }
                if (File.Exists(Path.Combine(myAppFolder, userToRemove.steamID64 + "Ai.json")))
                {
                    File.Delete(Path.Combine(myAppFolder, userToRemove.steamID64 + "Ai.json"));
                }
                lstvGames.Items.Clear();

            }


        }

        private void button2_Leave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void buttonStartGame_Leave(object sender, EventArgs e)
        {
            buttonStartGame.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void feetchGamesButton_Leave(object sender, EventArgs e)
        {
            feetchGamesButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnShowPassword_Leave(object sender, EventArgs e)
        {
            btnShowPassword.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCopyPassword_Leave(object sender, EventArgs e)
        {
            btnCopyPassword.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void addUserButton_Leave(object sender, EventArgs e)
        {
            addUserButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void deleteUser_Leave(object sender, EventArgs e)
        {
            deleteUser.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            lstvGames.Items.Clear();

            // Get the selected user's SteamID64 from the UserDataAccess.
            string steamID64 = _userDataAccess.LoadUsers()[comboBox1.SelectedIndex].steamID64;

            // Load the user's games.
            var loadedGames = _gameDataAccess.GetUserGames(steamID64);

            // Check if there's text to search for.
            string searchText = txtSearchBox.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchText) && searchText != "search for something...")
            {
                // If there is search text, filter the loaded games.
                loadedGames = loadedGames.Where(game => game.Name.ToLower().Contains(searchText)).ToList();
            }

            UpdateGamesListUI(loadedGames);

            string profileJsonPath = Path.Combine(myAppFolder, _userDataAccess.LoadUsers()[comboBox1.SelectedIndex].steamID64 + "Ai.json");
            if (File.Exists(profileJsonPath))
            {
                string jsonContent = File.ReadAllText(profileJsonPath);
                dynamic profileData = JsonConvert.DeserializeObject<dynamic>(jsonContent)[0];


                string profilePicUrl = profileData.ProfileIcon;
                string profileLink = profileData.ProfileLink;

                using (WebClient wc = new WebClient())
                {
                    byte[] bytes = wc.DownloadData(profilePicUrl);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        pictureBoxProfile.Image = Image.FromStream(ms);
                    }
                }

                linkLabelProfile.Tag = profileLink;

                linkLabelProfile.Text = profileData.Nickname;


            }

        }

        private void linkLabelProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelProfile.Tag is string url)
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
        }

        private void lstvGames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void labelGamesLibrary_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void txtSearchBox_Click(object sender, EventArgs e)
        {
            if (txtSearchBox.Text == "Search For Something...")
            {
                txtSearchBox.Clear();
            }

        }

        private void txtSearchBox_Leave(object sender, EventArgs e)
        {
            if (txtSearchBox.Text == "")
            {
                txtSearchBox.Text = "Search For Something...";
            }
        }
        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearchBox.Text.ToLower();
            List<GameInfo> filteredGames;

            // Make sure to load and assign _allGames before filtering
            if (!string.IsNullOrWhiteSpace(searchTerm) && txtSearchBox.Text != "Search For Something...")
            {
                // Filter the list based on the search term
                filteredGames = _allGames.Where(game => game.Name.ToLower().Contains(searchTerm)).ToList();
            }
            else
            {
                // If the search term is empty, use the full list
                filteredGames = _allGames;
            }

            // Update the ListView with the filtered list
            UpdateGamesListUI(filteredGames);
        }

        private void lstvGames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lstvGames.SelectedItems.Count > 0)
            {
                string selectedGameAppID = lstvGames.SelectedItems[0].Tag.ToString(); // Assuming the Tag property holds the AppID
                List<user> userlist = _userDataAccess.LoadUsers();
                string username = userlist[comboBox1.SelectedIndex].username;
                string decryptedPassword = CryptoUtility.DecryptString(userlist[comboBox1.SelectedIndex].password);
                _steamService.startGame(userlist, username, decryptedPassword, selectedGameAppID);
                Clipboard.SetText(selectedGameAppID);
            }
        }
    }
}
