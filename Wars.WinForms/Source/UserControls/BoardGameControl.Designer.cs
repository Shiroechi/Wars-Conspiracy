namespace Wars.WinForms.UserControls
{
	partial class BoardGameControl
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
			this.DefendButton = new System.Windows.Forms.Button();
			this.AttackButton = new System.Windows.Forms.Button();
			this.EnemyChoice = new System.Windows.Forms.ComboBox();
			this.ExecuteButton = new System.Windows.Forms.Button();
			this.InfoBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// DefendButton
			// 
			this.DefendButton.Location = new System.Drawing.Point(230, 200);
			this.DefendButton.Name = "DefendButton";
			this.DefendButton.Size = new System.Drawing.Size(100, 30);
			this.DefendButton.TabIndex = 3;
			this.DefendButton.Text = "Defend";
			this.DefendButton.UseVisualStyleBackColor = true;
			this.DefendButton.Click += new System.EventHandler(this.DefendButton_Click);
			// 
			// AttackButton
			// 
			this.AttackButton.Location = new System.Drawing.Point(50, 200);
			this.AttackButton.Name = "AttackButton";
			this.AttackButton.Size = new System.Drawing.Size(100, 30);
			this.AttackButton.TabIndex = 1;
			this.AttackButton.Text = "Attack";
			this.AttackButton.UseVisualStyleBackColor = true;
			this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
			// 
			// EnemyChoice
			// 
			this.EnemyChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EnemyChoice.FormattingEnabled = true;
			this.EnemyChoice.Location = new System.Drawing.Point(50, 250);
			this.EnemyChoice.Name = "EnemyChoice";
			this.EnemyChoice.Size = new System.Drawing.Size(150, 27);
			this.EnemyChoice.TabIndex = 2;
			// 
			// ExecuteButton
			// 
			this.ExecuteButton.Location = new System.Drawing.Point(230, 247);
			this.ExecuteButton.Name = "ExecuteButton";
			this.ExecuteButton.Size = new System.Drawing.Size(100, 30);
			this.ExecuteButton.TabIndex = 4;
			this.ExecuteButton.Text = "Execute";
			this.ExecuteButton.UseVisualStyleBackColor = true;
			this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
			// 
			// InfoBox
			// 
			this.InfoBox.BackColor = System.Drawing.SystemColors.Window;
			this.InfoBox.Enabled = false;
			this.InfoBox.Location = new System.Drawing.Point(50, 30);
			this.InfoBox.Multiline = true;
			this.InfoBox.Name = "InfoBox";
			this.InfoBox.ReadOnly = true;
			this.InfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.InfoBox.Size = new System.Drawing.Size(280, 150);
			this.InfoBox.TabIndex = 0;
			this.InfoBox.WordWrap = false;
			// 
			// BoardGameControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.InfoBox);
			this.Controls.Add(this.EnemyChoice);
			this.Controls.Add(this.ExecuteButton);
			this.Controls.Add(this.DefendButton);
			this.Controls.Add(this.AttackButton);
			this.Font = new System.Drawing.Font("Consolas", 12F);
			this.Name = "BoardGameControl";
			this.Size = new System.Drawing.Size(384, 361);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button DefendButton;
		private System.Windows.Forms.Button AttackButton;
		private System.Windows.Forms.ComboBox EnemyChoice;
		private System.Windows.Forms.Button ExecuteButton;
		private System.Windows.Forms.TextBox InfoBox;
	}
}
