using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Controls.Primitives;
using System;

namespace Demo.Example_Slider
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="CheckBox"/> class.
	/// </summary>
	public partial class View : Decorator, IExampleView
    {
		Element IExampleView.MainElement => e_slider;

		void AddEnums(Selector selector, Type type, object selectedItem)
		{
			foreach (var cur in Enum.GetValues(type))
				selector.Items.Add(cur);
			selector.SelectedItem = selectedItem;
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public View()
		{
			InitializeComponent();
		}

	}
}
