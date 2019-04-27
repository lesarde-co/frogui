using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;
using System.Reactive.Linq;

namespace Demo.Tip_Calculator
{
	/***************************************************************************************************
		IntegerBox class
	***************************************************************************************************/
	/// <summary>
	/// This element class is used for integer input using [-] [+] buttons. It inherits from <see cref="Border"/>
	/// because a border can host a child and can clip at the boreder's rounded perimeter.
	/// <para></para>
	/// See the associated design file more for details.
	/// </summary>
	public partial class IntegerBox : Border
	{
		/***********************************************************
			Value property
		***********************************************************/
		/// <summary>
		/// Identifies the <see cref="Value"/> dependency property.
		/// </summary>
		public static DependencyProperty<int, IntegerBox> ValueProperty = DependencyProperty<int, IntegerBox>
			.Register()
			//.Changed((d, e) => d.e_textBox.Text = e.NewValue.ToString());
			.Changed((d, e) => d.SyncText());

		/// <summary>
		/// Gets or sets the <see cref="int"/> value. This property should be used
		/// instead of the <see cref="TextBox.Text"/> property for managing the displayed text.
		/// </summary>
		public int Value
		{
			get => GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public IntegerBox()
		{
			InitializeComponent();

			// Observe the e_textBox's Text property. When it changes, convert the text to an integer and update the Value property
			e_textBox.GetObservable(TextBox.TextProperty)
				.Select(text => Int32.TryParse(text, out var value) ? value : 0)
				.Subscribe((value) =>
				{
					if (this.Value != value)
					{
						this.Value = value;
						SyncText();
					}
				});
		}

		/*******************************************************************************
			SyncText()
		*******************************************************************************/

		void SyncText() => e_textBox.Text = Value.ToString();

		/*******************************************************************************
			e_minus_Click()
		*******************************************************************************/

		void e_minus_Click(object sender, RoutedEventArgs e) => --Value;

		/*******************************************************************************
			e_plus_Click()
		*******************************************************************************/

		void e_plus_Click(object sender, RoutedEventArgs e) => ++Value;
	}
}

