using System.Collections.Generic;
using Poncho.Framework;

namespace Poncho.Events
{
	/// <summary>
	/// EventManager handles registering and unregistering EventListeners as well as passing events along to them.
	/// </summary>
	internal class EventManager
	{
		#region HELPERS
		/// <summary>
		/// EventCallback class has an EventListener and a priority property for sorting order.
		/// </summary>
		private class EventCallback
		{
			/// <summary>
			/// Listener to pass events to.
			/// </summary>
			public EventDelegate listener;

			/// <summary>
			/// Priority of the event.
			/// </summary>
			public int priority;
		}
		
		#endregion

		#region MEMBERS

		/// <summary>
		/// List for all listeners that handle bubbled events.
		/// </summary>
		private List<EventCallback> _bubbleList;

		/// <summary>
		/// List for all listeners that handle captured events.
		/// </summary>
		private List<EventCallback> _captureList;

		#endregion

		#region GETTERS & SETTERS
		/// <summary>
		/// Returns the event type that is listened for.
		/// </summary>
		public string type { get; private set; }

		/// <summary>
		/// Returns whether or not there are event listeners.
		/// </summary>
		public bool isEmpty { get { return _bubbleList.Count == 0 && _captureList.Count == 0; } }

		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="type"></param>
		public EventManager(string type)
		{
			this.type = type;
			_bubbleList = new List<EventCallback>();
			_captureList = new List<EventCallback>();
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Sorts events by priority.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		private int SortByPriority(EventCallback a, EventCallback b)
		{
			if (a.priority > b.priority) return -1;
			if (a.priority < b.priority) return 1;
			return 0;
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Adds an event listener if it is not already registered.
		/// </summary>
		/// <param name="listener"></param>
		/// <param name="useCapture"></param>
		/// <param name="priority"></param>
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
		/// <summary>
		/// Removes an event listener.
		/// </summary>
		/// <param name="listener"></param>
		/// <param name="useCapture"></param>
		public void Remove(EventDelegate listener, bool useCapture)
		{
			List<EventCallback> list = useCapture ? _captureList : _bubbleList;

			for (int i = list.Count - 1; i >= 0; --i)
			{
				if (list[i].listener == listener)
				{
					list[i].listener = null;
					list.RemoveAt(i);
					break;
				}
			}
		}
		
		// --------------------------------------------------------------
		public void Remove(bool useCapture)
		{
			List<EventCallback> list = useCapture ? _captureList : _bubbleList;
			list.Clear();
		}

		// --------------------------------------------------------------
		public void RemoveAll()
		{
			_captureList.Clear();
			_bubbleList.Clear();
		}

		// --------------------------------------------------------------
		/// <summary>
		/// Passes an event to the appropriate listeners.
		/// </summary>
		/// <param name="e"></param>
		public void Handle(Event e)
		{
			List<EventCallback> list = e.eventPhase == EventPhase.CAPTURE_PHASE ? _captureList : _bubbleList;

			// We use a copy of the list in case listeners are removed in the middle of being handled.
			// If one is removed, the listener on the EventCallback will be null and we'll just skip over it.
			List<EventCallback> copy = new List<EventCallback>(list);

			for (int i = 0; i < copy.Count; ++i)
			{
				if(e.propagation == Propagation.PROPAGATE_NONE) break;
				copy[i].listener?.Invoke(e);
			}
			copy.Clear();
		}

		#endregion
	}
}
