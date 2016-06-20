using System.Collections.Generic;
using System.Linq;
using Poncho.Events;

namespace Poncho.Display
{
	public class DisplayObject : EventDispatcher
	{
		public bool visible;
		public bool clickThrough;

		private List<Sprite> _children;

		public int numChildren { get { return _children.Count; } }
		public virtual string name { get; set; }
		
		// --------------------------------------------------------------
		public DisplayObject()
		{
			visible = true;
			clickThrough = false;
			_children = new List<Sprite>();
		}
		
		// --------------------------------------------------------------
		public Sprite AddChild(Sprite child) {
			child.RemoveFromDisplay();
			_children.Add(child);
			child.parent = this;
			return child;
		}
		
		// --------------------------------------------------------------
		public Sprite RemoveChild(Sprite child) {
			int index = _children.IndexOf(child);
			if(index > -1) {
				_children.RemoveAt(index);
				child.parent = null;
			}
			return child;
		}
		
		// --------------------------------------------------------------
		public Sprite AddChildAt(Sprite child, int index)
		{
			child.RemoveFromDisplay();
			if(index < _children.Count)
			{
				_children.Insert(index, child);
				child.parent = this;
			}
			return child;
		}
		
		// --------------------------------------------------------------
		public Sprite RemoveChildAt(int index)
		{
			if(index < _children.Count)
			{
				Sprite child = _children[index];
				RemoveChild(child);
				return child;
			}
			return null;
		}
		
		// --------------------------------------------------------------
		public Sprite GetChildAt(int index)
		{
			return _children.ElementAtOrDefault(index);
		}
		
		// --------------------------------------------------------------
		protected override List<EventDispatcher> GetHierarchy()
		{
			List<EventDispatcher> hierarchy = new List<EventDispatcher>();
			DisplayObject target = this;
			Sprite sprite = null;

			do
			{
				hierarchy.Add(target);
				sprite = target as Sprite;
				target = sprite?.parent;
			} while (target != null);

			return hierarchy;
		}
	}
}
