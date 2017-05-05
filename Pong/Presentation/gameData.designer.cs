namespace Pong.Presentation {
    partial class gameData {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameData));
            this.pictureBoxHandDetection = new System.Windows.Forms.PictureBox();
            this.labelOverview = new System.Windows.Forms.Label();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.listViewPlayers = new System.Windows.Forms.ListView();
            this.playerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playerHealth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playerScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelBalls = new System.Windows.Forms.Label();
            this.listViewBalls = new System.Windows.Forms.ListView();
            this.ballX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ballY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ballSpeedX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ballSpeedY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.listViewPowerups = new System.Windows.Forms.ListView();
            this.powerupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.powerupX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.powerupY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelPowerups = new System.Windows.Forms.Label();
            this.labelHandDetection = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHandDetection)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxHandDetection
            // 
            this.pictureBoxHandDetection.Location = new System.Drawing.Point(308, 231);
            this.pictureBoxHandDetection.Name = "pictureBoxHandDetection";
            this.pictureBoxHandDetection.Size = new System.Drawing.Size(264, 255);
            this.pictureBoxHandDetection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHandDetection.TabIndex = 0;
            this.pictureBoxHandDetection.TabStop = false;
            this.pictureBoxHandDetection.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBoxHandDetection.DoubleClick += new System.EventHandler(this.pictureBoxTest_DoubleClick);
            this.pictureBoxHandDetection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxHandDetection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBoxHandDetection.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // labelOverview
            // 
            this.labelOverview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelOverview.AutoSize = true;
            this.labelOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOverview.Location = new System.Drawing.Point(170, 9);
            this.labelOverview.Name = "labelOverview";
            this.labelOverview.Size = new System.Drawing.Size(212, 26);
            this.labelOverview.TabIndex = 1;
            this.labelOverview.Text = "Game data overview";
            this.labelOverview.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(13, 45);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(44, 13);
            this.labelPlayers.TabIndex = 2;
            this.labelPlayers.Text = "Players:";
            // 
            // listViewPlayers
            // 
            this.listViewPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.playerName,
            this.playerHealth,
            this.playerScore});
            this.listViewPlayers.Location = new System.Drawing.Point(16, 61);
            this.listViewPlayers.Name = "listViewPlayers";
            this.listViewPlayers.Size = new System.Drawing.Size(270, 129);
            this.listViewPlayers.TabIndex = 3;
            this.listViewPlayers.UseCompatibleStateImageBehavior = false;
            this.listViewPlayers.View = System.Windows.Forms.View.Details;
            // 
            // playerName
            // 
            this.playerName.Text = "Player name";
            this.playerName.Width = 115;
            // 
            // playerHealth
            // 
            this.playerHealth.Text = "Player health";
            this.playerHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerHealth.Width = 134;
            // 
            // playerScore
            // 
            this.playerScore.Text = "Player score";
            this.playerScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerScore.Width = 150;
            // 
            // labelBalls
            // 
            this.labelBalls.AutoSize = true;
            this.labelBalls.Location = new System.Drawing.Point(308, 45);
            this.labelBalls.Name = "labelBalls";
            this.labelBalls.Size = new System.Drawing.Size(32, 13);
            this.labelBalls.TabIndex = 4;
            this.labelBalls.Text = "Balls:";
            // 
            // listViewBalls
            // 
            this.listViewBalls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ballX,
            this.ballY,
            this.ballSpeedX,
            this.ballSpeedY});
            this.listViewBalls.Location = new System.Drawing.Point(308, 61);
            this.listViewBalls.Name = "listViewBalls";
            this.listViewBalls.Size = new System.Drawing.Size(264, 129);
            this.listViewBalls.TabIndex = 5;
            this.listViewBalls.UseCompatibleStateImageBehavior = false;
            this.listViewBalls.View = System.Windows.Forms.View.Details;
            // 
            // ballX
            // 
            this.ballX.Text = "X";
            // 
            // ballY
            // 
            this.ballY.Text = "Y";
            this.ballY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ballY.Width = 67;
            // 
            // ballSpeedX
            // 
            this.ballSpeedX.Text = "Speed X";
            this.ballSpeedX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ballSpeedX.Width = 124;
            // 
            // ballSpeedY
            // 
            this.ballSpeedY.Text = "Speed Y";
            this.ballSpeedY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ballSpeedY.Width = 137;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRefresh.Location = new System.Drawing.Point(12, 448);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(274, 38);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Refresh data";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // listViewPowerups
            // 
            this.listViewPowerups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.powerupName,
            this.powerupX,
            this.powerupY});
            this.listViewPowerups.Location = new System.Drawing.Point(12, 231);
            this.listViewPowerups.Name = "listViewPowerups";
            this.listViewPowerups.Size = new System.Drawing.Size(274, 196);
            this.listViewPowerups.TabIndex = 8;
            this.listViewPowerups.UseCompatibleStateImageBehavior = false;
            this.listViewPowerups.View = System.Windows.Forms.View.Details;
            // 
            // powerupName
            // 
            this.powerupName.Text = "Name";
            this.powerupName.Width = 115;
            // 
            // powerupX
            // 
            this.powerupX.Text = "X";
            this.powerupX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.powerupX.Width = 75;
            // 
            // powerupY
            // 
            this.powerupY.Text = "Y";
            this.powerupY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.powerupY.Width = 75;
            // 
            // labelPowerups
            // 
            this.labelPowerups.AutoSize = true;
            this.labelPowerups.Location = new System.Drawing.Point(9, 215);
            this.labelPowerups.Name = "labelPowerups";
            this.labelPowerups.Size = new System.Drawing.Size(57, 13);
            this.labelPowerups.TabIndex = 7;
            this.labelPowerups.Text = "Powerups:";
            // 
            // labelHandDetection
            // 
            this.labelHandDetection.AutoSize = true;
            this.labelHandDetection.Location = new System.Drawing.Point(305, 215);
            this.labelHandDetection.Name = "labelHandDetection";
            this.labelHandDetection.Size = new System.Drawing.Size(83, 13);
            this.labelHandDetection.TabIndex = 9;
            this.labelHandDetection.Text = "Hand detection:";
            // 
            // gameData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 500);
            this.Controls.Add(this.labelHandDetection);
            this.Controls.Add(this.listViewPowerups);
            this.Controls.Add(this.labelPowerups);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.listViewBalls);
            this.Controls.Add(this.labelBalls);
            this.Controls.Add(this.listViewPlayers);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.labelOverview);
            this.Controls.Add(this.pictureBoxHandDetection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "gameData";
            this.Text = "Game data";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHandDetection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHandDetection;
        private System.Windows.Forms.Label labelOverview;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.ListView listViewPlayers;
        private System.Windows.Forms.ColumnHeader playerName;
        private System.Windows.Forms.ColumnHeader playerHealth;
        private System.Windows.Forms.ColumnHeader playerScore;
        private System.Windows.Forms.Label labelBalls;
        private System.Windows.Forms.ListView listViewBalls;
        private System.Windows.Forms.ColumnHeader ballX;
        private System.Windows.Forms.ColumnHeader ballY;
        private System.Windows.Forms.ColumnHeader ballSpeedX;
        private System.Windows.Forms.ColumnHeader ballSpeedY;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ListView listViewPowerups;
        private System.Windows.Forms.ColumnHeader powerupName;
        private System.Windows.Forms.ColumnHeader powerupX;
        private System.Windows.Forms.ColumnHeader powerupY;
        private System.Windows.Forms.Label labelPowerups;
        private System.Windows.Forms.Label labelHandDetection;
    }
}