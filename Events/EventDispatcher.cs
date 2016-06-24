using System;
using System.Collections.Generic;
using Poncho.Framework;

namespace Poncho.Events
{
	public class EventDispatcher
	{
		private Dictionary<string, EventManager> _managers;
		
		// --------------------------------------------------------------
		public EventDispatcher()
		{
			_managers = new Dictionary<string, EventManager>();
		}
		
		// --------------------------------------------------------------
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
		public void RemoveEventListener(string type, EventDelegate listener, bool useCapture)
		{
			if(!_managers.ContainsKey(type)) return;
			_managers[type].Remove(listener, useCapture);
		}
		
		// --------------------------------------------------------------
		protected virtual List<EventDispatcher> GetHierarchy()
		{
			return new List<EventDispatcher> { this };
		}
		
		// --------------------------------------------------------------
		public void DispatchEvent(string type)
		{
			DispatchEvent( new Event(type) );
		}
		
		// --------------------------------------------------------------
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
				hierarchy[i].HandleEvent(e, true);
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
				hierarchy[i].HandleEvent(e, false);
				if (e.propagation == Propagation.PROPAGATE_REMAINDER) break;
				if(e.propagation == Propagation.PROPAGATE_NONE) return;
			}
		}

		// --------------------------------------------------------------
		private void HandleEvent(Event e, bool useCapture)
		{
			if(!_managers.ContainsKey(e.type)) return;
			
			_managers[e.type].Handle(e, useCapture);
		}
	}
}
