using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Controls.Primitives;
using Lesarde.Frogui.Input;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Media.Effects;
using Lesarde.Frogui.Shapes;
using System;
using System.Collections;
using System.Linq;
using System.Reactive.Linq;

namespace Demo
{
	/***************************************************************************************************
		MainWindow class
	***************************************************************************************************/

	public partial class MainWindow : Window
    {
		/***********************************************************
			Examples
		***********************************************************/

		Example[] Examples =
		{
			new Example(typeof(Example_Home.View), true,
				"",
				"",
				PROP.None
				),
			new Example(typeof(Example_Rectangle.View), true,
				"Draws a rectangle with a given Height and Width and other rendering characteristics.",
				"Using a variety of brushes with Frogui shapes, such as Rectangle, is trivial. Regardless of the brush type -- solid color, linear gradient, radial gradient, image -- the code technique is the same. " +
				"To get the same effect in HTML & CSS, a lot of code would be required and a variety of techniques would be needed.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Rectangle),
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.InPixels(400),
						Element.OpacityProperty, 1d,
						Shape.FillProperty, LinearGradientBrushes.Sunrise.Brush,
						Shape.StrokeProperty, SolidColorBrushes.DarkRed.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(20),
						Rectangle.RadiusXProperty, Length.InPixels(20),
						Rectangle.RadiusYProperty, Length.InPixels(20)
						),

					CreateStyle(typeof(Rectangle),
						Element.WidthProperty, new Length(50, Unit.Vw),
						Element.HeightProperty, new Length(50, Unit.Vh),
						Element.OpacityProperty,1d,
						Shape.FillProperty, SolidColorBrushes.White.Brush,
						Shape.StrokeProperty, SolidColorBrushes.Black.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(25),
						Rectangle.RadiusXProperty, Length.ZeroPx,
						Rectangle.RadiusYProperty, Length.ZeroPx
						),

					CreateStyle(typeof(Rectangle),
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(600),
						Element.OpacityProperty, 0.2d,
						Shape.FillProperty, SolidColorBrushes.Yellow.Brush,
						Shape.StrokeProperty, SolidColorBrushes.Purple.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(3),
						Rectangle.RadiusXProperty, Length.ZeroPx,
						Rectangle.RadiusYProperty, Length.ZeroPx
						),

					CreateStyle(typeof(Rectangle),
						Element.WidthProperty, Length.InPixels(500),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 0.5d,
						Shape.FillProperty, ImageBrushes.Disenchantment.Brush,
						Shape.StrokeProperty, SolidColorBrushes.Purple.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(2),
						Rectangle.RadiusXProperty, Length.InPixels(30),
						Rectangle.RadiusYProperty, Length.InPixels(30)
						),

					CreateStyle(typeof(Rectangle),
						Element.WidthProperty, Length.InPixels(800),
						Element.HeightProperty, Length.InPixels(800),
						Element.OpacityProperty, 1.0d,
						Shape.FillProperty, ImageBrushes.ScoobyDoo.Brush,
						Shape.StrokeProperty, LinearGradientBrushes.Rainbow.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(40),
						Rectangle.RadiusXProperty, Length.ZeroPx,
						Rectangle.RadiusYProperty, Length.ZeroPx
						)
				}),

		new Example(typeof(Example_Ellipse.View), true,
				"Draws a ellipse with a given Height and Width and other rendering characteristics.",
				"Frogui allows brushes of any type to be mixed for shape stroke and fill, as is demonstrated here with the Ellipse shape.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Ellipse),
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.InPixels(600),
						Element.OpacityProperty, 1.0d,
						Shape.FillProperty, SolidColorBrushes.DodgerBlue.Brush,
						Shape.StrokeProperty, LinearGradientBrushes.Sunrise.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(50)
						),

					CreateStyle(typeof(Ellipse),
						Element.WidthProperty, new Length(50, Unit.Vw),
						Element.HeightProperty, new Length(50, Unit.Vh),
						Element.OpacityProperty, 0.7d,
						Shape.FillProperty, SolidColorBrushes.Purple.Brush,
						Shape.StrokeProperty, SolidColorBrushes.Yellow.Brush,
						Shape.StrokeThicknessProperty, Length.ZeroPx
						),

					CreateStyle(typeof(Ellipse),
						Element.WidthProperty, Length.InPixels(200),
						Element.HeightProperty, Length.InPixels(80),
						Element.OpacityProperty, 0.25d,
						Shape.FillProperty, SolidColorBrushes.Orange.Brush,
						Shape.StrokeProperty, SolidColorBrushes.Black.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(2)
						),

					CreateStyle(typeof(Ellipse),
						Element.WidthProperty, Length.InPixels(500),
						Element.HeightProperty, Length.InPixels(350),
						Element.OpacityProperty, 1d,
						Shape.FillProperty, SolidColorBrushes.White.Brush,
						Shape.StrokeProperty, SolidColorBrushes.Black.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(25)
						),

