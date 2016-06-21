using Poncho.Display;

namespace Poncho.Text
{
	public class TextField : Sprite
	{
		private float _pivotX;
		private float _pivotY;

		public ushort width;
		public ushort height;
		public bool wordWrap;
		public bool multiline;
		public bool clipOverflow;
		public string text;
		public TextFormat format;
		public TextAlignment alignment;

		public override float pivotX { get { return _pivotX; } set { _pivotX = value; } }
		public override float pivotY { get { return _pivotY; } set { _pivotY = value; } }

		public TextField()
		{
			_pivotX = 0;
			_pivotY = 0;
			width	= 0;
			height	= 0;
		}
	}
}
