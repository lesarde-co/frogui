using Lesarde.Frogui;

namespace HelloWorld
{
    public partial class App : SinglePageApplication
    {
		/// <summary>
		/// This method is used to define the type that will be used as the root
		/// element of the application, which is <see cref="Greeting"/>.
		/// </summary>
		public void InitializeComponent()
		{
			this.StartupType = typeof(Greeting);
		}
	}
}
