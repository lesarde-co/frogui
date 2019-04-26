using Lesarde.Frogui.Controls;

namespace Demo
{
	/***************************************************************************************************
		 EnumImageEditor class
	***************************************************************************************************/
	/// <summary>
	/// Edits an enum property using a <see cref="Segmentor"/> whose members display an image representing
	/// the enum value.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EnumImageEditor<T> : EnumEditor<T>
    {
		/*******************************************************************************
			PrepSegment()
		*******************************************************************************/

		protected override void PrepSegment(Segment segment, string name, T value)
		{
			if ("None" == name)
				segment.ImageSource = MakeImageSource("None");
			else
				segment.ImageSource = MakeTypedImageSource(name);

			segment.Value = value;
		}
	}
}
