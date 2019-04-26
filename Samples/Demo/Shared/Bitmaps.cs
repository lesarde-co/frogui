using Lesarde.Frogui.Media.Imaging;
using System;

namespace Demo
{
	public class Bitmaps
	{
		public class BitmapInfo
		{
			public string FileName { get; set; }
			public string Name { get; set; }
			public BitmapImage Bitmap { get; set; }

			public BitmapInfo(string fileName)
			{
				this.FileName = fileName;
				this.Name = fileName.Substring(0, fileName.Length - 4).Replace('-', ' ');
				this.Bitmap = new BitmapImage(new System.Uri($"Resources/{fileName}", UriKind.Relative));
			}
		}

		public static BitmapInfo FroguiLogo = new BitmapInfo("Frogui-Logo.png");

		public static BitmapInfo Disenchantment = new BitmapInfo("Disenchantment.jpg");
		public static BitmapInfo ScoobyDoo = new BitmapInfo("Scooby-Doo.png");
		public static BitmapInfo TheSimpsons = new BitmapInfo("The-Simpsons.jpg");
		public static BitmapInfo TheFlintstones = new BitmapInfo("The-Flintstones.jpg");
		public static BitmapInfo TheJetsons = new BitmapInfo("The-Jetsons.jpg");
		public static BitmapInfo BobsBurgers = new BitmapInfo("Bobs-Burgers.jpg");
		public static BitmapInfo FamilyGuy = new BitmapInfo("Family-Guy.png");
		public static BitmapInfo KingOfTheHill = new BitmapInfo("King-Of-The-Hill.png");
		public static BitmapInfo CheckeredLight = new BitmapInfo("Checkered-Light.png");
		public static BitmapInfo CheckeredDark = new BitmapInfo("Checkered-Dark.png");
		public static BitmapInfo CheckeredMedium = new BitmapInfo("Checkered-Medium.png");
		public static BitmapInfo LesardeLogo = new BitmapInfo("Lesarde-Logo.png");
		public static BitmapInfo GmailLogo = new BitmapInfo("Gmail-Logo.png");
		public static BitmapInfo Sun = new BitmapInfo("Sun.png");
		public static BitmapInfo Cart = new BitmapInfo("Cart.png");
		public static BitmapInfo Email = new BitmapInfo("Email.png");
		public static BitmapInfo Search = new BitmapInfo("Search.png");
		public static BitmapInfo Filter = new BitmapInfo("Filter.png");
		public static BitmapInfo AmericanFlag = new BitmapInfo("American-Flag.png");

		public static BitmapInfo[] All = 
		{
			Disenchantment,
			ScoobyDoo,
			TheSimpsons,
			TheFlintstones,
			TheJetsons,
			BobsBurgers,
			FamilyGuy,
			KingOfTheHill,
			CheckeredLight,
			CheckeredDark,
			CheckeredMedium,
			LesardeLogo,
			GmailLogo,
			Sun,
			Cart,
			Email,
			Search,
			Filter,
			AmericanFlag
		};
	}
}
