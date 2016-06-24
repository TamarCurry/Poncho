
namespace Poncho.Events
{
	/// <summary>
	/// Values for an Event's eventPhase property.
	/// </summary>
	public enum EventPhase
	{
		/// <summary>
		/// Capture phase is handled from the top of the hierarchy and works its way down.
		/// </summary>
		CAPTURE_PHASE,

		/// <summary>
		/// Bubbling phase is handled from the bottom of the hierarchy and works its way up.
		/// </summary>
		BUBBLING_PHASE
	}
}