					CreateStyle(typeof(Ellipse),
						Element.WidthProperty, Length.InPixels(700),
						Element.HeightProperty, Length.InPixels(700),
						Element.OpacityProperty, 1d,
						Shape.FillProperty, ImageBrushes.Flintstones.Brush,
						Shape.StrokeProperty, LinearGradientBrushes.BlueHaze.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(60)
						)
				}),

			new Example(typeof(Example_Path.View), true,
				"Draws a series of connected lines and curves with a given Height and Width and other rendering characteristics.",
				"Like all Frogui shapes, a Path is completely scalable using Scalable Vector Graphics (SVG), retaining brilliant rendering accuracy at any size.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Path),
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.InPixels(600),
						Element.OpacityProperty, 1.0d,
						Shape.FillProperty, SolidColorBrushes.LimeGreen.Brush,
						Shape.StrokeProperty, SolidColorBrushes.Yellow.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(8)
						),

					CreateStyle(typeof(Path),
						Element.WidthProperty, new Length(50, Unit.Vw),
						Element.HeightProperty, new Length(50, Unit.Vh),
						Element.OpacityProperty, 0.7d,
						Shape.FillProperty, RadialGradientBrushes.Rainbow.Brush,
						Shape.StrokeProperty, SolidColorBrushes.MediumAquaMarine.Brush,
						Shape.StrokeThicknessProperty, Length.ZeroPx
						),

					CreateStyle(typeof(Path),
						Element.WidthProperty, Length.InPixels(100),
						Element.HeightProperty, Length.InPixels(180),
						Element.OpacityProperty, 0.5d,
						Shape.FillProperty, RadialGradientBrushes.BlueHaze.Brush,
						Shape.StrokeProperty, SolidColorBrushes.PeachPuff.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(2)
						),

					CreateStyle(typeof(Path),
						Element.WidthProperty, Length.InPixels(200),
						Element.HeightProperty, Length.InPixels(500),
						Element.OpacityProperty, 1d,
						Shape.FillProperty, SolidColorBrushes.HotPink.Brush,
						Shape.StrokeProperty, SolidColorBrushes.Yellow.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(25)
						),

					CreateStyle(typeof(Path),
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 1d,
						Shape.FillProperty, ImageBrushes.Flintstones.Brush,
						Shape.StrokeProperty, LinearGradientBrushes.BlueHaze.Brush,
						Shape.StrokeThicknessProperty, Length.InPixels(20)
						)
				}),

			new Example(typeof(Example_Image.View), true,
				"Represents a control that displays an image. The image source is specified by referring to an image file, using several supported formats.",
				"Images are a form of 'raster graphics' meaning image data is stored as a resolution-dependent matrix of pixels. Also known as a bitmap. Compared to scalable vector graphics (SVG), " +
				"raster graphics typically offer a finer level of detail, such as in a photo, but do not scale nearly as well and generally take up more memory. A variety of properties " +
				"makes rendering images a breeze in Frogui. And because the image source is abstracted from the Image element, it may be used multiple times in a view via a single source.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Image),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Image.BackgroundProperty, SolidColorBrushes.Purple.Brush,
						Image.SourceProperty, Bitmaps.ScoobyDoo.Bitmap,
						Image.StretchProperty, Stretch.None
						),

					CreateStyle(typeof(Image),
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(700),
						Element.OpacityProperty, 1.0d,
						Image.BackgroundProperty, SolidColorBrushes.Purple.Brush,
						Image.SourceProperty, Bitmaps.Disenchantment.Bitmap,
						Image.StretchProperty, Stretch.Fill
						),

					CreateStyle(typeof(Image),
						Element.WidthProperty, Length.InPixels(100),
						Element.HeightProperty, Length.InPixels(180),
						Element.OpacityProperty, 0.5d,
						Image.BackgroundProperty, SolidColorBrushes.LimeGreen.Brush,
						Image.SourceProperty, Bitmaps.FamilyGuy.Bitmap,
						Image.StretchProperty, Stretch.Uniform
						),

					CreateStyle(typeof(Image),
						Element.WidthProperty, Length.InPixels(200),
						Element.HeightProperty, Length.InPixels(500),
						Element.OpacityProperty, 1d,
						Image.BackgroundProperty, LinearGradientBrushes.Sunrise.Brush,
						Image.SourceProperty, Bitmaps.Sun.Bitmap,
						Image.StretchProperty, Stretch.UniformToFill
						),

					CreateStyle(typeof(Image),
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.InPixels(400),
						Element.OpacityProperty, 1d,
						Image.BackgroundProperty, null,
						Image.SourceProperty, Bitmaps.KingOfTheHill.Bitmap,
						Image.StretchProperty, Stretch.ScaleDown
						)
				}),

			// TODO:TextBlock is missing runs, e.g. bold.
			new Example(typeof(Example_TextBlock.View), true,
				"Provides a lightweight element for displaying small amounts of text flow content.",
				"Relative to other UI technologies, the web allows an unusual amount of freedom to stick text just about...anywhere. And it makes sense given the browser's evolution as a text-based medium. " +
				"Frogui takes a different approach: text may be presented using a very small set of elements, including TextBlock. This does not constrain how much or where text appears, just adds " +
				"rigor when working with text.",
				PROP.All,
				new Style[]
				{
					CreateStyle(typeof(TextBlock),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Verdana,
						Cascader.FontSizeProperty, FontSize.FromLength(72, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.Normal,
						Cascader.FontStyleProperty, FontStyle.Normal,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.Yellow.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Center,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.InPixels(22),
						Cascader.TextShadowColorProperty, SolidColorBrushes.Black.Brush,
						Cascader.TextShadowHorizontalOffsetProperty, Length.InPixels(10),
						Cascader.TextShadowVerticalOffsetProperty, Length.InPixels(10),
						TextBlock.BackgroundProperty, null,
						TextBlock.PaddingProperty, Thickness.ZeroPx,
						TextBlock.TextProperty, "Hello, World!"
						),

					CreateStyle(typeof(TextBlock),
						Element.WidthProperty, Length.InPixels(600),
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Garmond,
						Cascader.FontSizeProperty, FontSize.FromLength(32, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.Normal,
						Cascader.FontStyleProperty, FontStyle.Normal,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.Black.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Left,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Cascader.TextShadowHorizontalOffsetProperty, Length.ZeroPx,
						Cascader.TextShadowVerticalOffsetProperty, Length.ZeroPx,
						TextBlock.BackgroundProperty, SolidColorBrushes.White.Brush,
						TextBlock.PaddingProperty, Thickness.InPixels(20),
						TextBlock.TextProperty, Common.LoremIpsum
						),

					CreateStyle(typeof(TextBlock),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.CourierNew,
						Cascader.FontSizeProperty, FontSize.FromLength(48, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.Expanded,
						Cascader.FontStyleProperty, FontStyle.Italic,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Center,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.InPixels(12),
						Cascader.TextShadowColorProperty, SolidColorBrushes.Lime.Brush,
						Cascader.TextShadowHorizontalOffsetProperty, Length.InPixels(4),
						Cascader.TextShadowVerticalOffsetProperty, Length.InPixels(4),
						TextBlock.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						TextBlock.PaddingProperty, Thickness.InPixels(30),
						TextBlock.TextProperty, "The only source of knowledge is experience. ~ Albert Einstein"
						),

					CreateStyle(typeof(TextBlock),
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Verdana,
						Cascader.FontSizeProperty, FontSize.FromLength(64, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.SemiCondensed,
						Cascader.FontStyleProperty, FontStyle.Italic,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.AquaMarine.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Center,
						Cascader.TextDecorationColorProperty, SolidColorBrushes.Red.Brush,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.Underline,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.Wavy,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Cascader.TextShadowHorizontalOffsetProperty, Length.ZeroPx,
						Cascader.TextShadowVerticalOffsetProperty, Length.ZeroPx,
						TextBlock.BackgroundProperty, SolidColorBrushes.Black.Brush,
						TextBlock.PaddingProperty, Thickness.InPixels(30),
						TextBlock.TextProperty, "In a gentle way, you can shake the world. ~ Mahatma Gandhi"
						),

					CreateStyle(typeof(TextBlock),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.TrebuchetMS,
						Cascader.FontSizeProperty, FontSize.FromLength(72, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.Normal,
						Cascader.FontStyleProperty, FontStyle.Normal,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Bold),
						Cascader.ForegroundProperty, SolidColorBrushes.MediumPurple.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Center,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Cascader.TextShadowHorizontalOffsetProperty, Length.ZeroPx,
						Cascader.TextShadowVerticalOffsetProperty, Length.ZeroPx,
						TextBlock.BackgroundProperty, RadialGradientBrushes.Rainbow.Brush,
						TextBlock.PaddingProperty, Thickness.InPixels(50),
						TextBlock.TextProperty, "Peace"
						)
				}),

			new Example(typeof(Example_Pixy.View), true,
				"Provides an element that displays text, an image or both.",
				"Pairing text with an image is a common UI pattern and is what the Pixy element was created to do. For instance, a button often displays text, an image or both. Pixies are used within buttons and throughout Frogui to simplify design when just text, an image or both are needed.",
				PROP.All,
				new Style[]
				{
					CreateStyle(typeof(Pixy),
						Pixy.GapProperty, Length.Auto,
						Pixy.ImageSourceProperty, Bitmaps.Filter.Bitmap,
						Pixy.TextProperty, "Filter",
						Pixy.LayoutProperty, PixyLayout.TextAboveImage,
						Cascader.FontSizeProperty, FontSize.FromLength(12, Unit.Pt),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush
						),
					CreateStyle(typeof(Pixy),
						Pixy.GapProperty, Length.Auto,
						Pixy.ImageSourceProperty, Bitmaps.Email.Bitmap,
						Pixy.TextProperty, "Email",
						Pixy.LayoutProperty, PixyLayout.TextBelowImage,
						Cascader.FontSizeProperty, FontSize.FromLength(14, Unit.Pt),
						Cascader.ForegroundProperty, SolidColorBrushes.DodgerBlue.Brush
						),
					CreateStyle(typeof(Pixy),
						Pixy.GapProperty, Length.InPixels(10),
						Pixy.ImageSourceProperty, Bitmaps.LesardeLogo.Bitmap,
						Pixy.TextProperty, "Lesarde",
						Pixy.LayoutProperty, PixyLayout.TextRightOfImage,
						Cascader.FontSizeProperty, FontSize.FromLength(48, Unit.Pt),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush
						),
					CreateStyle(typeof(Pixy),
						Pixy.GapProperty, Length.Auto,
						Pixy.ImageSourceProperty, Bitmaps.Sun.Bitmap,
						Pixy.TextProperty, "Another sunny day...",
						Pixy.LayoutProperty, PixyLayout.TextLeftOfImage,
						Cascader.FontSizeProperty, FontSize.FromLength(32, Unit.Pt),
						Cascader.ForegroundProperty, SolidColorBrushes.Yellow.Brush
						),
					CreateStyle(typeof(Pixy),
						Pixy.GapProperty, Length.InPixels(4),
						Pixy.ImageSourceProperty, Bitmaps.Cart.Bitmap,
						Pixy.TextProperty, "Cart",
						Pixy.LayoutProperty, PixyLayout.TextBelowImage,
						Cascader.FontSizeProperty, FontSize.FromLength(11, Unit.Pt),
						Cascader.ForegroundProperty, SolidColorBrushes.LightGray.Brush
						),
					CreateStyle(typeof(Pixy),
						Pixy.GapProperty, Length.InPixels(15),
						Pixy.ImageSourceProperty, Bitmaps.ScoobyDoo.Bitmap,
						Pixy.TextProperty, "Did someone say it's time for a 'Scooby Snack'?",
						Pixy.LayoutProperty, PixyLayout.TextBelowImage,
						Cascader.FontSizeProperty, FontSize.FromLength(32, Unit.Pt),
						Cascader.ForegroundProperty, SolidColorBrushes.SandyBrown.Brush
						),
					CreateStyle(typeof(Pixy),
						Pixy.GapProperty, Length.InPixels(8),
						Pixy.ImageSourceProperty, Bitmaps.AmericanFlag.Bitmap,
						Pixy.TextProperty, "Born in the USA",
						Pixy.LayoutProperty, PixyLayout.TextRightOfImage,
						Cascader.FontSizeProperty, FontSize.FromLength(24, Unit.Pt),
						Cascader.ForegroundProperty, SolidColorBrushes.DodgerBlue.Brush
						)

				}),

			new Example(typeof(Example_HtmlBlock.View), true,
				"Provides an element for displaying HTML content.",
				"The HtmlBlock control is a portal that bypasses Frogui to gain direct access to the DOM. Ideally, it is only used when other Frogui elements do not suffice.",
				PROP.All,
				new Style[]
				{
					CreateStyle(typeof(HtmlBlock),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Verdana,
						Cascader.FontSizeProperty, FontSize.FromLength(72, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.Normal,
						Cascader.FontStyleProperty, FontStyle.Normal,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.Yellow.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Center,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.InPixels(22),
						Cascader.TextShadowColorProperty, SolidColorBrushes.Black.Brush,
						Cascader.TextShadowHorizontalOffsetProperty, Length.InPixels(10),
						Cascader.TextShadowVerticalOffsetProperty, Length.InPixels(10),
						HtmlBlock.BackgroundProperty, null,
						HtmlBlock.PaddingProperty, Thickness.ZeroPx,
						HtmlBlock.TextProperty, @"<h1 style='color: #5e9ca0;'>Hello, <span style='color: #3366ff;'>World</span>!</h1><p>&nbsp;</p>"
						),

					CreateStyle(typeof(HtmlBlock),
						Element.WidthProperty, Length.InPixels(600),
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Garmond,
						Cascader.FontSizeProperty, FontSize.FromLength(32, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.Normal,
						Cascader.FontStyleProperty, FontStyle.Normal,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.Black.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Left,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Cascader.TextShadowHorizontalOffsetProperty, Length.ZeroPx,
						Cascader.TextShadowVerticalOffsetProperty, Length.ZeroPx,
						HtmlBlock.BackgroundProperty, SolidColorBrushes.White.Brush,
						HtmlBlock.PaddingProperty, Thickness.InPixels(20),
						HtmlBlock.TextProperty, $@"<p style='color: purple'>{Common.LoremIpsum}</p>"
						),

					CreateStyle(typeof(HtmlBlock),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.CourierNew,
						Cascader.FontSizeProperty, FontSize.FromLength(18, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.None,
						Cascader.FontStyleProperty, FontStyle.None,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, null,
						Cascader.TextAlignmentProperty, TextAlignment.Left,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.InPixels(12),
						Cascader.TextShadowColorProperty, null,
						Cascader.TextShadowHorizontalOffsetProperty, Length.ZeroPx,
						Cascader.TextShadowVerticalOffsetProperty, Length.ZeroPx,
						HtmlBlock.BackgroundProperty, null,
						HtmlBlock.PaddingProperty, Thickness.InPixels(30),
						HtmlBlock.TextProperty, @"<style>
* {
  box-sizing: border-box;
}

body {
  font-family: Arial, Helvetica, sans-serif;
}

/* Style the header */
header {
  background-color: #666;
  padding: 30px;
  text-align: center;
  font-size: 35px;
  color: white;
}

/* Create two columns/boxes that floats next to each other */
nav {
  float: left;
  width: 30%;
  height: 300px; /* only for demonstration, should be removed */
  background: #ccc;
  padding: 20px;
}

/* Style the list inside the menu */
nav ul {
  list-style-type: none;
  padding: 0;
}

article {
  float: left;
  padding: 20px;
  width: 70%;
  background-color: #f1f1f1;
  height: 300px; /* only for demonstration, should be removed */
}

/* Clear floats after the columns */
section:after {
  content: '';
  display: table;
  clear: both;
}

/* Style the footer */
footer {
  background-color: #777;
  padding: 10px;
  text-align: center;
  color: white;
}

/* Responsive layout - makes the two columns/boxes stack on top of each other instead of next to each other, on small screens */
@media (max-width: 600px) {
  nav, article {
    width: 100%;
    height: auto;
  }
}
</style>
</head>
<body>

<h2>CSS Layout Float</h2>
<p>In this example, we have created a header, two columns/boxes and a footer. On smaller screens, the columns will stack on top of each other.</p>
<p>Resize the browser window to see the responsive effect (you will learn more about this in our next chapter - HTML Responsive.)</p>

<header>
  <h2>Cities</h2>
</header>

<section>
  <nav>
    <ul>
      <li><a href='#'>London</a></li>
      <li><a href='#'>Paris</a></li>
      <li><a href='#'>Tokyo</a></li>
    </ul>
  </nav>
  
  <article>
    <h1>London</h1>
    <p>London is the capital city of England. It is the most populous city in the  United Kingdom, with a metropolitan area of over 13 million inhabitants.</p>
    <p>Standing on the River Thames, London has been a major settlement for two millennia, its history going back to its founding by the Romans, who named it Londinium.</p>
  </article>
</section>

<footer>
  <p>Footer</p>
</footer>"
						),

					CreateStyle(typeof(HtmlBlock),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Verdana,
						Cascader.FontSizeProperty, FontSize.FromLength(13, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.SemiCondensed,
						Cascader.FontStyleProperty, FontStyle.Italic,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.Gray.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Center,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Cascader.TextShadowHorizontalOffsetProperty, Length.ZeroPx,
						Cascader.TextShadowVerticalOffsetProperty, Length.ZeroPx,
						HtmlBlock.BackgroundProperty, SolidColorBrushes.White.Brush,
						HtmlBlock.PaddingProperty, Thickness.InPixels(30),
						HtmlBlock.TextProperty,
		@"<table>
<style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;	
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

tr:nth-child(even)
{
	background - color: #dddddd;
}
</style>
  <tr>
    <th>Company</th>
    <th>Contact</th>
    <th>Country</th>
  </tr>
  <tr>
    <td>Priya Bellevue</td>
    <td>Toby Clarita</td>
    <td>Germany</td>
  </tr>
  <tr>
    <td>Centro comercial Cancun</td>
    <td>Oliver Wrigley</td>
    <td>Mexico</td>
  </tr>
  <tr>
    <td>Jyoti Path</td>
    <td>Tommy Hopper</td>
    <td>Austria</td>
  </tr>
  <tr>
    <td>Island Joe</td>
    <td>Daisy Barkson</td>
    <td>UK</td>
  </tr>
  <tr>
    <td>Smiling Bacchus Winecellars</td>
    <td>Donna Hotsy</td>
    <td>Japan</td>
  </tr>
  <tr>
    <td>Magazzini Gratsi</td>
    <td>Fabio Lipolis</td>
    <td>Italy</td>
  </tr>
</table>
"
						),

					CreateStyle(typeof(HtmlBlock),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.TrebuchetMS,
						Cascader.FontSizeProperty, FontSize.FromLength(12, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.None,
						Cascader.FontStyleProperty, FontStyle.Normal,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Left,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Cascader.TextShadowHorizontalOffsetProperty, Length.ZeroPx,
						Cascader.TextShadowVerticalOffsetProperty, Length.ZeroPx,
						HtmlBlock.BackgroundProperty, LinearGradientBrushes.GrayFade.Brush,
						HtmlBlock.PaddingProperty, Thickness.InPixels(20),
						HtmlBlock.TextProperty, @"<h2>Ordered List with Lowercase Roman Numbers</h2>
<ol type='1'>
  <li>Coffee</li>
  <li>Tea</li>
  <li>Milk</li>
</ol>  
<ol type='a'>
  <li>Coffee</li>
  <li>Tea</li>
  <li>Milk</li>
</ol>  
<ol type='i'>
  <li>Coffee</li>
  <li>Tea</li>
  <li>Milk</li>
</ol>  
<h2>A Description List</h2>
<dl>
  <dt>Coffee</dt>
  <dd>- black hot drink</dd>
  <dt>Milk</dt>
  <dd>- white cold drink</dd>
</dl>
<h2>A Nested List</h2>
<p>List can be nested (lists inside lists):</p>
<ul>
  <li>Coffee</li>
  <li>Tea
    <ul>
      <li>Black tea</li>
      <li>Green tea</li>
    </ul>
  </li>
  <li>Milk</li>
</ul>
"
						)
				}),

			new Example(typeof(Example_TextBox.View), true,
				"Represents a control that can be used to display and edit plain text (single or multi-line).",
				"TextBox, like all Frogui text-based elements, can access the rich text styling available in browsers, such as shadows and decorations, through properties. " +
				"Furthermore, all controls and many elements derive from the Cascader element which automatically leverages browser's cascading text styling.",
				PROP.All,
				new Style[]
				{
					CreateStyle(typeof(TextBox),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Verdana,
						Cascader.FontSizeProperty, FontSize.FromLength(72, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.Normal,
						Cascader.FontStyleProperty, FontStyle.Normal,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.Yellow.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Center,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.InPixels(22),
						Cascader.TextShadowColorProperty, SolidColorBrushes.Black.Brush,
						Cascader.TextShadowHorizontalOffsetProperty, Length.InPixels(10),
						Cascader.TextShadowVerticalOffsetProperty, Length.InPixels(10),
						TextBox.BackgroundProperty, null,
						TextBox.TextProperty, "Hello, World!"
						),

					CreateStyle(typeof(TextBox),
						Element.WidthProperty, Length.InPixels(600),
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Garmond,
						Cascader.FontSizeProperty, FontSize.FromLength(32, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.Normal,
						Cascader.FontStyleProperty, FontStyle.Normal,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.Black.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Left,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Cascader.TextShadowHorizontalOffsetProperty, Length.ZeroPx,
						Cascader.TextShadowVerticalOffsetProperty, Length.ZeroPx,
						TextBox.BackgroundProperty, SolidColorBrushes.White.Brush,
						TextBox.TextProperty, Common.LoremIpsum
						),

					CreateStyle(typeof(TextBox),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1.0d,
						Cascader.FontFamilyProperty, Common.FontFamilies.CourierNew,
						Cascader.FontSizeProperty, FontSize.FromLength(48, Unit.Pt),
						Cascader.FontStretchProperty, FontStretch.Expanded,
						Cascader.FontStyleProperty, FontStyle.Italic,
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.TextAlignmentProperty, TextAlignment.Center,
						Cascader.TextDecorationColorProperty, null,
						Cascader.TextDecorationLinesProperty, TextDecorationLines.None,
						Cascader.TextDecorationStyleProperty, TextDecorationStyle.None,
						Cascader.TextShadowBlurProperty, Length.InPixels(12),
						Cascader.TextShadowColorProperty, SolidColorBrushes.Lime.Brush,
						Cascader.TextShadowHorizontalOffsetProperty, Length.InPixels(4),
						Cascader.TextShadowVerticalOffsetProperty, Length.InPixels(4),
						TextBox.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						TextBox.TextProperty, "The only source of knowledge is experience. ~ Albert Einstein"
						)
				}),

			new Example(typeof(Example_NumericEdit.View), true,
				"Represents a control that can be used to display and edit numbers.",
				"This control is an excellent example of where Frogui is heading with more advanced controls. The NumericEdit control has a decent number of properties in this release but " +
				"will evolve to match the features available in the most advanced UI frameworks. Other editing controls will follow such as date pickers, search and email, to name a few.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(NumericEdit),
						NumericEdit.CornerRadiusProperty, CornerRadius.ZeroPx,
						NumericEdit.VaryButtonBackgroundProperty, SolidColorBrushes.Silver.Brush,
						NumericEdit.BackgroundProperty, null,
						NumericEdit.VaryButtonFillProperty, SolidColorBrushes.Black.Brush,
						NumericEdit.VaryButtonLengthProperty, Length.InPixels(13),
						NumericEdit.VaryButtonDesignProperty, VaryDesign.Triangle,
						NumericEdit.VaryButtonPlacementProperty, VaryButtonPlacement.ColumnRight,
						NumericEdit.BorderBrushProperty, null,
						NumericEdit.BorderThicknessProperty, Length.ZeroPx,
						NumericEdit.SymbolProperty, null,
						Cascader.ForegroundProperty, null,
						Cascader.FontSizeProperty, FontSize.FromLength(11, Unit.Pt),
						Cascader.TextAlignmentProperty, TextAlignment.Left
						),
					CreateStyle(typeof(NumericEdit),
						NumericEdit.CornerRadiusProperty, CornerRadius.InPixels(9),
						NumericEdit.VaryButtonBackgroundProperty, SolidColorBrushes.White.Brush,
						NumericEdit.BackgroundProperty, null,
						NumericEdit.VaryButtonFillProperty, SolidColorBrushes.Black.Brush,
						NumericEdit.VaryButtonLengthProperty, Length.InPixels(32),
						NumericEdit.VaryButtonDesignProperty, VaryDesign.Sign,
						NumericEdit.VaryButtonPlacementProperty, VaryButtonPlacement.VerticalEnds,
						NumericEdit.BorderBrushProperty, SolidColorBrushes.Silver.Brush,
						NumericEdit.BorderThicknessProperty, Length.InPixels(2),
						NumericEdit.SymbolBackgroundProperty, SolidColorBrushes.White.Brush,
						NumericEdit.SymbolForegroundProperty, SolidColorBrushes.Silver.Brush,
						NumericEdit.SymbolPlacementProperty, SymbolPlacement.Right,
						NumericEdit.SymbolProperty, "kg",
						Cascader.ForegroundProperty, null,
						Cascader.FontSizeProperty, FontSize.FromLength(18, Unit.Pt),
						Cascader.TextAlignmentProperty, TextAlignment.Center
						),
					CreateStyle(typeof(NumericEdit),
						NumericEdit.CornerRadiusProperty, CornerRadius.InPixels(11),
						NumericEdit.VaryButtonBackgroundProperty, LinearGradientBrushes.GrayFade.Brush,
						NumericEdit.BackgroundProperty, SolidColorBrushes.Black.Brush,
						NumericEdit.VaryButtonFillProperty, SolidColorBrushes.White.Brush,
						NumericEdit.VaryButtonLengthProperty, Length.InPixels(32),
						NumericEdit.VaryButtonDesignProperty, VaryDesign.Chevron,
						NumericEdit.VaryButtonPlacementProperty, VaryButtonPlacement.ColumnLeft,
						NumericEdit.BorderBrushProperty, SolidColorBrushes.Gray.Brush,
						NumericEdit.BorderThicknessProperty, Length.InPixels(1.5),
						NumericEdit.SymbolProperty, null,
						Cascader.ForegroundProperty, SolidColorBrushes.LimeGreen.Brush,
						Cascader.FontSizeProperty, FontSize.FromLength(15, Unit.Pt),
						Cascader.TextAlignmentProperty, TextAlignment.Right
						),
					CreateStyle(typeof(NumericEdit),
						NumericEdit.CornerRadiusProperty, CornerRadius.ZeroPx,
						NumericEdit.VaryButtonBackgroundProperty, SolidColorBrushes.Orange.Brush,
						NumericEdit.BackgroundProperty, SolidColorBrushes.Indigo.Brush,
						NumericEdit.VaryButtonFillProperty, SolidColorBrushes.Black.Brush,
						NumericEdit.VaryButtonLengthProperty, Length.InPixels(54),
						NumericEdit.VaryButtonDesignProperty, VaryDesign.Sign,
						NumericEdit.VaryButtonPlacementProperty, VaryButtonPlacement.RowLeft,
						NumericEdit.BorderBrushProperty, null,
						NumericEdit.BorderThicknessProperty, Length.ZeroPx,
						NumericEdit.SymbolProperty, null,
						Cascader.ForegroundProperty, SolidColorBrushes.PaleGoldenRod.Brush,
						Cascader.FontSizeProperty, FontSize.FromLength(36, Unit.Pt),
						Cascader.TextAlignmentProperty, TextAlignment.Right
						),
					CreateStyle(typeof(NumericEdit),
						NumericEdit.CornerRadiusProperty, CornerRadius.InPixels(30),
						NumericEdit.VaryButtonBackgroundProperty, SolidColorBrushes.Black.Brush,
						NumericEdit.BackgroundProperty, RadialGradientBrushes.Ruby.Brush,
						NumericEdit.VaryButtonFillProperty, SolidColorBrushes.DarkRed.Brush,
						NumericEdit.VaryButtonLengthProperty, Length.InPixels(60),
						NumericEdit.VaryButtonDesignProperty, VaryDesign.Arrow,
						NumericEdit.VaryButtonPlacementProperty, VaryButtonPlacement.ColumnLeft,
						NumericEdit.BorderBrushProperty, null,
						NumericEdit.BorderThicknessProperty, Length.ZeroPx,
						NumericEdit.SymbolProperty, null,
						Cascader.ForegroundProperty, SolidColorBrushes.SeaShell.Brush,
						Cascader.FontSizeProperty, FontSize.FromLength(38, Unit.Pt),
						Cascader.TextAlignmentProperty, TextAlignment.Center
						),
					CreateStyle(typeof(NumericEdit),
						NumericEdit.CornerRadiusProperty, CornerRadius.InPixels(4),
						NumericEdit.VaryButtonBackgroundProperty, SolidColorBrushes.Silver.Brush,
						NumericEdit.BackgroundProperty, null,
						NumericEdit.VaryButtonFillProperty, SolidColorBrushes.Black.Brush,
						NumericEdit.VaryButtonLengthProperty, Length.InPixels(20),
						NumericEdit.VaryButtonDesignProperty, VaryDesign.LineArrow,
						NumericEdit.VaryButtonPlacementProperty, VaryButtonPlacement.ColumnRight,
						NumericEdit.BorderBrushProperty, null,
						NumericEdit.BorderThicknessProperty, Length.ZeroPx,
						NumericEdit.SymbolBackgroundProperty, SolidColorBrushes.LightGreen.Brush,
						NumericEdit.SymbolForegroundProperty, SolidColorBrushes.SeaGreen.Brush,
						NumericEdit.SymbolPlacementProperty, SymbolPlacement.Left,
						NumericEdit.SymbolProperty, "$",
						Cascader.ForegroundProperty, null,
						Cascader.FontSizeProperty, FontSize.FromLength(15, Unit.Pt),
						Cascader.TextAlignmentProperty, TextAlignment.Left
						),
					CreateStyle(typeof(NumericEdit),
						NumericEdit.CornerRadiusProperty, CornerRadius.ZeroPx,
						NumericEdit.VaryButtonBackgroundProperty, null,
						NumericEdit.BackgroundProperty, LinearGradientBrushes.GrayFade.Brush,
						NumericEdit.VaryButtonFillProperty, SolidColorBrushes.Silver.Brush,
						NumericEdit.VaryButtonLengthProperty, Length.InPixels(20),
						NumericEdit.VaryButtonDesignProperty, VaryDesign.LineArrow,
						NumericEdit.VaryButtonPlacementProperty, VaryButtonPlacement.RowRight,
						NumericEdit.BorderBrushProperty, SolidColorBrushes.AliceBlue.Brush,
						NumericEdit.BorderThicknessProperty, Length.InPixels(2),
						NumericEdit.SymbolProperty, null,
						Cascader.ForegroundProperty, SolidColorBrushes.Lime.Brush,
						Cascader.FontSizeProperty, FontSize.FromLength(20, Unit.Pt),
						Cascader.TextAlignmentProperty, TextAlignment.Left
						)
				}),

			new Example(typeof(Example_Border.View), true,
				"An element that draws a border, background, or both around another element.",
				"Frogui combines the best of the WPF/UWP Border element with the power of the web. Brushes may be used and all the advanced web border features, such as patterns, are available.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Border),
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.InPixels(400),
						Element.OpacityProperty, 1d,
						Border.BackgroundProperty, LinearGradientBrushes.TwilightZone.Brush,
						Border.BorderBrushProperty, SolidColorBrushes.Magenta.Brush,
						Border.BorderThicknessProperty, Thickness.InPixels(20),
						Border.BorderPatternProperty, new BorderPattern(StrokePattern.Solid),
						Border.CornerRadiusProperty, CornerRadius.InPixels(20)
						),

					CreateStyle(typeof(Border),
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(200),
						Element.OpacityProperty,1d,
						Border.BackgroundProperty, SolidColorBrushes.Black.Brush,
						Border.BorderBrushProperty, SolidColorBrushes.White.Brush,
						Border.BorderThicknessProperty, Thickness.InPixels(25),
						Border.BorderPatternProperty, new BorderPattern(StrokePattern.Solid),
						Border.CornerRadiusProperty, CornerRadius.InPixels(40)
						),

					CreateStyle(typeof(Border),
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(600),
						Element.OpacityProperty, 0.7d,
						Border.BackgroundProperty, SolidColorBrushes.Yellow.Brush,
						Border.BorderBrushProperty, SolidColorBrushes.Violet.Brush,
						Border.BorderThicknessProperty, Thickness.InPixels(3),
						Border.BorderPatternProperty, new BorderPattern(StrokePattern.Dashed),
						Border.CornerRadiusProperty, CornerRadius.ZeroPx
						),

					CreateStyle(typeof(Border),
						Element.WidthProperty, Length.InPixels(250),
						Element.HeightProperty, Length.InPixels(180),
						Element.OpacityProperty, 1d,
						Border.BackgroundProperty, null,
						Border.BorderBrushProperty, SolidColorBrushes.DarkSeaGreen.Brush,
						Border.BorderThicknessProperty, Thickness.InPixels(16),
						Border.BorderPatternProperty, new BorderPattern(StrokePattern.Dotted),
						Border.CornerRadiusProperty, CornerRadius.InPixels(30)
						),

					CreateStyle(typeof(Border),
						Element.WidthProperty, Length.InPixels(800),
						Element.HeightProperty, Length.InPixels(800),
						Element.OpacityProperty, 1.0d,
						Border.BackgroundProperty, ImageBrushes.ScoobyDoo.Brush,
						Border.BorderBrushProperty, SolidColorBrushes.LightYellow.Brush,
						Border.BorderThicknessProperty, Thickness.InPixels(40),
						Border.BorderPatternProperty, new BorderPattern(StrokePattern.Outset),
						Border.CornerRadiusProperty, CornerRadius.InPixels(50)
						)
				}),

			new Example(typeof(Example_Button.View), true,
				"Represents a button control, which reacts to the Click event.",
				"Buttons are one of the most fascinating and ubiquitous UI controls ever, and their appearance is as varied as the web itself! Frogui recognizes the need to customize buttons and, like all " +
				"other controls, buttons have a wide variety of properties that allow achieving a custom look without resorting to custom coding.",
				PROP.All,
				new Style[]
				{
					CreateStyle(typeof(Button),
						Element.WidthProperty, Length.InPixels(160),
						Element.HeightProperty, Length.InPixels(36),
						Element.OpacityProperty, 1d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(8, Unit.Pt),
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Bold),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Control.PaddingProperty, Thickness.ZeroPx,
						Button.BackgroundProperty, SolidColorBrushes.LimeGreen.Brush,
						Button.BorderBrushProperty, null,
						Button.BorderThicknessProperty, Thickness.ZeroPx,
						Button.BorderPatternProperty, new BorderPattern(StrokePattern.Solid),
						Button.CornerRadiusProperty, CornerRadius.InPixels(22),
						Button.PixyGapProperty, Length.ZeroPx,
						Button.TextProperty, "SHUFFLE PLAY",
						Button.ImageSourceProperty, null
						),

					CreateStyle(typeof(Button),
						Element.WidthProperty, Length.InPixels(120),
						Element.HeightProperty, Length.InPixels(36),
						Element.OpacityProperty, 1d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(7, Unit.Pt),
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Bold),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Control.PaddingProperty, Thickness.ZeroPx,
						Button.BackgroundProperty, null,
						Button.BorderBrushProperty, SolidColorBrushes.Gray.Brush,
						Button.BorderThicknessProperty, Thickness.InPixels(1.5),
						Button.BorderPatternProperty, new BorderPattern(StrokePattern.Solid),
						Button.CornerRadiusProperty, CornerRadius.InPixels(22),
						Button.PixyGapProperty, Length.ZeroPx,
						Button.TextProperty, "FOLLOW",
						Button.ImageSourceProperty, null
						),

					CreateStyle(typeof(Button),
						Element.WidthProperty, Length.InPixels(180),
						Element.HeightProperty, Length.InPixels(40),
						Element.OpacityProperty, 1d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(10, Unit.Pt),
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Bold),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Control.PaddingProperty, Thickness.ZeroPx,
						Button.BackgroundProperty, SolidColorBrushes.Blue.Brush,
						Button.BorderBrushProperty, SolidColorBrushes.RoyalBlue.Brush,
						Button.BorderThicknessProperty, Thickness.InPixels(0),
						Button.BorderPatternProperty, new BorderPattern(StrokePattern.Solid),
						Button.CornerRadiusProperty, CornerRadius.InPixels(4),
						Button.PixyGapProperty, Length.ZeroPx,
						Button.TextProperty, "Try 1 month for $1",
						Button.ImageSourceProperty, null
						),

					CreateStyle(typeof(Button),
						Element.WidthProperty, Length.InPixels(100),
						Element.HeightProperty, Length.InPixels(100),
						Element.OpacityProperty, 1d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Arial,
						Cascader.FontSizeProperty, FontSize.FromLength(11, Unit.Pt),
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Bold),
						Cascader.ForegroundProperty, SolidColorBrushes.Gray.Brush,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Control.PaddingProperty, Thickness.ZeroPx,
						Button.BackgroundProperty, SolidColorBrushes.Transparent.Brush,
						Button.BorderBrushProperty, SolidColorBrushes.MediumSeaGreen.Brush,
						Button.BorderThicknessProperty, Thickness.InPixels(3),
						Button.BorderPatternProperty, new BorderPattern(StrokePattern.Solid),
						Button.CornerRadiusProperty, CornerRadius.InPixels(50),
						Button.PixyGapProperty, Length.InPixels(2),
						Button.PixyLayoutProperty, PixyLayout.TextBelowImage,
						Button.TextProperty, "search",
						Button.ImageSourceProperty, Bitmaps.Search.Bitmap
						),

					CreateStyle(typeof(Button),
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto,
						Element.OpacityProperty, 1d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Arial,
						Cascader.FontSizeProperty, FontSize.FromLength(14, Unit.Pt),
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Control.PaddingProperty, Thickness.InPixels(8),
						Button.BackgroundProperty, SolidColorBrushes.Chocolate.Brush,
						Button.BorderBrushProperty, SolidColorBrushes.White.Brush,
						Button.BorderThicknessProperty, Thickness.InPixels(2),
						Button.BorderPatternProperty, new BorderPattern(StrokePattern.Solid),
						Button.CornerRadiusProperty, CornerRadius.InPixels(12),
						Button.PixyGapProperty, Length.InPixels(8),
						Button.PixyLayoutProperty, PixyLayout.TextRightOfImage,
						Button.TextProperty, "checkout",
						Button.ImageSourceProperty, Bitmaps.Cart.Bitmap
						),

					CreateStyle(typeof(Button),
						Element.WidthProperty, Length.InPixels(124),
						Element.HeightProperty, Length.InPixels(124),
						Element.OpacityProperty, 0.76d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Verdana,
						Cascader.FontSizeProperty, FontSize.FromLength(22, Unit.Pt),
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Bold),
						Cascader.ForegroundProperty, SolidColorBrushes.Transparent.Brush,
						Cascader.TextShadowBlurProperty, Length.InPixels(3),
						Cascader.TextShadowColorProperty, SolidColorBrushes.Black.Brush,
						Control.PaddingProperty, Thickness.ZeroPx,
						Button.BackgroundProperty, RadialGradientBrushes.Ruby.Brush,
						Button.BorderBrushProperty, SolidColorBrushes.DarkGray.Brush,
						Button.BorderThicknessProperty, Thickness.InPixels(4),
						Button.BorderPatternProperty, new BorderPattern(StrokePattern.Solid),
						Button.CornerRadiusProperty, CornerRadius.InPixels(64),
						Button.TextProperty, "start",
						Button.ImageSourceProperty, null
						),

					CreateStyle(typeof(Button),
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.InPixels(40),
						Element.OpacityProperty, 1d,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(13, Unit.Pt),
						Cascader.FontWeightProperty, FontWeight.FromKind(FontWeightKind.Normal),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.TextShadowBlurProperty, Length.ZeroPx,
						Cascader.TextShadowColorProperty, null,
						Control.PaddingProperty, Thickness.ZeroPx,
						Button.BackgroundProperty, SolidColorBrushes.DarkSlateGray.Brush,
						Button.BorderBrushProperty, null,
						Button.BorderThicknessProperty, Thickness.InPixels(0),
						Button.BorderPatternProperty, new BorderPattern(StrokePattern.Solid),
						Button.CornerRadiusProperty, CornerRadius.ZeroPx,
						Button.PixyGapProperty, Length.InPixels(16),
						Button.PixyLayoutProperty, PixyLayout.TextRightOfImage,
						Button.TextProperty, "REFINE RESULTS",
						Button.ImageSourceProperty, Bitmaps.Filter.Bitmap
						),

				}),

			new Example(typeof(Example_CheckBox.View), true,
				"Represents a control that a user can select and clear.",
				"Like buttons, checkboxes offer a wide variety of properties to customize their look. And they use pixies internally to simplify working with text and image pairs.",
				PROP.All,
				new Style[]
				{
					CreateStyle(typeof(CheckBox),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(18, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(2),
						ButtonBase.TextProperty, "Accounts Receivable",
						ButtonBase.ImageSourceProperty, null,
						CheckBox.BorderBrushProperty, null,
						CheckBox.CheckDesignProperty, CheckDesign.Normal,
						CheckBox.GapProperty, Length.InPixels(6),
						CheckBox.BorderSizeProperty, Length.InPixels(27),
						CheckBox.BackgroundProperty, SolidColorBrushes.SeaGreen.Brush,
						CheckBox.CheckBrushProperty, SolidColorBrushes.White.Brush,
						CheckBox.BorderThicknessProperty, Length.ZeroPx,
						CheckBox.CornerRadiusProperty, CornerRadius.InPixels(5),
						CheckBox.UseIndeterminateProperty, true,
						CheckBox.CheckStateProperty, CheckState.Checked
					),
					CreateStyle(typeof(CheckBox),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Garmond,
						Cascader.FontSizeProperty, FontSize.FromLength(11, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(3),
						ButtonBase.TextProperty, "Strawberries",
						ButtonBase.ImageSourceProperty, null,
						CheckBox.BorderBrushProperty, null,
						CheckBox.CheckDesignProperty, CheckDesign.Thin,
						CheckBox.GapProperty, Length.InPixels(9),
						CheckBox.BorderSizeProperty, Length.InPixels(17),
						CheckBox.BackgroundProperty, SolidColorBrushes.MediumBlue.Brush,
						CheckBox.CheckBrushProperty, SolidColorBrushes.White.Brush,
						CheckBox.BorderThicknessProperty, Length.ZeroPx,
						CheckBox.CornerRadiusProperty, CornerRadius.ZeroPx,
						CheckBox.UseIndeterminateProperty, false,
						CheckBox.CheckStateProperty, CheckState.Checked
					),
					CreateStyle(typeof(CheckBox),
						Cascader.ForegroundProperty, SolidColorBrushes.Peru.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(13, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(3),
						ButtonBase.TextProperty, "Green Bay",
						ButtonBase.ImageSourceProperty, null,
						CheckBox.BorderBrushProperty, SolidColorBrushes.Gray.Brush,
						CheckBox.CheckDesignProperty, CheckDesign.Normal,
						CheckBox.GapProperty, Length.InPixels(6),
						CheckBox.BorderSizeProperty, Length.InPixels(20),
						CheckBox.BackgroundProperty, SolidColorBrushes.White.Brush,
						CheckBox.CheckBrushProperty, SolidColorBrushes.Black.Brush,
						CheckBox.BorderThicknessProperty, Length.InPixels(1),
						CheckBox.CornerRadiusProperty, CornerRadius.InPixels(10),
						CheckBox.UseIndeterminateProperty, true,
						CheckBox.CheckStateProperty, CheckState.Indeterminate
					),
					CreateStyle(typeof(CheckBox),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(18, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(3),
						ButtonBase.TextProperty, String.Empty,
						ButtonBase.ImageSourceProperty, Bitmaps.AmericanFlag.Bitmap,
						CheckBox.BorderBrushProperty, SolidColorBrushes.LightSeaGreen.Brush,
						CheckBox.CheckDesignProperty, CheckDesign.Fat,
						CheckBox.GapProperty, Length.InPixels(11),
						CheckBox.BorderSizeProperty, Length.InPixels(32),
						CheckBox.BackgroundProperty, SolidColorBrushes.DarkSlateBlue.Brush,
						CheckBox.CheckBrushProperty, SolidColorBrushes.White.Brush,
						CheckBox.BorderThicknessProperty, Length.InPixels(4),
						CheckBox.CornerRadiusProperty, CornerRadius.InPixels(7),
						CheckBox.UseIndeterminateProperty, false,
						CheckBox.CheckStateProperty, CheckState.Checked
					),
					CreateStyle(typeof(CheckBox),
						Cascader.ForegroundProperty, SolidColorBrushes.Yellow.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Courier,
						Cascader.FontSizeProperty, FontSize.FromLength(12, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(3),
						ButtonBase.TextProperty, "Include Giftcard",
						ButtonBase.ImageSourceProperty, null,
						CheckBox.BorderBrushProperty, SolidColorBrushes.Yellow.Brush,
						CheckBox.CheckDesignProperty, CheckDesign.Normal,
						CheckBox.GapProperty, Length.InPixels(8),
						CheckBox.BorderSizeProperty, Length.InPixels(21),
						CheckBox.BackgroundProperty, RadialGradientBrushes.GrayFade.Brush,
						CheckBox.CheckBrushProperty, SolidColorBrushes.MediumTurquoise.Brush,
						CheckBox.BorderThicknessProperty, Length.InPixels(1),
						CheckBox.CornerRadiusProperty, CornerRadius.ZeroPx,
						CheckBox.UseIndeterminateProperty, false,
						CheckBox.CheckStateProperty, CheckState.Checked
					)
				}),

			new Example(typeof(Example_RadioButton.View), true,
				"Represents a button that is typically grouped with other RadioButton controls, one of which may be selected at a time.",
				"Radio buttons derive from GroupControl, which means they are only effective when grouped with other radio buttons. Radio buttons may be " +
				"customized to achieve a countless variety of looks. And GroupControl may be used as a base class to create any groupable control you can dream up.",
				PROP.All,
				new Style[]
				{
					CreateStyle(typeof(RadioButton),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(18, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(2),
						ButtonBase.TextProperty, "Accounts Payable",
						ButtonBase.ImageSourceProperty, null,
						RadioButton.BorderBrushProperty, null,
						RadioButton.GapProperty, Length.InPixels(6),
						RadioButton.BorderSizeProperty, Length.InPixels(27),
						RadioButton.BackgroundProperty, SolidColorBrushes.SeaGreen.Brush,
						RadioButton.CheckBrushProperty, SolidColorBrushes.White.Brush,
						RadioButton.BorderThicknessProperty, Length.ZeroPx,
						RadioButton.IsCheckedProperty, true
					),
					CreateStyle(typeof(RadioButton),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Courier,
						Cascader.FontSizeProperty, FontSize.FromLength(24, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(16),
						ButtonBase.TextProperty, "I am afraid I can't do that Dave.",
						ButtonBase.ImageSourceProperty, null,
						RadioButton.BorderBrushProperty, LinearGradientBrushes.Chrome.Brush,
						RadioButton.GapProperty, Length.InPixels(14),
						RadioButton.BorderSizeProperty, Length.InPixels(45),
						RadioButton.BackgroundProperty, RadialGradientBrushes.Ruby.Brush,
						RadioButton.CheckBrushProperty, SolidColorBrushes.Yellow.Brush,
						RadioButton.BorderThicknessProperty, Length.InPixels(4),
						RadioButton.IsCheckedProperty, true
					),
					CreateStyle(typeof(RadioButton),
						Cascader.ForegroundProperty, SolidColorBrushes.LightBlue.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Garmond,
						Cascader.FontSizeProperty, FontSize.FromLength(11, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(3),
						ButtonBase.TextProperty, "Blueberries",
						ButtonBase.ImageSourceProperty, null,
						RadioButton.BorderBrushProperty, null,
						RadioButton.GapProperty, Length.InPixels(9),
						RadioButton.BorderSizeProperty, Length.InPixels(17),
						RadioButton.BackgroundProperty, SolidColorBrushes.MediumBlue.Brush,
						RadioButton.CheckBrushProperty, SolidColorBrushes.White.Brush,
						RadioButton.BorderThicknessProperty, Length.ZeroPx,
						RadioButton.IsCheckedProperty, true
					),
					CreateStyle(typeof(RadioButton),
						Cascader.ForegroundProperty, SolidColorBrushes.Turquoise.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(13, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(5),
						ButtonBase.TextProperty, "Florida",
						ButtonBase.ImageSourceProperty, null,
						RadioButton.BorderBrushProperty, SolidColorBrushes.Gray.Brush,
						RadioButton.GapProperty, Length.InPixels(6),
						RadioButton.BorderSizeProperty, Length.InPixels(20),
						RadioButton.BackgroundProperty, SolidColorBrushes.White.Brush,
						RadioButton.CheckBrushProperty, SolidColorBrushes.Black.Brush,
						RadioButton.BorderThicknessProperty, Length.InPixels(1),
						RadioButton.IsCheckedProperty, true
					),
					CreateStyle(typeof(RadioButton),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Helvetica,
						Cascader.FontSizeProperty, FontSize.FromLength(18, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(3),
						ButtonBase.TextProperty, String.Empty,
						ButtonBase.ImageSourceProperty, Bitmaps.AmericanFlag.Bitmap,
						RadioButton.BorderBrushProperty, SolidColorBrushes.LightSeaGreen.Brush,
						RadioButton.GapProperty, Length.InPixels(11),
						RadioButton.BorderSizeProperty, Length.InPixels(32),
						RadioButton.BackgroundProperty, SolidColorBrushes.DarkSlateBlue.Brush,
						RadioButton.CheckBrushProperty, SolidColorBrushes.White.Brush,
						RadioButton.BorderThicknessProperty, Length.InPixels(4),
						RadioButton.IsCheckedProperty, true
					),
					CreateStyle(typeof(RadioButton),
						Cascader.ForegroundProperty, SolidColorBrushes.Yellow.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Courier,
						Cascader.FontSizeProperty, FontSize.FromLength(12, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(6),
						ButtonBase.TextProperty, "Thursday",
						ButtonBase.ImageSourceProperty, null,
						RadioButton.BorderBrushProperty, SolidColorBrushes.Yellow.Brush,
						RadioButton.GapProperty, Length.InPixels(8),
						RadioButton.BorderSizeProperty, Length.InPixels(21),
						RadioButton.BackgroundProperty, RadialGradientBrushes.GrayFade.Brush,
						RadioButton.CheckBrushProperty, SolidColorBrushes.MediumTurquoise.Brush,
						RadioButton.BorderThicknessProperty, Length.InPixels(1),
						RadioButton.IsCheckedProperty, true
					),
					CreateStyle(typeof(RadioButton),
						Cascader.ForegroundProperty, SolidColorBrushes.White.Brush,
						Cascader.FontFamilyProperty, Common.FontFamilies.Impact,
						Cascader.FontSizeProperty, FontSize.FromLength(22, Unit.Pt),
						Control.PaddingProperty, Thickness.InPixels(6),
						ButtonBase.TextProperty, "Resume Game",
						ButtonBase.ImageSourceProperty, null,
						RadioButton.BorderBrushProperty, LinearGradientBrushes.Chrome.Brush,
						RadioButton.GapProperty, Length.InPixels(3),
						RadioButton.BorderSizeProperty, Length.InPixels(27),
						RadioButton.BackgroundProperty, SolidColorBrushes.Black.Brush,
						RadioButton.CheckBrushProperty, SolidColorBrushes.LimeGreen.Brush,
						RadioButton.BorderThicknessProperty, Length.InPixels(4),
						RadioButton.IsCheckedProperty, true
					)
				}),

			new Example(typeof(Example_ScrollBar.View), true,
				"Represents a control that provides a scroll bar that has a sliding thumb button whose position corresponds to a value.",
				"Web developers have wanted a way to customize scroll bars for a long time. The good news is customization has reached the experimental level in the web standard. The bad news is it is not " +
				"widely supported in browsers. Because Frogui DOES NOT use web scroll bar technology, it is not limited. As you can see the properties available are unprecedented for web scroll bar design. An important next step " +
				"for Frogui is to utilize native browser scrolling when advanced features are not needed. In this release we wanted to push the limits to better understand them.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(ScrollBar),
						ScrollBar.VaryButtonDesignProperty, VaryDesign.LineArrow,
						ScrollBar.BackgroundProperty, null,
						ScrollBar.BorderBrushProperty, null,
						ScrollBar.VaryButtonBackgroundProperty, null,
						ScrollBar.VaryButtonFillProperty, SolidColorBrushes.Silver.Brush,
						ScrollBar.BorderThicknessProperty, Length.ZeroPx,
						ScrollBar.VaryButtonLengthProperty, Length.InPixels(36),
						TrackBase.TrackShadowBlurProperty, Length.ZeroPx,
						TrackBase.TrackShadowColorProperty, null,
						TrackBase.TrackShadowSpreadProperty, Length.ZeroPx,
						TrackBase.OrientationProperty, Orientation.Vertical,
						TrackBase.TrackBackgroundProperty, SolidColorBrushes.Silver.Brush,
						TrackBase.TrackBorderBrushProperty, SolidColorBrushes.Transparent.Brush,
						TrackBase.TrackBorderThicknessProperty, Length.InPixels(16),
						TrackBase.ThumbBackgroundProperty, SolidColorBrushes.DimGray.Brush,
						TrackBase.ThumbBorderBrushProperty, SolidColorBrushes.Transparent.Brush,
						TrackBase.ThumbBorderThicknessProperty, Length.ZeroPx,
						TrackBase.EdgeDesignProperty, TrackEdgeDesign.Round,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.InPixels(38),
						Element.HeightProperty, Length.InPixels(500)
					),
					CreateStyle(typeof(ScrollBar),
						ScrollBar.VaryButtonDesignProperty, VaryDesign.None,
						ScrollBar.BackgroundProperty, null,
						ScrollBar.BorderBrushProperty, null,
						ScrollBar.VaryButtonBackgroundProperty, null,
						ScrollBar.VaryButtonFillProperty, null,
						ScrollBar.BorderThicknessProperty, Length.ZeroPx,
						ScrollBar.VaryButtonLengthProperty, Length.InPixels(22),
						TrackBase.TrackShadowBlurProperty, Length.InPixels(13),
						TrackBase.TrackShadowColorProperty, SolidColorBrushes.Gray.Brush,
						TrackBase.TrackShadowSpreadProperty, Length.InPixels(5),
						TrackBase.OrientationProperty, Orientation.Vertical,
						TrackBase.TrackBackgroundProperty, SolidColorBrushes.LightGray.Brush,
						TrackBase.TrackBorderBrushProperty, SolidColorBrushes.Transparent.Brush,
						TrackBase.TrackBorderThicknessProperty, Length.InPixels(0),
						TrackBase.ThumbBackgroundProperty, LinearGradientBrushes.Ruby.Brush,
						TrackBase.ThumbBorderBrushProperty, SolidColorBrushes.Transparent.Brush,
						TrackBase.ThumbBorderThicknessProperty, Length.InPixels(3),
						TrackBase.EdgeDesignProperty, TrackEdgeDesign.Round,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.InPixels(26),
						Element.HeightProperty, Length.InPixels(400)
					),
					CreateStyle(typeof(ScrollBar),
						ScrollBar.VaryButtonDesignProperty, VaryDesign.None,
						ScrollBar.BackgroundProperty, null,
						ScrollBar.BorderBrushProperty, null,
						ScrollBar.VaryButtonBackgroundProperty, null,
						ScrollBar.VaryButtonFillProperty, null,
						ScrollBar.BorderThicknessProperty, Length.ZeroPx,
						ScrollBar.VaryButtonLengthProperty, Length.ZeroPx,
						TrackBase.TrackShadowBlurProperty, Length.ZeroPx,
						TrackBase.TrackShadowColorProperty, null,
						TrackBase.TrackShadowSpreadProperty, Length.ZeroPx,
						TrackBase.OrientationProperty, Orientation.Vertical,
						TrackBase.TrackBackgroundProperty, SolidColorBrushes.SeaGreen.Brush,
						TrackBase.TrackBorderBrushProperty, SolidColorBrushes.Transparent.Brush,
						TrackBase.TrackBorderThicknessProperty, Length.InPixels(16),
						TrackBase.ThumbBackgroundProperty, SolidColorBrushes.LightGreen.Brush,
						TrackBase.ThumbBorderBrushProperty, SolidColorBrushes.Transparent.Brush,
						TrackBase.ThumbBorderThicknessProperty, Length.ZeroPx,
						TrackBase.EdgeDesignProperty, TrackEdgeDesign.Square,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.InPixels(60),
						Element.HeightProperty, Length.InPixels(700)
					),
					CreateStyle(typeof(ScrollBar),
						ScrollBar.VaryButtonDesignProperty, VaryDesign.Chevron,
						ScrollBar.BackgroundProperty, SolidColorBrushes.Silver.Brush,
						ScrollBar.BorderBrushProperty, null,
						ScrollBar.VaryButtonBackgroundProperty, null,
						ScrollBar.VaryButtonFillProperty, SolidColorBrushes.Black.Brush,
						ScrollBar.BorderThicknessProperty, Length.ZeroPx,
						ScrollBar.VaryButtonLengthProperty, Length.InPixels(20),
						TrackBase.TrackShadowBlurProperty, Length.ZeroPx,
						TrackBase.TrackShadowColorProperty, null,
						TrackBase.TrackShadowSpreadProperty, Length.ZeroPx,
						TrackBase.OrientationProperty, Orientation.Vertical,
						TrackBase.TrackBackgroundProperty, null,
						TrackBase.TrackBorderBrushProperty, null,
						TrackBase.TrackBorderThicknessProperty, Length.ZeroPx,
						TrackBase.ThumbBackgroundProperty, SolidColorBrushes.Gray.Brush,
						TrackBase.ThumbBorderBrushProperty, null,
						TrackBase.ThumbBorderThicknessProperty, Length.ZeroPx,
						TrackBase.EdgeDesignProperty, TrackEdgeDesign.Square,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.InPixels(20),
						Element.HeightProperty, Length.InPixels(400)
					),
					CreateStyle(typeof(ScrollBar),
						ScrollBar.VaryButtonDesignProperty, VaryDesign.None,
						ScrollBar.BackgroundProperty, SolidColorBrushes.White.Brush,
						ScrollBar.BorderBrushProperty, SolidColorBrushes.Silver.Brush,
						ScrollBar.VaryButtonBackgroundProperty, null,
						ScrollBar.VaryButtonFillProperty, SolidColorBrushes.Black.Brush,
						ScrollBar.BorderThicknessProperty, Length.InPixels(2),
						ScrollBar.VaryButtonLengthProperty, Length.ZeroPx,
						TrackBase.TrackShadowBlurProperty, Length.ZeroPx,
						TrackBase.TrackShadowColorProperty, null,
						TrackBase.TrackShadowSpreadProperty, Length.ZeroPx,
						TrackBase.OrientationProperty, Orientation.Vertical,
						TrackBase.TrackBackgroundProperty, null,
						TrackBase.TrackBorderBrushProperty, null,
						TrackBase.TrackBorderThicknessProperty, Length.InPixels(1),
						TrackBase.ThumbBackgroundProperty, SolidColorBrushes.Red.Brush,
						TrackBase.ThumbBorderBrushProperty, null,
						TrackBase.ThumbBorderThicknessProperty, Length.ZeroPx,
						TrackBase.EdgeDesignProperty, TrackEdgeDesign.Round,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.InPixels(20),
						Element.HeightProperty, Length.InPixels(500)
					),
					CreateStyle(typeof(ScrollBar),
						ScrollBar.VaryButtonDesignProperty, VaryDesign.Arrow,
						ScrollBar.BackgroundProperty, null,
						ScrollBar.BorderBrushProperty, null,
						ScrollBar.VaryButtonBackgroundProperty, null,
						ScrollBar.VaryButtonFillProperty, SolidColorBrushes.LimeGreen.Brush,
						ScrollBar.BorderThicknessProperty, Length.ZeroPx,
						ScrollBar.VaryButtonLengthProperty, Length.InPixels(22),
						TrackBase.TrackShadowBlurProperty, Length.InPixels(14),
						TrackBase.TrackShadowColorProperty, SolidColorBrushes.Gray.Brush,
						TrackBase.TrackShadowSpreadProperty, Length.InPixels(3),
						TrackBase.OrientationProperty, Orientation.Vertical,
						TrackBase.TrackBackgroundProperty, SolidColorBrushes.White.Brush,
						TrackBase.TrackBorderBrushProperty, null,
						TrackBase.TrackBorderThicknessProperty, Length.InPixels(1),
						TrackBase.ThumbBackgroundProperty, LinearGradientBrushes.Sapphire.Brush,
						TrackBase.ThumbBorderBrushProperty, null,
						TrackBase.ThumbBorderThicknessProperty, Length.InPixels(1),
						TrackBase.EdgeDesignProperty, TrackEdgeDesign.Round,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.InPixels(20),
						Element.HeightProperty, Length.InPixels(500)
					),
					CreateStyle(typeof(ScrollBar),
						ScrollBar.VaryButtonDesignProperty, VaryDesign.Triangle,
						ScrollBar.BackgroundProperty, SolidColorBrushes.Salmon.Brush,
						ScrollBar.BorderBrushProperty, SolidColorBrushes.Silver.Brush,
						ScrollBar.VaryButtonBackgroundProperty, SolidColorBrushes.AliceBlue.Brush,
						ScrollBar.VaryButtonFillProperty, SolidColorBrushes.LimeGreen.Brush,
						ScrollBar.BorderThicknessProperty, Length.InPixels(13),
						ScrollBar.VaryButtonLengthProperty, Length.InPixels(83),
						TrackBase.TrackShadowBlurProperty, Length.InPixels(26),
						TrackBase.TrackShadowColorProperty, SolidColorBrushes.MidnightBlue.Brush,
						TrackBase.TrackShadowSpreadProperty, Length.InPixels(5),
						TrackBase.OrientationProperty, Orientation.Vertical,
						TrackBase.TrackBackgroundProperty, SolidColorBrushes.LimeGreen.Brush,
						TrackBase.TrackBorderBrushProperty, SolidColorBrushes.DarkMagenta.Brush,
						TrackBase.TrackBorderThicknessProperty, Length.InPixels(12),
						TrackBase.ThumbBackgroundProperty, ImageBrushes.ScoobyDoo.Brush,
						TrackBase.ThumbBorderBrushProperty, SolidColorBrushes.NavajoWhite.Brush,
						TrackBase.ThumbBorderThicknessProperty, Length.InPixels(6),
						TrackBase.EdgeDesignProperty, TrackEdgeDesign.Round,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.InPixels(200),
						Element.HeightProperty, Length.InPixels(600)
					),
				}),

			new Example(typeof(Example_Slider.View), true,
				"Represents a control that lets the user select from a range of values by moving a thumb along a track.",
				"Presently the slider has a decent number of features but is far from what we envision. Properties are going to be added to enable virtually any look you can imagine, " +
				"including notches and tick marks and positional labels, to name a couple.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Slider),
						Slider.TrackBreadthProperty, Length.InPixels(2),
						Slider.ThumbButtonBreadthProperty, Length.InPixels(16),
						Slider.ThumbButtonLengthProperty, Length.InPixels(16),
						Slider.OrientationProperty, Orientation.Vertical,
						Slider.TrackBackgroundProperty, SolidColorBrushes.White.Brush,
						Slider.TrackBorderBrushProperty, null,
						Slider.TrackBorderThicknessProperty, Length.ZeroPx,
						Slider.ThumbBackgroundProperty, SolidColorBrushes.CornFlowerBlue.Brush,
						Slider.ThumbBorderBrushProperty, null,
						Slider.ThumbBorderThicknessProperty, Length.ZeroPx,
						Slider.EdgeDesignProperty, TrackEdgeDesign.Square,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.InPixels(400)
					),
					CreateStyle(typeof(Slider),
						Slider.TrackBreadthProperty, Length.InPixels(8),
						Slider.ThumbButtonBreadthProperty, Length.InPixels(27),
						Slider.ThumbButtonLengthProperty, Length.InPixels(16),
						Slider.OrientationProperty, Orientation.Horizontal,
						Slider.TrackBackgroundProperty, null,
						Slider.TrackBorderBrushProperty, SolidColorBrushes.Yellow.Brush,
						Slider.TrackBorderThicknessProperty, Length.InPixels(1),
						Slider.ThumbBackgroundProperty, SolidColorBrushes.Yellow.Brush,
						Slider.ThumbBorderBrushProperty, SolidColorBrushes.Black.Brush,
						Slider.ThumbBorderThicknessProperty, Length.InPixels(1.5),
						Slider.EdgeDesignProperty, TrackEdgeDesign.HalfRound,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.InPixels(500),
						Element.HeightProperty, Length.InPixels(40)
					),
					CreateStyle(typeof(Slider),
						Slider.TrackBreadthProperty, Length.InPixels(12),
						Slider.ThumbButtonBreadthProperty, Length.InPixels(28),
						Slider.ThumbButtonLengthProperty, Length.InPixels(28),
						Slider.OrientationProperty, Orientation.Vertical,
						Slider.TrackBackgroundProperty, RadialGradientBrushes.Sapphire.Brush,
						Slider.TrackBorderBrushProperty, SolidColorBrushes.DodgerBlue.Brush,
						Slider.TrackBorderThicknessProperty, Length.InPixels(1),
						Slider.ThumbBackgroundProperty, LinearGradientBrushes.Chrome.Brush,
						Slider.ThumbBorderBrushProperty, SolidColorBrushes.LightGray.Brush,
						Slider.ThumbBorderThicknessProperty, Length.InPixels(2),
						Slider.EdgeDesignProperty, TrackEdgeDesign.Round,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.InPixels(500)
					),
					CreateStyle(typeof(Slider),
						Slider.TrackBreadthProperty, Length.InPixels(10),
						Slider.ThumbButtonBreadthProperty, Length.InPixels(30),
						Slider.ThumbButtonLengthProperty, Length.InPixels(30),
						Slider.OrientationProperty, Orientation.Horizontal,
						Slider.TrackBackgroundProperty, SolidColorBrushes.LightGray.Brush,
						Slider.TrackBorderBrushProperty, null,
						Slider.TrackBorderThicknessProperty, Length.InPixels(1),
						Slider.ThumbBackgroundProperty, SolidColorBrushes.Teal.Brush,
						Slider.ThumbBorderBrushProperty, null,
						Slider.ThumbBorderThicknessProperty, Length.ZeroPx,
						Slider.EdgeDesignProperty, TrackEdgeDesign.Round,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.InPixels(600),
						Element.HeightProperty, Length.InPixels(40)
					),
					CreateStyle(typeof(Slider),
						Slider.TrackBreadthProperty, Length.InPixels(9),
						Slider.ThumbButtonBreadthProperty, Length.InPixels(22),
						Slider.ThumbButtonLengthProperty, Length.InPixels(46),
						Slider.OrientationProperty, Orientation.Vertical,
						Slider.TrackBackgroundProperty, RadialGradientBrushes.Rainbow.Brush,
						Slider.TrackBorderBrushProperty, SolidColorBrushes.LightSteelBlue.Brush,
						Slider.TrackBorderThicknessProperty, Length.InPixels(1),
						Slider.ThumbBackgroundProperty, SolidColorBrushes.Lime.Brush,
						Slider.ThumbBorderBrushProperty, SolidColorBrushes.LawnGreen.Brush,
						Slider.ThumbBorderThicknessProperty, Length.InPixels(2),
						Slider.EdgeDesignProperty, TrackEdgeDesign.QuarterRound,
						RangeBase.ValueProperty, 1m,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.InPixels(350)
					),
				}),

			new Example(typeof(Example_Flex.View), true,
				"Defines an element whose layout is responsive and whose children are positioned accordingly without need for individual positioning.",
				"The Flex element is an excellent example of Frogui leveraging the power of HTML, in this case the HTML Flexbox element. The Flex element makes building responsive views simple.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.NoWrap,
						Flex.DirectionProperty, FlexDirection.Column,
						Panel.BackgroundProperty, null,
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.NoWrap,
						Flex.DirectionProperty, FlexDirection.ColumnReverse,
						Panel.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.NoWrap,
						Flex.DirectionProperty, FlexDirection.Row,
						Panel.BackgroundProperty, null,
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.NoWrap,
						Flex.DirectionProperty, FlexDirection.RowReverse,
						Panel.BackgroundProperty, null,
						Element.OpacityProperty, 0.5d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.Wrap,
						Flex.DirectionProperty, FlexDirection.Column,
						Panel.BackgroundProperty, ImageBrushes.Flintstones.Brush,
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.Wrap,
						Flex.DirectionProperty, FlexDirection.ColumnReverse,
						Panel.BackgroundProperty, null,
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.Wrap,
						Flex.DirectionProperty, FlexDirection.Row,
						Panel.BackgroundProperty, null,
						Element.OpacityProperty, 0.3d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.Wrap,
						Flex.DirectionProperty, FlexDirection.RowReverse,
						Panel.BackgroundProperty, RadialGradientBrushes.RicePaperFade.Brush,
						Element.OpacityProperty, 0.7d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.WrapReverse,
						Flex.DirectionProperty, FlexDirection.Column,
						Panel.BackgroundProperty, null,
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.WrapReverse,
						Flex.DirectionProperty, FlexDirection.ColumnReverse,
						Panel.BackgroundProperty, LinearGradientBrushes.GrayFade.Brush,
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.WrapReverse,
						Flex.DirectionProperty, FlexDirection.Row,
						Panel.BackgroundProperty, null,
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Flex),
						Flex.WrappingProperty, FlexWrapping.WrapReverse,
						Flex.DirectionProperty, FlexDirection.RowReverse,
						Panel.BackgroundProperty, null,
						Element.OpacityProperty, 1d
					)
				}),

			new Example(typeof(Example_Grid.View), true,
				"Defines a flexible grid area that consists of columns and rows used to position children.",
				"The Grid element shares the same name of its WPF/UWP counterpart but takes grid features to a much more advanced place " +
				"by levering all the power of the awesome HTML grid element. Connecting child elements to a parent grid is made simple using anchors.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Grid),
						Grid.ColumnCountProperty, 2,
						Grid.RowCountProperty, 2,
						Grid.ColumnGapProperty, Length.ZeroPx,
						Grid.RowGapProperty, Length.ZeroPx,
						Panel.BackgroundProperty, null,
						Element.WidthProperty, Length.InPixels(200),
						Element.HeightProperty, Length.InPixels(200),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Grid),
						Grid.ColumnCountProperty, 4,
						Grid.RowCountProperty, 4,
						Grid.ColumnGapProperty, Length.ZeroPx,
						Grid.RowGapProperty, Length.ZeroPx,
						Panel.BackgroundProperty, RadialGradientBrushes.Rainbow.Brush,
						Element.WidthProperty, Length.InPixels(800),
						Element.HeightProperty, Length.InPixels(800),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Grid),
						Grid.ColumnCountProperty, 5,
						Grid.RowCountProperty, 5,
						Grid.ColumnGapProperty, Length.InPixels(8),
						Grid.RowGapProperty, Length.InPixels(8),
						Panel.BackgroundProperty, null,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.InPixels(600),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Grid),
						Grid.ColumnCountProperty, 5,
						Grid.RowCountProperty, 5,
						Grid.ColumnGapProperty, Length.InPixels(20),
						Grid.RowGapProperty, Length.InPixels(20),
						Panel.BackgroundProperty, SolidColorBrushes.DarkViolet.Brush,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.InPixels(600),
						Element.OpacityProperty, 0.5d
					),
					CreateStyle(typeof(Grid),
						Grid.ColumnCountProperty, 8,
						Grid.RowCountProperty, 8,
						Grid.ColumnGapProperty, Length.InPixels(20),
						Grid.RowGapProperty, Length.InPixels(4),
						Panel.BackgroundProperty, null,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.InPixels(500),
						Element.OpacityProperty, 1d
					)
				}),

			new Example(typeof(Example_Paper.View), true,
				"Defines an area within which child elements may be explicitly positioned using coordinates relative to the paper area.",
				"Sometimes a panel is needed that allows precise child element placement. This classic layout technique still serves an important purpose, " +
				"and is exactly what the Paper element is designed for. The Paper element is loosely analogous to the WPF/UWP Canvas control.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Paper),
						Panel.BackgroundProperty, null,
						Element.WidthProperty, new Length(70, Unit.Vw),
						Element.HeightProperty, new Length(70, Unit.Vh),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Paper),
						Panel.BackgroundProperty, SolidColorBrushes.MidnightBlue.Brush,
						Element.WidthProperty, new Length(80, Unit.Vw),
						Element.HeightProperty, new Length(80, Unit.Vh),
						Element.OpacityProperty, 0.8d
					),
					CreateStyle(typeof(Paper),
						Panel.BackgroundProperty, SolidColorBrushes.DeepPink.Brush,
						Element.WidthProperty, new Length(50, Unit.Vw),
						Element.HeightProperty, new Length(50, Unit.Vh),
						Element.OpacityProperty, 0.3d
					),
					CreateStyle(typeof(Paper),
						Panel.BackgroundProperty, SolidColorBrushes.DarkSlateBlue.Brush,
						Element.WidthProperty, new Length(70, Unit.Vw),
						Element.HeightProperty, new Length(70, Unit.Vh),
						Element.OpacityProperty, 1d
					),
				}),

			new Example(typeof(Example_ScrollViewer.View), true,
				"Represents a control with a scrollable area that can contain a child element.",
				"If you have never used a control whose only purpose is to allow its child element to be scrolled you are in for a treat with our ScrollViewer. This " +
				"example presently only allows a TextBlock to be scrolled but you may literally use any element as the child of a ScrollViewer.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(ScrollViewer),
						Control.ForegroundProperty, SolidColorBrushes.White.Brush,
						ScrollViewer.BackgroundProperty, null,
						ScrollViewer.BorderBrushProperty, null,
						ScrollViewer.BorderThicknessProperty, Length.Auto,
						ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.InPixels(600)
					),
					CreateStyle(typeof(ScrollViewer),
						Control.ForegroundProperty, SolidColorBrushes.Black.Brush,
						ScrollViewer.BackgroundProperty, SolidColorBrushes.White.Brush,
						ScrollViewer.BorderBrushProperty, SolidColorBrushes.Gray.Brush,
						ScrollViewer.BorderThicknessProperty, Length.InPixels(2),
						ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.InPixels(600)
					),
					CreateStyle(typeof(ScrollViewer),
						Control.ForegroundProperty, SolidColorBrushes.LimeGreen.Brush,
						ScrollViewer.BackgroundProperty, LinearGradientBrushes.Sapphire.Brush,
						ScrollViewer.BorderBrushProperty, SolidColorBrushes.Blue.Brush,
						ScrollViewer.BorderThicknessProperty, Length.InPixels(5),
						ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden,
						ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						Element.WidthProperty, Length.InPixels(350),
						Element.HeightProperty, Length.InPixels(500)
					),
					CreateStyle(typeof(ScrollViewer),
						Control.ForegroundProperty, SolidColorBrushes.White.Brush,
						ScrollViewer.BackgroundProperty, null,
						ScrollViewer.BorderBrushProperty, SolidColorBrushes.LightGoldenRodYellow.Brush,
						ScrollViewer.BorderThicknessProperty, Length.InPixels(20),
						ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled,
						ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled,
						Element.WidthProperty, Length.InPixels(800),
						Element.HeightProperty, Length.InPixels(700)
					),
					CreateStyle(typeof(ScrollViewer),
						Control.ForegroundProperty, SolidColorBrushes.LightPink.Brush,
						ScrollViewer.BackgroundProperty, null,
						ScrollViewer.BorderBrushProperty, SolidColorBrushes.White.Brush,
						ScrollViewer.BorderThicknessProperty, Length.InPixels(1),
						ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden,
						ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Visible,
						Element.WidthProperty, Length.InPixels(400),
						Element.HeightProperty, Length.InPixels(400)
					),
				}),

			new Example(typeof(Example_Popup.View), true,
				"Represents a pop-up window that has content.",
				"A pop-up element is very unique in that it floats in front of other elements. Interestingly, though browsers " +
				"have strong pop-up power, they can be a challenge to work with. The Frogui Popup is easy to use and exposes properties to allow for really cool transition animation. " +
				"At the moment the number of animation types is limited but before long there will be all sorts of beautiful ways to show and hide your pop-up.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.InPlace,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Absolute,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.SlideRelative,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Bottom,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.InPlace,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Center,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 0.5d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.SlideRelative,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Left,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.SlideRelative,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Right,
						Element.WidthProperty, Length.InPixels(500),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 0.7d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.SlideRelative,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Top,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.InPlace,
						Popup.ClipModeProperty, PopupClipMode.Clip,
						Popup.PlacementModeProperty, PopupPlacementMode.Absolute,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.SlideRelative,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Bottom,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 0.3d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.InPlace,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Center,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.SlideUp,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Left,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.SlideRelative,
						Popup.ClipModeProperty, PopupClipMode.None,
						Popup.PlacementModeProperty, PopupPlacementMode.Right,
						Element.WidthProperty, Length.InPixels(500),
						Element.HeightProperty, Length.InPixels(300),
						Element.OpacityProperty, 0.7d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.SlideRight,
						Popup.ClipModeProperty, PopupClipMode.MaximumSpaceClip,
						Popup.PlacementModeProperty, PopupPlacementMode.Top,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(800),
						Element.OpacityProperty, 1d
					),
					CreateStyle(typeof(Popup),
						Popup.TransitionModeProperty, PopupTransitionMode.SlideLeft,
						Popup.ClipModeProperty, PopupClipMode.MaximumSpaceClip,
						Popup.PlacementModeProperty, PopupPlacementMode.Bottom,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.InPixels(900),
						Element.OpacityProperty, 0.3d
					)
				}),

			// TODO:Got to emphasize how our ItemsControl can show SVG! No body else can, not even web 2.0!!!
			new Example(typeof(Example_ItemsControl.View), true,
				"Represents a control that can be used to present a collection of items.",
				"In WPF/UWP, doing fascinating visual things with a collection of items is easy using ItemsControl and other derived classes. In such controls, the model-view pattern is utilized and the underlying " +
				"model collections may be filtered, sorted, grouped and virtualized for high-performance. Furthermore, the item views are completely customizable. " +
				"There is no comparison between the ease and power offered in such frameworks relative to web client frameworks. Frogui is modelled on WPF/UWP. " +
				"In this release many -- but not all -- of these features are available.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(ItemsControl),
						ItemsControl.BackgroundProperty, null,
						ItemsControl.BorderBrushProperty, null,
						ItemsControl.BorderThicknessProperty, Length.ZeroPx,
						ItemsControl.ItemsSourceProperty, Common.LoremIpsumWords,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto
					),
					CreateStyle(typeof(ItemsControl),
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Common.LoremIpsumWords,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto
					),
					CreateStyle(typeof(ItemsControl),
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, People.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto
					),
					CreateStyle(typeof(ItemsControl),
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Common.Cartoons,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto
					),
					CreateStyle(typeof(ItemsControl),
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, SolidColorBrushes.Singleton.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto
					),
					CreateStyle(typeof(ItemsControl),
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkOrchid.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, LinearGradientBrushes.Singleton.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto
					),
					CreateStyle(typeof(ItemsControl),
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, RadialGradientBrushes.Singleton.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto
					),
					CreateStyle(typeof(ItemsControl),
						ItemsControl.BackgroundProperty, SolidColorBrushes.Black.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Bitmaps.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto
					),
				}),

			new Example(typeof(Example_ListBox.View), true,
				"Represents a control that contains a list of selectable items.",
				"ListBox builds on ItemsControl, adding selectability. ListBox also builds on the ListBase class, which allows precise control over item layout.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, null,
						ItemsControl.BorderBrushProperty, null,
						ItemsControl.BorderThicknessProperty, Length.ZeroPx,
						ItemsControl.ItemsSourceProperty, Common.LoremIpsumWords,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, new Length(70, Unit.Vh)
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Common.LoremIpsumWords,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, new Length(70, Unit.Vh),
						Selector.SelectedIndexProperty, 0
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.Wrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Row,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkOrange.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Common.LoremIpsumWords,
						Element.WidthProperty, new Length(60, Unit.Vw),
						Element.HeightProperty, Length.Auto
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, People.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, new Length(70, Unit.Vh),
						Selector.SelectedIndexProperty, 0
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.Wrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Row,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, People.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, Length.Auto
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Common.Cartoons,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, new Length(70, Unit.Vh),
						Selector.SelectedIndexProperty, 0
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, SolidColorBrushes.Singleton.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, new Length(70, Unit.Vh)
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled,
						ListBase.ItemsWrappingProperty, FlexWrapping.Wrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, SolidColorBrushes.Singleton.All,
						Element.WidthProperty, new Length(70, Unit.Vh),
						Element.HeightProperty, new Length(70, Unit.Vh),
						Selector.SelectedIndexProperty, 0
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.Wrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Row,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, SolidColorBrushes.Singleton.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, new Length(70, Unit.Vh)
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkOrchid.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, LinearGradientBrushes.Singleton.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, new Length(70, Unit.Vh),
						Selector.SelectedIndexProperty, 0
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, RadialGradientBrushes.Singleton.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, new Length(70, Unit.Vh)
					),
					CreateStyle(typeof(ListBox),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.Black.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightCoral.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Bitmaps.All,
						Element.WidthProperty, Length.Auto,
						Element.HeightProperty, new Length(70, Unit.Vh),
						Selector.SelectedIndexProperty, 0
					),
				}),

			// TODO:Our ComboBox
			new Example(typeof(Example_Droplist.View), true,
				"Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.",
				"ComboBox builds on ItemsControl, offering lots of model-view power and great looks. A wide variety of properties are exposed so you can tune the look of your combobox to suit " +
				"your tastes without needing to create a custom control.",
				PROP.NoCascade,
				new Style[]
				{
					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, null,
						Droplist.ToggleButtonBorderThicknessProperty, Length.ZeroPx,
						Droplist.ToggleButtonDesignProperty, VaryDesign.Triangle,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.White.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(25),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.Black.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LimeGreen.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Common.LoremIpsumWords,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),
					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, SolidColorBrushes.White.Brush,
						Droplist.ToggleButtonBorderThicknessProperty, Length.ZeroPx,
						Droplist.ToggleButtonDesignProperty, VaryDesign.Triangle,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.Blue.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(25),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.Black.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LimeGreen.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Common.LoremIpsumWords,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),
					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, null,
						Droplist.ToggleButtonBorderThicknessProperty, Length.InPixels(1),
						Droplist.ToggleButtonDesignProperty, VaryDesign.Chevron,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.LightGray.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(40),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.Black.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightGray.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, Common.LoremIpsumWords,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),
					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, SolidColorBrushes.Black.Brush,
						Droplist.ToggleButtonBorderThicknessProperty, Length.InPixels(3),
						Droplist.ToggleButtonDesignProperty, VaryDesign.Arrow,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.Blue.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(25),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkMagenta.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightGray.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(3),
						ItemsControl.ItemsSourceProperty, Common.LoremIpsumWords,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),

					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, SolidColorBrushes.Black.Brush,
						Droplist.ToggleButtonBorderThicknessProperty, Length.InPixels(1),
						Droplist.ToggleButtonDesignProperty, VaryDesign.Arrow,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.Blue.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(25),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkBlue.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightGray.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, People.All,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),

					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, SolidColorBrushes.Black.Brush,
						Droplist.ToggleButtonBorderThicknessProperty, Length.InPixels(3),
						Droplist.ToggleButtonDesignProperty, VaryDesign.Triangle,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.Orange.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(25),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.Black.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightGray.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(3),
						ItemsControl.ItemsSourceProperty, Common.Cartoons,
						Element.WidthProperty, Length.InPixels(350),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),

					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, SolidColorBrushes.Black.Brush,
						Droplist.ToggleButtonBorderThicknessProperty, Length.InPixels(3),
						Droplist.ToggleButtonDesignProperty, VaryDesign.Triangle,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.LightSeaGreen.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(25),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.Black.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightGray.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(3),
						ItemsControl.ItemsSourceProperty, SolidColorBrushes.Singleton.All,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),

					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, SolidColorBrushes.Black.Brush,
						Droplist.ToggleButtonBorderThicknessProperty, Length.InPixels(1),
						Droplist.ToggleButtonDesignProperty, VaryDesign.Triangle,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.Yellow.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(25),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.Black.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.White.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, LinearGradientBrushes.Singleton.All,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),

					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, SolidColorBrushes.DarkSlateGray.Brush,
						Droplist.ToggleButtonBorderThicknessProperty, Length.InPixels(1),
						Droplist.ToggleButtonDesignProperty, VaryDesign.Triangle,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.DeepPink.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(35),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.DarkSlateGray.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LimeGreen.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(1),
						ItemsControl.ItemsSourceProperty, RadialGradientBrushes.Singleton.All,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),

					CreateStyle(typeof(Droplist),
						Droplist.ToggleButtonBackgroundProperty, SolidColorBrushes.Black.Brush,
						Droplist.ToggleButtonBorderThicknessProperty, Length.InPixels(3),
						Droplist.ToggleButtonDesignProperty, VaryDesign.LineArrow,
						Droplist.ToggleButtonFillProperty, SolidColorBrushes.White.Brush,
						Droplist.ToggleButtonLengthProperty, Length.InPixels(25),
						ListBase.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto,
						ListBase.ItemsWrappingProperty, FlexWrapping.NoWrap,
						ListBase.ItemsDirectionProperty, FlexDirection.Column,
						ItemsControl.BackgroundProperty, SolidColorBrushes.Black.Brush,
						ItemsControl.BorderBrushProperty, SolidColorBrushes.LightGray.Brush,
						ItemsControl.BorderThicknessProperty, Length.InPixels(3),
						ItemsControl.ItemsSourceProperty, Bitmaps.All,
						Element.WidthProperty, Length.InPixels(300),
						Element.HeightProperty, Length.Auto,
						Selector.SelectedIndexProperty, 0
					),
				}),

			new Example(typeof(Example_Alignment_Properties.View), false,
				"Demonstrates the Element.HorizontalAlignment and Element.VerticalAlignment properties.",
				"Alignment is challenging in HTML and CSS. In Frogui all you need to know is these two properties. Alignment may also be combined with other properties to precisely place elements.",
				PROP.None
				),
			
			new Example(typeof(Example_Binding_A.View), false,
				"Demonstrates basic Frogui data-binding.",
				"Data-binding is the process that establishes a connection between the application UI and business logic. If you have ever done data-binding with web technology you know " +
				"it can be very challenging. Fortunately, advanced data-binding is available in Frogui and is easy to use thanks to the advantages of C# over JavaScript.",
				PROP.None),

			new Example(typeof(Example_Observable_A.View), false,
				"Demonstrates the fascinating power of the popular Reactive Extentions (rx) framework.",
				"Rx is an API for asynchonous programming with observable streams, and has been integrated into Frogui as a first-class feature.",
				PROP.None),

			new Example(typeof(Example_Calculator.View), false,
				"A calculator applet.",
				"Have fun and enjoy the views! Just do not use for critical calculations as the demo is a work-in-progress. The Grid element is used here to layout the interface.",
				PROP.None
				),

			new Example(typeof(Example_Tip_Calculator.View), false,
				"A tip-calculator applet",
				"This example demonstrates the NumericEdit control and encourages the important practice of tipping!",
				PROP.None
				),

			new Example(typeof(Example_Animation_A.View), false,
				"Demonstrates the Element.Animation property.",
				"A bunch of circles with differing properties are created using the Ellipse element. Each circle has a distinct animation easing and duration. " +
				"Click anywhere on the screen to see a subset of circles move to the spot.",
				PROP.None
				)
		};
	}
}

/*
 *
 *
 * @"<script>
function update(sw) {
  var pic;
  if (sw === 0) {
    pic = 'red'
  }
  else if (sw === 1) {
    pic = 'orange'
  }
  else {
    pic = 'yellow'
  }
  document.getElementById('myDiv').style.backgroundColor = pic;
}
</script>

<div id='myDiv' style='background-color:blue;height:200px;padding:20px'>

<p style='color:white;font-size:large'>
JavaScript
<button type='button' onclick='update(0)'>Red</button>
<button type='button' onclick='update(1)'>Orange</button>
<button type='button' onclick='update(2)'>Yellow</button>
</p>

</div>"
*/

