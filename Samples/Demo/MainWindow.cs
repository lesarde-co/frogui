using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;

namespace Demo
{
	/***************************************************************************************************
		MainWindow class (code-behind)
	***************************************************************************************************/
	/// <summary>
	/// This application's main window class.
	/// <para></para>
	/// Because this is a designed class, the class is partial, and is
	/// divided into two source files: MainWindow.design.cs, which is the design source
	/// and MainWindow.cs, which is the code-behind source.
	/// </summary>
	public partial class MainWindow : Window
    {
		/***********************************************************
			DemoId enum
		***********************************************************/
		/// <summary>
		/// Contains an item for each demonstration in this app.
		/// </summary>
		enum DemoId
		{
			None,
			LayoutAlignment,
			TextBlock,
			Image,
			Rectangle,
			Ellipse,
			Border,
			ScrollViewer,
			TextBox,
			Flex,
			Calculator,
			TipCalculator
		}

		/***********************************************************
			read-only values
		***********************************************************/

		/// <summary>
		/// Create a "normal" corner radius for buttons for reuse.
		/// </summary>
		readonly Length NormalButtonCornerRadius = new Length(5, Unit.Px);

		/***********************************************************
			Me property
		***********************************************************/

		public static MainWindow Me { get; private set; }

		/***********************************************************
			variables
		***********************************************************/

		/// <summary>
		/// Keeps track of the current demo id.
		/// </summary>
		DemoId currentDemoId;

		/// <summary>
		/// Keeps track of the current demo object.
		/// </summary>
		UIElement currentDemo;
		
		/*******************************************************************************
			$
		*******************************************************************************/
		/// <summary>
		/// Creates a <see cref="MainWindow"/> object.
		/// </summary>
		public MainWindow()
		{
			Me = this;

			InitializeComponent();

			// Set the background of this window
			Background = new LinearGradientBrush(
				new GradientStopCollection()
					.Add(new GradientStop(Color.FromRgb(0x00, 0x00, 0x20), new Length(20.0, Unit.Percent)))
					.Add(new GradientStop(Colors.RoyalBlue, new Length(100.0, Unit.Percent))));
			
			// Create the home button
			var e_homeButton = new Button()
			{
				Margin = new Thickness(new Length(5, Unit.Px)),
				BorderThickness = new Thickness(new Length(1.5, Unit.Px)),
				Background = new LinearGradientBrush(
				new GradientStopCollection()
					.Add(new GradientStop(Color.FromRgba(0x00, 0x00, 0x00, 0.33), new Length(0.0, Unit.Percent)))
					.Add(new GradientStop(Color.FromRgba(0xff, 0xff, 0xff, 0.33), new Length(46.0, Unit.Percent)))
					.Add(new GradientStop(Color.FromRgba(0xff, 0xff, 0xff, 0.33), new Length(64.0, Unit.Percent)))
					.Add(new GradientStop(Color.FromRgba(0x00, 0x00, 0x00, 0.33), new Length(100.0, Unit.Percent))),
					new LinearGradientAngle(LinearGradientAngleKind.ToBottom)
					),
				BorderBrush = Common.GetSolidColorBrush(Colors.DarkSlateBlue),
				CornerRadius = new CornerRadius(NormalButtonCornerRadius),
				Padding = new Thickness(new Length(4, Unit.Px), new Length(8, Unit.Px), new Length(4, Unit.Px), new Length(8, Unit.Px)),

				Child = new Image()
				{
					Source = Common.lesardeLogoImage,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center,
					Opacity = 0.8
				}
			};

			// Handle the home button click event.
			e_homeButton.Click += (sender, e) => ShowDemo(DemoId.None, null);

			// Add the home button to the button list
			e_buttons.Children.Add(e_homeButton);

#if WASM
			var BuildName = "wasm";
#else
			var BuildName = "os";
#endif
			e_buttons.Children.Add(new TextBlock()
			{
				Text = BuildName,
				HorizontalAlignment = HorizontalAlignment.Center,
				Foreground = Common.GetSolidColorBrush(Colors.DarkSlateBlue),
				FontSize = Common.FontSizeMix[0]
			});

			Title = $"Frogui Demo ({BuildName})";


			// Create the demo button background
			var buttonBackground = new LinearGradientBrush(
				new GradientStopCollection()
					.Add(new GradientStop(Color.FromRgb(0x3f, 0x92, 0xc6), new Length(0.0, Unit.Percent)))
					.Add(new GradientStop(Color.FromRgb(0x25, 0x74, 0xa3), new Length(56.0, Unit.Percent)))
					.Add(new GradientStop(Color.FromRgb(0x1d, 0x5f, 0x88), new Length(64.0, Unit.Percent)))
					.Add(new GradientStop(Color.FromRgb(0x1d, 0x5f, 0x88), new Length(100.0, Unit.Percent))),
					new LinearGradientAngle(LinearGradientAngleKind.ToBottom)
					);

			// Add all the demo buttons to the button list
			foreach (DemoId cur in Enum.GetValues(typeof(DemoId)))
				if (DemoId.None != cur)
					AddDemoButton(cur, buttonBackground);
		}

