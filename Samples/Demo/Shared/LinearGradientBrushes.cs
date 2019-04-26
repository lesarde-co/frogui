using System.Collections.Generic;
using Lesarde.Frogui;
using Lesarde.Frogui.Media;

namespace Demo
{
	/***************************************************************************************************
		LinearGradientBrushes class
	***************************************************************************************************/
	/// <summary>
	/// Implements a set of predefined linear gradient brushes.
	/// </summary>
	public class LinearGradientBrushes : Brushes
	{
		static readonly IList<BrushInfo> all = new List<BrushInfo>();

		public override IList<BrushInfo> All => all;

		public override BrushVariety Variety => BrushVariety.LinearGradient;

		/***********************************************************
			Singleton property
		***********************************************************/

		public static LinearGradientBrushes Singleton { get; } = new LinearGradientBrushes();

		/***********************************************************
			the brushes
		***********************************************************/

		public static BrushInfo Sunrise { get; } = Add(new LinearGradientBrush(Common.GradientStops_Sunrise));
		public static BrushInfo BlueHaze { get; } = Add(new LinearGradientBrush(Common.GradientStops_BlueHaze));
		public static BrushInfo ShadedWhite { get; } = Add(new LinearGradientBrush(Common.GradientStops_ShadedWhite));
		public static BrushInfo TwilightZone { get; } = Add(new LinearGradientBrush(Common.GradientStops_TwilightZone));
		public static BrushInfo Rainbow { get; } = Add(new LinearGradientBrush(Common.GradientStops_Rainbow));
		public static BrushInfo Chrome { get; } = Add(new LinearGradientBrush(Common.GradientStops_Chrome));
		public static BrushInfo Ruby { get; } = Add(new LinearGradientBrush(Common.GradientStops_Ruby));
		public static BrushInfo Sapphire { get; } = Add(new LinearGradientBrush(Common.GradientStops_Sapphire));
		public static BrushInfo GrayFade { get; } = Add(new LinearGradientBrush(Common.GradientStops_GrayFade));
		public static BrushInfo RicePaperFade { get; } = Add(new LinearGradientBrush(Common.GradientStops_RicePaperFade));

		/*******************************************************************************
			! $
		*******************************************************************************/

		static LinearGradientBrushes()
		{
			Init(typeof(LinearGradientBrushes), all);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		private LinearGradientBrushes() { }

		/*******************************************************************************
			Add()
		*******************************************************************************/

		static BrushInfo Add(LinearGradientBrush brush) => Add(brush, all);
	}
}
