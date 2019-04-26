using Lesarde.Frogui.Media;

namespace Demo
{
	/***************************************************************************************************
		BrushInfo class
	***************************************************************************************************/

	public class BrushInfo
	{
		public Brush Brush { get; set; }
		public string Name { get; set; }

		public string BrushTypeName => Brush.GetType().Name;
	}
}
