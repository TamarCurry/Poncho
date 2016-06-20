namespace Poncho.Geom
{
	public class ImageRect
	{
		public int x { get; }
		public int y { get; }
		public ushort width { get; }
		public ushort height { get; }
		
		// --------------------------------------------------------------
		public ImageRect(int x, int y, ushort width, ushort height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}
	}
}
