using System;
using System.Windows.Forms;

using Wars.Core.Board;
using Wars.Core.Command;
using Wars.Core.Player;
using Wars.WinForms.Forms;

using CommandType = Wars.Core.Command.CommandType;

namespace Wars.WinForms.UserControls
{
	public partial class BoardGameControl : UserControl
	{
		#region Member

		private MainForm _Parent;
		private BoardGame _BoardGame;
		private Nation _Player;

		#endregion Member

		public BoardGameControl(MainForm parent, byte player = 4)
		{
			InitializeComponent();

			this.InfoBox.HideSelection = true;

			this._Parent = parent;
			this._BoardGame = new BoardGame(player); //init gameplay and create AI

			this._Player = new Nation(player, "player", "#FFFF00");
			this._BoardGame.AddPlayer(this._Player);

			this.UpdateEnemyChoice();
			this.UpdateHp();

			this.ExecuteButton.Enabled = false;
		}

		~BoardGameControl()
		{
			this.InfoBox.Dispose();
			this.AttackButton.Dispose();
			this.DefendButton.Dispose();
			this.EnemyChoice.Dispose();
			this.ExecuteButton.Dispose();
		}

		private void AttackButton_Click(object sender, EventArgs e)
		{
			Commands cmd = new Commands();
			cmd.SetFrom(this._Player);
			cmd.SetCommandType(CommandType.Attack);
			cmd.SetTo((Nation)this.EnemyChoice.SelectedItem);
			this._BoardGame.AddCommands(cmd);

			this.AttackButton.Enabled = false;
			this.DefendButton.Enabled = false;
			this.EnemyChoice.Enabled = false;
			this.ExecuteButton.Enabled = true;
			this.InfoBox.SelectionLength = 0;
		}

		private void DefendButton_Click(object sender, EventArgs e)
		{
			Commands cmd = new Commands();
			cmd.SetFrom(this._Player);
			cmd.SetCommandType(CommandType.Defend); 
			this._BoardGame.AddCommands(cmd);

			this.AttackButton.Enabled = false;
			this.DefendButton.Enabled = false;
			this.EnemyChoice.Enabled = false;
			this.ExecuteButton.Enabled = true;
		}

		private void ExecuteButton_Click(object sender, EventArgs e)
		{
			this._BoardGame.CreateCommandAI();
			this._BoardGame.Execute();

			this.UpdateHp();
			this.UpdateEnemyChoice();

			if (this._BoardGame.GetAliveNation().Count == 1)
			{
				MessageBox.Show(this, "Winner " + this._BoardGame.GetAliveNation()[0].GetName(), "Attention");
				this._Parent.ChangeScreen(new MainMenuControl(this._Parent));
			}
			else if(this._BoardGame.GetAliveNation().Count <= 0)
			{
				MessageBox.Show(this, "DRAW", "Attention");
				this._Parent.ChangeScreen(new MainMenuControl(this._Parent));
			}
			else
			{
				if (this._Player.GetLifePoint() <= 0)
				{
					this.AttackButton.Enabled = false;
					this.DefendButton.Enabled = false;
					this.EnemyChoice.Enabled = false;
					this.ExecuteButton.Enabled = true;
				}
				else
				{
					this.AttackButton.Enabled = true;
					this.DefendButton.Enabled = true;
					this.EnemyChoice.Enabled = true;
					this.ExecuteButton.Enabled = false;
				}
			}
		}

		/// <summary>
		/// update all registered player life point
		/// </summary>
		private void UpdateHp()
		{
			this.InfoBox.Text = "";

			foreach (Nation player in this._BoardGame.GetNation()) 
			{
				this.InfoBox.Text += player.GetName() + " = " + player.GetLifePoint().ToString();
				this.InfoBox.Text += Environment.NewLine;
			}
		}

		/// <summary>
		/// update enemy choice
		/// </summary>
		private void UpdateEnemyChoice()
		{
			if (this._BoardGame.GetEnemyChoice(this._Player).Count <= 0) 
			{
				this.EnemyChoice.Items.Clear();
				return;
			}

			this.EnemyChoice.Items.Clear();
			foreach (Nation nation in this._BoardGame.GetEnemyChoice(this._Player))
			{
				this.EnemyChoice.Items.Add(nation);
			}
			this.EnemyChoice.SelectedIndex = 0;
		}

		/// <summary>
		/// fast forward the game, if the player is dead.
		/// </summary>
		private void FastForward()
		{
			while (this._BoardGame.GetAliveNation().Count > 1) 
			{
				this.ExecuteButton.PerformClick();
			}
		}
	}
}
