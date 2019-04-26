using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Data;
using System.Collections;

namespace Demo
{
	public class ItemsSourceEditor : MagicSlider, IPropertyEditor
	{
		static readonly IEnumerable[] ItemSources =
		{
			Common.LoremIpsumWords,
			People.All,
			Common.Cartoons,
			SolidColorBrushes.Singleton.All,
			LinearGradientBrushes.Singleton.All,
			RadialGradientBrushes.Singleton.All,
			Bitmaps.All
			//Common.RandomItems
		};

		public ItemsSourceEditor()
		{
			this.SmallChange = 1.0m;
			this.LargeChange = 1.0m;
			this.Maximum = ItemSources.Length;
		}

		public override bool TranslateToUserValue1(decimal value, out object newValue)
		{
			var intValue = (int)value;

			if (0 == intValue)
			{
				newValue = null;
				return true;
			}

			newValue = ItemSources[intValue-1];
			return true;
		}

		public override void TranslateFromUserValue1(object userValue1, out decimal newValue)
		{
			for (var i = 0; i < ItemSources.Length; ++i)
			{
				if (ItemSources[i] == userValue1)
				{
					newValue = i + 1;
					return;
				}
			}

			//throw new System.Exception();
			newValue = 0m;
		}

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(UserValue1Property, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
	}
}
