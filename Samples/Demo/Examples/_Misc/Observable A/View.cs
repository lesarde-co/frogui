using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace Demo.Example_Observable_A
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="CheckBox"/> class.
	/// </summary>
	public partial class View : Flex, IExampleView
    {
		public View()
		{
			InitializeComponent();

#if ! WASM
			// e_tb1 <- e_tb2
			e_tb1.CreateObservable(TextBox.TextProperty)
				.Subscribe(v => e_tb2.Text = v);

			// e_tb1 <- e_tb3 - delay 2 seconds
			e_tb1.CreateObservable(TextBox.TextProperty)
				.Delay(TimeSpan.FromSeconds(2))
				.Subscribe(v => e_tb3.Text = v);

			// e_tb1 <- e_tb4 - delay 4 seconds
			e_tb1.CreateObservable(TextBox.TextProperty)
				.Delay(TimeSpan.FromSeconds(4))
				.Subscribe(v => e_tb4.Text = v);

			// e_tb1 <- e_tb5 - replace 'a' with '*'
			e_tb1.CreateObservable(TextBox.TextProperty)
				.Select(v => e_tb5.Text = v.Replace('a', '*'))
				.Subscribe(v => e_tb5.Text = v);

			// e_tb1 <- e_tb6 - throttle 3 seconds
			e_tb1.CreateObservable(TextBox.TextProperty)
				.Throttle(TimeSpan.FromSeconds(3))
				.Subscribe(v => e_tb6.Text = v);

			// e_tb1 <- e_tb7 - buffer 1 second
			e_tb1.CreateObservable(TextBox.TextProperty)
				.Buffer(TimeSpan.FromSeconds(1))
				.Select(argsList => string.Join('\n', argsList))
				.Subscribe(v => e_tb7.Text = v);

			// e_tb1 <- e_tb8 - TimeInterval()
			e_tb1.CreateObservable(TextBox.TextProperty)
				.TimeInterval()
				.Subscribe(v => e_timeInterval.Text = v.Interval.ToString());
#endif
		}

		Element IExampleView.MainElement => this;
	}
}
