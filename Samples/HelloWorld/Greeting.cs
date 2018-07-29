using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace HelloWorld
{
    public partial class Greeting : TextBlock
    {
		public Greeting()
		{
			System.Console.WriteLine("a-Greeting()");

			InitializeComponent();

			//System.Console.WriteLine("b-Greeting()");

			//System.Console.WriteLine("text prop = " + this.Text);
		}
	}
}
