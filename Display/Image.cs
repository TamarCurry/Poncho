using Poncho.Geom;

namespace Poncho.Display
{
	/// <summary>
	/// This class holds on to data regarding how an image should be rendered.
	/// It does not actually include any pixel or texture data.
	/// An image can represent an entire texture or only a portion of a texture.
	/// </summary>
	public class Image
	{
		#region GETTERS
		/// <summary>
		/// The name of the image that is rendered.
		/// </summary>
		public string name { get; }
		
		/// <summary>
		/// The pivot for the image that is rendered.
		/// </summary>
		public Pivot pivot { get; }

		/// <summary>
		/// The rectangular region specifying what pixels in a texture should be used to draw the image.
		/// </summary>
		public ImageRect rect { get; }
		
		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="rect"></param>
		/// <param name="pivot"></param>
		public Image(string name, ImageRect rect, Pivot pivot)
		{
			this.name = name;
			this.rect = rect;
			this.pivot = pivot;
		}

		#endregion
	}
}

