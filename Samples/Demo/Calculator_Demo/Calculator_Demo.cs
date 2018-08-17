using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Input;
using Lesarde.Frogui.Media;
using System;

namespace Demo.Calculator
{
	/***************************************************************************************************
		Calculator_Demo class
	***************************************************************************************************/
	/// <summary>
	/// This element is used as the root of the calculator demo. It inherits from <see cref="Grid"/>
	/// because the calculator view is very grid-like. This is the view associated with the
	/// <see cref="Calculator.Model"/> class.
	/// <para></para>
	/// Note the <see cref="Model"/> property creates the model object during initialization.
	/// The technique works well here, but is not generally how models are wired to views.
	/// </summary>
	public partial class Calculator_Demo : Grid
	{
		public static readonly FontWeight FontWeight = new FontWeight(FontWeightKind.Lighter);
		public static readonly FontFamily FontFamily = Common.Helvetica;

		public Model Model { get; } = new Model();

		/// <summary>
		/// Update the view when the <see cref="Model.DisplayChanged"/> is fired.
		/// </summary>
		void Model_DisplayChanged()
		{
			e_text.Foreground = (Model.InError) ? errorBrush : foreground;
			e_text.Text = Model.DisplayText;
		}

		/// <summary>
		/// The constructor of a design must always first call <see cref="InitializeComponent"/>.
		/// </summary>
		public Calculator_Demo()
		{
			InitializeComponent();

			// User code below

			Model.DisplayChanged += Model_DisplayChanged;
			MainWindow.Me.KeyDown += OnKeyDown;

			// Create all the buttons. Once the design tool is ready, the code below
			// will not be needed and would, instead, be generated in the design.cs file.

			e_memClear = AddButton(PadButton.ID.MemClear, "mc", 0, 2, memBrush);
			e_memRecall = AddButton(PadButton.ID.MemRecall, "mr", 1, 2, memBrush);
			e_memAdd = AddButton(PadButton.ID.MemAdd, "m+", 2, 2, memBrush);
			e_memSubtract = AddButton(PadButton.ID.MemSubtract, "m-", 3, 2, memBrush);

			e_allClear = AddButton(PadButton.ID.AllClear, "AC", 0, 3, funcBrush);
			e_percent = AddButton(PadButton.ID.Percent, "%", 1, 3, funcBrush);
			e_divide = AddButton(PadButton.ID.Divide, "÷", 2, 3, funcBrush);
			e_multiple = AddButton(PadButton.ID.Multiply, "×", 3, 3, funcBrush);

			e_d7 = AddButton(PadButton.ID.D7, "7", 0, 4, digitBrush);
			e_d8 = AddButton(PadButton.ID.D8, "8", 1, 4, digitBrush);
			e_d9 = AddButton(PadButton.ID.D9, "9", 2, 4, digitBrush);
			e_subtract = AddButton(PadButton.ID.Subtract, "-", 3, 4, funcBrush);

			e_d4 = AddButton(PadButton.ID.D4, "4", 0, 5, digitBrush);
			e_d5 = AddButton(PadButton.ID.D5, "5", 1, 5, digitBrush);
			e_d6 = AddButton(PadButton.ID.D6, "6", 2, 5, digitBrush);
			e_add = AddButton(PadButton.ID.Add, "+", 3, 5, funcBrush);

			e_d1 = AddButton(PadButton.ID.D1, "1", 0, 6, digitBrush);
			e_d2 = AddButton(PadButton.ID.D2, "2", 1, 6, digitBrush);
			e_d3 = AddButton(PadButton.ID.D3, "3", 2, 6, digitBrush);
			e_equal = AddButton(PadButton.ID.Equal, "=", 3, 1, 6, 2, equalBrush);

			e_d0 = AddButton(PadButton.ID.D0, "0", 0, 7, digitBrush);
			e_decimal = AddButton(PadButton.ID.Decimal, ".", 1, 7, digitBrush);
			e_negate = AddButton(PadButton.ID.Negate, "±", 2, 7, digitBrush);
		}

		~Calculator_Demo()
		{
			MainWindow.Me.KeyDown -= OnKeyDown;
		}

		/// <summary>
		/// Convenience method for adding buttons
		/// </summary>
		PadButton AddButton(PadButton.ID id, string text, int column, int row, Brush background) => AddButton(id, text, column, 1, row, 1, background);

