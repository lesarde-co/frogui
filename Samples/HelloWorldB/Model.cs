using Lesarde.Frogui;

namespace HelloWorldB
{
	/***************************************************************************************************
		Model class
	***************************************************************************************************/
	/// <summary>
	/// Used to model this application's message. Given the simple requirements of this app, having
	/// a model class is excessive, but serves as an ideal way to demonstrate how to design
	/// models and views.
	/// <para/>
	/// Note that this Model is a plain old CLR type, since it does not inherit from <see cref="DependencyObject"/>.
	/// </summary>
	public class Model
	{
		public string Message { get; } = "Hello, World!";
	}
}
