namespace Wars.WinForms.UserControls
{
	partial class MainMenuControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TitleLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.PlayerCount = new System.Windows.Forms.NumericUpDown();
			this.PlayButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PlayerCount)).BeginInit();
			this.SuspendLayout();
			// 
			// TitleLabel
			// 
			this.TitleLabel.Font = new System.Drawing.Font("Consolas", 18F);
			this.TitleLabel.Location = new System.Drawing.Point(0, 60);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(384, 30);
			this.TitleLabel.TabIndex = 0;
			this.TitleLabel.Text = "Wars Conspiracy";
			this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 130);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(384, 30);
			this.label2.TabIndex = 1;
			this.label2.Text = "How many player?";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PlayerCount
			// 
			this.PlayerCount.Location = new System.Drawing.Point(142, 170);
			this.PlayerCount.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.PlayerCount.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.PlayerCount.Name = "PlayerCount";
			this.PlayerCount.Size = new System.Drawing.Size(100, 26);
			this.PlayerCount.TabIndex = 2;
			this.PlayerCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.PlayerCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// PlayButton
			// 
			this.PlayButton.Location = new System.Drawing.Point(142, 240);
			this.PlayButton.Name = "PlayButton";
			this.PlayButton.Size = new System.Drawing.Size(100, 30);
			this.PlayButton.TabIndex = 3;
			this.PlayButton.Text = "Play";
			this.PlayButton.UseVisualStyleBackColor = true;
			this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
			// 
			// MainMenuControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.PlayButton);
			this.Controls.Add(this.PlayerCount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TitleLabel);
			this.Font = new System.Drawing.Font("Consolas", 12F);
			this.Name = "MainMenuControl";
			this.Size = new System.Drawing.Size(384, 361);
			((System.ComponentModel.ISupportInitialize)(this.PlayerCount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown PlayerCount;
		private System.Windows.Forms.Button PlayButton;
	}
}
