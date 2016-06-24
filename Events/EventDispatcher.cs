using System.Collections.Generic;
using Poncho.Framework;

namespace Poncho.Events
{
	/// <summary>
	/// EventDispatchers are capable of sending up events.
	/// Typically, an event goes through two phases - a capture phase and a bubble phase.
	/// Capture phases start at the top level and work their way down.
	/// Once the capture phase is finished, a bubble phase starts and works its way up.
	/// The phases are typically only used for DisplayObjects.
	/// </summary>
	public class EventDispatcher
	{
		#region MEMBERS
		
		/// <summary>
		/// List of event managers.
		/// </summary>
		private Dictionary<string, EventManager> _managers;

		#endregion MEMBERS

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		public EventDispatcher()
		{
			_managers = new Dictionary<string, EventManager>();
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Registers an event listener to listen for an event.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="listener"></param>
		/// <param name="useCapture"></param>
		/// <param name="priority"></param>
		public void AddEventListener(string type, EventDelegate listener, bool useCapture = false, int priority = 0)
		{
			EventManager em = null;
			if (_managers.ContainsKey(type))
			{
				em = _managers[type];
			}
			else
			{
				em = new EventManager(type);
				_managers.Add(type, em);
			}

			em.Add(listener, useCapture, priority);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Removes an event listener from listening for an event.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="listener"></param>
		/// <param name="useCapture"></param>
		public void RemoveEventListener(string type, EventDelegate listener, bool useCapture=false)
		{
			if(!_managers.ContainsKey(type)) return;
			_managers[type].Remove(listener, useCapture);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Removes listeners of the specified type.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="useCapture"></param>
		public void RemoveListeners(string type, bool useCapture=false)
		{
			if(!_managers.ContainsKey(type)) return;
			_managers[type].Remove(useCapture);
		}

		// --------------------------------------------------------------
		/// <summary>
		/// Removes all listeners.
		/// </summary>
		public void RemoveAllListeners()
		{
			foreach (KeyValuePair<string, EventManager> eventManager in _managers)
			{
				eventManager.Value.RemoveAll();
			}
		}

		// --------------------------------------------------------------
		/// <summary>
		/// Helper function for easily adding or removing event listeners.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="active"></param>
		/// <param name="listener"></param>
		/// <param name="useCapture"></param>
		/// <param name="priority"></param>
		public void SetListener(string type, bool active, EventDelegate listener, bool useCapture = false, int priority = 0)
		{
			if(active) AddEventListener(type, listener, useCapture, priority);
			else RemoveEventListener(type, listener, useCapture);
		}

		// --------------------------------------------------------------
		/// <summary>
		/// Dispatches an event of the specified type.
		/// </summary>
		/// <param name="type"></param>
		public void DispatchEvent(string type)
		{
			DispatchEvent( new Event(type) );
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Dispatches the provided event.
		/// </summary>
		/// <param name="e"></param>
		public void DispatchEvent(Event e)
		{
			List<EventDispatcher> hierarchy = GetHierarchy();
			e.target = this;
			e.eventPhase = EventPhase.CAPTURE_PHASE;

			int count = hierarchy.Count;
			// capture phase
			for (int i = count - 1; i >= 0; --i)
			{
				e.currentTarget = hierarchy[i];
				hierarchy[i].HandleEvent(e);
				if (e.propagation == Propagation.PROPAGATE_REMAINDER) break;
				if(e.propagation == Propagation.PROPAGATE_NONE) return;
			}
			
			// only continue if we can propagate the event
			if(e.propagation != Propagation.PROPAGATE_ALL) return;
			
			e.eventPhase = EventPhase.BUBBLING_PHASE;
			// bubbling phase
			for (int i = 0; i < count; ++i)
			{
				e.currentTarget = hierarchy[i];
				hierarchy[i].HandleEvent(e);
				if (e.propagation == Propagation.PROPAGATE_REMAINDER) break;
				if(e.propagation == Propagation.PROPAGATE_NONE) return;
			}
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Returns a hierarchy of EventDispatchers to use for each EventPhase.
		/// </summary>
		/// <returns></returns>
		protected virtual List<EventDispatcher> GetHierarchy()
		{
			return new List<EventDispatcher> { this };
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Handles an event that has been dispatched.
		/// </summary>
		/// <param name="e"></param>
		private void HandleEvent(Event e)
		{
			if(!_managers.ContainsKey(e.type)) return;
			
			_managers[e.type].Handle(e);
		}

		#endregion
	}
}
