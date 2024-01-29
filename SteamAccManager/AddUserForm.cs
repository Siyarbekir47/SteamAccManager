using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SteamAccManager.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SteamAccManager
{
    public partial class AddUserForm : Form
    {

        private Form1 mainForm;

        public AddUserForm(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Benutzername ist leer.");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Passwort ist leer.");
            }
            else
            {
                string user = textBox1.Text;
                string pass = textBox2.Text;
                mainForm.AddNewUser(user, pass);

                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void showPasswordButton_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                // Show the password
                textBox2.PasswordChar = '\0'; // Setting it to '\0' shows the text
                showPasswordButton.BackColor = Color.Green;
            }
            else
            {
                // Mask the password again
                textBox2.PasswordChar = '*'; // Setting it back to '*' masks the text
                showPasswordButton.BackColor = Color.Red;
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
