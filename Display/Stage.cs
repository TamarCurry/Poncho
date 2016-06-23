namespace Poncho.Display
{
	/// <summary>
	/// Represents the highest level DisplayObject there is.
	/// Every DisplayObject that is visible is attached to the stage.
	/// There is only ever one stage. It cannot be instantiated outside of this class.
	/// </summary>
	public sealed class Stage : DisplayObjectContainer
	{
		#region GETTERS
		/// <summary>
		/// Stage singleton.
		/// </summary>
		public static Stage instance { get; private set; }
		
		public override string name {get { return "stage"; }}
		internal override bool parentable { get { return false; } }

		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Static constructor.
		/// </summary>
		static Stage()
		{
			instance = new Stage();
		}

		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		private Stage() { }
		
		#endregion
	}
}
