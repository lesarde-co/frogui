using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using System;
using System.Reactive.Linq;

namespace Demo.Example_Tip_Calculator
{
	/***************************************************************************************************
		View class

		TODO:Add localized currency support
		https://docs.microsoft.com/en-us/globalization/locale/currency-formatting-in-the-dotnet-framework
		https://stackoverflow.com/questions/14162357/convert-currency-string-to-decimal

		TODO:Diagram how Tip Calc works -- data-binding & observation
	***************************************************************************************************/
	/// <summary>
	/// This is the main element of the tip calculator demo. It inherits from <see cref="Border"/>
	/// which provides a simple way to pad and have a background.
	/// <para></para>
	/// Uses <see cref="Tip_Calculator.Model"/> as a model.
	/// </summary>
	public partial class View : Border, IViewOfModel<Model>, IExampleView
	{
		/***********************************************************
			Model property
		***********************************************************/

		public Model Model => (Model)ModelObject;

		public object ModelObject
		{
			get => DataContext;
			set => DataContext = value;
		}

		Element IExampleView.MainElement => this;

		//public object ModelObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		/*******************************************************************************
			$
		*******************************************************************************/

		public View()
		{
			InitializeComponent();

			ModelObject = new Model();

			// Observe the Model.NumPeopleProperty
			Model
				.CreateObservable(Model.NumPeopleProperty)
				.Select(numPeople => 1 == numPeople ? Visibility.Collapsed : Visibility.Visible)
				.Subscribe(vis => 
				{
					e_tipPerPersonLabel.Visibility = vis;
					e_totalPerPersonLabel.Visibility = vis;
				});
		}
	}
}