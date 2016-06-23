using System.Collections.Generic;
using System.Linq;

namespace Poncho.Display
{
	public class DisplayObjectContainer : DisplayObject
	{
		private List<DisplayObject> _children;

		public int numChildren { get { return _children.Count; } }
		
		// --------------------------------------------------------------
		public DisplayObjectContainer()
		{
			_children = new List<DisplayObject>();
		}

		// --------------------------------------------------------------
		public DisplayObject AddChild(DisplayObject child)
		{
			if (child?.parentable ?? false)
			{
				child.RemoveFromDisplay();
				_children.Add(child);
				child.parent = this;
			}
			return child;
		}
		
		// --------------------------------------------------------------
		public DisplayObject RemoveChild(DisplayObject child) {
			int index = _children.IndexOf(child);
			if(index > -1) {
				_children.RemoveAt(index);
				child.parent = null;
			}
			return child;
		}
		
		// --------------------------------------------------------------
		public DisplayObject AddChildAt(DisplayObject child, int index)
		{
			if(child?.parentable ?? false)
			{
				child.RemoveFromDisplay();
				if(index < _children.Count)
				{
					_children.Insert(index, child);
					child.parent = this;
				}
			}
			return child;
		}
		
		// --------------------------------------------------------------
		public DisplayObject RemoveChildAt(int index)
		{
			if(index < _children.Count)
			{
				DisplayObject child = _children[index];
				RemoveChild(child);
				return child;
			}
			return null;
		}
		
		// --------------------------------------------------------------
		public DisplayObject GetChildAt(int index)
		{
			return _children.ElementAtOrDefault(index);
		}
	}
}
