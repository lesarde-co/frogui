using Lesarde.Frogui.Controls;
using Demo;
using Demo.Button_Class;

namespace Demo.Button_Class
{
	public partial class View : Lesarde.Frogui.Controls.Flex
	{
		public partial class AssetSheet : Lesarde.Frogui.AssetSheet
		{
			// Singleton property
			public static AssetSheet Singleton { get; } = new AssetSheet();

			// Styles
			public Lesarde.Frogui.Style FunButton { get; }
			public Lesarde.Frogui.Style FunText { get; }

			// Constructor
			public AssetSheet()
			{
				// FunButton style
				AddStyle(nameof(FunButton), FunButton = new Lesarde.Frogui.Style(typeof(Lesarde.Frogui.Controls.Button), false));
				FunButton.Setters
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.MarginProperty, new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(5,Lesarde.Frogui.Unit.Px))))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.BorderThicknessProperty, new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(3,Lesarde.Frogui.Unit.Px))))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.BackgroundProperty, new Lesarde.Frogui.Media.SolidColorBrush(Lesarde.Frogui.Media.Colors.Red)))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.BorderBrushProperty, new Lesarde.Frogui.Media.SolidColorBrush(Lesarde.Frogui.Media.Colors.White)))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.CornerRadiusProperty, new Lesarde.Frogui.CornerRadius(new Lesarde.Frogui.Length(3,Lesarde.Frogui.Unit.Px))))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.PaddingProperty, new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(4,Lesarde.Frogui.Unit.Px))))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.VerticalAlignmentProperty, Lesarde.Frogui.VerticalAlignment.Top));

				// Common.PointerEntered visual state
				FunButton.VisualStateSetters.Add(Lesarde.Frogui.Controls.Button.Common_PointerEntered_VisualState, new Lesarde.Frogui.SetterBaseCollection()
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.BackgroundProperty, new Lesarde.Frogui.Media.SolidColorBrush(Lesarde.Frogui.Media.Color.FromRgb(0xFF, 0x40, 0x40)))));

				// Common.Pressed visual state
				FunButton.VisualStateSetters.Add(Lesarde.Frogui.Controls.Button.Common_Pressed_VisualState, new Lesarde.Frogui.SetterBaseCollection()
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.BackgroundProperty, new Lesarde.Frogui.Media.SolidColorBrush(Lesarde.Frogui.Media.Colors.DarkRed)))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.Button.BorderBrushProperty, new Lesarde.Frogui.Media.SolidColorBrush(Lesarde.Frogui.Media.Colors.LightGray))));


				// FunText style
				AddStyle(nameof(FunText), FunText = new Lesarde.Frogui.Style(typeof(Lesarde.Frogui.Controls.TextBlock), false));
				FunText.Setters
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.TextBlock.MarginProperty, new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(16,Lesarde.Frogui.Unit.Px))))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.TextBlock.SelectableProperty, false))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.TextBlock.ForegroundProperty, new Lesarde.Frogui.Media.SolidColorBrush(Lesarde.Frogui.Media.Colors.White)))
					.Add(new Lesarde.Frogui.Setter(Lesarde.Frogui.Controls.TextBlock.FontSizeProperty, Lesarde.Frogui.Media.FontSize.FromKind(Lesarde.Frogui.Media.FontSizeKind.Medium)));
			}
		}
		// Element properties

		// InitializeComponent()
		public void InitializeComponent()
		{
			// Assign the assets singleton to the Assets property.
			this.Assets = AssetSheet.Singleton;

			// Initialize this element's properties
			this.Margin = new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(16,Lesarde.Frogui.Unit.Px));

			// __anon1 element
			var __anon1 = new Lesarde.Frogui.Controls.Button()
			{
				VerticalAlignment = Lesarde.Frogui.VerticalAlignment.Top,
				Margin = new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(5,Lesarde.Frogui.Unit.Px))
			};
			this.Children.Add(__anon1);

			// __anon2 element
			var __anon2 = new Lesarde.Frogui.Controls.TextBlock()
			{
				Text = "Default Style",
				Margin = new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(5,Lesarde.Frogui.Unit.Px)),
				Selectable = false
			};
			__anon1.Child = __anon2;

			// __anon3 element
			var __anon3 = new Lesarde.Frogui.Controls.Button()
			{
				Margin = new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(5,Lesarde.Frogui.Unit.Px)),
				CornerRadius = new Lesarde.Frogui.CornerRadius(new Lesarde.Frogui.Length(45,Lesarde.Frogui.Unit.Px)),
				Padding = new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(8,Lesarde.Frogui.Unit.Px)),
				Background = new Lesarde.Frogui.Media.SolidColorBrush(Lesarde.Frogui.Media.Colors.Blue),
				VerticalAlignment = Lesarde.Frogui.VerticalAlignment.Top,
				Width = new Lesarde.Frogui.Length(90,Lesarde.Frogui.Unit.Px),
				Height = new Lesarde.Frogui.Length(90,Lesarde.Frogui.Unit.Px),
				BorderThickness = new Lesarde.Frogui.Thickness(new Lesarde.Frogui.Length(0,Lesarde.Frogui.Unit.Px))
			};
			this.Children.Add(__anon3);

			// __anon4 element
			var __anon4 = new Lesarde.Frogui.Controls.Image()
			{
				Source = Demo.Common.GmailIcon,
				HorizontalAlignment = Lesarde.Frogui.HorizontalAlignment.Center,
				VerticalAlignment = Lesarde.Frogui.VerticalAlignment.Center,
				Width = new Lesarde.Frogui.Length(64,Lesarde.Frogui.Unit.Px),
				Height = new Lesarde.Frogui.Length(64,Lesarde.Frogui.Unit.Px)
			};
			__anon3.Child = __anon4;

			// __anon5 element
			var __anon5 = new Lesarde.Frogui.Controls.Button()
			{
				Style = AssetSheet.Singleton.FunButton
			};
			this.Children.Add(__anon5);

			// __anon6 element
			var __anon6 = new Lesarde.Frogui.Controls.TextBlock()
			{
				Text = "Fun #1",
				Style = AssetSheet.Singleton.FunText
			};
			__anon5.Child = __anon6;

			// __anon7 element
			var __anon7 = new Lesarde.Frogui.Controls.Button()
			{
				Style = AssetSheet.Singleton.FunButton
			};
			this.Children.Add(__anon7);

			// __anon8 element
			var __anon8 = new Lesarde.Frogui.Controls.TextBlock()
			{
				Text = "Fun #2",
				Style = AssetSheet.Singleton.FunText
			};
			__anon7.Child = __anon8;

			// __anon9 element
			var __anon9 = new Lesarde.Frogui.Controls.Button()
			{
				Style = AssetSheet.Singleton.FunButton
			};
			this.Children.Add(__anon9);

			// __anon10 element
			var __anon10 = new Lesarde.Frogui.Controls.TextBlock()
			{
				Text = "Fun #3",
				Style = AssetSheet.Singleton.FunText
			};
			__anon9.Child = __anon10;
		}
	}
}
