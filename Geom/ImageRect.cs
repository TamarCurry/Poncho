namespace Poncho.Geom
{
	/// <summary>
	/// An ImageRect represents the rectangular regions of an image within a texture.
	/// Coordinates are integers that start at the top left (0,0) of the image and extend to width-1 and height-1.
	/// Coordinates and size are exact measurements in ImageRect. It starts at the top left of an image and goes to the bottom right.
	/// If you want to use relative coordinates and sizes, please use ImageRectF.
	/// </summary>
	public class ImageRect
	{
		#region GETTERS
		/// <summary>
		/// X (left) coordinate of the image.
		/// </summary>
		public int x { get; }

		/// <summary>
		/// Y (top) coordinate of the image.
		/// </summary>
		public int y { get; }

		/// <summary>
		/// Width of the image.
		/// </summary>
		public ushort width { get; }

		/// <summary>
		/// Height of the image.
		/// </summary>
		public ushort height { get; }
		
		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public ImageRect(int x, int y, ushort width, ushort height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}
		
		#endregion
	}
}
