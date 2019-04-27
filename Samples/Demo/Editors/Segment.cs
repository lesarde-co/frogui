using Lesarde.Frogui;
using Lesarde.Frogui.Media.Imaging;
using System;

namespace Demo
{
	/***************************************************************************************************
		Segment class
	***************************************************************************************************/
	/// <summary>
	/// Model for an item in a <see cref="MagicSegmentor"/>. Derives from <see cref="PixyModel"/>
	/// so has <see cref="PixyModel.Text"/> and <see cref="PixyModel.ImageSource"/> properties,
	/// and adds a <see cref="Segment.Value"/> property.
	/// </summary>
	public class Segment : PixyModel
	{
		public object Value { get; set;  }

		public Segment() { }
	}
}
