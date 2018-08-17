
namespace Demo.TipCalculator
{
	/***************************************************************************************************
		Model class
	***************************************************************************************************/
	/// <summary>
	/// Serves as the model for the tip calculator.
	/// </summary>
	public class Model
	{
		/***********************************************************
			constants
		***********************************************************/

		const double
			DefaultBill = 0.0d;

		const int
			DefaultTip = 20,
			DefaultNumPeople = 1;

		/***********************************************************
			Bill property
		***********************************************************/

		double bill;
		public double Bill
		{
			get => bill;
			set
			{
				if (bill == value)
					return;

				if (value < 0.0 || value > 1000000.00)
					bill = DefaultBill;
				else
					bill = value;
			}
		}

		/***********************************************************
			TipPercent property
		***********************************************************/

		int tipPercent;
		public int TipPercent
		{
			get => tipPercent;
			set
			{
				if (tipPercent == value)
					return;

				if (value < 0 || value > 100)
					tipPercent = DefaultTip;
				else
					tipPercent = value;
			}
		}

		/***********************************************************
			NumPeople property
		***********************************************************/

		int numPeople;
		public int NumPeople
		{
			get => numPeople;
			set
			{
				if (numPeople == value)
					return;

				if (value < 1 || value > 1000)
					numPeople = DefaultNumPeople;
				else
					numPeople = value;
			}
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public Model()
		{
			Bill = DefaultBill;
			TipPercent = DefaultTip;
			NumPeople = DefaultNumPeople;
		}
	}
}
