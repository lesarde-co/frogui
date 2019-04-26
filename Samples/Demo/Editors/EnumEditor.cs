using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Data;
using Lesarde.Frogui.Media.Imaging;
using System;
using System.Collections.Generic;

namespace Demo
{
    public abstract class EnumEditor<T> : MagicSegmentor, IPropertyEditor
    {
		/***********************************************************
			Segments property
		***********************************************************/

		public override Segment[] Segments => segments;

		static Segment[] segments;

		/***********************************************************
			NameOfT property
		***********************************************************/

		string NameOfT => typeof(T).Name;

		/*******************************************************************************
			$
		*******************************************************************************/

		public EnumEditor()
		{
		}

		/*******************************************************************************
			Initialize()
		*******************************************************************************/

		protected override void Initialize()
		{
			if (null == segments)
			{
				var items = new List<Segment>();

				var names = typeof(T).GetEnumNames();
				var values = typeof(T).GetEnumValues();

				var i = 0;
				foreach (var value in values)
				{
					var segment = new Segment();
					PrepSegment(segment, names[i], (T)values.GetValue(i));
					items.Add(segment);
					++i;
				}
				segments = items.ToArray();
			}

			base.Initialize();
		}

		/*******************************************************************************
			UseValue()
		*******************************************************************************/

		protected virtual bool UseValue(T value) => true;

		/*******************************************************************************
			PrepSegment()
		*******************************************************************************/

		protected abstract void PrepSegment(Segment segment, string name, T value);

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			SetBinding(SelectedValueProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		}

		/*******************************************************************************
			MakeImageSource()
		*******************************************************************************/

		protected BitmapImage MakeImageSource(string name) => new BitmapImage(new System.Uri($"Resources/Icon-{name}.png", UriKind.Relative));

		/*******************************************************************************
			MakeTypedImageSource()
		*******************************************************************************/

		protected BitmapImage MakeTypedImageSource(string name) => MakeImageSource($"{NameOfT}-{name}");
	}
}
