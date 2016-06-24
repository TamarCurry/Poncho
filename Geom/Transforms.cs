using System;

namespace Poncho.Geom
{
	/// <summary>
	/// The Transforms class holds on to positioning, rotation, and scaling values.
	/// </summary>
	public class Transforms
	{
		#region MEMBERS
		/// <summary>
		/// X coordinate.
		/// </summary>
		public float x;

		/// <summary>
		/// Y coordinate.
		/// </summary>
		public float y;

		/// <summary>
		/// Horizontal scaling.
		/// </summary>
		public float scaleX;

		/// <summary>
		/// Vertical scaling.
		/// </summary>
		public float scaleY;

		/// <summary>
		/// Rotational scaling.
		/// </summary>
		private float _rotation;

		/// <summary>
		/// Previous rotation value.
		/// </summary>
		private float _prevRotation;

		/// <summary>
		/// Cached sine value of the rotation.
		/// </summary>
		private float _sin;

		/// <summary>
		/// Cached cosine value of the rotation.
		/// </summary>
		private float _cos;

		#endregion

		#region GETTERS & SETTERS
		/// <summary>
		/// Current rotation of this transform. Rotation ranges from 180 degrees to -180 degrees.
		/// </summary>
		public float rotation {
			get { return _rotation; }
			set
			{
				_rotation = value % 360;
				if(_rotation > 180 ) {
					_rotation = _rotation - 360;
				}
				else if ( _rotation < -180 )
				{
					_rotation = _rotation + 360;
				}
			}
		}

		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		public Transforms()
		{
			Identity();
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Resets all properties to their default values.
		/// </summary>
		public void Identity()
		{
			scaleX = 1;
			scaleY = 1;
			rotation = 0;
			x = 0;
			y = 0;
			_prevRotation = -1000;
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Creates a clone of this Transforms.
		/// </summary>
		/// <returns></returns>
		public Transforms Clone()
		{
			Transforms copy = new Transforms();
			copy.scaleX = scaleX;
			copy.scaleY = scaleY;
			copy.rotation = rotation;
			copy.x = x;
			copy.y = y;
			return copy;
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Updates the sine and cosine values for the rotation.
		/// </summary>
		private void UpdateSineAndCosine()
		{
			if(_prevRotation == rotation) return;
			
			_prevRotation = rotation;
			double r = rotation * Math.PI / 180;
			_cos = (float)Math.Cos(r);
			_sin = (float)Math.Sin(r);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Sets the provided x and y values to what position they would be at once transforms are applied.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void GetPositions( ref float x, ref float y )
		{
			UpdateSineAndCosine();
			float ox = x;
			float oy = y;
			x = ((ox * _cos * scaleX) - (oy * _sin * scaleY));
			y = ((oy * _cos * scaleY) + (ox * _sin * scaleX));
		}
		
		#endregion
	}
}
