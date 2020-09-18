using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Wars.Core.Player;
using Wars.WinForms.UserControls;

namespace Wars.WinForms.Forms
{
	public partial class MainForm : Form
	{
		#region Member

		public UserControl _CurrentControl;

		#endregion Member

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this._CurrentControl = new MainMenuControl(this);
			this.Controls.Add(this._CurrentControl);
		}

		public void ChangeScreen(UserControl new_screen)
		{
			if (this._CurrentControl.GetType() == new_screen.GetType()) 
			{
				return;
			}

			this.Controls.Remove(this._CurrentControl);
			this._CurrentControl.Dispose();
			this._CurrentControl = new_screen;
			this.Controls.Add(this._CurrentControl);
		}
	}
}
