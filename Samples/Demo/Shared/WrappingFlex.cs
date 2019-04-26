using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo
{
	/***************************************************************************************************
		WrappingFlex class (design)
	***************************************************************************************************/
	/// <summary>
	/// Used as a base class by demo classes which want to show multiple samples in a free-form,
	/// left-top-right, top-to-bottom wrap.
	/// </summary>
	public abstract class WrappingFlex : Flex
    {
		/// <summary>
		/// Used to skip samples permutations to keep the demo performance snappy for builds.
		/// </summary>
		protected readonly int Skip;

		protected int Current { get; private set; }

		public WrappingFlex(int windowsSkip, int wasmSkip)
		{
#if WASM
			this.Skip = wasmSkip;
#else
			this.Skip = windowsSkip;
#endif
			Wrapping = FlexWrapping.Wrap;
		}

		protected bool IsReady() => ++Current % Skip == 0;

		protected void AddSample(Element child) => Children.Add(child);
	}
}
