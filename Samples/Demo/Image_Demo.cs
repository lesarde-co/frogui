using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;

namespace Demo
{
	/***************************************************************************************************
		Image_Demo class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Image"/> element.
	/// </summary>
	public partial class Image_Demo : WrappingFlex
    {
		public Image_Demo() : base(1, 1)
		{
			InitializeComponent();

			foreach (var size in Common.SizesMix)
				foreach (Stretch stretch in Enum.GetValues(typeof(Stretch)))
					foreach (var bitmap in Common.Bitmaps)
						if (IsReady())
							AddExample(new Image()
							{
								Source = bitmap,
								Width = size.Item1,
								Height = size.Item2,
								Stretch = stretch,
								Margin = Common.Margin
							});
		}
	}
}
