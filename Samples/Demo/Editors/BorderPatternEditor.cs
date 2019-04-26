using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo
{
    public class BorderPatternEditor : EnumEditor<StrokePattern>
    {
		protected override void PrepSegment(Segment segment, string name, StrokePattern value)
		{
			segment.Text = name;
			segment.Value = new BorderPattern(value);
		}
	}
}
