using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
	public partial class MenuButton : Lesarde.Frogui.Controls.Button
	{
		public MenuButton()
		{
			InitializeComponent();
		}

		public string Text
		{
			get => e_text.Text;
			set => e_text.Text = value;
		}
	}
}
