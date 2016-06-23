using Poncho.Geom;

namespace Poncho.Display
{
	public class Sprite : DisplayObjectContainer
	{
		public ushort imageWidth { get { return image?.rect.width ?? 0; } }
		public ushort imageHeight { get { return image?.rect.height ?? 0; } }
		public ushort pivotX { get { return image?.pivot.x ?? 0; } }
		public ushort pivotY { get { return image?.pivot.y ?? 0; } }
		public Image image;
	}
}
