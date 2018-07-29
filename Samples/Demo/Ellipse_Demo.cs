using Lesarde.Frogui.Media;
using Lesarde.Frogui.Shapes;
using System;

namespace Demo
{
	/***************************************************************************************************
		Ellipse_Demo class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Ellipse"/> element.
	/// </summary>
	public partial class Ellipse_Demo : WrappingFlex
    {
		public Ellipse_Demo() : base(11, 55)
		{
			InitializeComponent();

			foreach (var size in Common.SizesMix)
				foreach (Stretch stretch in Enum.GetValues(typeof(Stretch)))
					foreach (var thickness in Common.LengthMix)
						foreach (var stroke in Common.BrushesMix)
							foreach (var fill in Common.BrushesMix)
								if (IsReady())
									AddExample(new Ellipse()
									{
										Width = size.Item1,
										Height = size.Item2,
										StrokeThickness = thickness,
										Stroke = stroke,
										Fill = fill,
										Margin = Common.Margin
									});
		}
	}
}
