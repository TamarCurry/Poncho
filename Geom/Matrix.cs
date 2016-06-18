using System;

namespace Poncho.Geom
{
	public class Matrix
	{
		private static Matrix _multiplier = new Matrix();

		public float a;
		public float b;
		public float c;
		public float d;
		public float tx;
		public float ty;

		public Matrix()
		{
			Identity();
		}

		public void Identity()
		{
			a = 1;
			b = 0;
			c = 0;
			d = 1;
			tx = 0;
			ty = 0;
		}

		public void Scale(float sx, float sy)
		{
			_multiplier.a = sx;
			_multiplier.b = 0;
			_multiplier.c = 0;
			_multiplier.d = sy;
			ConcatTransformation(_multiplier, false);
		}

		public void Translate(float x, float y)
		{
			tx += x;
			ty += y;
		}

		public void Rotate(double radians)
		{
			float sin = (float) Math.Sin(radians);
			float cos = (float) Math.Cos(radians);
			_multiplier.a = cos;
			_multiplier.b = sin;
			_multiplier.c = -sin;
			_multiplier.d = cos;
			ConcatTransformation(_multiplier, false);
		}

		public void Concat(Matrix m)
		{
			ConcatTransformation(m, true);
		}

		private void ConcatTransformation(Matrix m, bool translate)
		{
			float na = (a * m.a) + (b * m.c);
			float nb = (a * m.b) + (b * m.d);
			float nc = (c * m.a) + (d * m.c);
			float nd = (c * m.b) + (d * m.d);
			float nx = (tx * m.a) + (ty * m.c) + m.tx;
			float ny = (tx * m.b) + (ty * m.d) + m.ty;
			a = na;
			b = nb;
			c = nc;
			d = nd;

			if (translate)
			{
				tx = nx;
				ty = ny;
			}
		}

		public void GetPosition(ref float x, ref float y)
		{
			float nx = (x*a) + (y*c) + tx;
			float ny = (x*b) + (y*d) + ty;
			x = nx;
			y = ny;
		}
	}
}
