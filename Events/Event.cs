
namespace Poncho.Events
{
	public class Event
	{
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
	}
}
