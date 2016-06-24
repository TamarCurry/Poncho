
namespace Poncho.Events
{
	/// <summary>
	/// Enum listing the different propagation options for events.
	/// </summary>
	internal enum Propagation
	{
		/// <summary>
		/// Event is sent to all event listeners.
		/// </summary>
		PROPAGATE_ALL,

		/// <summary>
		/// Event is only sent to listeners for the current EventDispatcher and then stops.
		/// </summary>
		PROPAGATE_REMAINDER,

		/// <summary>
		/// Event is no longer sent to any listeners.
		/// </summary>
		PROPAGATE_NONE
	}
}
