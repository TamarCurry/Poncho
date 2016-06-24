namespace Poncho.Geom
{
	/// <summary>
	/// PivotF represents a point around which an image can be scaled and/or rotated.
	/// The x and y values are floating point numbers that are typically multiplied by an image's width and height to get exact positioning. 
	/// If you desire exact pixel coordinates, use Pivot.
	/// </summary>
	public class PivotF
	{
		#region GETTERS
		/// <summary>
		/// X coordinate.
		/// </summary>
		public float x { get; }
		
		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <summary>
		/// Y coordinate.
		/// </summary>
		public float y { get; }

		public PivotF(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		
		#endregion
	}
}
