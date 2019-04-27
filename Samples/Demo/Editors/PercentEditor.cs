using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Data;

namespace Demo
{
	public class PercentEditor : DoubleSlider
	{
		public PercentEditor()
		{
			SmallChange = 0.01m;
			LargeChange = SmallChange;
			Maximum = 1.0m;
		}
	}
}
