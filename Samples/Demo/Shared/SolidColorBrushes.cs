using Lesarde.Frogui.Media;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
	/***************************************************************************************************
		SolidColorBrushes class
	***************************************************************************************************/
	/// <summary>
	/// Implements a set of predefined solid color brushes.
	/// </summary>
	public class SolidColorBrushes : Brushes
	{
		static readonly IList<BrushInfo> all = new List<BrushInfo>();

		public override IList<BrushInfo> All => all;

		public override BrushVariety Variety => BrushVariety.Solid;

		/***********************************************************
			Singleton property
		***********************************************************/

		public static SolidColorBrushes Singleton { get; } = new SolidColorBrushes();

		/***********************************************************
			the brushes
		***********************************************************/

		public static BrushInfo AliceBlue { get; } = Add(Colors.AliceBlue);
		public static BrushInfo AntiqueWhite { get; } = Add(Colors.AntiqueWhite);
		public static BrushInfo Aqua { get; } = Add(Colors.Aqua);
		public static BrushInfo AquaMarine { get; } = Add(Colors.AquaMarine);
		public static BrushInfo Azure { get; } = Add(Colors.Azure);
		public static BrushInfo Beige { get; } = Add(Colors.Beige);
		public static BrushInfo Bisque { get; } = Add(Colors.Bisque);
		public static BrushInfo Black { get; } = Add(Colors.Black);
		public static BrushInfo BlanchedAlmond { get; } = Add(Colors.BlanchedAlmond);
		public static BrushInfo Blue { get; } = Add(Colors.Blue);
		public static BrushInfo BlueViolet { get; } = Add(Colors.BlueViolet);
		public static BrushInfo Brown { get; } = Add(Colors.Brown);
		public static BrushInfo BurlyWood { get; } = Add(Colors.BurlyWood);
		public static BrushInfo CadetBlue { get; } = Add(Colors.CadetBlue);
		public static BrushInfo Chartreuse { get; } = Add(Colors.Chartreuse);
		public static BrushInfo Chocolate { get; } = Add(Colors.Chocolate);
		public static BrushInfo Coral { get; } = Add(Colors.Coral);
		public static BrushInfo CornFlowerBlue { get; } = Add(Colors.CornFlowerBlue);
		public static BrushInfo CornSilk { get; } = Add(Colors.CornSilk);
		public static BrushInfo Crimson { get; } = Add(Colors.Crimson);
		public static BrushInfo Cyan { get; } = Add(Colors.Cyan);
		public static BrushInfo DarkBlue { get; } = Add(Colors.DarkBlue);
		public static BrushInfo DarkCyan { get; } = Add(Colors.DarkCyan);
		public static BrushInfo DarkGoldenRod { get; } = Add(Colors.DarkGoldenRod);
		public static BrushInfo DarkGray { get; } = Add(Colors.DarkGray);
		public static BrushInfo DarkGreen { get; } = Add(Colors.DarkGreen);
		public static BrushInfo DarkKhaki { get; } = Add(Colors.DarkKhaki);
		public static BrushInfo DarkMagenta { get; } = Add(Colors.DarkMagenta);
		public static BrushInfo DarkOliveGreen { get; } = Add(Colors.DarkOliveGreen);
		public static BrushInfo DarkOrange { get; } = Add(Colors.DarkOrange);
		public static BrushInfo DarkOrchid { get; } = Add(Colors.DarkOrchid);
		public static BrushInfo DarkRed { get; } = Add(Colors.DarkRed);
		public static BrushInfo DarkSalmon { get; } = Add(Colors.DarkSalmon);
		public static BrushInfo DarkSeaGreen { get; } = Add(Colors.DarkSeaGreen);
		public static BrushInfo DarkSlateBlue { get; } = Add(Colors.DarkSlateBlue);
		public static BrushInfo DarkSlateGray { get; } = Add(Colors.DarkSlateGray);
		public static BrushInfo DarkTurquoise { get; } = Add(Colors.DarkTurquoise);
		public static BrushInfo DarkViolet { get; } = Add(Colors.DarkViolet);
		public static BrushInfo DeepPink { get; } = Add(Colors.DeepPink);
		public static BrushInfo DeepSkyBlue { get; } = Add(Colors.DeepSkyBlue);
		public static BrushInfo DimGray { get; } = Add(Colors.DimGray);
		public static BrushInfo DodgerBlue { get; } = Add(Colors.DodgerBlue);
		public static BrushInfo FireBrick { get; } = Add(Colors.FireBrick);
		public static BrushInfo FloralWhite { get; } = Add(Colors.FloralWhite);
		public static BrushInfo ForestGreen { get; } = Add(Colors.ForestGreen);
		public static BrushInfo Fuchsia { get; } = Add(Colors.Fuchsia);
		public static BrushInfo Gainsboro { get; } = Add(Colors.Gainsboro);
		public static BrushInfo GhostWhite { get; } = Add(Colors.GhostWhite);
		public static BrushInfo Gold { get; } = Add(Colors.Gold);
		public static BrushInfo GoldenRod { get; } = Add(Colors.GoldenRod);
		public static BrushInfo Gray { get; } = Add(Colors.Gray);
		public static BrushInfo Green { get; } = Add(Colors.Green);
		public static BrushInfo GreenYellow { get; } = Add(Colors.GreenYellow);
		public static BrushInfo HoneyDew { get; } = Add(Colors.HoneyDew);
		public static BrushInfo HotPink { get; } = Add(Colors.HotPink);
		public static BrushInfo IndianRed { get; } = Add(Colors.IndianRed);
		public static BrushInfo Indigo { get; } = Add(Colors.Indigo);
		public static BrushInfo Ivory { get; } = Add(Colors.Ivory);
		public static BrushInfo Khaki { get; } = Add(Colors.Khaki);
		public static BrushInfo Lavender { get; } = Add(Colors.Lavender);
		public static BrushInfo LavenderBlush { get; } = Add(Colors.LavenderBlush);
		public static BrushInfo LawnGreen { get; } = Add(Colors.LawnGreen);
		public static BrushInfo LemonChiffon { get; } = Add(Colors.LemonChiffon);
		public static BrushInfo LightBlue { get; } = Add(Colors.LightBlue);
		public static BrushInfo LightCoral { get; } = Add(Colors.LightCoral);
		public static BrushInfo LightCyan { get; } = Add(Colors.LightCyan);
		public static BrushInfo LightGoldenRodYellow { get; } = Add(Colors.LightGoldenRodYellow);
		public static BrushInfo LightGreen { get; } = Add(Colors.LightGreen);
		public static BrushInfo LightGray { get; } = Add(Colors.LightGray);
		public static BrushInfo LightPink { get; } = Add(Colors.LightPink);
		public static BrushInfo LightSalmon { get; } = Add(Colors.LightSalmon);
		public static BrushInfo LightSeaGreen { get; } = Add(Colors.LightSeaGreen);
		public static BrushInfo LightSkyBlue { get; } = Add(Colors.LightSkyBlue);
		public static BrushInfo LightSlateGray { get; } = Add(Colors.LightSlateGray);
		public static BrushInfo LightSteelBlue { get; } = Add(Colors.LightSteelBlue);
		public static BrushInfo LightYellow { get; } = Add(Colors.LightYellow);
		public static BrushInfo Lime { get; } = Add(Colors.Lime);
		public static BrushInfo LimeGreen { get; } = Add(Colors.LimeGreen);
		public static BrushInfo Linen { get; } = Add(Colors.Linen);
		public static BrushInfo Magenta { get; } = Add(Colors.Magenta);
		public static BrushInfo Maroon { get; } = Add(Colors.Maroon);
		public static BrushInfo MediumAquaMarine { get; } = Add(Colors.MediumAquaMarine);
		public static BrushInfo MediumBlue { get; } = Add(Colors.MediumBlue);
		public static BrushInfo MediumOrchid { get; } = Add(Colors.MediumOrchid);
		public static BrushInfo MediumPurple { get; } = Add(Colors.MediumPurple);
		public static BrushInfo MediumSeaGreen { get; } = Add(Colors.MediumSeaGreen);
		public static BrushInfo MediumSlateBlue { get; } = Add(Colors.MediumSlateBlue);
		public static BrushInfo MediumSpringGreen { get; } = Add(Colors.MediumSpringGreen);
		public static BrushInfo MediumTurquoise { get; } = Add(Colors.MediumTurquoise);
		public static BrushInfo MediumVioletRed { get; } = Add(Colors.MediumVioletRed);
		public static BrushInfo MidnightBlue { get; } = Add(Colors.MidnightBlue);
		public static BrushInfo MintCream { get; } = Add(Colors.MintCream);
		public static BrushInfo MistyRose { get; } = Add(Colors.MistyRose);
		public static BrushInfo Moccasin { get; } = Add(Colors.Moccasin);
		public static BrushInfo NavajoWhite { get; } = Add(Colors.NavajoWhite);
		public static BrushInfo Navy { get; } = Add(Colors.Navy);
		public static BrushInfo OldLace { get; } = Add(Colors.OldLace);
		public static BrushInfo Olive { get; } = Add(Colors.Olive);
		public static BrushInfo OliveDrab { get; } = Add(Colors.OliveDrab);
		public static BrushInfo Orange { get; } = Add(Colors.Orange);
		public static BrushInfo OrangeRed { get; } = Add(Colors.OrangeRed);
		public static BrushInfo Orchid { get; } = Add(Colors.Orchid);
		public static BrushInfo PaleGoldenRod { get; } = Add(Colors.PaleGoldenRod);
		public static BrushInfo PaleGreen { get; } = Add(Colors.PaleGreen);
		public static BrushInfo PaleTurquoise { get; } = Add(Colors.PaleTurquoise);
		public static BrushInfo PaleVioletRed { get; } = Add(Colors.PaleVioletRed);
		public static BrushInfo PapayaWhip { get; } = Add(Colors.PapayaWhip);
		public static BrushInfo PeachPuff { get; } = Add(Colors.PeachPuff);
		public static BrushInfo Peru { get; } = Add(Colors.Peru);
		public static BrushInfo Pink { get; } = Add(Colors.Pink);
		public static BrushInfo Plum { get; } = Add(Colors.Plum);
		public static BrushInfo PowderBlue { get; } = Add(Colors.PowderBlue);
		public static BrushInfo Purple { get; } = Add(Colors.Purple);
		public static BrushInfo Red { get; } = Add(Colors.Red);
		public static BrushInfo RosyBrown { get; } = Add(Colors.RosyBrown);
		public static BrushInfo RoyalBlue { get; } = Add(Colors.RoyalBlue);
		public static BrushInfo SaddleBrown { get; } = Add(Colors.SaddleBrown);
		public static BrushInfo Salmon { get; } = Add(Colors.Salmon);
		public static BrushInfo SandyBrown { get; } = Add(Colors.SandyBrown);
		public static BrushInfo SeaGreen { get; } = Add(Colors.SeaGreen);
		public static BrushInfo SeaShell { get; } = Add(Colors.SeaShell);
		public static BrushInfo Sienna { get; } = Add(Colors.Sienna);
		public static BrushInfo Silver { get; } = Add(Colors.Silver);
		public static BrushInfo SkyBlue { get; } = Add(Colors.SkyBlue);
		public static BrushInfo SlateBlue { get; } = Add(Colors.SlateBlue);
		public static BrushInfo SlateGray { get; } = Add(Colors.SlateGray);
		public static BrushInfo Snow { get; } = Add(Colors.Snow);
		public static BrushInfo SpringGreen { get; } = Add(Colors.SpringGreen);
		public static BrushInfo SteelBlue { get; } = Add(Colors.SteelBlue);
		public static BrushInfo Tan { get; } = Add(Colors.Tan);
		public static BrushInfo Teal { get; } = Add(Colors.Teal);
		public static BrushInfo Thistle { get; } = Add(Colors.Thistle);
		public static BrushInfo Tomato { get; } = Add(Colors.Tomato);
		public static BrushInfo Transparent { get; } = Add(Colors.Transparent);
		public static BrushInfo Turquoise { get; } = Add(Colors.Turquoise);
		public static BrushInfo Violet { get; } = Add(Colors.Violet);
		public static BrushInfo Wheat { get; } = Add(Colors.Wheat);
		public static BrushInfo White { get; } = Add(Colors.White);
		public static BrushInfo WhiteSmoke { get; } = Add(Colors.WhiteSmoke);
		public static BrushInfo Yellow { get; } = Add(Colors.Yellow);
		public static BrushInfo YellowGreen { get; } = Add(Colors.YellowGreen);

		/*******************************************************************************
			! $
		*******************************************************************************/

		static SolidColorBrushes()
		{
			Init(typeof(SolidColorBrushes), all);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		private SolidColorBrushes() { }


		/*******************************************************************************
			Add()
		*******************************************************************************/

		static BrushInfo Add(Color color) => Add(new SolidColorBrush(color), all);
	}
}
