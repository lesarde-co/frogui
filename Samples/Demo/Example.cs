using Lesarde.Frogui;
using Lesarde.Frogui.Media.Imaging;
using System;
using System.Linq;

namespace Demo
{
	public enum PROP
	{
		All,
		None,
		NoCascade
	}

	public class Example
	{
		public Type Type { get; set; }
		public bool UseCustomIcon { get; set; }
		public string Notes { get; set; }
		public string FunFact { get; set; }
		public PROP Prop { get; set; }
		public Style[] Presets { get; set; }
		public BitmapImage Icon { get; set; }

		public string DisplayName => Type.Namespace.Split('.').Last().Substring("Example_".Length).Replace('_', ' ');

		public Example(Type type, bool useCustomIcon, string notes, string funFact, PROP prop, Style[] presets = null)
		{
			this.Type = type;
			this.UseCustomIcon = useCustomIcon;
			this.Notes = notes;
			this.FunFact = funFact;
			this.Prop = prop;
			this.Presets = presets;

			var iconFileName = (useCustomIcon) ? DisplayName : "Misc";

			Icon = new BitmapImage(new System.Uri($"Resources/Menu-{iconFileName}.png", UriKind.Relative));
		}
	}
}
