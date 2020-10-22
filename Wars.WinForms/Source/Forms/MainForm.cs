using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using Wars.WinForms.UserControls;

namespace Wars.WinForms.Forms
{
	public partial class MainForm : Form
	{
		#region Member

		public UserControl _CurrentControl;

		#endregion Member

		#region Constructor & Destructor

		public MainForm()
		{
			InitializeComponent();
		}

		~MainForm()
		{
			this._CurrentControl.Dispose();
			this.Dispose();
		}

		#endregion Constructor & Destructor
		
		#region Form Event

		private void MainForm_Load(object sender, EventArgs e)
		{
			this._CurrentControl = new MainMenuControl(this);
			this.Controls.Add(this._CurrentControl);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			var result = MessageBox.Show(this, "Do You want to close the window?", "Warning!", MessageBoxButtons.YesNo);
			if (result == DialogResult.No)
			{
				e.Cancel = true;
			}
		}

		#endregion Form Event

		#region Public Method

		/// <summary>
		/// Change the display screen.
		/// </summary>
		/// <param name="new_screen">Control to show.</param>
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

		#endregion Public Method
	}
}
