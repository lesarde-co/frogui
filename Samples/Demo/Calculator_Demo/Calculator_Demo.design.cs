using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo.Calculator
{
	public partial class Calculator_Demo : Grid
	{
		Border
			e_display;

		TextBlock
			e_text;

		PadButton
			e_memClear,
			e_memRecall,
			e_memAdd,
			e_memSubtract,
			e_allClear,
			e_percent,
			e_divide,
			e_multiple,
			e_subtract,
			e_add,
			e_d0,
			e_d1,
			e_d2,
			e_d3,
			e_d4,
			e_d5,
			e_d6,
			e_d7,
			e_d8,
			e_d9,
			e_decimal,
			e_negate,
			e_equal;

		SolidColorBrush
			borderBrush = new SolidColorBrush(Color.FromRgb(6, 9, 14)),
			displayBrush = new SolidColorBrush(Color.FromRgb(45, 48, 53)),
			memBrush = new SolidColorBrush(Color.FromRgb(30, 31, 35)),
			funcBrush = new SolidColorBrush(Color.FromRgb(45, 46, 51)),
			digitBrush = new SolidColorBrush(Color.FromRgb(58, 61, 68)),
			equalBrush = new SolidColorBrush(Color.FromRgb(205, 54, 45)),
			foreground = Common.GetSolidColorBrush(Colors.White),
			errorBrush = Common.GetSolidColorBrush(Colors.Red);


		public void InitializeComponent()
		{
			// Add columns and rows to the grid

			ColumnDefinitions
				.Add(new ColumnDefinition())
				.Add(new ColumnDefinition())
				.Add(new ColumnDefinition())
				.Add(new ColumnDefinition());

			RowDefinitions
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition());

			// Create the calculator display's text
			e_text = new TextBlock()
			{
				FontWeight = Calculator_Demo.FontWeight,
				FontFamily = Calculator_Demo.FontFamily,
				FontSize = FontSize.FromLength(9, Lesarde.Frogui.Unit.Vw),
				HorizontalAlignment = Lesarde.Frogui.HorizontalAlignment.Right,
				VerticalAlignment = Lesarde.Frogui.VerticalAlignment.Center
			};

			// Create the calculator's display
			e_display = new Border()
			{
				Background = displayBrush,
				BorderBrush = borderBrush,
				BorderThickness = new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(3, Lesarde.Frogui.Unit.Px)),
				BorderPattern = new Lesarde.Frogui.BorderPattern(Lesarde.Frogui.StrokePattern.Solid),
				Child = e_text,
				Padding = new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(8, Lesarde.Frogui.Unit.Px))
			};

			// Add the display to the grid
			Children.Add(e_display, new Grid.Anchor("0", "4", "0", "2"));

		}

	}
}
