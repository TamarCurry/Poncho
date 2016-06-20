
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Poncho.Events
{
	public class Event
	{
		private static List<Event> _activeEvents = new List<Event>();

		public static Event activeEvent { get { return _activeEvents.FirstOrDefault(); } }

		public string type { get; private set; }
		public EventDispatcher target { get; internal set; }
		public EventDispatcher currentTarget { get; internal set; }
		public EventPhase eventPhase { get; internal set; }
		internal Propagation propagation { get; private set; }
		
		// --------------------------------------------------------------
		public Event(string type)
		{
			this.type = type;
			propagation = Propagation.PROPAGATE_ALL;
		}
		
		// --------------------------------------------------------------
		public void StopPropagation()
		{
			if (propagation == Propagation.PROPAGATE_ALL)
			{
				propagation = Propagation.PROPAGATE_REMAINDER;
			}
		}
		
		// --------------------------------------------------------------
		public void StopImmediatePropagation()
		{
			propagation = Propagation.PROPAGATE_NONE;
		}
		
		// --------------------------------------------------------------
		internal static void AddEvent(Event e)
		{
			_activeEvents.Insert(0, e);
		}

		internal static void RemoveLastEvent()
		{
			if(_activeEvents.Count > 0) _activeEvents.RemoveAt(0);
		}
	}
}
