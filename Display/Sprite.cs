namespace Poncho.Display
{
	/// <summary>
	/// A Sprite is a DisplayObjectContainer that also has an image associated with it.
	/// </summary>
	public class Sprite : DisplayObjectContainer
	{
		/// <summary>
		/// Width of the source image.
		/// </summary>
		public ushort imageWidth { get { return image?.rect.width ?? 0; } }

		/// <summary>
		/// Height of the source image.
		/// </summary>
		public ushort imageHeight { get { return image?.rect.height ?? 0; } }

		/// <summary>
		/// Horizontal pivot of the source image.
		/// </summary>
		public ushort pivotX { get { return image?.pivot.x ?? 0; } }

		/// <summary>
		/// Vertical pivot of the source image.
		/// </summary>
		public ushort pivotY { get { return image?.pivot.y ?? 0; } }

		/// <summary>
		/// Image instance used to indicate what visuals to render to the screen and how.
		/// </summary>
		public Image image;
	}
}
