using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_Grid
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Grid"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		/***********************************************************
			...
		***********************************************************/

		int origColumnCount = 0;
		int origRowCount = 0;

		/***********************************************************
			MainElement property
		***********************************************************/

		Element IExampleView.MainElement => e_grid;

		/*******************************************************************************
			$
		*******************************************************************************/

		public View()
		{
			InitializeComponent();

			e_grid.AddPropertyChangedListener(Grid.ColumnCountProperty, ColumnCountChanged, true);
			e_grid.AddPropertyChangedListener(Grid.RowCountProperty, RowCountChanged, true);
		}

		/*******************************************************************************
			ColumnCountChanged()
		*******************************************************************************/

		internal void ColumnCountChanged(int newColumnCount)
		{
			// Increasing
			if (newColumnCount > origColumnCount)
			{
				for (var column = origColumnCount; column < newColumnCount; ++column)
					for (var row = 0; row < e_grid.RowCount; ++row)
						AddBall(column, row);
			}
			// Decreasing
			else
			{
				for (var column = newColumnCount; column < origColumnCount; ++column)
					for (var row = 0; row < e_grid.RowCount; ++row)
						RemoveBall(column, row);
			}

			origColumnCount = newColumnCount;
		}

		/*******************************************************************************
			RowCountChanged()
		*******************************************************************************/

		internal void RowCountChanged(int newRowCount)
		{
			// Increasing
			if (newRowCount > origRowCount)
			{
				for (var column = 0; column < e_grid.ColumnCount; ++column)
					for (var row = origRowCount; row < newRowCount; ++row)
						AddBall(column, row);
			}
			// Decreasing
			else
			{
				for (var column = 0; column < e_grid.ColumnCount; ++column)
					for (var row = newRowCount; row < origRowCount; ++row)
						RemoveBall(column, row);
			}

			origRowCount = newRowCount;
		}

		/*******************************************************************************
			AddBall()
		*******************************************************************************/

		void AddBall(int column, int row)
		{
			var e_ball = new Ellipse()
			{
				Stroke = SolidColorBrushes.Yellow.Brush,
				Fill = SolidColorBrushes.Blue.Brush,
				MinWidth = Length.InPixels(10),
				MinHeight = Length.InPixels(10)
			};

			e_grid.Children.Add(e_ball, new GridAnchor(column, row));
		}

		/*******************************************************************************
			RemoveBall()
		*******************************************************************************/

		void RemoveBall(int column, int row)
		{
			foreach (var cur in e_grid.Children)
			{
				var anchor = (GridAnchor)cur.Anchor;

				if (anchor.ColumnAsInt == column && anchor.RowAsInt == row)
				{
					e_grid.Children.Remove(cur);
					return;
				}
			}
		}
	}
}
