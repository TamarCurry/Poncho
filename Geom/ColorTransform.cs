namespace Poncho.Geom
{
	/// <summary>
	/// ColorTransform represents the color that is applied to a DisplayObject when it is rendered to the screen.
	/// A ColorTransform that is pure white (red=1, green=1, blue=1, alpha=1) will render the DisplayObject as it originally appears.
	/// A ColorTransform that is (red=0, green=0, blue=0, alpha=1) will render the DisplayObject black.
	/// </summary>
	public class ColorTransform
	{
		#region MEMBERS
		/// <summary>
		/// Red multiplier.
		/// </summary>
		private float _red;

		/// <summary>
		/// Green multiplier.
		/// </summary>
		private float _green;

		/// <summary>
		/// Blue multiplier.
		/// </summary>
		private float _blue;

		/// <summary>
		/// Alpha multiplier.
		/// </summary>
		private float _alpha;

		#endregion

		#region GETTERS & SETTERS
		// --------------------------------------------------------------
		/// <summary>
		/// Red multiplier. Value values range between 0 and 1 inclusive.
		/// </summary>
		public float red
		{
			get
			{
				return _red;
			}
			set
			{
				_red = value;
				if (_red < 0) _red = 0;
				if (_red > 1) _red = 1;
			}
		}

		/// <summary>
		/// Green multiplier. Value values range between 0 and 1 inclusive.
		/// </summary>
		public float green
		{
			get
			{
				return _green;
			}
			set
			{
				_green = value;
				if (_green < 0) _green = 0;
				if (_green > 1) _green = 1;
			}
		}

		/// <summary>
		/// Blue multiplier. Value values range between 0 and 1 inclusive.
		/// </summary>
		public float blue
		{
			get
			{
				return _blue;
			}
			set
			{
				_blue = value;
				if (_blue < 0) _blue = 0;
				if (_blue > 1) _blue = 1;
			}
		}

		/// <summary>
		/// Alpha multiplier. Value values range between 0 and 1 inclusive.
		/// </summary>
		public float alpha
		{
			get
			{
				return _alpha;
			}
			set
			{
				_alpha = value;
				if (_alpha < 0) _alpha = 0;
				if (_alpha > 1) _alpha = 1;
			}
		}
		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="red"></param>
		/// <param name="green"></param>
		/// <param name="blue"></param>
		/// <param name="alpha"></param>
		public ColorTransform(float red = 1, float green = 1, float blue = 1, float alpha = 1)
		{
			this.red	= red;
			this.green	= green;
			this.blue	= blue;
			this.alpha	= alpha;
		}

		// --------------------------------------------------------------
		/// <summary>
		/// Concatenates a ColorTransform resulting in an additive combination of the two.
		/// </summary>
		/// <param name="color"></param>
		public void Concat(ColorTransform color)
		{
			red		*= color.red;
			green	*= color.green;
			blue	*= color.blue;
			alpha	*= color.alpha;
		}
		#endregion
	}
}
