
using Wars.Core.Player;

namespace Wars.Core.Command
{
	public class Commands
	{
		#region Member

		private Nation _From;
		private Nation _To;
		private CommandType _CommandType;

		#endregion Member

		#region Constructor & Destructor

		/// <summary>
		/// Constructor.
		/// </summary>
		public Commands(Nation from = null, Nation to = null)
		{
			this._From = from;
			this._To = to;
			this._CommandType = CommandType.None;
		}

		/// <summary>
		/// Destructor.
		/// </summary>
		~Commands()
		{
			//this._From = this._To = null;
		}

		#endregion Constructor & Destructor

		#region Public Method

		public void SetFrom(Nation nation)
		{
			this._From = nation;
		}

		public Nation GetFrom()
		{
			return this._From;
		}

		public void SetTo(Nation nation)
		{
			this._To = nation;
		}

		public Nation GetTo()
		{
			return this._To;
		}

		/// <summary>
		/// Set <see cref="CommandType"/>.
		/// </summary>
		/// <param name="command"></param>
		public void SetCommandType(CommandType command)
		{
			this._CommandType = command;
		}

		/// <summary>
		/// Get <see cref="CommandType"/>.
		/// </summary>
		/// <returns></returns>
		public CommandType GetCommandType()
		{
			return this._CommandType;
		}

		public void Reset()
		{
			this._From = this._To = null;
			this._CommandType = CommandType.None;
		}

		public Commands Clone()
		{
			return new Commands()
			{
				_From = this._From,
				_To = this._To,
				_CommandType = this._CommandType
			};
		}

		#endregion Public Method

		#region Override

		public override string ToString()
		{
			if (this._CommandType == CommandType.Defend) 
			{
				return this._From.GetName() + " Defend ";
			}
			else
			{
				return this._From.GetName() + " Attack " + this._To.GetName();
			}
		}
 
		#endregion Override
	}
}
