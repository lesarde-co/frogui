using Lesarde.Frogui;
using Lesarde.Frogui.Input;
using System;
using System.Windows.Input;

namespace Demo.Example_Calculator
{
	/***************************************************************************************************
		ViewModel class
	***************************************************************************************************/
	/// <summary>
	/// This serves as the calculator's model.
	/// <para></para>
	/// TODO: There are some bugs in this model.
	/// </summary>
	public class ViewModel : DependencyObject
	{
		/***********************************************************
			Commands class
		***********************************************************/

		public static class Commands
		{
			public static Command MemClear { get; } = new Command()
				.Add(new KeyInput(Key.C, ModifierKeys.Alt));

			public static Command MemRecall { get; } = new Command()
				.Add(new KeyInput(Key.R, ModifierKeys.Alt));

			public static Command MemAdd { get; } = new Command()
				.Add(new KeyInput(NumpadKey.Add, ModifierKeys.Alt))
				.Add(new KeyInput(AddChar, ModifierKeys.Alt));

			public static Command MemSubtract { get; } = new Command()
				.Add(new KeyInput(NumpadKey.Subtract, ModifierKeys.Alt))
				.Add(new KeyInput(SubtractChar, ModifierKeys.Alt));

			public static Command AllClear { get; } = new Command()
				.Add(new KeyInput(Key.C));

			public static Command Negate { get; } = new Command()
				.Add(new KeyInput(NumpadKey.ChangeSign));

			public static Command Equal { get; } = new Command()
				.Add(new KeyInput(NumpadKey.Equal))
				.Add(new KeyInput(NumpadKey.Enter))
				.Add(new KeyInput(EqualChar));

			public static Command Percent { get; } = new Command()
				.Add(new KeyInput(PercentChar));

			public static Command Add { get; } = new Command()
				.Add(new KeyInput(NumpadKey.Add))
				.Add(new KeyInput(AddChar));

			public static Command Subtract { get; } = new Command()
				.Add(new KeyInput(NumpadKey.Subtract))
				.Add(new KeyInput(SubtractChar));

			public static Command Multiply { get; } = new Command()
				.Add(new KeyInput(NumpadKey.Multiply))
				.Add(new KeyInput(MultiplyChar));

			public static Command Divide { get; } = new Command()
				.Add(new KeyInput(NumpadKey.Divide))
				.Add(new KeyInput(DivideChar));

			public static Command D0 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D0))
				.Add(new KeyInput(ViewModel.D0));

