using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Calculator
{
	/***************************************************************************************************
		Model class
	***************************************************************************************************/
	/// <summary>
	/// This serves as the calculator's model.
	/// <para></para>
	/// TODO: There are some bugs in this model.
	/// </summary>
	public class Model
	{
		public const char ZeroChar = '0';
		public const char NineChar = '9';
		public const char DecimalChar = '.';
		public const char BackspaceChar = '\b';
		public const char AddChar = '+';
		public const char SubtractChar = '-';
		public const char MultiplyChar = '*';
		public const char DivideChar = '/';
		public const char EqualChar = '=';

		public const string ZeroString = "0";

		public string DisplayText { get; set; }

		double DisplayValue => Convert.ToDouble(DisplayText);

		public double Memory { get; set; }
		public bool EraseDisplay { get; set; }

		public bool InError { get; set; }

		PadButton.ID lastOp, prevOp;
		public PadButton.ID LastOp
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

		public Model()
		{
			ProcessOp(PadButton.ID.AllClear);
		}

		void AddToDisplay(char c)
		{
			if (c == DecimalChar)
			{
				if (DisplayText.Contains(DecimalChar))
					return;
				DisplayText += c;
			}
			else if (c >= ZeroChar && c <= NineChar)
				DisplayText = (ZeroString == DisplayText) ? $"{c}" : $"{DisplayText}{c}";
			else if (c == BackspaceChar)
				if (DisplayText.Length <= 1)
					DisplayText = String.Empty;
				else
				{
					var i = DisplayText.Length;
					DisplayText = DisplayText.Remove(DisplayText.Length - 1, 1);
				}

			UpdateDisplay();
		}

		public event Action DisplayChanged;

		void UpdateDisplay() => DisplayChanged?.Invoke();

		public void ProcessOp(PadButton.ID id)
		{
			if (PadButton.ID.AllClear != id && InError)
				return;

			Double d = 0.0;

			switch (id)
			{
				case PadButton.ID.Add:
				case PadButton.ID.Subtract:
				case PadButton.ID.Divide:
				case PadButton.ID.Multiply:
				case PadButton.ID.Percent:
					LastOp = id;
					if (EraseDisplay)
						break;
					if (null != LastText)
						CalcResults(id);
					LastText = DisplayText;
					EraseDisplay = true;
					break;
				case PadButton.ID.AllClear:
					LastOp = PadButton.ID.None;
					LastText = null;
					DisplayText = ZeroString;
					UpdateDisplay();
					break;
				case PadButton.ID.Negate:
					DisplayText = (DisplayValue * -1.0d).ToString();
					UpdateDisplay();
					break;
				case PadButton.ID.Equal:
					if (EraseDisplay)
						break;
					CalcResults(id);
					EraseDisplay = true;
					LastOp = PadButton.ID.None;
					LastText = DisplayText;
					break;
				case PadButton.ID.MemClear:
					Memory = 0.0F;
					break;
				case PadButton.ID.MemRecall:
					DisplayText = Memory.ToString();
					UpdateDisplay();
					EraseDisplay = false;
					break;
				case PadButton.ID.MemAdd:
					d = Memory + DisplayValue;
					Memory = d;
					EraseDisplay = true;
					break;
				case PadButton.ID.MemSubtract:
					d = Memory - DisplayValue;
					Memory = d;
					EraseDisplay = true;
					break;
			}
		}

		private void CalcResults(PadButton.ID id)
		{
			if (PadButton.ID.None == LastOp)
				return;

			double d;

			d = Calc(LastOp);
			DisplayText = d.ToString();

			UpdateDisplay();
		}

		private double Calc(PadButton.ID id)
		{
			double d = 0.0;

			try
			{
				switch (LastOp)
				{
					case PadButton.ID.Divide:
						d = LastValue / DisplayValue;
						CheckResult(d);
						break;
					case PadButton.ID.Add:
						d = LastValue + DisplayValue;
						CheckResult(d);
						break;
					case PadButton.ID.Multiply:
						d = LastValue * DisplayValue;
						CheckResult(d);
						break;
					case PadButton.ID.Percent:
						{
							var pct = DisplayValue / 100.0F;
							var last = LastValue;
							switch (prevOp)
							{
								case PadButton.ID.Add:
									d = last + pct;
									break;
								case PadButton.ID.Subtract:
									d = last - pct;
									break;
								case PadButton.ID.Multiply:
									d = last * pct;
									break;
								case PadButton.ID.Divide:
									d = last / pct;
									break;
								default:
									break;
							}

							CheckResult(d);
						}
						break;
					case PadButton.ID.Subtract:
						d = LastValue - DisplayValue;
						CheckResult(d);
						break;
					case PadButton.ID.Negate:
						d = LastValue * (-1.0F);
						break;
				}
			}
			catch
			{
				d = 0;
			}

			return d;
		}

		private void CheckResult(double d)
		{
			if (Double.IsNegativeInfinity(d) || Double.IsPositiveInfinity(d) || Double.IsNaN(d))
			{
				InError = true;
				DisplayText = "ERROR";
				UpdateDisplay();
			}
		}

	}
}
