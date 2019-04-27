using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo.Calculator
{
	/***************************************************************************************************
		PadButton class
	***************************************************************************************************/
	/// <summary>
	/// This element class is used for all buttons on the calculator.
	/// </summary>
	public partial class PadButton : Button
	{
		static readonly FontSize _FontSize = FontSize.FromLength(6, Lesarde.Frogui.Unit.Vw);
		static readonly CornerRadius _CornerRadius = new Lesarde.Frogui.CornerRadius(new Lesarde.Frogui.Length(0, Lesarde.Frogui.Unit.Px));

		public string Text { get => e_text.Text; set => e_text.Text = value; }

		public PadButton()
		{
			InitializeComponent();
		}
	}
}
