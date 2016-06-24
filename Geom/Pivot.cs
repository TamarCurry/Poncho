namespace Poncho.Geom
{
	/// <summary>
	/// Pivot represents a point around which an image can be scaled and/or rotated.
	/// The x and y values are exact integers. If you desire floating point values, use PivotF.
	/// </summary>
	public class Pivot
	{
		#region GETTERS
		/// <summary>
		/// X coordinate.
		/// </summary>
		public ushort x { get; }

		/// <summary>
		/// Y coordinate.
		/// </summary>
		public ushort y { get; }

		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Pivot(ushort x, ushort y)
		{
			this.x = x;
			this.y = y;
		}
		
		#endregion
	}
}
