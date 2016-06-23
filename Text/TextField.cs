using Poncho.Display;

namespace Poncho.Text
{
	public class TextField : DisplayObject
	{
		public bool wordWrap;
		public bool multiline;
		public bool clipOverflow;
		public float pivotX;
		public float pivotY;
		public string text;
		public ushort width;
		public ushort height;
		public TextFormat format;
		public TextAlignment alignment;
	}
}
