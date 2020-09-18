namespace Wars.Core.Player
{
	public class Nation
	{
		#region Member

		/// <summary>
		/// Unique Identifier for each player.
		/// </summary>
		private byte _ID;

		/// <summary>
		/// Nation name.
		/// </summary>
		private string _Name;

		/// <summary>
		/// Nation color.
		/// </summary>
		private string _HexColor;
		
		/// <summary>
		/// Nation life point.
		/// </summary>
		private byte _LifePoint;

		#endregion Member

		#region Constructor & Destructor

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name">Player or nation name.</param>
		/// <param name="hex_color">Color in hexadecimal format.</param>
		public Nation(byte id = 0, string name = "", string hex_color = "", byte point = 50)
		{
			this._ID = id;
			this._Name = name;
			this._HexColor = hex_color;
			this._LifePoint = point;
		}

		/// <summary>
		/// Destructor.
		/// </summary>
		~Nation()
		{
			this._Name = this._HexColor = "";
			this._ID = this._LifePoint = 0;
		}

		#endregion Constructor & Destructor

		#region Public Method

		/// <summary>
		/// Get Unique Identifier for each player.
		/// </summary>
		/// <returns></returns>
		public byte GetId()
		{
			return this._ID;
		}

		/// <summary>
		/// Get nation name.
		/// </summary>
		/// <returns></returns>
		public string GetName()
		{
			return this._Name;
		}

		/// <summary>
		/// Get nation color.
		/// </summary>
		/// <returns></returns>
		public string GetHexColor()
		{
			return this._HexColor;
		}

		/// <summary>
		/// Set new <see cref="_LifePoint"/> for the nation.
		/// </summary>
		/// <param name="point">New <see cref="_LifePoint"/>.</param>
		public void SetLifePoint(byte point)
		{
			if (point < 0) 
			{
				point = 0;
			}
			this._LifePoint = point;
		}

		/// <summary>
		/// Gey nation remaining <see cref="_LifePoint"/>.
		/// </summary>
		/// <returns></returns>
		public byte GetLifePoint()
		{
			return this._LifePoint;
		}

		public void SubstractLifePoint(byte point)
		{
			if (point > this._LifePoint) 
			{
				this._LifePoint = 0;
			}
			else
			{
				this._LifePoint -= point;
			}
		}

		/// <summary>
		/// Make deep clone of this object. 
		/// </summary>
		/// <returns></returns>
		public Nation Clone()
		{
			return new Nation(this._ID,
							  this._Name,
							  this._HexColor,
							  this._LifePoint);
		}

		#endregion Public Method

		#region Override

		public override string ToString()
		{
			return this._Name;
		}

		#endregion Override
	}
}
