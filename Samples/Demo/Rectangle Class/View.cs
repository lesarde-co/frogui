using Lesarde.Frogui.Shapes;

namespace Demo.Rectangle_Class
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Rectangle"/> element.
	/// </summary>
	public partial class View : WrappingFlex
    {
		public View() : base(8, 48)
		{
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
