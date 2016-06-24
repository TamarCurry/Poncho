using Poncho.Events;


namespace Poncho.Framework
{
	/// <summary>
	/// Houses the different kind of Delegates that are used in the framework.
	/// </summary>

	/// <summary>
	/// Delegate that is used to subscribe to the update loop.
	/// </summary>
	public delegate void UpdateDelegate();

	/// <summary>
	/// Delegate that is used to listen for events.
	/// </summary>
	/// <param name="e"></param>
	public delegate void EventDelegate(Event e);
}
