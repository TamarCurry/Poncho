using System;

namespace Poncho.Geom
{
	public class Transforms
	{
		private float _rotation;
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
		public void GetPositions( ref float x, ref float y )
		{
			double r = rotation * Math.PI / 180;
			float c = (float)Math.Cos(r);
			float s = (float)Math.Sin(r);
			float ox = x;
			float oy = y;
			x = ((ox * c * scaleX) - (oy * s * scaleY));
			y = ((oy * c * scaleY) + (ox * s * scaleX));
		}
		
		// --------------------------------------------------------------
		public Transforms Concatenate(Transforms t)
		{
			Transforms copy = t.Clone();
			
			GetPositions(ref copy.x, ref copy.y);

			// translate
			copy.x += x;
			copy.y += y;
				
			// rotate
			double r = copy.rotation * Math.PI / 180;
			float c = (float)Math.Cos(r);
			float s = (float)Math.Sin(r);
			c *= scaleY;
			s *= scaleX;
			copy.rotation = rotation + (float)(Math.Atan2(s, c) * 180 / Math.PI);

			// scale
			copy.scaleX *= scaleX;
			copy.scaleY *= scaleY;

			return copy;
		}
	}
}
