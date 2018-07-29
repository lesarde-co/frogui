using Lesarde.Frogui.Shapes;

namespace Demo
{
	/***************************************************************************************************
		Rectangle_Demo class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Rectangle"/> element.
	/// </summary>
	public partial class Rectangle_Demo : WrappingFlex
    {
		public Rectangle_Demo() : base(11, 55)
		{
			InitializeComponent();

			foreach (var size in Common.SizesMix)
				foreach (var thickness in Common.LengthMix)
					foreach (var radiusX in Common.RadiusMix)
						foreach (var radiusY in Common.RadiusMix)
							foreach (var stroke in Common.BrushesMix)
								foreach (var fill in Common.BrushesMix)
									if (IsReady())
										AddExample(new Rectangle()
										{
											Width = size.Item1,
											Height = size.Item2,
											StrokeThickness = thickness,
											Stroke = stroke,
											Fill = fill,
											Margin = Common.Margin,
											RadiusX = radiusX,
											RadiusY = radiusY,
										});
		}
	}
}
