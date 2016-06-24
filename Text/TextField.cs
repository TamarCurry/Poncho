using Poncho.Display;

namespace Poncho.Text
{
	/// <summary>
	/// TextFields are DisplayObjects that display text.
	/// </summary>
	public class TextField : DisplayObject
	{
		/// <summary>
		/// Indicates if text should wrap once it reaches the edge of the TextField.
		/// </summary>
		public bool wordWrap;

		/// <summary>
		/// Indicates whether or not the text can render new lines.
		/// </summary>
		public bool multiline;

		/// <summary>
		/// Indicates whether or not the text should be rendered if it spills out of its bounds.
		/// </summary>
		public bool clipOverflow;

		/// <summary>
		/// Horizontal pivot of the text field, typically ranging in value from 0f to 1f.
		/// </summary>
		public float pivotX;

		/// <summary>
		/// Vertical pivot of the text field, typically ranging in value from 0f to 1f.
		/// </summary>
		public float pivotY;

		/// <summary>
		/// Text to be rendered.
		/// </summary>
		public string text;

		/// <summary>
		/// Width to use for the bounds of the text.
		/// </summary>
		public ushort width;

		/// <summary>
		/// Height to use for the bounds of the text.
		/// </summary>
		public ushort height;

		/// <summary>
		/// Format for the text.
		/// </summary>
		public TextFormat format;

		/// <summary>
		/// Specifies how the text is aligned.
		/// </summary>
		public TextAlignment alignment;
	}
}
