using Lesarde.Frogui;
using Lesarde.Frogui.Media;
using System.Threading.Tasks;

namespace HelloWorld
{
    public partial class App : SinglePageApplication
    {
		public void InitializeComponent()
		{
			System.Console.WriteLine("InitializeComponent");

			this.StartupType = typeof(Greeting);
		}
	}
}
