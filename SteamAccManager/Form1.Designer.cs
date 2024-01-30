namespace SteamAccManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            PnlNav = new Panel();
            feetchGamesButton = new Button();
            btnShowPassword = new Button();
            btnCopyPassword = new Button();
            buttonStartGame = new Button();
            addUserButton = new Button();
            button2 = new Button();
            deleteUser = new Button();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            linkLabelProfile = new LinkLabel();
            pictureBoxProfile = new PictureBox();
            labelGamesLibrary = new Label();
            txtSearchBox = new TextBox();
            lstvGames = new ListView();
            tabFirst = new ColumnHeader();
            imgIcons = new ImageList(components);
            exitButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(PnlNav);
            panel1.Controls.Add(feetchGamesButton);
            panel1.Controls.Add(btnShowPassword);
            panel1.Controls.Add(btnCopyPassword);
            panel1.Controls.Add(buttonStartGame);
            panel1.Controls.Add(addUserButton);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(deleteUser);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(266, 577);
            panel1.TabIndex = 0;
            // 
            // PnlNav
            // 
            PnlNav.BackColor = Color.FromArgb(0, 126, 249);
            PnlNav.Location = new Point(0, 303);
            PnlNav.Name = "PnlNav";
            PnlNav.Size = new Size(3, 100);
            PnlNav.TabIndex = 2;
            // 
            // feetchGamesButton
            // 
            feetchGamesButton.BackColor = Color.Transparent;
            feetchGamesButton.Dock = DockStyle.Bottom;
            feetchGamesButton.FlatAppearance.BorderSize = 0;
            feetchGamesButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 51, 72);
            feetchGamesButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 72);
            feetchGamesButton.FlatStyle = FlatStyle.Flat;
            feetchGamesButton.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            feetchGamesButton.ForeColor = Color.FromArgb(0, 126, 249);
            feetchGamesButton.Image = (Image)resources.GetObject("feetchGamesButton.Image");
            feetchGamesButton.ImageAlign = ContentAlignment.MiddleRight;
            feetchGamesButton.Location = new Point(0, 367);
            feetchGamesButton.Name = "feetchGamesButton";
            feetchGamesButton.RightToLeft = RightToLeft.No;
            feetchGamesButton.Size = new Size(266, 42);
            feetchGamesButton.TabIndex = 3;
            feetchGamesButton.Text = "Feetch";
            feetchGamesButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            feetchGamesButton.UseMnemonic = false;
            feetchGamesButton.UseVisualStyleBackColor = false;
            feetchGamesButton.Click += feetchGamesButton_Click;
            feetchGamesButton.Leave += feetchGamesButton_Leave;
            // 
            // btnShowPassword
            // 
            btnShowPassword.BackColor = Color.Transparent;
            btnShowPassword.Dock = DockStyle.Bottom;
            btnShowPassword.FlatAppearance.BorderSize = 0;
            btnShowPassword.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 51, 72);
            btnShowPassword.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 72);
            btnShowPassword.FlatStyle = FlatStyle.Flat;
            btnShowPassword.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            btnShowPassword.ForeColor = Color.FromArgb(0, 126, 249);
            btnShowPassword.Image = (Image)resources.GetObject("btnShowPassword.Image");
            btnShowPassword.ImageAlign = ContentAlignment.MiddleRight;
            btnShowPassword.Location = new Point(0, 409);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.RightToLeft = RightToLeft.No;
            btnShowPassword.Size = new Size(266, 42);
            btnShowPassword.TabIndex = 3;
            btnShowPassword.Text = "Show Password";
            btnShowPassword.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnShowPassword.UseMnemonic = false;
            btnShowPassword.UseVisualStyleBackColor = false;
            btnShowPassword.Click += btnShowPassword_Click;
            btnShowPassword.Leave += btnShowPassword_Leave;
            // 
            // btnCopyPassword
            // 
            btnCopyPassword.BackColor = Color.Transparent;
            btnCopyPassword.Dock = DockStyle.Bottom;
            btnCopyPassword.FlatAppearance.BorderSize = 0;
            btnCopyPassword.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 51, 72);
            btnCopyPassword.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 72);
            btnCopyPassword.FlatStyle = FlatStyle.Flat;
            btnCopyPassword.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            btnCopyPassword.ForeColor = Color.FromArgb(0, 126, 249);
            btnCopyPassword.Image = (Image)resources.GetObject("btnCopyPassword.Image");
            btnCopyPassword.ImageAlign = ContentAlignment.MiddleRight;
            btnCopyPassword.Location = new Point(0, 451);
            btnCopyPassword.Name = "btnCopyPassword";
            btnCopyPassword.RightToLeft = RightToLeft.No;
            btnCopyPassword.Size = new Size(266, 42);
            btnCopyPassword.TabIndex = 3;
            btnCopyPassword.Text = "Copy Password";
            btnCopyPassword.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCopyPassword.UseMnemonic = false;
            btnCopyPassword.UseVisualStyleBackColor = false;
            btnCopyPassword.Click += btnCopyPassword_Click_1;
            btnCopyPassword.Leave += btnCopyPassword_Leave;
            // 
            // buttonStartGame
            // 
            buttonStartGame.BackColor = Color.Transparent;
            buttonStartGame.Dock = DockStyle.Top;
            buttonStartGame.FlatAppearance.BorderSize = 0;
            buttonStartGame.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 51, 72);
            buttonStartGame.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 72);
            buttonStartGame.FlatStyle = FlatStyle.Flat;
            buttonStartGame.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            buttonStartGame.ForeColor = Color.FromArgb(0, 126, 249);
            buttonStartGame.Image = (Image)resources.GetObject("buttonStartGame.Image");
            buttonStartGame.ImageAlign = ContentAlignment.MiddleRight;
            buttonStartGame.Location = new Point(0, 264);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.RightToLeft = RightToLeft.No;
            buttonStartGame.Size = new Size(266, 70);
            buttonStartGame.TabIndex = 2;
            buttonStartGame.Text = "Quick Start";
            buttonStartGame.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonStartGame.UseMnemonic = false;
            buttonStartGame.UseVisualStyleBackColor = false;
            buttonStartGame.Click += buttonStartGame_Click;
            buttonStartGame.Leave += buttonStartGame_Leave;
            // 
            // addUserButton
            // 
            addUserButton.BackColor = Color.Transparent;
            addUserButton.Dock = DockStyle.Bottom;
            addUserButton.FlatAppearance.BorderSize = 0;
            addUserButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 51, 72);
            addUserButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 72);
            addUserButton.FlatStyle = FlatStyle.Flat;
            addUserButton.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            addUserButton.ForeColor = Color.FromArgb(0, 126, 249);
            addUserButton.Image = (Image)resources.GetObject("addUserButton.Image");
            addUserButton.ImageAlign = ContentAlignment.MiddleRight;
            addUserButton.Location = new Point(0, 493);
            addUserButton.Name = "addUserButton";
            addUserButton.RightToLeft = RightToLeft.No;
            addUserButton.Size = new Size(266, 42);
            addUserButton.TabIndex = 3;
            addUserButton.Text = "Add new User";
            addUserButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            addUserButton.UseMnemonic = false;
            addUserButton.UseVisualStyleBackColor = false;
            addUserButton.Click += addUserButton_Click;
            addUserButton.Leave += addUserButton_Leave;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 51, 72);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 72);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            button2.ForeColor = Color.FromArgb(0, 126, 249);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.Location = new Point(0, 194);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.No;
            button2.Size = new Size(266, 70);
            button2.TabIndex = 1;
            button2.Text = "Login";
            button2.TextImageRelation = TextImageRelation.TextBeforeImage;
            button2.UseMnemonic = false;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.Leave += button2_Leave;
            // 
            // deleteUser
            // 
            deleteUser.BackColor = Color.Transparent;
            deleteUser.Dock = DockStyle.Bottom;
            deleteUser.FlatAppearance.BorderSize = 0;
            deleteUser.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 51, 72);
            deleteUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 72);
            deleteUser.FlatStyle = FlatStyle.Flat;
            deleteUser.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            deleteUser.ForeColor = Color.FromArgb(0, 126, 249);
            deleteUser.Image = (Image)resources.GetObject("deleteUser.Image");
            deleteUser.ImageAlign = ContentAlignment.MiddleRight;
            deleteUser.Location = new Point(0, 535);
            deleteUser.Name = "deleteUser";
            deleteUser.RightToLeft = RightToLeft.No;
            deleteUser.Size = new Size(266, 42);
            deleteUser.TabIndex = 3;
            deleteUser.Text = "Delete User";
            deleteUser.TextImageRelation = TextImageRelation.TextBeforeImage;
            deleteUser.UseMnemonic = false;
            deleteUser.UseVisualStyleBackColor = false;
            deleteUser.Click += deleteUser_Click;
            deleteUser.Leave += deleteUser_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(linkLabelProfile);
            panel2.Controls.Add(pictureBoxProfile);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(266, 194);
            panel2.TabIndex = 0;
            panel2.MouseDown += panel2_MouseDown;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(45, 51, 72);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("MS PGothic", 12F);
            comboBox1.ForeColor = Color.FromArgb(158, 161, 176);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(16, 170);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(236, 24);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // linkLabelProfile
            // 
            linkLabelProfile.ActiveLinkColor = Color.FromArgb(0, 126, 249);
            linkLabelProfile.AutoSize = true;
            linkLabelProfile.DisabledLinkColor = Color.FromArgb(0, 126, 249);
            linkLabelProfile.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            linkLabelProfile.ForeColor = Color.FromArgb(0, 126, 249);
            linkLabelProfile.LinkColor = Color.FromArgb(0, 126, 249);
            linkLabelProfile.Location = new Point(67, 147);
            linkLabelProfile.Name = "linkLabelProfile";
            linkLabelProfile.Size = new Size(80, 16);
            linkLabelProfile.TabIndex = 1;
            linkLabelProfile.TabStop = true;
            linkLabelProfile.Text = "ProfileLink";
            linkLabelProfile.VisitedLinkColor = Color.FromArgb(0, 126, 249);
            linkLabelProfile.LinkClicked += linkLabelProfile_LinkClicked;
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.Image = (Image)resources.GetObject("pictureBoxProfile.Image");
            pictureBoxProfile.Location = new Point(67, 16);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(128, 128);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProfile.TabIndex = 0;
            pictureBoxProfile.TabStop = false;
            // 
            // labelGamesLibrary
            // 
            labelGamesLibrary.AutoSize = true;
            labelGamesLibrary.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold);
            labelGamesLibrary.ForeColor = Color.FromArgb(158, 161, 176);
            labelGamesLibrary.Location = new Point(284, 12);
            labelGamesLibrary.Name = "labelGamesLibrary";
            labelGamesLibrary.Size = new Size(212, 32);
            labelGamesLibrary.TabIndex = 1;
            labelGamesLibrary.Text = "Games Library";
            labelGamesLibrary.MouseDown += labelGamesLibrary_MouseDown;
            // 
            // txtSearchBox
            // 
            txtSearchBox.BackColor = Color.FromArgb(47, 54, 61);
            txtSearchBox.BorderStyle = BorderStyle.None;
            txtSearchBox.Cursor = Cursors.IBeam;
            txtSearchBox.Font = new Font("MS PGothic", 12F);
            txtSearchBox.ForeColor = SystemColors.ScrollBar;
            txtSearchBox.Location = new Point(512, 38);
            txtSearchBox.Multiline = true;
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.Size = new Size(170, 20);
            txtSearchBox.TabIndex = 2;
            txtSearchBox.Text = "Search For Something...";
            txtSearchBox.Click += txtSearchBox_Click;
            txtSearchBox.TextChanged += txtSearchBox_TextChanged;
            txtSearchBox.Leave += txtSearchBox_Leave;
            // 
            // lstvGames
            // 
            lstvGames.BackColor = Color.FromArgb(47, 54, 61);
            lstvGames.BorderStyle = BorderStyle.None;
            lstvGames.Columns.AddRange(new ColumnHeader[] { tabFirst });
            lstvGames.Font = new Font("MS PGothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstvGames.ForeColor = Color.FromArgb(158, 161, 176);
            lstvGames.HeaderStyle = ColumnHeaderStyle.None;
            lstvGames.LargeImageList = imgIcons;
            lstvGames.Location = new Point(290, 65);
            lstvGames.Name = "lstvGames";
            lstvGames.OwnerDraw = true;
            lstvGames.Size = new Size(392, 500);
            lstvGames.SmallImageList = imgIcons;
            lstvGames.TabIndex = 3;
            lstvGames.UseCompatibleStateImageBehavior = false;
            lstvGames.View = View.Tile;
            lstvGames.DrawItem += lstvGames_DrawItem;
            lstvGames.MouseDoubleClick += lstvGames_MouseDoubleClick;
            // 
            // tabFirst
            // 
            tabFirst.Text = "Game";
            tabFirst.Width = 370;
            // 
            // imgIcons
            // 
            imgIcons.ColorDepth = ColorDepth.Depth32Bit;
            imgIcons.ImageSize = new Size(32, 32);
            imgIcons.TransparentColor = Color.Transparent;
            // 
            // exitButton
            // 
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = Color.White;
            exitButton.Location = new Point(669, 0);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(32, 25);
            exitButton.TabIndex = 4;
            exitButton.Text = "X";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 41, 46);
            ClientSize = new Size(701, 577);
            Controls.Add(exitButton);
            Controls.Add(lstvGames);
            Controls.Add(txtSearchBox);
            Controls.Add(labelGamesLibrary);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(701, 577);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Steam-Manager@Siyarbekir";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnCopyPassword;
        private Button feetchGamesButton;
        private Button btnShowPassword;
        private Button buttonStartGame;
        private Button button2;
        private Panel panel2;
        private Button deleteUser;
        private Button addUserButton;
        private LinkLabel linkLabelProfile;
        private PictureBox pictureBoxProfile;
        private ComboBox comboBox1;
        private Label labelGamesLibrary;
        private TextBox txtSearchBox;
        private ListView lstvGames;
        private ImageList imgIcons;
        private Button exitButton;
        private Panel PnlNav;
        private ColumnHeader tabFirst;
    }
}
