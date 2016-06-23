using System.Collections.Generic;
using System.Linq;
using Poncho.Events;
using Poncho.Geom;

namespace Poncho.Display
{
	public class DisplayObject : EventDispatcher
	{
		public bool visible;
		public bool clickThrough;

		internal bool parentable;
		
		public virtual string name { get; set; }
		public Transforms transforms { get; private set; }
		public float x { get { return transforms.x; } set { transforms.x = value; } }
		public float y { get { return transforms.y; } set { transforms.y = value; } }
		public float scaleX { get { return transforms.scaleX; } set { transforms.scaleX = value; } }
		public float scaleY { get { return transforms.scaleY; } set { transforms.scaleY = value; } }
		public float rotation { get { return transforms.rotation; } set { transforms.rotation = value; } }
		public DisplayObjectContainer parent { get; internal set; }

		// --------------------------------------------------------------
		public DisplayObject()
		{
			visible = true;
			parentable = true;
			clickThrough = false;
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
		
		// --------------------------------------------------------------
		protected override List<EventDispatcher> GetHierarchy()
		{
			List<EventDispatcher> hierarchy = new List<EventDispatcher>();
			DisplayObject target = this;

			do
			{
				hierarchy.Add(target);
				target = target.parent;
			} while (target != null);

			return hierarchy;
		}
	}
}
