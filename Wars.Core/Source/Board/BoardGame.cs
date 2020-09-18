using System;
using System.Collections.Generic;

using Litdex.Security.RNG;
using Litdex.Security.RNG.PRNG;

using Wars.Core.Command;
using Wars.Core.Player;

namespace Wars.Core.Board
{
	public class BoardGame
	{
		#region Member

		private byte _Turn;
		private readonly byte _MinimalPlayerCount = 4;
		private readonly byte _MaximumPlayerCount = 8;

		private readonly byte _AttackDamage = 10;
		private readonly byte _DefendCost = 5;

		//AI player
		private List<Nation> _Nation;

		//Registered commands
		private List<Commands> _Commands;

		#endregion Member

		#region Constructor & Destructor

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="player"></param>
		public BoardGame(byte player = 4)
		{
			this._Turn = 0;

			if (player < this._MinimalPlayerCount || player > this._MaximumPlayerCount) 
			{
				return;
			}

			this._Nation = new List<Nation>();
			this._Commands = new List<Commands>();

			//create AI
			for (byte i = 1; i < player; i++) 
			{
				this._Nation.Add(new Nation(i, "AI " + i, RandomHexColor(i)));
			}
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		~BoardGame()
		{
			this._Nation.Clear();
			this._Commands.Clear();
		}

		#endregion Constructor & Destructor.

		#region Private Method

		/// <summary>
		/// Generate random hex color
		/// </summary>
		/// <param name="seed"></param>
		/// <returns></returns>
		private string RandomHexColor(byte seed)
		{
			string hex = "#";
			hex += seed * 10; 
			hex += seed * 20; 
			hex += seed * 30;
			return hex;
		}

		/// <summary>
		/// remove illegal commands.
		/// remove oldest commands if there's duplicate.
		/// </summary>
		/// <returns></returns>
		private void CheckIllegelCommand()
		{
			foreach (Nation nation in this._Nation)
			{
				var result = this._Commands.FindAll(
					delegate (Commands find)
					{
						return find.GetFrom().GetId() == nation.GetId();
					}
					);

				if (result.Count != 1)
				{
					Console.WriteLine("Illegal " + nation.GetName() + " command");
					for (byte i = 0; i < result.Count - i; i++)
					{
						result.RemoveAt(i);
					}
				}
			}
		}

		private Nation RandomAttackNation(Random64 random, List<Nation> nation)
		{
			if (nation.Count > 1) 
			{
				return random.Choice(nation);
			}
			else
			{
				return nation[0];
			}
		}

		private Nation RandomAttackNation(Random32 random, List<Nation> nation)
		{
			if (nation.Count > 1)
			{
				return random.Choice(nation);
			}
			else
			{
				return nation[0];
			}
		}

		#endregion Private Method

		#region Public Method

		/// <summary>
		/// Insert player nation.
		/// </summary>
		/// <param name="player"></param>
		public void AddPlayer(Nation player)
		{
			if (player == null) 
			{
				return;
			}

			this._Nation.Add(player);
		}

		/// <summary>
		/// Add command that player an AI choose.
		/// </summary>
		/// <param name="command"></param>
		public void AddCommands(Commands command)
		{
			if (command == null)
			{
				return;
			}
			this._Commands.Add(command);
		}

		/// <summary>
		/// Create a <see cref="Commands"/> for every AI.
		/// </summary>
		/// <returns></returns>
		public void CreateCommandAI()
		{
			//using random to determine AI logic
			Xoroshiro128plus random = new Xoroshiro128plus();
			random.Reseed();

			Commands SingleCommands = new Commands();

			foreach (Nation from in this.GetAliveNation()) 
			{
				// do not proceed if current nation
				// is a player
				if (from.GetName().Substring(0, 2) != "AI") 
				{
					continue;
				}

				//determine attack/defend
				//true => attack
				//false => defend
				if (random.NextBoolean() == true)
				{
					SingleCommands.SetFrom(from);
					SingleCommands.SetCommandType(CommandType.Attack);
					SingleCommands.SetTo(this.RandomAttackNation(random, this.GetEnemyChoice(from)));
				}
				else
				{
					SingleCommands.SetFrom(from);
					SingleCommands.SetCommandType(CommandType.Defend);
				}

				this.AddCommands(SingleCommands.Clone());
			}
		}

		/// <summary>
		/// Process all commands
		/// </summary>
		public void Execute()
		{
			this.CheckIllegelCommand();

			this._Turn += 1;

			//removed command list
			List<Commands> remove = new List<Commands>();

			//
			// 1. Process Defend Command
			// 
			// remove player/AI nation who is choose <defend> and
			// copy that command to removed list

			//store player/AI that choose defend
			List<Nation> defend = new List<Nation>();

			for (byte i = 0; i < this._Commands.Count; i++) 
			{
				if (this._Commands[i].GetCommandType() == CommandType.Defend) 
				{
					Nation temp = this._Commands[i].GetFrom();
					temp.SubstractLifePoint(this._DefendCost); //substract life point
					defend.Add(temp);
					remove.Add(this._Commands[i]);
					Console.WriteLine(temp.GetName() + " Defend");
				}
			}

			//remove command in removed list
			foreach(var item in remove)
			{
				this._Commands.Remove(item);
			}	

			if (this._Commands.Count <= 0 ||
				this._Commands == null)
			{
				return;
			}

			//
			// 2. Remove all nation that <attack> the defended nation.
			//

			for (byte i = 0; i < this._Commands.Count; i++)
			{
				if (defend.Exists(
						delegate (Nation nation)
						{
							return nation.GetId() == this._Commands[i].GetTo().GetId();
						})
					)
				{
					Console.WriteLine(this._Commands[i].GetFrom().GetName() + " Attack " +
						this._Commands[i].GetTo().GetName() + " Null");

					remove.Add(this._Commands[i]);
				}
			}

			foreach (var item in remove)
			{
				this._Commands.Remove(item);
			}

			if (this._Commands.Count <= 0 ||
				this._Commands == null)
			{
				return;
			}

			//
			// 3. Process remaining command that <Attack> nation
			//	  that not defended
			// 

			for (byte i = 0; i < this._Commands.Count; i++)
			{
				this._Commands[i].GetTo().SubstractLifePoint(this._AttackDamage);

				Console.WriteLine(this._Commands[i].GetFrom().GetName() + " Attack " +
					this._Commands[i].GetTo().GetName());

				remove.Add(this._Commands[i]);
			}

			foreach (var item in remove)
			{
				this._Commands.Remove(item);
			}
		}

		//
		//---------- GLOBAL METHOD ----------
		// 

		/// <summary>
		/// Get current turn in game board.
		/// </summary>
		/// <returns></returns>
		public byte GetTurn()
		{
			return this._Turn;
		}

		/// <summary>
		/// Get all registered <see cref="Nation"/> in this board.
		/// </summary>
		/// <returns></returns>
		public List<Nation> GetNation()
		{
			return this._Nation;
		}

		/// <summary>
		/// Get all nation that still alive except yours
		/// </summary>
		/// <param name="me">your nation object</param>
		/// <returns></returns>
		public List<Nation> GetEnemyChoice(Nation me)
		{
			List<Nation> alive = this.GetAliveNation();
			List<Nation> enemy = new List<Nation>();

			foreach (Nation item in alive) 
			{
				if (item.GetId() != me.GetId()) 
				{
					enemy.Add(item);
				}
			}
			return enemy;
		}

		/// <summary>
		/// Get all dead <see cref="Nation"/>
		/// </summary>
		/// <returns></returns>
		public List<Nation> GetDeadNation()
		{
			List<Nation> dead = new List<Nation>();

			foreach(Nation nation in this._Nation)
			{
				if (nation.GetLifePoint() <= 0) 
				{
					dead.Add(nation);
				}
			}
			return dead;
		}

		/// <summary>
		/// Get all alive <see cref="Nation"/>
		/// </summary>
		/// <returns></returns>
		public List<Nation> GetAliveNation()
		{
			List<Nation> alive = new List<Nation>();

			foreach (Nation nation in this._Nation)
			{
				if (nation.GetLifePoint() > 0)
				{
					alive.Add(nation);
				}
			}
			return alive;
		}

		#endregion Public Method
	}
}