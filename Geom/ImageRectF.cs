
namespace Poncho.Geom
{
	/// <summary>
	/// An ImageRectF represents the rectangular regions of an image within a texture.
	/// Coordinates are floating point values that typically start at the top left (0,0) of the image and typically extend to (1,1).
	/// Coordinates and size are relative measurements in ImageRectF. They are applied as a percentage of the width and height.
	/// It starts at the top left of an image and goes to the bottom right.
	/// If you want to use exact coordinates and sizes, please use ImageRect.
	/// </summary>
	public class ImageRectF
	{
		#region GETTERS
		/// <summary>
		/// X (left) coordinate of the image.
		/// </summary>
		public float x { get; }

		/// <summary>
		/// Y (top) coordinate of the image.
		/// </summary>
		public float y { get; }
		
		/// <summary>
		/// Width of the image.
		/// </summary>
		public float width { get; }
		
		/// <summary>
		/// Height of the image.
		/// </summary>
		public float height { get; }
		
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
		public ImageRectF(float x, float y, float width, float height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		#endregion
	}
}
