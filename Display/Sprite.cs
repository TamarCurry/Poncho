using Poncho.Geom;

namespace Poncho.Display
{
	public class Sprite : DisplayObject
	{
		public Transforms transforms { get; private set; }
		public int imageWidth { get { return image?.rect.width ?? 0; } }
		public int imageHeight { get { return image?.rect.height ?? 0; } }
		public float x { get { return transforms.x; } set { transforms.x = value; } }
		public float y { get { return transforms.y; } set { transforms.y = value; } }
		public float scaleX { get { return transforms.scaleX; } set { transforms.scaleX = value; } }
		public float scaleY { get { return transforms.scaleY; } set { transforms.scaleY = value; } }
		public float rotation { get { return transforms.rotation; } set { transforms.rotation = value; } }
		public virtual float pivotX { get { return image?.pivot.x ?? 0; } set {} }
		public virtual float pivotY { get { return image?.pivot.y ?? 0; } set {} }
		public Image image;
		public DisplayObject parent { get; internal set; }
		
		// --------------------------------------------------------------
		public Sprite()
		{
			transforms = new Transforms();
		}
		
		// --------------------------------------------------------------
		public void RemoveFromDisplay()
		{
			if(parent != null)
			{
				parent.RemoveChild(this);
				parent = null;
			}
		}
	}
}
