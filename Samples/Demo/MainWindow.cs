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
	public class ExampleView : Pixy
	{
		public ExampleView()
		{
			HorizontalAlignment = HorizontalAlignment.Left;
			Foreground = SolidColorBrushes.White.Brush;
			Margin = Thickness.InPixels(3);
			Layout = PixyLayout.TextRightOfImage;
			Gap = Length.InPixels(16);
			SetBinding(TextProperty, new Lesarde.Frogui.Data.Binding(nameof(Example.DisplayName)));
			SetBinding(ImageSourceProperty, new Lesarde.Frogui.Data.Binding(nameof(Example.Icon)));
		}
	}

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
			Me property
		***********************************************************/

		public static MainWindow Me { get; private set; }

		/***********************************************************
			PropertyEditorManager property
		***********************************************************/

		PropertyEditorManager PropertyEditorManager { get; }

		/***********************************************************
			properties
		***********************************************************/

		/// <summary>
		/// Keeps track of the current example.
		/// </summary>
		//Example CurrentExample => null == CurrentDemo ? null : CurrentDemo.GetType();
		Example CurrentExample { get; set; }

		/// <summary>
		/// Keeps track of the current demo object.
		/// </summary>
		Element CurrentExampleElement { get; set; }

		IExampleView CurrentExampleView => (IExampleView)CurrentExampleElement;

		public BrushPicker e_brushPicker { get; set; }

		/***********************************************************
			Commands class
		***********************************************************/

		public static class Commands
		{
			//public static RoutedCommand<Type> RunDemo { get; } = new RoutedCommand<Type>();
			public static RoutedCommand<Example> RunDemo { get; } = new RoutedCommand<Example>();
		}

		/*******************************************************************************
			$
		*******************************************************************************/
		/// <summary>
		/// Creates a <see cref="MainWindow"/> object.
		/// </summary>
		public MainWindow()
		{
			Me = this;

			// Prepare the property editor manager
			PropertyEditorManager = new PropertyEditorManager();

			PropertyEditorManager.RegisterDefaultEditor(typeof(VaryDesign), typeof(EnumImageEditor<VaryDesign>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(bool), typeof(BooleanEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(BorderPattern), typeof(BorderPatternEditor));

			//PropertyEditorManager.RegisterDefaultEditor(typeof(Brush), typeof(BrushEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(Brush), typeof(BrushEditor));

			PropertyEditorManager.RegisterDefaultEditor(typeof(BorderBackgroundClip), typeof(EnumTextEditor<BorderBackgroundClip>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(CheckDesign), typeof(EnumTextEditor<CheckDesign>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(CheckState), typeof(EnumTextEditor<CheckState>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(CornerRadius), typeof(CornerRadiusEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(CornerRadiusMode), typeof(EnumTextEditor<CornerRadiusMode>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(Decimal), typeof(DecimalEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(Direction), typeof(EnumTextEditor<Direction>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(Double), typeof(DoubleEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(DroplistInputMode), typeof(EnumTextEditor<DroplistInputMode>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(FlexDirection), typeof(EnumTextEditor<FlexDirection>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(FlexWrapping), typeof(EnumTextEditor<FlexWrapping>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(FontFamily), typeof(FontFamilyEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(FontSize), typeof(FontSizeEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(FontStretch), typeof(EnumImageEditor<FontStretch>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(FontStyle), typeof(EnumTextEditor<FontStyle>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(FontWeight), typeof(FontWeightEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(IEnumerable), typeof(ItemsSourceEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(ImageSource), typeof(ImageSourceEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(int), typeof(IntEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(Length), typeof(LengthEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(NumericTypeFilter), typeof(EnumTextEditor<NumericTypeFilter>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(Orientation), typeof(EnumImageEditor<Orientation>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(PixyLayout), typeof(EnumImageEditor<PixyLayout>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(PopupClipMode), typeof(EnumTextEditor<PopupClipMode>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(PopupPlacementMode), typeof(EnumImageEditor<PopupPlacementMode>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(PopupTransitionMode), typeof(EnumTextEditor<PopupTransitionMode>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(TextBoxResize), typeof(EnumTextEditor<TextBoxResize>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(ScrollBarVisibility), typeof(EnumTextEditor<ScrollBarVisibility>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(SelectionMode), typeof(EnumTextEditor<SelectionMode>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(SolidColorBrush), typeof(NullableSolidBrushColorEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(Stretch), typeof(EnumTextEditor<Stretch>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(string), typeof(TextEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(SliderPreviewSource), typeof(EnumTextEditor<SliderPreviewSource>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(SymbolPlacement), typeof(EnumTextEditor<SymbolPlacement>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(TextAlignment), typeof(EnumImageEditor<TextAlignment>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(TextDecorationLines), typeof(EnumImageEditor<TextDecorationLines>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(TextDecorationStyle), typeof(EnumImageEditor<TextDecorationStyle>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(Thickness), typeof(ThicknessEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(TrackEdgeDesign), typeof(EnumImageEditor<TrackEdgeDesign>));
			PropertyEditorManager.RegisterDefaultEditor(typeof(GraphicsEffect), typeof(GraphicsEffectEditor));
			PropertyEditorManager.RegisterDefaultEditor(typeof(VaryButtonPlacement), typeof(EnumTextEditor<VaryButtonPlacement>));

			PropertyEditorManager.RegisterEditor(typeof(double), PropertyEditorHint.Double_Percent, typeof(PercentEditor));

			InitializeComponent();

			((IPropertyEditor)e_backgroundEditor).BindToSourceProperty(e_designSurface, Box.BackgroundProperty);
			e_backgroundEditor.Brush = ImageBrushes.CheckeredDark.Brush;

#if x
			CommandBindings.Add(Commands.RunDemo)
				// .Throttle(new TimeSpan(1000)) // Slow down happy clicks. NOTE: For Frogui v 0.2.0, avoid concurrent Reactive Extension (Rx) methods for routed commands
				.Where(e => e.Parameter != CurrentExample)  // Only allow a different demo request through
				.Subscribe(e =>
				{
					// If just a query then indicate the command can execute
					if (e.IsQuery)
						e.CanExecute = true;
					// Execute the command
					else
					{
						ShowExample(e.Parameter);
						e.Handled = true;
					}
				});
#endif

#if WASM
			var BuildName = "WebAssembly";
#else
			var BuildName = "Windows";
#endif

			e_buildType.Text = BuildName;

			Title = $"Frogui Demo ({BuildName})";

#if x
			foreach (var cur in Examples)
				AddDemo(cur);
#else
			e_exampleList.ItemViewMatcher = new SingleModelViewMatcher(typeof(ExampleView));
			e_exampleList.ItemsSource = Examples;
			e_exampleList.AddPropertyChangedListener(Selector.SelectedItemProperty, v => ShowExample((Example)v), true);
			e_exampleList.SelectedIndex = 0;
#endif
		}

		/*******************************************************************************
			ExampleSelectionChanged()
		*******************************************************************************/

		//void ExampleSelectionChanged(object selectedItem)
		//{
		//	var example = (Example)selectedItem;


		//}

		/*******************************************************************************
			CreateStyle()
		*******************************************************************************/
		/// <summary>
		/// Helper method that creates a new style.
		/// </summary>
		/// <param name="targetType">The target type of the style.</param>
		/// <param name="setterParts">Object pairs (<see cref="DependencyProperty"/>
		/// and <see cref="object"/>) that are converted into <see cref="Setter"/>
		/// objects.
		/// </param>
		/// <returns></returns>
		static Style CreateStyle(Type targetType, params object[] setterParts)
		{
			var s = new Style(targetType);

			for (var i = 0; i < setterParts.Length / 2; ++i)
				s.Setters.Add(new Setter((DependencyProperty)setterParts[i * 2], setterParts[i * 2 + 1]));

			return s;
		}

		/*******************************************************************************
			e_homeButton_Click()
		*******************************************************************************/

		void e_homeButton_Click(object sender, RoutedEventArgs e) => ShowExample(null);

		/*******************************************************************************
			e_showProperties_Checked/Unchecked()
		*******************************************************************************/

		void e_showProperties_Checked(object sender, RoutedEventArgs e) => SyncPropertiesPanel();

		void e_showProperties_Unchecked(object sender, RoutedEventArgs e) => SyncPropertiesPanel();

		/*******************************************************************************
			ShowExample()
		*******************************************************************************/

		void ShowExample(Example newExample)
		{
			// If there is currently a demo being shows then remove it
			if (null != CurrentExample)
			{
				var exampleView = (IExampleView)CurrentExampleElement;
				exampleView.MainElement.ClearBindings();

				e_exampleHost.Child = null;
				CurrentExampleElement = null;
				e_notes.Text = null;
				e_funFact.Text = null;
				HidePropertiesPanel();
			}

			CurrentExample = newExample;

			// Create and set the new demo
			if (null != newExample)
			{
				CurrentExampleElement = (Element)Activator.CreateInstance(newExample.Type);

				// Have the example element (which frames the main example element) turn off clipping so shadows show up
				CurrentExampleElement.ClipHorizontalOverflow = false;
				CurrentExampleElement.ClipVerticalOverflow = false;

				//var exampleView = (IExampleView)CurrentExampleElement;

				e_exampleHost.Child = CurrentExampleElement;
				e_notes.Text = newExample.Notes;
				e_funFact.Text = newExample.FunFact;

				// Prepare Presets area
				if (null == newExample.Presets)
					e_presetArea.Visibility = Visibility.Collapsed;
				else
				{
					e_presetArea.Visibility = Visibility.Visible;
					e_presetSelector.Init(newExample.Presets, CurrentExampleView);
				}

				//if (newExample.Prop != PROP.None)
				//{
				//	e_propertiesEditorScrollViewer.Visibility = Visibility.Visible;

				//	foreach (var segment in PropertyEditorManager.CreateEditorSegments(CurrentExampleView.MainElement, (doType, dp) => doType != typeof(Cascader) || PROP.All == newExample.Prop))
				//		e_propertiesEditor.Members.Add((Element)segment.Editor, new Placecard(segment.Label));
				//}
			}

			//CurrentExample = newExample;

			SyncPropertiesPanel();
		}

		/*******************************************************************************
			HidePropertiesPanel()
		*******************************************************************************/

		void HidePropertiesPanel()
		{
			e_propertiesEditor.Members.Clear();
			e_propertiesEditorScrollViewer.Visibility = Visibility.Collapsed;
		}

		/*******************************************************************************
			ShowPropertiesPanel()
		*******************************************************************************/

		void ShowPropertiesPanel()
		{
			e_propertiesEditorScrollViewer.Visibility = Visibility.Visible;

			foreach (var segment in PropertyEditorManager.CreateEditorSegments(CurrentExampleView.MainElement, (doType, dp) => doType != typeof(Cascader) || PROP.All == CurrentExample.Prop))
				e_propertiesEditor.Members.Add((Element)segment.Editor, new Placecard(segment.Label));
		}

		/*******************************************************************************
			SyncPropertiesPanel()
		*******************************************************************************/

		void SyncPropertiesPanel()
		{
			if (e_showProperties.IsChecked)
			{
				e_brushPicker = new BrushPicker();
				e_grid.Children.Add(e_brushPicker, new GridAnchor(2, 2));
			}
			else
			{
				e_grid.Children.Remove(e_brushPicker);
				e_brushPicker = null;
			}

			if (null != CurrentExample && e_showProperties.IsChecked && PROP.None != CurrentExample.Prop)
				ShowPropertiesPanel();
			else
				HidePropertiesPanel();
		}
	}
}