			public static Command D1 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D1))
				.Add(new KeyInput(ViewModel.D1));

			public static Command D2 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D2))
				.Add(new KeyInput(ViewModel.D2));

			public static Command D3 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D3))
				.Add(new KeyInput(ViewModel.D3));

			public static Command D4 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D4))
				.Add(new KeyInput(ViewModel.D4));

			public static Command D5 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D5))
				.Add(new KeyInput(ViewModel.D5));

			public static Command D6 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D6))
				.Add(new KeyInput(ViewModel.D6));

			public static Command D7 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D7))
				.Add(new KeyInput(ViewModel.D7));

			public static Command D8 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D8))
				.Add(new KeyInput(ViewModel.D8));

			public static Command D9 { get; } = new Command()
				.Add(new KeyInput(NumpadKey.D9))
				.Add(new KeyInput(ViewModel.D9));

			public static Command Decimal { get; } = new Command()
				.Add(new KeyInput(DecimalChar));

			public static Command Backspace { get; } = new Command()
				.Add(new KeyInput(Key.Back));
		}

		public const char D0 = '0';
		public const char D1 = '1';
		public const char D2 = '2';
		public const char D3 = '3';
		public const char D4 = '4';
		public const char D5 = '5';
		public const char D6 = '6';
		public const char D7 = '7';
		public const char D8 = '8';
		public const char D9 = '9';
		public const char DecimalChar = '.';
		public const char AddChar = '+';
		public const char SubtractChar = '-';
		public const char MultiplyChar = '*';
		public const char DivideChar = '/';
		public const char EqualChar = '=';
		public const char PercentChar = '%';

		public const string ZeroString = "0";


		double DisplayValue => Convert.ToDouble(DisplayText);

		public double Memory { get; set; }
		public bool EraseDisplay { get; set; }


		ICommand lastOp, prevOp;
		public ICommand LastOp
		{
			get => lastOp;

			set
			{
				prevOp = lastOp;
				lastOp = value;
			}
		}

		string LastText { get; set; }

		double LastValue => Convert.ToDouble(LastText);

		/***********************************************************
			DisplayText property
		***********************************************************/
		/// <summary>
		/// Identifies the <see cref="DisplayText"/> dependency property.
		/// </summary>
		public static DependencyProperty<string, ViewModel> DisplayTextProperty { get; }  = DependencyProperty<string, ViewModel>
			.Register()
			.Changed((d, e) => { });

		/// <summary>
		/// Gets or sets the display text.
		/// </summary>
		public string DisplayText
		{
			get => GetValue(DisplayTextProperty);
			set => SetValue(DisplayTextProperty, value);
		}

		/***********************************************************
			InError property
		***********************************************************/

		/// <summary>
		/// Identifies the <see cref="InError"/> dependency property.
		/// </summary>
		public static DependencyProperty<bool, ViewModel> InErrorProperty { get; } = DependencyProperty<bool, ViewModel>
			.Register()
			.Changed((d, e) => { });

		/// <summary>
		/// Gets or sets the display text.
		/// </summary>
		public bool InError
		{
			get => GetValue(InErrorProperty);
			set => SetValue(InErrorProperty, value);
		}

		public void ProcessKey(char c)
		{
			InError = false;

			if (EraseDisplay)
			{
				DisplayText = ZeroString;
				EraseDisplay = false;
			}
			
			AddToDisplay(c);
		}

		public ViewModel()
		{
			CommandBindings.Add(Commands.MemClear).Subscribe(e =>
			{
				if (!InError)
					Memory = 0.0F;
			});

			CommandBindings.Add(Commands.MemRecall).Subscribe(e =>
			{
				if (!InError)
				{
					DisplayText = Memory.ToString();
					EraseDisplay = false;
				}
			});

			CommandBindings.Add(Commands.MemAdd).Subscribe(e =>
			{
				if (!InError)
				{
					var d = Memory + DisplayValue;
					Memory = d;
					EraseDisplay = true;
				}
			});

			CommandBindings.Add(Commands.MemSubtract).Subscribe(e =>
			{
				if (!InError)
				{
					var d = Memory - DisplayValue;
					Memory = d;
					EraseDisplay = true;
				}
			});

			CommandBindings.Add(Commands.AllClear).Subscribe(e => DoAllClear());
			CommandBindings.Add(Commands.Percent).Subscribe(e =>MathFunc(Commands.Percent));

			CommandBindings.Add(Commands.Add).Subscribe(e => MathFunc(Commands.Add));
			CommandBindings.Add(Commands.Subtract).Subscribe(e => MathFunc(Commands.Subtract));
			CommandBindings.Add(Commands.Divide).Subscribe(e => MathFunc(Commands.Divide));
			CommandBindings.Add(Commands.Multiply).Subscribe(e => MathFunc(Commands.Multiply));

			CommandBindings.Add(Commands.Negate).Subscribe(e =>
			{
				if (!InError)
					DisplayText = (DisplayValue * -1.0d).ToString();
			});

			CommandBindings.Add(Commands.Equal).Subscribe(e =>
			{
				if (!InError)
				{
					if (EraseDisplay)
						return;
					CalcResults();
					EraseDisplay = true;
					LastOp = null;
					LastText = DisplayText;
				}
			});

			CommandBindings.Add(Commands.D0).Subscribe(e => ProcessKey(D0));
			CommandBindings.Add(Commands.D1).Subscribe(e => ProcessKey(D1));
			CommandBindings.Add(Commands.D2).Subscribe(e => ProcessKey(D2));
			CommandBindings.Add(Commands.D3).Subscribe(e => ProcessKey(D3));
			CommandBindings.Add(Commands.D4).Subscribe(e => ProcessKey(D4));
			CommandBindings.Add(Commands.D5).Subscribe(e => ProcessKey(D5));
			CommandBindings.Add(Commands.D6).Subscribe(e => ProcessKey(D6));
			CommandBindings.Add(Commands.D7).Subscribe(e => ProcessKey(D7));
			CommandBindings.Add(Commands.D8).Subscribe(e => ProcessKey(D8));
			CommandBindings.Add(Commands.D9).Subscribe(e => ProcessKey(D9));
			CommandBindings.Add(Commands.Decimal).Subscribe(e => ProcessKey(DecimalChar));

			CommandBindings.Add(Commands.Backspace).Subscribe(e =>
			{
				if (!InError)
					DisplayText = (DisplayText.Length > 1) ? DisplayText.Substring(0, DisplayText.Length - 1) : DisplayText = ZeroString;
			});

			DoAllClear();
		}

		void DoAllClear()
		{
			LastOp = null;
			LastText = null;
			DisplayText = ZeroString;
		}

		void MathFunc(ICommand op)
		{
			if (InError)
				return;

			LastOp = op;
			if (EraseDisplay)
				return;
			if (null != LastText)
				CalcResults();
			LastText = DisplayText;
			EraseDisplay = true;
		}

		void AddToDisplay(char c)
		{
			if (c == DecimalChar)
			{
				if (DisplayText.Contains(DecimalChar))
					return;
				DisplayText += c;
			}
			else if (c >= D0 && c <= D9)
				DisplayText = (ZeroString == DisplayText) ? $"{c}" : $"{DisplayText}{c}";

		}

		void CalcResults()
		{
			if (null == LastOp)
				return;

			var d = Calc();
			DisplayText = d.ToString();
		}

		double Calc()
		{
			var d = 0.0;

			try
			{
				if (Commands.Divide == LastOp)
				{
					d = LastValue / DisplayValue;
					CheckResult(d);
				}
				else if (Commands.Add == LastOp)
				{
					d = LastValue + DisplayValue;
					CheckResult(d);
				}
				else if (Commands.Multiply == LastOp)
				{
					d = LastValue * DisplayValue;
					CheckResult(d);
				}
				else if (Commands.Percent == LastOp)
				{
					var pct = DisplayValue / 100.0F;
					var last = LastValue;
					if (Commands.Add == prevOp)
						d = last + pct;
					else if (Commands.Subtract == prevOp)
						d = last - pct;
					else if (Commands.Multiply == prevOp)
						d = last * pct;
					else if (Commands.Divide == prevOp)
						d = last / pct;

					CheckResult(d);
				}
				else if (Commands.Subtract == LastOp)
				{
					d = LastValue - DisplayValue;
					CheckResult(d);
				}
				else if (Commands.Negate == LastOp)
					d = LastValue * (-1.0F);
			}
			catch
			{
				d = 0;
			}

			return d;
		}

		void CheckResult(double d)
		{
			if (Double.IsNegativeInfinity(d) || Double.IsPositiveInfinity(d) || Double.IsNaN(d))
			{
				InError = true;
				DisplayText = "ERROR";
			}
		}
	}
}