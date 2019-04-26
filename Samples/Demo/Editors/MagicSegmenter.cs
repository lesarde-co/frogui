using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using System.Linq;
namespace Demo
{
	public abstract class MagicSegmentor : Segmentor
    {
		public abstract Segment[] Segments { get; }

		public MagicSegmentor()
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
			HorizontalAlignment = HorizontalAlignment.Left;
			VerticalAlignment = VerticalAlignment.Top;

			SelectedValuePath = new PropertyPath(nameof(Segment.Value));

			foreach (var cur in Segments)
				Items.Add(cur);

			SelectedItem = Items[0];
		}

		public void SelectBySegmentValue(object value)
		{
			foreach (Segment segment in Items)
				if (segment.Value == value || segment.Value.Equals(value))
				{
					SelectedItem = segment;
					return;
				}
		}

	}
}
