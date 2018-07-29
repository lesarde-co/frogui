using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using Lesarde.Frogui;

namespace HelloWorld
{
	public partial class Greeting : TextBlock
	{
		public void InitializeComponent()
		{
			System.Console.WriteLine("Greeting.IC");
			Text = "Hello, World!";
			FontSize = FontSize.FromKind(FontSizeKind.Large);
			HorizontalAlignment = HorizontalAlignment.Center;
			VerticalAlignment = VerticalAlignment.Center;
		}
	}
}
