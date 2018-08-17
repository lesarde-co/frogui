using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;

namespace Demo.TipCalculator
{
	public partial class IntegerBox : Border
	{
		public event Action ValueChanged;

		public Grid
			e_frame;

		public Button
			e_minus,
			e_plus;

		public TextBox
			e_textBox;

		public int value;
		public int Value
		{
			get => value;
			set
			{
				if (this.value == value)
					return;

				SetValue(value);
				e_textBox.Text = value.ToString();
			}
		}

		void SetValue(int value)
		{
			if (this.value == value)
				return;

			this.value = value;

			ValueChanged?.Invoke();
		}

		public void InitializeComponent()
		{
			// Create a grid which will be this border's child and will host the [-][text][+] elements.
			e_frame = new Grid()
			{
				HorizontalAlignment = HorizontalAlignment.Stretch
			};

			Child = e_frame;

			// Add three columns to the grid, allowing the middle column where the text appears
			// to be fractional (in this case, it will take up all unused space).
			e_frame.ColumnDefinitions
				.Add(new ColumnDefinition(new GridLength(new Length(0, Unit.Auto))))
				.Add(new ColumnDefinition(new GridLength(new Length(1, Unit.Fr))))
				.Add(new ColumnDefinition(new GridLength(new Length(0, Unit.Auto))));

			var round = new Length(5, Unit.Px);
			var sharp = new Length(0, Unit.Px);

			// Minus button
			e_minus = CreateButton("-", new CornerRadius(round, sharp, sharp, round));
			e_minus.Click += (sender, e) => --Value;

			// Plus button
			e_plus = CreateButton("+", new CornerRadius(sharp, round, round, sharp));
			e_plus.Click += (sender, e) => ++Value;

			// Text
			e_textBox = new TextBox()
			{
				HorizontalAlignment = HorizontalAlignment.Right,
				VerticalAlignment = VerticalAlignment.Stretch,
				TextAlignment = TextAlignment.Right,
				FontFamily = TipCalculator_Demo.FontFamily,
				FontSize = TipCalculator_Demo.InputFontSize,
				FontWeight = TipCalculator_Demo.FontWeight
			};
			e_textBox.TextChanged += TextChanged;

			// Add children to the frame
			e_frame.Children.Add(e_minus);
			e_frame.Children.Add(e_textBox, new Grid.Anchor(1, 0));
			e_frame.Children.Add(e_plus, new Grid.Anchor(2, 0));
		}

		/// <summary>
		/// When the text changes, convert to an int and forward
		/// </summary>
		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			SetValue(Convert.ToInt32(e_textBox.Text));
		}

		/// <summary>
		/// Creates either a [-] or [+] button
		/// </summary>
		public Button CreateButton(string text, CornerRadius cornerRadius) => new Button()
			{
				Background = ButtonBackground,
				Width = new Length(64, Unit.Px),
				//Height = new Length(64, Unit.Px),
				BorderThickness = new Thickness(new Length(0, Unit.Px)),
				CornerRadius = cornerRadius,
				Child = new TextBlock()
				{
					Selectable = false,
					FontFamily = TipCalculator_Demo.FontFamily,
					FontSize =  ButtonFontSize,
					FontWeight = TipCalculator_Demo.FontWeight,
					Text = text,
					Foreground = TipCalculator_Demo.LabelForeground,
					HorizontalAlignment = Lesarde.Frogui.HorizontalAlignment.Center,
					VerticalAlignment = Lesarde.Frogui.VerticalAlignment.Center
				}
			};
	}
}

