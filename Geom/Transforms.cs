using System;

namespace Poncho.Geom
{
	public class Transforms
	{
		private float _rotation;
		private float _prevRotation;
		private float _sin;
		private float _cos;
		public float scaleX;
		public float scaleY;
		public float x;
		public float y;
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
		
		// --------------------------------------------------------------
		public Transforms()
		{
			Identity();
		}
		
		// --------------------------------------------------------------
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
		private void UpdateSineAndCosine()
		{
			if(_prevRotation == rotation) return;
			
			_prevRotation = rotation;
			double r = rotation * Math.PI / 180;
			_cos = (float)Math.Cos(r);
			_sin = (float)Math.Sin(r);
		}
		
		// --------------------------------------------------------------
		public void GetPositions( ref float x, ref float y )
		{
			UpdateSineAndCosine();
			float ox = x;
			float oy = y;
			x = ((ox * _cos * scaleX) - (oy * _sin * scaleY));
			y = ((oy * _cos * scaleY) + (ox * _sin * scaleX));
		}
	}
}
