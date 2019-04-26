using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using System;
using System.Reactive.Linq;

namespace Demo.Example_Binding_A
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

			e_tb1.DataContext = e_tb2;
			e_tb2.DataContext = e_tb3;

		}

		Element IExampleView.MainElement => this;
	}
}
