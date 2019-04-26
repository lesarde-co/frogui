using Lesarde.Frogui.Media;
using static Demo.Bitmaps;

namespace Demo
{
    public class CartoonModel
    {
		public string Name { get; set; }
		public string Producer { get; set; }
		public string StartYear { get; set; }
		public ImageSource Image { get; set; }

		public CartoonModel(BitmapInfo info, string producer, string startYear)
		{
			Name = info.Name;
			Image = info.Bitmap;
			Producer = producer;
			StartYear = startYear;
		}
	}
}
