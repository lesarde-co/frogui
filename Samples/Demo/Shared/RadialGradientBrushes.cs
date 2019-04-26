using Lesarde.Frogui;
using Lesarde.Frogui.Media;
using System.Collections.Generic;

namespace Demo
{
	/***************************************************************************************************
		RadialGradientBrushes class
	***************************************************************************************************/
	/// <summary>
	/// Implements a set of predefined radial gradient brushes.
	/// </summary>
	public class RadialGradientBrushes : Brushes
	{
		static readonly IList<BrushInfo> all = new List<BrushInfo>();

		public override IList<BrushInfo> All => all;

		public override BrushVariety Variety => BrushVariety.RadialGradient;

		/***********************************************************
			Singleton property
		***********************************************************/

		public static RadialGradientBrushes Singleton { get; } = new RadialGradientBrushes();

		/***********************************************************
			the brushes
		***********************************************************/

		public static BrushInfo Sunrise { get; } = Add(new RadialGradientBrush(Common.GradientStops_Sunrise));
		public static BrushInfo BlueHaze { get; } = Add(new RadialGradientBrush(Common.GradientStops_BlueHaze));
		public static BrushInfo ShadedWhite { get; } = Add(new RadialGradientBrush(Common.GradientStops_ShadedWhite));
		public static BrushInfo TwilightZone { get; } = Add(new RadialGradientBrush(Common.GradientStops_TwilightZone));
		public static BrushInfo Rainbow { get; } = Add(new RadialGradientBrush(Common.GradientStops_Rainbow));
		public static BrushInfo Chrome { get; } = Add(new RadialGradientBrush(Common.GradientStops_Chrome));
		public static BrushInfo Ruby { get; } = Add(new RadialGradientBrush(Common.GradientStops_Ruby));
		public static BrushInfo Sapphire { get; } = Add(new RadialGradientBrush(Common.GradientStops_Sapphire));
		public static BrushInfo GrayFade { get; } = Add(new RadialGradientBrush(Common.GradientStops_GrayFade));
		public static BrushInfo RicePaperFade { get; } = Add(new RadialGradientBrush(Common.GradientStops_RicePaperFade));

		/*******************************************************************************
			! $
		*******************************************************************************/

		static RadialGradientBrushes()
		{
			Init(typeof(RadialGradientBrushes), all);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		private RadialGradientBrushes() { }

		/*******************************************************************************
			Add()
		*******************************************************************************/

		static BrushInfo Add(RadialGradientBrush brush) => Add(brush, all);
	}
}
