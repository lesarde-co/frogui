using Lesarde;
using System;

namespace Demo
{
	[Flags]
	public enum BrushVariety : uint
	{
		None = FLAG.Flag_01,
		Solid = FLAG.Flag_02,
		LinearGradient = FLAG.Flag_03,
		RadialGradient = FLAG.Flag_04,
		Image = FLAG.Flag_05
	}
}
