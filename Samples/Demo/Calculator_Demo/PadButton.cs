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
	public class PadButton : Button
	{
		/// <summary>
		/// Used to identify each button on the calculator
		/// </summary>
		public enum ID
		{
			None,

			MemClear,
			MemRecall,
			MemAdd,
			MemSubtract,

			AllClear,
			Percent,
			Add,
			Subtract,
			Divide,
			Multiply,

			D0,
			D1,
			D2,
			D3,
			D4,
			D5,
			D6,
			D7,
			D8,
			D9,

			Decimal,
			Negate,
			Equal,

			Backspace
		}

		static readonly FontSize _FontSize = FontSize.FromLength(6, Lesarde.Frogui.Unit.Vw);
		static readonly CornerRadius _CornerRadius = new Lesarde.Frogui.CornerRadius(new Lesarde.Frogui.Length(0, Lesarde.Frogui.Unit.Px));

		public ID Id { get; }

		public PadButton(ID id, string text, Brush foreground, Brush background, Brush borderBrush)
		{
			Id = id;
			CornerRadius = _CornerRadius;
			BorderBrush = borderBrush;
			Background = background;
			Child = new TextBlock()
			{
				Selectable = false,
				FontFamily = Calculator_Demo.FontFamily,
				FontSize = _FontSize,
				FontWeight = Calculator_Demo.FontWeight,
				Text = text,
				Foreground = foreground,
				HorizontalAlignment = Lesarde.Frogui.HorizontalAlignment.Center,
				VerticalAlignment = Lesarde.Frogui.VerticalAlignment.Center
			};
		}

	}
}
