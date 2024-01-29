using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SteamAccManager
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            passLabel = new Label();
            userLabel = new Label();
            showPasswordButton = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new Point(24, 66);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(57, 15);
            passLabel.TabIndex = 18;
            passLabel.Text = "Passwort:";
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Location = new Point(24, 21);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(86, 15);
            userLabel.TabIndex = 17;
            userLabel.Text = "Benutzername:";
            // 
            // showPasswordButton
            // 
            showPasswordButton.BackColor = SystemColors.ButtonHighlight;
            showPasswordButton.BackgroundImageLayout = ImageLayout.Center;
            showPasswordButton.FlatAppearance.BorderSize = 0;
            showPasswordButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            showPasswordButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            showPasswordButton.FlatStyle = FlatStyle.Flat;
            showPasswordButton.Location = new Point(217, 89);
            showPasswordButton.Name = "showPasswordButton";
            showPasswordButton.Size = new Size(25, 17);
            showPasswordButton.TabIndex = 16;
            showPasswordButton.UseVisualStyleBackColor = false;
            showPasswordButton.Click += showPasswordButton_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(24, 89);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(187, 23);
            textBox2.TabIndex = 15;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(24, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(187, 23);
            textBox1.TabIndex = 14;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown_1;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(24, 122);
            button1.Name = "button1";
            button1.Size = new Size(187, 65);
            button1.TabIndex = 13;
            button1.Text = "Benutzer hinzufügen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 209);
            Controls.Add(passLabel);
            Controls.Add(userLabel);
            Controls.Add(showPasswordButton);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "AddUserForm";
            Text = "Benutzer Hinzufügen";
            Load += AddUserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label passLabel;
        private Label userLabel;
        private Button showPasswordButton;
        private TextBox textBox2;
        private Button button1;
        private TextBox textBox1;
    }
}