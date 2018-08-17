using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Input;
using Lesarde.Frogui.Media;
using System;

namespace Demo.TipCalculator
{
	/***************************************************************************************************
		TipCalculator_Demo class
	***************************************************************************************************/
	/// <summary>
	/// This is the main element of the tip calculator demo. It inherits from <see cref="Border"/>
	/// which provides a simple way to pad and have a background.
	/// <para></para>
	/// Uses <see cref="TipCalculator.Model"/> as a model.
	/// </summary>
	public partial class TipCalculator_Demo : Border
	{
		/***********************************************************
			elements
		***********************************************************/

		TextBox
			e_bill;

		IntegerBox
			e_tipPercent,
			e_numPeople;

		TextBlock
			e_tipPerPersonLabel,
			e_tipPerPerson,
			e_totalPerPersonLabel,
			e_totalPerPerson;

		/***********************************************************
			Model property
		***********************************************************/

		public Model Model { get; } = new Model();

		/*******************************************************************************
			$
		*******************************************************************************/

		public TipCalculator_Demo()
		{
			InitializeComponent();

			//
			// Prepare the input segment
			//

			var e_input = AddSegment();

			var gridPadding = new Thickness(new Length(32, Unit.Px));

			var e_inputGrid = new Grid() { Padding = gridPadding };

			e_input.Child = e_inputGrid;

			e_inputGrid.RowDefinitions
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition());

			AddLabel(e_inputGrid, "Bill", 0);
			AddLabel(e_inputGrid, "Tip %", 2);
			AddLabel(e_inputGrid, "Number of People", 4);

			e_bill = new TextBox() { Text = String.Empty, TextAlignment = TextAlignment.Right, FontFamily = FontFamily, FontSize = InputFontSize };

			e_inputGrid.Children.Add(e_bill, new Grid.Anchor(0, 1));

			e_bill.TextChanged += (sender, e) =>
			{
				Model.Bill = Convert.ToDouble(e_bill.Text);
				UpdateUi();
			};

			e_tipPercent = new IntegerBox();
			e_tipPercent.ValueChanged += () =>
			{
				Model.TipPercent = e_tipPercent.Value;
				UpdateUi();
			};

			e_inputGrid.Children.Add(e_tipPercent, new Grid.Anchor(0, 3));

			e_numPeople = new IntegerBox() { Value = 1 };
			e_numPeople.ValueChanged += () =>
			{
				Model.NumPeople = e_numPeople.Value;
				UpdateUi();
			};

			e_inputGrid.Children.Add(e_numPeople, new Grid.Anchor(0, 5));

			//
			// Prepare the output segment
			//

			var e_output = AddSegment();

			var e_outputGrid = new Grid() { Padding = gridPadding };

			e_output.Child = e_outputGrid;

			e_outputGrid.RowDefinitions
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition())
				.Add(new RowDefinition());

			AddLabel(e_outputGrid, "Tip", 0, false, VerticalAlignment.Bottom);
			e_tipPerPersonLabel = AddLabel(e_outputGrid, "per person", 1, true, VerticalAlignment.Top);
			AddLabel(e_outputGrid, "Total", 3, false, VerticalAlignment.Bottom);
			e_totalPerPersonLabel = AddLabel(e_outputGrid, "per person", 4, true, VerticalAlignment.Top);

			e_tipPerPerson = AddTotal(e_outputGrid, 0);
			e_totalPerPerson = AddTotal(e_outputGrid, 3);

			// Add the segments to the flex

			e_flex.Children.Add(e_input);
			e_flex.Children.Add(e_output);

			UpdateUi();
		}

		/*******************************************************************************
			AddSegment()
		*******************************************************************************/
		static Border AddSegment()
		{
			var width = new Length(360, Unit.Px);
			var height = new Length(300, Unit.Px);
			var cornerRadius = new CornerRadius(new Length(20, Unit.Px));
			var borderThickness = new Thickness(new Length(4, Unit.Px));
			var background = new SolidColorBrush(Color.FromRgb(1, 117, 192));

			var element = new Border()
			{
				Width = width,
				Height = height,
				Background = background,
				CornerRadius = cornerRadius,
				BorderThickness = borderThickness,
				BackgroundClip = BorderBackgroundClip.ContentBox
			};

			return element;
		}

		/*******************************************************************************
			AddLabel()
		*******************************************************************************/
		/// <summary>
		/// Adds a label to a segment,
		/// </summary>
		TextBlock AddLabel(Grid grid, string text, int row, bool isSecondary = false, VerticalAlignment verticalAlignment = VerticalAlignment.Center)
		{
			var element = new TextBlock() { Text = text, VerticalAlignment = verticalAlignment, FontFamily = FontFamily, Foreground = (isSecondary) ? SecondaryLabelForeground : LabelForeground, FontSize = LabelFontSize };

			grid.Children.Add(element, new Grid.Anchor(0, row));

			return element;
		}

		/*******************************************************************************
			AddTotal()
		*******************************************************************************/
		/// <summary>
		/// Adds a TextBlock used for totals to a segment.
		/// </summary>
		TextBlock AddTotal(Grid grid, int row)
		{
			var element = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center, FontFamily = FontFamily, Foreground = LabelForeground, FontSize = TotalFontSize };

			grid.Children.Add(element, new Grid.Anchor(1, 1, row, 2));

			return element;
		}

		/*******************************************************************************
			UpdateUi()
		*******************************************************************************/

		void UpdateUi()
		{
			e_bill.Text = ToMoney(Model.Bill);
			e_tipPercent.Value = Model.TipPercent;
			e_numPeople.Value = Model.NumPeople;

			var singlePerson = 1 == Model.NumPeople;

			e_tipPerPersonLabel.Visibility = (singlePerson) ? Visibility.Collapsed : Visibility.Visible;
			e_totalPerPersonLabel.Visibility = (singlePerson) ? Visibility.Collapsed : Visibility.Visible;

			var totalTip = Model.Bill * Model.TipPercent / 100;
			var totalBill = Model.Bill + totalTip;

			var tipPerPerson = totalTip / Model.NumPeople;
			var totalPerPerson = totalBill / Model.NumPeople;

			e_tipPerPerson.Text = ToMoneyWithCurrencySymbol(tipPerPerson);
			e_totalPerPerson.Text = ToMoneyWithCurrencySymbol(totalPerPerson);

			string ToMoney(double value) => string.Format("{0:N2}", value);
			string ToMoneyWithCurrencySymbol(double value) => string.Format("${0:N2}", value);
		}

	}
}