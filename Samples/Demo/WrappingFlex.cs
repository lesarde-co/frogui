using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo
{
	/***************************************************************************************************
		WrappingFlex class (design)
	***************************************************************************************************/
	/// <summary>
	/// Used as a base class by demo classes which want to show multiple examples in a free-form,
	/// left-top-right, top-to-bottom wrap.
	/// </summary>
	public abstract class WrappingFlex : Flex
    {
		/// <summary>
		/// Used to skip example permutations to keep the demo performance snappy for builds.
		/// </summary>
		protected readonly int Skip;

		protected int Current { get; private set; }

		public WrappingFlex(int osSkip, int wasmSkip)
		{
#if WASM
			this.Skip = wasmSkip;
#else
			this.Skip = osSkip;
#endif
			Wrapping = FlexWrapping.Wrap;
		}

		protected bool IsReady() => ++Current % Skip == 0;

		protected void AddExample(UIElement child) => Children.Add(child);
	}
}
