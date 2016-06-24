using System;
using System.Collections.Generic;
using Poncho.Framework;

namespace Poncho.Events
{
	internal class EventManager
	{
		private class EventCallback
		{
			public EventDelegate listener;
			public int priority;
		}

		private List<EventCallback> _bubbleList;
		private List<EventCallback> _captureList;
		
		public string type { get; private set; }
		public bool isEmpty { get { return _bubbleList.Count == 0 && _captureList.Count == 0; } }

		// --------------------------------------------------------------
		public EventManager(string type)
		{
			this.type = type;
			_bubbleList = new List<EventCallback>();
			_captureList = new List<EventCallback>();
		}
		
		// --------------------------------------------------------------
		private int SortByPriority(EventCallback a, EventCallback b)
		{
			if (a.priority > b.priority) return -1;
			if (a.priority < b.priority) return 1;
			return 0;
		}
		
		// --------------------------------------------------------------
		public void Add(EventDelegate listener, bool useCapture, int priority)
		{
			List<EventCallback> list = useCapture ? _captureList : _bubbleList;

			for (int i = list.Count - 1; i >= 0; --i)
			{
				if(list[i].listener == listener) return;
			}

			EventCallback ec = new EventCallback();
			ec.listener = listener;
			ec.priority = priority;
			list.Add(ec);
			list.Sort(SortByPriority);
		}
		
		// --------------------------------------------------------------
		public void Remove(EventDelegate listener, bool useCapture)
		{
			List<EventCallback> list = useCapture ? _captureList : _bubbleList;

			for (int i = list.Count - 1; i >= 0; --i)
			{
				if (list[i].listener == listener)
				{
					list.RemoveAt(i);
					break;
				}
			}
		}
		
		// --------------------------------------------------------------
		public void Handle(Event e, bool useCapture)
		{
			List<EventCallback> list = useCapture ? _captureList : _bubbleList;

			for (int i = 0; i < list.Count; ++i)
			{
				if(e.propagation != Propagation.PROPAGATE_NONE)
				{
					list[i].listener(e);
				}
			}
		}
	}
}
