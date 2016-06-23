using System;
using System.Collections.Generic;
using System.Linq;

namespace Poncho.Display
{
	/// <summary>
	/// A DisplayObject that can hold other DisplayObjects.
	/// </summary>
	public class DisplayObjectContainer : DisplayObject
	{
		#region MEMBERS
		/// <summary>
		/// Toggles mouse interactivity with children.
		/// </summary>
		public bool mouseChildren;

		/// <summary>
		/// List of child DisplayObjects.
		/// </summary>
		private List<DisplayObject> _children;

		#endregion

		#region GETTERS
		// --------------------------------------------------------------
		/// <summary>
		/// Number of child DisplayObjects.
		/// </summary>
		public int numChildren { get { return _children.Count; } }

		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		public DisplayObjectContainer()
		{
			mouseChildren = true;
			_children = new List<DisplayObject>();
		}

		// --------------------------------------------------------------
		/// <summary>
		/// Adds a DisplayObject as a child.
		/// </summary>
		/// <param name="child"></param>
		/// <returns></returns>
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
		/// <summary>
		/// Removes a DisplayObject as a child.
		/// </summary>
		/// <param name="child"></param>
		/// <returns></returns>
		public DisplayObject RemoveChild(DisplayObject child) {
			int index = _children.IndexOf(child);
			if(index > -1 && child != null) {
				_children.RemoveAt(index);
				child.parent = null;
			}
			return child;
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Adds a DisplayObject at the specfied index in the display list.
		/// </summary>
		/// <param name="child"></param>
		/// <param name="index"></param>
		/// <returns></returns>
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
		/// <summary>
		/// Removes the DisplayObject at the specified index in the display list.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
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
		/// <summary>
		/// Returns the DisplayObject at the specified Index.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public DisplayObject GetChildAt(int index)
		{
			return _children.ElementAtOrDefault(index);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Returns the first DisplayObject with the specified name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public DisplayObject GetChildByName(string name)
		{
			return _children.Find(child => child.name == name);
		}
		
		// --------------------------------------------------------------
		public void RemoveChildren(int startIndex = 0, int endIndex = Int32.MaxValue)
		{
			if(startIndex < 0) return;
			int n = numChildren;
			if (endIndex > n-1) endIndex = n-1;

			for (int i = 0; i <= endIndex; i++)
			{
				_children[i].parent = null;
			}

			_children.Clear();
		}

		#endregion
	}
}
