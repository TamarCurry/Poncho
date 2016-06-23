using System.Collections.Generic;
using Poncho.Events;
using Poncho.Geom;

namespace Poncho.Display
{
	/// <summary>
	/// Represents an object that can be rendered to the screen.
	/// </summary>
	public class DisplayObject : EventDispatcher
	{
		/// <summary>
		/// Toggles the DisplayObject's visibility.
		/// </summary>
		public bool visible;

		/// <summary>
		/// 
		/// </summary>
		public bool mouseEnabled;

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
			mouseEnabled = true;
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
