using System;
using System.Collections.Generic;
using System.Text;

using Wars.Core.Player;

namespace Wars.Core.Command
{
	public class Request
	{
		#region Member

		private Nation _From;
		private Nation _To;
		private string _Message;

		#endregion region Member

		#region Constructor & Destructor

		public Request(Nation from, Nation to, string message = "")
		{
			this._From = from;
			this._To = to;
			this._Message = message;
		}

		~Request()
		{
			this._Message = "";
		}

		#endregion Constructor & Destructor

	}
}
