using System.Collections.Generic;
using System.Linq;

namespace Poncho.Events
{
	/// <summary>
	/// An Event is a way of broadcasting when something has happened.
	/// EventDispatchers can listen for a variety of events and take action depending on the type of event and its parameters.
	/// Events can be dispatched by calling DispatchEvent on an EventDispatcher instance.
	/// Listen for events by calling EventDispatcher::AddEventListener.
	/// Stop listening for events by calling EventDispatcher::RemoveEventListener.
	/// </summary>
	public class Event
	{
		#region MEMBERS
		/// <summary>
		/// List of active events that have been dispatched.
		/// </summary>
		private static List<Event> _activeEvents = new List<Event>();

		#endregion

		#region GETTERS & SETTERS
		
		/// <summary>
		/// The most recent event to be dispatched.
		/// </summary>
		public static Event activeEvent { get { return _activeEvents.FirstOrDefault(); } }

		public string type { get; private set; }
		public EventPhase eventPhase { get; internal set; }
		public EventDispatcher target { get; internal set; }
		public EventDispatcher currentTarget { get; internal set; }

		internal Propagation propagation { get; private set; }

		#endregion

		#region METHODS
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
		
		#endregion
	}
}
