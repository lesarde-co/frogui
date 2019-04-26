using Lesarde.Frogui;

namespace HelloWorldC
{
	/***************************************************************************************************
		ViewModel class
	***************************************************************************************************/
	/// <summary>
	/// Used to model this application's message. Given the simple requirements of this app, having
	/// a view-model class is excessive, but serves as an ideal way to demonstrate how to design
	/// views and view-models.
	/// <para/>
	/// When using Frogui, as with general MVVM development, determining when to use a model versus
	/// a view-model sometimes comes down to a matter of preference. In scenarios where only one or
	/// the other is needed, we recommand using a model if the type is a plain CLR class, and a
	/// view-model (by inheriting from <see cref="DependencyObject"/>) if binding, command processing
	/// or other features offered by <see cref="DependencyObject"/> are needed.
	/// <para/>
	/// Another advantage of dependency properties is they DO NOT take up memory space unless they
	/// are set to a value other than the default. In some cases this is a nominal advantage,
	/// while in other cases, such as when there are many objects, many properties or both the
	/// space savings can be substantial.
	/// <para/>
	/// Inherits from DependencyObject so that dependency properties can be used.
	/// </summary>
	public class ViewModel : DependencyObject
	{
		/***********************************************************
			Message property
		***********************************************************/
		/// <summary>
		/// Identifies the <see cref="MessageProperty"/> dependency property.
		/// <para>
		/// The actual name of a dependency property is derived by removing
		/// "Property" from the dependency property name. In this case,
		/// "MessageProperty" minus "Property" yields "Message."
		/// This may be a little bit confusing if you are new to XAML-based
		/// development, but it's done that way so that a "wrapper" property
		/// can also be made which is accessible from C#. In this case,
		/// the wrapper property below this property is called Message.
		/// </para>
		/// </summary>
		public static DependencyProperty<string, ViewModel> MessageProperty { get; } = DependencyProperty<string, ViewModel>
			.Register() // Register the "Message" dependency property
			.Default("Hello, World!"); // Set the default values to "Hello, World!"

		/// <summary>
		/// Gets or sets the messages.
		/// <para/>
		/// You may be wondering why there is a setter below since this app's
		/// only purpose is to say hello to the world :) It's simply there
		/// in case you'd like to experiment with changing the message
		/// while the app is running.
		/// <para/>
		/// Because the binding in Greeting.xaml to this property
		/// uses the default mode (BindingMode.OneWay), any changes
		/// to this property will update automatically in the display.
		/// </summary>
		public string Message
		{
			get => GetValue(MessageProperty);
			set => SetValue(MessageProperty, value);
		}

	}
}
