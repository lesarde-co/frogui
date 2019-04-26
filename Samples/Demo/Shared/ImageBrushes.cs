using Lesarde.Frogui;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Media.Imaging;
using System.Collections.Generic;

namespace Demo
{
	/***************************************************************************************************
		ImageBrushes class
	***************************************************************************************************/
	/// <summary>
	/// Implements a set of predefined image brushes.
	/// </summary>
	public class ImageBrushes : Brushes
	{
		static readonly IList<BrushInfo> all = new List<BrushInfo>();

		public override IList<BrushInfo> All => all;

		public override BrushVariety Variety => BrushVariety.Image;

		/***********************************************************
			Singleton property
		***********************************************************/

		public static ImageBrushes Singleton { get; } = new ImageBrushes();

		/***********************************************************
			the brushes
		***********************************************************/

		public static BrushInfo Disenchantment { get; } = Add(Bitmaps.Disenchantment.Bitmap);
		public static BrushInfo ScoobyDoo { get; } = Add(Bitmaps.ScoobyDoo.Bitmap);
		public static BrushInfo Simpsons { get; } = Add(Bitmaps.TheSimpsons.Bitmap);
		public static BrushInfo Flintstones { get; } = Add(Bitmaps.TheFlintstones.Bitmap);
		public static BrushInfo Jetsons { get; } = Add(Bitmaps.TheJetsons.Bitmap);
		public static BrushInfo BobsBurgers { get; } = Add(Bitmaps.BobsBurgers.Bitmap);
		public static BrushInfo FamilyGuy { get; } = Add(Bitmaps.FamilyGuy.Bitmap);
		public static BrushInfo CheckeredLight { get; } = Add(Bitmaps.CheckeredLight.Bitmap);
		public static BrushInfo CheckeredMedium { get; } = Add(Bitmaps.CheckeredMedium.Bitmap);
		public static BrushInfo CheckeredDark { get; } = Add(Bitmaps.CheckeredDark.Bitmap);

		/*******************************************************************************
			! $
		*******************************************************************************/

		static ImageBrushes()
		{
			Init(typeof(ImageBrushes), all);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		private ImageBrushes() { }

		/*******************************************************************************
			Add()
		*******************************************************************************/

		static BrushInfo Add (BitmapImage image) => Add(new ImageBrush(image), all);
	}
}
