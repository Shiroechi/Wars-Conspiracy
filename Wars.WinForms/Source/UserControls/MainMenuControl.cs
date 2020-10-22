using System;
using System.Windows.Forms;

using Wars.WinForms.Forms;

namespace Wars.WinForms.UserControls
{
	public partial class MainMenuControl : UserControl
	{
		#region Member

		private readonly MainForm _Parent;

		#endregion Member

		#region Constructor & Destructor

		public MainMenuControl()
		{
			InitializeComponent();
		}

		public MainMenuControl(MainForm parent)
		{
			InitializeComponent();
			this._Parent = parent;
		}

		~MainMenuControl()
		{
			this.TitleLabel.Dispose();
			this.label2.Dispose();
			this.PlayerCount.Dispose();
			this.PlayButton.Dispose();
		}

		#endregion Constructor & Destructor

		#region Button Event

		private void PlayButton_Click(object sender, EventArgs e)
		{
			this._Parent.ChangeScreen(new BoardGameControl(this._Parent, (byte)this.PlayerCount.Value));
		}

		#endregion Button Event
	}
}
