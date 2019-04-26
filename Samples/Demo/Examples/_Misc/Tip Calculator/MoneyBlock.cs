using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo.Example_Tip_Calculator
{
	/***************************************************************************************************
		MoneyBlock class
	***************************************************************************************************/
	/// <summary>
	/// A control that allows money values to be displayed in text form.
	/// </summary>
	public class MoneyBlock : TextBlock
    {
		/***********************************************************
			Money property
		***********************************************************/
		/// <summary>
		/// Identifies the <see cref="Money"/> dependency property.
		/// </summary>
		public static DependencyProperty<decimal, MoneyBlock> MoneyProperty { get; } = DependencyProperty<decimal, MoneyBlock>
			.Register()
			.Changed((d, e) => d.SyncText());

		/// <summary>
		/// Gets or sets the <see cref="decimal"/> money value. This property should be used
		/// instead of the <see cref="TextBlock.Text"/> property for managing the displayed text.
		/// </summary>
		public decimal Money 
		{
			get => GetValue(MoneyProperty);
			set => SetValue(MoneyProperty, value);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public MoneyBlock()
		{
			SyncText();
		}

		/*******************************************************************************
			SyncText()
		*******************************************************************************/

		void SyncText() => Text = Example_Tip_Calculator.Money.ToText(Money);
	}
}
