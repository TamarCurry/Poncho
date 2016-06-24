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
		#region GETTERS & SETTERS
		/// <summary>
		/// The type of event being dispatched.
		/// </summary>
		public string type { get; private set; }

		/// <summary>
		/// The phase the event this is in. Should be either EventPhase.CAPTURE or EventPhase.BUBBLING.
		/// </summary>
		public EventPhase eventPhase { get; internal set; }

		/// <summary>
		/// The original dispatcher of the event.
		/// </summary>
		public EventDispatcher target { get; internal set; }

		/// <summary>
		/// The current target of the event.
		/// </summary>
		public EventDispatcher currentTarget { get; internal set; }

		/// <summary>
		/// Controls if and how the event propagates.
		/// </summary>
		internal Propagation propagation { get; private set; }

		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="type"></param>
		public Event(string type)
		{
			this.type = type;
			propagation = Propagation.PROPAGATE_ALL;
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Stops propagation after all of the current target's listeners for this event are finished.
		/// </summary>
		public void StopPropagation()
		{
			if (propagation == Propagation.PROPAGATE_ALL)
			{
				propagation = Propagation.PROPAGATE_REMAINDER;
			}
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Stops propagation immediately. No more event listeners will catch this event.
		/// </summary>
		public void StopImmediatePropagation()
		{
			propagation = Propagation.PROPAGATE_NONE;
		}
		
		#endregion
	}
}