		/*******************************************************************************
			AddButton()
		*******************************************************************************/
		/// <summary>
		/// Adds a demo button. Note that the <see cref="FrameworkElement.Tag"/> property
		/// is used to keep track of the <paramref name="demoId"/>.
		/// </summary>
		/// <param name="demoId">The demonstration to associate with the button.</param>
		void AddDemoButton(DemoId demoId, Brush background)
		{
			// Create a demo button
			var button = new Button()
			{
				Margin = new Thickness(new Length(5, Unit.Px)),
				BorderThickness = new Thickness(new Length(1, Unit.Px)),
				Background = background,
				BorderBrush = Common.GetSolidColorBrush(Colors.SlateBlue),
				CornerRadius = new CornerRadius(new Length(0, Unit.Px), NormalButtonCornerRadius, NormalButtonCornerRadius, new Length(12, Unit.Px)),
				Padding = new Thickness(new Length(4, Unit.Px)),
				Tag = demoId,
				Child = new TextBlock() // Use a TextBlock as the button's child.
				{
					Text = demoId.ToString(),
					Foreground = Common.GetSolidColorBrush(Colors.White),
					HorizontalAlignment = HorizontalAlignment.Center,
					IsHitTestVisible = false,
				}
			};

			// Handle the Click event
			button.Click += DemoButton_Click;

			// Finally, add the button to the list of buttons
			e_buttons.Children.Add(button);
		}

		/*******************************************************************************
			DemoButton_Click()
		*******************************************************************************/
		/// <summary>
		/// Handles any demo button clicks.
		/// </summary>
		void DemoButton_Click(object sender, RoutedEventArgs e)
		{
			// Determine which demo was requested
			var id = (DemoId)((Button)sender).Tag;

			if (id == currentDemoId)
				return;

			// Run the requested demo
			switch (id)
			{
				case DemoId.LayoutAlignment:
					ShowDemo(id, new LayoutAlignment_Demo());
					break;
				case DemoId.TextBlock:
					ShowDemo(id, new TextBlock_Demo());
					break;
				case DemoId.Rectangle:
					ShowDemo(id, new Rectangle_Demo());
					break;
				case DemoId.Ellipse:
					ShowDemo(id, new Ellipse_Demo());
					break;
				case DemoId.Border:
					ShowDemo(id, new Border_Demo());
					break;
				case DemoId.Image:
					ShowDemo(id, new Image_Demo());
					break;
				case DemoId.ScrollViewer:
					ShowDemo(id, new ScrollViewer_Demo());
					break;
				case DemoId.TextBox:
					ShowDemo(id, new TextBox_Demo());
					break;
				case DemoId.Flex:
					ShowDemo(id, new Flex_Demo());
					break;
				case DemoId.Calculator:
					ShowDemo(id, new Calculator.Calculator_Demo());
					break;
				case DemoId.TipCalculator:
					ShowDemo(id, new TipCalculator.TipCalculator_Demo());
					break;
			}
		}

		/*******************************************************************************
			ShowDemo()
		*******************************************************************************/
		/// <summary>
		/// Shows the requested demo. If <paramref name="newDemo"/> is null then the
		/// app returns to the home state.
		/// </summary>
		/// <param name="newDemo"></param>
		void ShowDemo(DemoId demoId, UIElement newDemo)
		{
			if (null != currentDemo)
				e_scollViewer.Child = null;

			if (null != newDemo)
				e_scollViewer.Child = newDemo;

			currentDemoId = demoId;
			currentDemo = newDemo;
		}

	}
}
