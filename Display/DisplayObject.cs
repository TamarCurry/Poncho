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
		#region GETTERS & SETTERS
		/// <summary>
		/// Toggles the DisplayObject's visibility.
		/// </summary>
		public bool visible;

		/// <summary>
		/// Toggles whether or not mouse interactivity is enabled.
		/// </summary>
		public bool mouseEnabled;

		/// <summary>
		/// Indicates whether or not this DisplayObject can be added as a child to a DisplayObjectContainer
		/// </summary>
		internal virtual bool parentable { get { return true; } }
		
		/// <summary>
		/// Name of the DisplayObject,
		/// </summary>
		public virtual string name { get; set; }

		/// <summary>
		/// Transforms object used to modify the DisplayObject's position, scale, and rotation.
		/// </summary>
		public Transforms transforms { get; private set; }

		/// <summary>
		/// X position of the DisplayObject.
		/// </summary>
		public float x { get { return transforms.x; } set { transforms.x = value; } }

		/// <summary>
		/// Y position of the DisplayObject.
		/// </summary>
		public float y { get { return transforms.y; } set { transforms.y = value; } }

		/// <summary>
		/// Horizontal scale of the DisplayObject.
		/// </summary>
		public float scaleX { get { return transforms.scaleX; } set { transforms.scaleX = value; } }

		/// <summary>
		/// Vertical scale of the DisplayObject.
		/// </summary>
		public float scaleY { get { return transforms.scaleY; } set { transforms.scaleY = value; } }

		/// <summary>
		/// Rotation of the DisplayObject.
		/// Rotation goes in a clockwise direction.
		/// </summary>
		public float rotation { get { return transforms.rotation; } set { transforms.rotation = value; } }
		
		/// <summary>
		/// The DisplayObject's parent.
		/// </summary>
		public DisplayObjectContainer parent { get; internal set; }
		
		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		public DisplayObject()
		{
			visible = true;
			mouseEnabled = true;
			transforms = new Transforms();
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Removes the DisplayObject from the display list.
		/// </summary>
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
		#endregion
	}
}
