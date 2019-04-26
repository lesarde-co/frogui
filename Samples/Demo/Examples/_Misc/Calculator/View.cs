using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using System;
using System.Reactive.Linq;

namespace Demo.Example_Calculator
{
	/***************************************************************************************************
		Calculator_Demo class
	***************************************************************************************************/
	/// <summary>
	/// This element is used as the root of the calculator demo. It inherits from <see cref="Grid"/>
	/// because the calculator view is very grid-like. This is the view associated with the
	/// <see cref="Calculator.ViewModel"/> class.
	/// <para></para>
	/// Note the <see cref="ViewModel"/> property creates the model object during initialization.
	/// The technique works well here, but is not generally how models are wired to views.
	/// </summary>
	public partial class View : Grid, Lesarde.Frogui.IViewOfViewModel<ViewModel>, IExampleView
	{
		public ViewModel ViewModel { get => (ViewModel)DataContext; set => DataContext = value; }

		Element IExampleView.MainElement => this;

		/// <summary>
		/// The constructor of a design must always first call <see cref="InitializeComponent"/>.
		/// </summary>
		public View()
		{
			InitializeComponent();

			ViewModel = new ViewModel();

			// User code below

			ViewModel.CreateObservable(ViewModel.InErrorProperty)
				.Select(inError => inError ? MyAssets.Singleton.MyErrorForeground : MyAssets.Singleton.MyForeground)
				.Subscribe((displayForeground) => e_text.Foreground = displayForeground);
		}
	}
}