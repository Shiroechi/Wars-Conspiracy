using System;
using System.Windows.Forms;

using Wars.WinForms.Forms;

namespace Wars.WinForms.UserControls
{
	public partial class MainMenuControl : UserControl
	{
		#region Member

		private MainForm _Parent;

		#endregion Member

		public MainMenuControl()
		{
			InitializeComponent();
		}

		~MainMenuControl()
		{
			this.TitleLabel.Dispose();
			this.label2.Dispose();
			this.PlayerCount.Dispose();
			this.PlayButton.Dispose();
		}

		public MainMenuControl(MainForm parent)
		{
			InitializeComponent();
			this._Parent = parent;
		}

		private void PlayButton_Click(object sender, EventArgs e)
		{
			this._Parent.ChangeScreen(new BoardGameControl(this._Parent, (byte)this.PlayerCount.Value));
		}
	}
}
