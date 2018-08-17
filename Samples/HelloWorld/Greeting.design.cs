using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using Lesarde.Frogui;

namespace HelloWorld
{
	public partial class Greeting : TextBlock
	{
		/// <summary>
		/// This is where an element initializes, specifically, where anything declarative in nature associated with
		/// the element should take place. When the design tool is available, this file will be generated.
		/// </summary>
		public void InitializeComponent()
		{
			Text = "Hello, World!";
			FontSize = FontSize.FromKind(FontSizeKind.Large);
			HorizontalAlignment = HorizontalAlignment.Center;
			VerticalAlignment = VerticalAlignment.Center;
		}
	}
}
