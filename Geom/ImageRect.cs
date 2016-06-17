namespace Poncho.Geom
{
	public class ImageRect
	{
		public int x { get; }
		public int y { get; }
		public uint width { get; }
		public uint height { get; }
		
		// --------------------------------------------------------------
		public ImageRect(int x, int y, uint width, uint height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}
	}
}
