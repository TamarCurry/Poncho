using Poncho.Display;

namespace Poncho.Text
{
	public class TextField : Sprite
	{
		//private ushort _pivotX;
		//private ushort _pivotY;

		public ushort width;
		public ushort height;
		public bool wordWrap;
		public bool multiline;
		public bool clipOverflow;
		public string text;
		public TextFormat format;
		public TextAlignment alignment;

		//public override ushort pivotX { get { return _pivotX; } set { _pivotX = value; } }
		//public override ushort pivotY { get { return _pivotY; } set { _pivotY = value; } }

		public TextField()
		{
			//_pivotX = 0;
			//_pivotY = 0;
			width	= 0;
			height	= 0;
		}
	}
}
