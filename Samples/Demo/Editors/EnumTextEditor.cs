using Lesarde.Frogui.Controls;

namespace Demo
{
	/***************************************************************************************************
		 EnumImageEditor class
	***************************************************************************************************/
	/// <summary>
	/// Edits an enum property using a <see cref="Segmentor"/> whose members display the enum value's name.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EnumTextEditor<T> : EnumEditor<T>
    {
		/*******************************************************************************
			PrepSegment()
		*******************************************************************************/

		protected override void PrepSegment(Segment segment, string name, T value)
		{
			segment.Text = name;
			segment.Value = value;
		}
	}
}
