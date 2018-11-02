using Lesarde.Frogui;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Demo.Tip_Calculator
{
	/***************************************************************************************************
		Model class
	***************************************************************************************************/
	/// <summary>
	/// Serves as the model for the tip calculator.
	/// </summary>
	public class Model : DependencyObject, INotifyPropertyChanged
	{
		/***********************************************************
			PropertyChanged event
		***********************************************************/

		public event PropertyChangedEventHandler PropertyChanged;

		/***********************************************************
			Bill property
		***********************************************************/

		public static DependencyProperty<decimal, Model> BillProperty = DependencyProperty<decimal, Model>
			.Register()
			.Validation(Validate.Range(0.00M, 1000000.00M, "bill"))
			.Changed((d, e) => d.CalcResults());

		public decimal Bill
		{
			get => GetValue(BillProperty);
			set => SetValue(BillProperty, value);
		}

		/***********************************************************
			TipPercent property
		***********************************************************/

		public static DependencyProperty<int, Model> TipPercentProperty = DependencyProperty<int, Model>
			.Register()
			.Validation(Validate.Range(0, 100, "tip percent"))
			.Default(20)
			.Changed((d, e) => d.CalcResults());

		public int TipPercent
		{
			get => GetValue(TipPercentProperty);
			set => SetValue(TipPercentProperty, value);
		}

		/***********************************************************
			NumPeople property
		***********************************************************/

		public static DependencyProperty<int, Model> NumPeopleProperty = DependencyProperty<int, Model>
			.Register()
			.Validation(Validate.Range(1, 1000, "number of people"))
			.Default(1)
			.Changed((d, e) => d.CalcResults());

		public int NumPeople
		{
			get => GetValue(NumPeopleProperty);
			set => SetValue(NumPeopleProperty, value);
		}

		/***********************************************************
			TipPerPerson property
		***********************************************************/

		public static DependencyProperty<decimal, Model> TipPerPersonProperty = DependencyProperty<decimal, Model>
			.Register();

		public decimal TipPerPerson
		{
			get => GetValue(TipPerPersonProperty);
			set => SetValue(TipPerPersonProperty, value);
		}

		/***********************************************************
			TotalPerPerson property
		***********************************************************/

		public decimal TotalPerPerson
		{
			get => totalPerPerson;
			set
			{
				totalPerPerson = value;
				NotifyPropertyChanged();
			}
		}

		decimal totalPerPerson;

		/*******************************************************************************
			CalcResults()
		*******************************************************************************/

		void CalcResults()
		{
			//Application.Me.LogWriteLine("CalcResults");
			var totalTip = Bill * TipPercent / 100;
			var totalBill = Bill + totalTip;

			TipPerPerson = totalTip / NumPeople;
			TotalPerPerson = totalBill / NumPeople;
		}

		/*******************************************************************************
			NotifyPropertyChanged()
		*******************************************************************************/
		/// <summary>
		/// This method is called by the Set accessor of each property. 
		/// The <see cref="CallerMemberNameAttribute"/> that is applied to the optional <paramref name="propertyName"/>
		/// parameter causes the property name of the caller to be substituted as an argument.
		/// </summary>
		/// <param name="propertyName">The name of the property that has changed.</param>
		void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
