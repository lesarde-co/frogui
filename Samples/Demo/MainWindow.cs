using Lesarde.Frogui;
using Lesarde.Frogui.Input;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Text.RegularExpressions;

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
			Me property
		***********************************************************/

		public static MainWindow Me { get; private set; }

		/***********************************************************
			properties
		***********************************************************/

		/// <summary>
		/// Keeps track of the current demo type.
		/// </summary>
		Type CurrentDemoType => null == CurrentDemo ? null : CurrentDemo.GetType();

		/// <summary>
		/// Keeps track of the current demo object.
		/// </summary>
		UIElement CurrentDemo { get; set; }

		/***********************************************************
			Commands class
		***********************************************************/

		public static class Commands
		{
			public static RoutedCommand<Type> RunDemo { get; } = new RoutedCommand<Type>();
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

			InitializeComponent();

			CommandBindings.Add(Commands.RunDemo)
				// .Throttle(new TimeSpan(1000)) // Slow down happy clicks. NOTE: For Frogui v 0.2.0, avoid concurrent Reactive Extension (Rx) methods for routed commands
				.Where(e => e.Parameter != CurrentDemoType)  // Only allow a different demo request through
				.Subscribe(e =>
				{
					// If just a query then indicate the command can execute
					if (e.IsQuery)
						e.CanExecute = true;
					// Execute the command
					else
					{
						ShowDemo(e.Parameter);
						e.Handled = true;
					}
				});

#if WASM
			var BuildName = "WebAssembly";
#else
			var BuildName = "Simulator";
#endif

			e_buildType.Text = BuildName;

			Title = $"Frogui Demo ({BuildName})";

			AddDemo(typeof(Rectangle_Class.View));
			AddDemo(typeof(Ellipse_Class.View));
			AddDemo(typeof(Path_Class.View));
			AddDemo(typeof(Image_Class.View));
			AddDemo(typeof(TextBlock_Class.View));
			AddDemo(typeof(TextBox_Class.View));
			AddDemo(typeof(Border_Class.View));
			AddDemo(typeof(Button_Class.View));
#if ! WASM // Not ready in time for v0.2.0
			AddDemo(typeof(CheckBox_Class.View));
#endif
			AddDemo(typeof(Flex_Class.View));
			AddDemo(typeof(ScrollViewer_Class.View));
			AddDemo(typeof(Alignment_Properties.View));
			AddDemo(typeof(Calculator.View));
			AddDemo(typeof(Tip_Calculator.View));
		}

		/*******************************************************************************
			AddButton()
		*******************************************************************************/
		/// <summary>
		/// Adds a demo for use.
		/// </summary>
		void AddDemo(Type demoType)
		{
			var name = demoType.Namespace.Split('.').Last().Replace('_', ' ');
			//name = Regex.Replace(name, "(\\B[A-Z])", " $1");

			var button = new MenuButton() { CommandParameter = demoType, Text = name };
			e_buttons.Children.Add(button);
		}

		/*******************************************************************************
			e_homeButton_Click()
		*******************************************************************************/

		void e_homeButton_Click(object sender, RoutedEventArgs e) => ShowDemo(null);

		/*******************************************************************************
			ShowDemo()
		*******************************************************************************/

		void ShowDemo(Type newDemoType)
		{
			// If there is currently a demo being shows then remove it
			if (null != CurrentDemo)
				e_scrollViewer.Child = null;

			// If no demo was requested then reset
			if (null == newDemoType)
				CurrentDemo = null;
			// Create and set the new demo
			else
			{
				CurrentDemo = (UIElement)Activator.CreateInstance(newDemoType);
				e_scrollViewer.Child = CurrentDemo;
			}
		}
	}
}
