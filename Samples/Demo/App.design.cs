using Lesarde.Frogui;
using Lesarde.Frogui.Media;
using System.Threading.Tasks;

namespace Demo
{
	/***************************************************************************************************
		App class (design)
	***************************************************************************************************/
	public partial class App : SinglePageApplication
    {
		public void InitializeComponent()
		{
			// Indicate that the MainWindow class is this app's root element
			this.StartupType = typeof(MainWindow);
		}
	}
}
