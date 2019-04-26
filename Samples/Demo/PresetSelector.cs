using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo
{
	//public class PresetSelector : Droplist
	public class PresetSelector : ListBox
	{
		static readonly string[] Names = {
			"None",
			"A",
			"B",
			"C",
			"D",
			"E",
			"F",
			"G",
			"H",
			"I",
			"J",
			"K",
			"L",
			"M",
			"N",
			"O",
			"P",
			"Q",
			"R",
			"S",
			"T",
			"U",
			"V",
			"W",
			"X",
			"Y",
			"Z"
		};

		Style[] presets;
		IExampleView exampleView;

		public PresetSelector()
		{
			this.ItemsWrapping = FlexWrapping.Wrap;
			this.ItemsDirection = FlexDirection.Row;

			this.ItemViewMatcher = new SingleModelViewMatcher(typeof(StringView));
		}

		public void Init(Style[] presets, IExampleView exampleView)
		{
			var totalPresets = presets.Length;
			var totalDroplistItems = totalPresets + 1;
			this.presets = presets;
			this.exampleView = exampleView;

			// Increasings items in dropdown...
			if (totalDroplistItems > Items.Count)
			{
				for (var i = Items.Count; i < totalDroplistItems; ++i)
					this.Items.Add(Names[i]);
			}
			// Decreasing items in dropdown...
			else if (totalDroplistItems < Items.Count)
			{
				for (var i = Items.Count; i > totalDroplistItems; --i)
					this.Items.RemoveAt(i-1);
			}

			SelectedItem = Names[0];

			Sync();
		}

		protected override void OnSelectedItemChanged(object origValue, object newValue)
		{
			base.OnSelectedItemChanged(origValue, newValue);
			if (null != exampleView)
				Sync();
		}

		void Sync()
		{
			if (SelectedIndex > 0)
				exampleView.MainElement.Style = presets[SelectedIndex - 1];
		}
	}
}
