using Lesarde.Frogui.Media;

namespace Demo
{
    public class FontWeightEditor : EnumEditor<FontWeightKind>
    {
		protected override void PrepSegment(Segment segment, string name, FontWeightKind value)
		{
			segment.Text = name;
			segment.Value = FontWeight.FromKind(value);
		}
	}
}
