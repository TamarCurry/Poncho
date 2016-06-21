namespace Poncho.Text
{
	public class TextFormat
	{
		public ushort size { get; private set; }
		public string font { get; private set; }

		public TextFormat(string font, ushort size)
		{
			this.font = font;
			this.size = size;
		}
	}
}
