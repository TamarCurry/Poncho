using Poncho.Geom;

namespace Poncho.Display
{
	public class Image
	{
		public string name { get; }
		public Pivot pivot { get; }
		public ImageRect rect { get; }

		public Image(string name, ImageRect rect, Pivot pivot)
		{
			this.name = name;
			this.rect = rect;
			this.pivot = pivot;
		}
	}
}

