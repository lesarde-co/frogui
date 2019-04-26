using System.Text.RegularExpressions;

namespace Demo.Example_Tip_Calculator
{
	/***************************************************************************************************
		Money class
	***************************************************************************************************/

	public class Money
    {
		const string Pattern = "\\d+.\\d*";

		/*******************************************************************************
			ToText()
		*******************************************************************************/
		/// <summary>
		/// Convert the specified <see cref="value"/> to a money string.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToText(decimal value) => string.Format("${0:N2}", value);

		/*******************************************************************************
			ToDecimal()
		*******************************************************************************/
		/// <summary>
		/// Convert the specified money string to a money decimal, or 0 if the conversion fails.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static decimal ToDecimal(string s)
		{
#if notyet // KEY:GlobalizationInWasm - This works for Windows but not yet for was wasm
			if (decimal.TryParse(s, System.Globalization.NumberStyles.Currency, null, out var result))
			{
				Lesarde.Frogui.Application.Me.LogWriteLine($"ToDecimal({s}) = {result}");
				return result;
			}

			Lesarde.Frogui.Application.Me.LogWriteLine($"ToDecimal({s}) failed.");
			return 0;
#else
			var decStr = Regex.Match(s, Pattern);
			if (decStr.Success && decimal.TryParse(decStr.Value, out var decValue))
				return decValue;

			return 0.0M;
#endif
		}
	}
}
