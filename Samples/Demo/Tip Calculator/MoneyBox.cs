using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using System;
using System.Reactive.Linq;
using System.Text.RegularExpressions;

namespace Demo.Tip_Calculator
{
	/***************************************************************************************************
		MoneyBox class
	***************************************************************************************************/
	/// <summary>
	/// A control that allows money values to be edited in text form.
	/// </summary>
	public class MoneyBox : TextBox
    {
		/***********************************************************
			Money property
		***********************************************************/
		/// <summary>
		/// Identifies the <see cref="Money"/> dependency property.
		/// </summary>
		public static DependencyProperty<decimal, MoneyBox> MoneyProperty = DependencyProperty<decimal, MoneyBox>
			.Register()
			.Changed((d, e) => d.SyncText());

		/// <summary>
		/// Gets or sets the <see cref="decimal"/> money value. This property should be used
		/// instead of the <see cref="TextBox.Text"/> property for managing the displayed text.
		/// </summary>
		public decimal Money 
		{
			get => GetValue(MoneyProperty);
			set => SetValue(MoneyProperty, value);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public MoneyBox()
		{
			SyncText();

			// Observe the Text property. When it changes, convert the string to a decimal and update the Money property
			GetObservable(TextProperty)
				.Select(a => Tip_Calculator.Money.ToDecimal(a))
				.Subscribe((b) => { Money = b; });
		}

		/*******************************************************************************
			SyncText()
		*******************************************************************************/

		void SyncText() => Text = Tip_Calculator.Money.ToText(Money);
	}
}
