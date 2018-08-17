using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo.TipCalculator
{
	/***************************************************************************************************
		IntegerBox class
	***************************************************************************************************/
	/// <summary>
	/// This element class is used for integer input using [-] [+] buttons. It inherits from <see cref="Border"/>
	/// because a border can host a child and can clip at the boreder's rounded perimeter.
	/// <para></para>
	/// See the associated design file more for details.
	/// </summary>
	public partial class IntegerBox : Border
	{
		static readonly FontSize ButtonFontSize = FontSize.FromLength(24, Lesarde.Frogui.Unit.Pt);
		static readonly CornerRadius ButtonCornerRadius = new Lesarde.Frogui.CornerRadius(new Lesarde.Frogui.Length(0, Lesarde.Frogui.Unit.Px));
		static readonly Brush ButtonBackground = new SolidColorBrush(Color.FromRgb(5, 97, 156));
		static readonly FontWeight ButtonFontWeight = new FontWeight(FontWeightKind.Bold);

		public IntegerBox()
		{
			InitializeComponent();
		}

	}
}