		/// <summary>
		/// Convenience method for adding buttons
		/// </summary>
		PadButton AddButton(PadButton.ID id, string text, int column, int columnSpan, int row, int rowSpan, Brush background)
		{
			var button = new PadButton(id, text, foreground, background, borderBrush);

			button.Click += Button_Click;
			Children.Add(button, new Grid.Anchor(column, columnSpan, row, rowSpan));

			return button;
		}

		/// <summary>
		/// Handle key down events.
		/// </summary>
		void OnKeyDown(object sender, KeyEventArgs e)
		{
			var unicodeZero = Convert.ToInt32(Model.ZeroChar);

			// If the numpad was used then process accordingly. This may seem
			// redudant considering the rest of the method body, but numpad
			// keys will always generate these, regardless of whether [NumLock]
			// is pressed.
			switch (e.NumpadKey)
			{
				case NumpadKey.Add:
					Model.ProcessOp(PadButton.ID.Add);
					return;
				case NumpadKey.Subtract:
					Model.ProcessOp(PadButton.ID.Subtract);
					return;
				case NumpadKey.Multiply:
					Model.ProcessOp(PadButton.ID.Multiply);
					return;
				case NumpadKey.Divide:
					Model.ProcessOp(PadButton.ID.Divide);
					return;
				case NumpadKey.ChangeSign:
					Model.ProcessOp(PadButton.ID.Negate);
					return;
				case NumpadKey.Enter:
				case NumpadKey.Equal:
					Model.ProcessOp(PadButton.ID.Equal);
					return;
				case NumpadKey.Decimal:
					Model.ProcessKey(Model.DecimalChar);
					return;
				case NumpadKey n when n >= NumpadKey.D0 && n <= NumpadKey.D9:
					Model.ProcessKey(Convert.ToChar((int)e.NumpadKey - (int)NumpadKey.D0  + unicodeZero));
					return;
			}

			// If a familiar key was pressed that maps to the calculator keys then process it
			switch (e.KeyText[0])
			{
				case Model.AddChar:
					Model.ProcessOp(PadButton.ID.Add);
					return;
				case Model.SubtractChar:
					Model.ProcessOp(PadButton.ID.Subtract);
					return;
				case Model.MultiplyChar:
					Model.ProcessOp(PadButton.ID.Multiply);
					return;
				case Model.DivideChar:
					Model.ProcessOp(PadButton.ID.Divide);
					return;
				case Model.EqualChar:
					Model.ProcessOp(PadButton.ID.Equal);
					return;
				case Model.DecimalChar:
					Model.ProcessKey(Model.DecimalChar);
					return;
				case char c when c >= Model.ZeroChar && c <= Model.NineChar:
					Model.ProcessKey(c);
					return;
			}
		}

		/// <summary>
		/// Handle any calculator button click.
		/// </summary>
		void Button_Click(object sender, Lesarde.Frogui.RoutedEventArgs e)
		{
			var button = (PadButton)sender;

			switch (button.Id)
			{
				case PadButton.ID.MemClear:
				case PadButton.ID.MemRecall:
				case PadButton.ID.MemAdd:
				case PadButton.ID.MemSubtract:
				case PadButton.ID.AllClear:
				case PadButton.ID.Percent:
				case PadButton.ID.Add:
				case PadButton.ID.Subtract:
				case PadButton.ID.Divide:
				case PadButton.ID.Multiply:
				case PadButton.ID.Negate:
				case PadButton.ID.Equal:
					Model.ProcessOp(button.Id);
					break;

				case PadButton.ID.D0:
				case PadButton.ID.D1:
				case PadButton.ID.D2:
				case PadButton.ID.D3:
				case PadButton.ID.D4:
				case PadButton.ID.D5:
				case PadButton.ID.D6:
				case PadButton.ID.D7:
				case PadButton.ID.D8:
				case PadButton.ID.D9:
					Model.ProcessKey(Convert.ToChar(Convert.ToInt16(Model.ZeroChar) + (int)button.Id - (int)PadButton.ID.D0));
					break;
				case PadButton.ID.Decimal:
					Model.ProcessKey(Model.DecimalChar);
					break;
			}
		}


	}
}