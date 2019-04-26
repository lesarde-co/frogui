using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;
using Lesarde.Frogui.Media;
using System;
using static Demo.Bitmaps;
using static Demo.Common;

namespace Demo
{
	/***************************************************************************************************
		ImageSourceEditor class
	***************************************************************************************************/
	/// <summary>
	/// Editor for properties of type <see cref="Lesarde.Frogui.Media.ImageSource"/>.
	/// <para>
	/// The source of the images is <see cref="Common.BitmapInfos"/>.
	/// </para>
	/// </summary>
	public class ImageSourceEditor : MagicSlider, IPropertyEditor
	{
		/***********************************************************
			MyPreviewView class
		***********************************************************/

		class MyPreviewView : Grid
		{
			TextBlock e_name { get; } = new TextBlock()
			{
				Foreground = SolidColorBrushes.LightGray.Brush,
				Width = new Length(175, Unit.Px)
			};

			Border e_border { get; } = new Border()
			{
				Margin = new Thickness(new Length(8, Unit.Px), Length.ZeroPx, new Length(8, Unit.Px), Length.ZeroPx),
				Width = new Length(40, Unit.Px),
				Height = new Length(20, Unit.Px),
				BorderBrush = SolidColorBrushes.DarkSlateGray.Brush,
				BorderThickness = new Thickness(new Length(0.5, Unit.Px)),
				CornerRadius = new CornerRadius(new Length(4, Unit.Px))
			};

			Image e_image { get; } = new Image();

			public MyPreviewView()
			{
				ColumnCount = 2;

				AddPropertyChangedListener(Element.DataContextProperty, v =>
					//.Subscribe(v =>
					{
						if (v is BitmapInfo bitmapInfo)
						{
							//var colorInfo = SolidColorBrushes.All[(int)v];

							e_name.Text = bitmapInfo.Name;
							e_image.Source = bitmapInfo.Bitmap;
						}
					});

				this.Children.Add(e_border);
				this.Children.Add(e_name, new GridAnchor(1, 0));
				e_border.Child = e_image;
			}
		}

		/***********************************************************
			ImageSource property
		***********************************************************/

		public static DependencyProperty<ImageSource, ImageSourceEditor> ImageSourceProperty { get; } = DependencyProperty<ImageSource, ImageSourceEditor>
			.Register();

		public ImageSource ImageSource
		{
			get => GetValue(ImageSourceProperty);
			set => SetValue(ImageSourceProperty, value);
		}

		/***********************************************************
			Items property
		***********************************************************/

		public Brushes Items
		{
			get => items;

			set
			{
				this.items = value;
				if (null != value)
					this.Maximum = Items.All.Count - 1;
			}
		}

		Brushes items;

		public override bool TranslateToUserValue1(decimal value, out object newValue)
		{
			newValue = Bitmaps.All[(int)value];
			return true;
		}

		public override bool TranslateToUserValue2(decimal value, out object newValue)
		{
			newValue = Bitmaps.All[(int)value].Bitmap;
			return true;
		}

		public override void TranslateFromUserValue1(object userValue1, out decimal newValue)
		{
			newValue = Array.IndexOf(Bitmaps.All, userValue1);
		}

		public override void TranslateFromUserValue2(object userValue2, out decimal newValue)
		{
			for (var i = 0; i < Bitmaps.All.Length; ++i)
				if (Bitmaps.All[i].Bitmap == userValue2)
				{
					newValue = i;
					return;
				}

			newValue = 0;
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public ImageSourceEditor()
		{
			PreviewSource = SliderPreviewSource.UserValue1;
			PreviewView = new MyPreviewView();

			this.SmallChange = 1.0m;
			this.LargeChange = 1.0m;

			this.Maximum = Bitmaps.All.Length - 1;
		}

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			SetBinding(UserValue2Property, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		}
	}

}
