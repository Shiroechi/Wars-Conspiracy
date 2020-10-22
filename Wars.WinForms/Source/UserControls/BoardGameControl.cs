using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using Wars.Core.Board;
using Wars.Core.Command;
using Wars.Core.Player;
using Wars.WinForms.Forms;

using CommandType = Wars.Core.Common.CommandType;

namespace Wars.WinForms.UserControls
{
	public partial class BoardGameControl : UserControl
	{
		#region Member

		private readonly MainForm _Parent;
		private readonly BoardGame _BoardGame;
		private readonly Nation _Player;

		#endregion Member

		#region Constructor & Destructor

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

		#endregion Constructor & Destructor

		#region Button Event

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

		private void ExecuteButton_Click (object sender, EventArgs e)
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
			else if (this._BoardGame.GetAliveNation().Count <= 0)
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

					var result = MessageBox.Show(
						this, 
						"Want to use fast forward?", 
						"Attention!", 
						MessageBoxButtons.YesNo);

					if (result == DialogResult.Yes)
					{
						this.FastForward();
					}
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

		#endregion Button Event

		#region Private Method

		private async Task RunAsync()
		{
			await this.UpdateHp();
			await this.UpdateEnemyChoice();
		}

		/// <summary>
		/// update all registered player life point
		/// </summary>
		private Task UpdateHp()
		{
			this.InfoBox.Text = "";

			foreach (Nation player in this._BoardGame.GetNation())
			{
				this.InfoBox.Text += player.GetName() + " = " + player.GetLifePoint().ToString();
				this.InfoBox.Text += Environment.NewLine;
			}

			return Task.CompletedTask;
		}

		/// <summary>
		/// update enemy choice
		/// </summary>
		private Task UpdateEnemyChoice()
		{
			if (this._BoardGame.GetEnemyChoice(this._Player).Count <= 0)
			{
				this.EnemyChoice.Items.Clear();
				return Task.CompletedTask;
			}

			this.EnemyChoice.Items.Clear();

			foreach (Nation nation in this._BoardGame.GetEnemyChoice(this._Player))
			{
				this.EnemyChoice.Items.Add(nation);
			}
			
			this.EnemyChoice.SelectedIndex = 0;

			return Task.CompletedTask;
		}

		/// <summary>
		/// fast forward the game, if the player is dead.
		/// </summary>
		private Task FastForward()
		{
			while (this._BoardGame.GetAliveNation().Count > 1)
			{
				this.ExecuteButton.PerformClick();
			}

			return Task.CompletedTask;
		}

		#endregion Private Method
	}
}
