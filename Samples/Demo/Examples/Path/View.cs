using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_Path
{
	 
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Path"/> class.
	/// <para>
	/// Coding paths is definitely not intuitive and can become quite complex. Working with
	/// paths is easier using XAML (e.g. Path Data="M150 0 L75 200 L225 200 Z") or even
	/// better, using an SVG path editing tool. We were not able to get paths working in XAML in
	/// time for this release.
	/// </para>
	/// </summary>
	public partial class View : Flex, IExampleView
    {
		Element IExampleView.MainElement => e_check;

		Path e_check { get; set; }

		public View()
		{
			InitializeComponent();

			// Create a check mark path (see class comments above).
			e_check = new Path();
			var pg = new PathGeometry();
			e_check.Data = pg;
			pg.Figures = new PathFigureCollection();
			var pf = new PathFigure();
			pf.StartPoint = new PointFloat(9.97498, 1.22334);
			pg.Figures.Add(pf);
			pf.Segments = new PathSegmentCollection();
			pf.Segments.Add(new LineSegment(new PointFloat(4.6983, 9.09834), true));
			pf.Segments.Add(new LineSegment(new PointFloat(4.52164, 9.09834), true));
			pf.Segments.Add(new LineSegment(new PointFloat(0, 5.19331), true));
			pf.Segments.Add(new LineSegment(new PointFloat(1.27664, 3.52165), true));
			pf.Segments.Add(new LineSegment(new PointFloat(4.255, 6.08833), true));
			pf.Segments.Add(new LineSegment(new PointFloat(8.33331, 1.52588e-005), true));
			pf.Segments.Add(new LineSegment(new PointFloat(9.97498, 1.22334), true));

			Children.Add(e_check);
		}
	}
}
