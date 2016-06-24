namespace Poncho.Text
{
	/// <summary>
	/// TextFormat is used to determine how a text in a TextField is rendered.
	/// </summary>
	public class TextFormat
	{
		#region GETTERS & SETTERS
		/// <summary>
		/// The size of the text.
		/// </summary>
		public ushort size { get; private set; }

		/// <summary>
		/// The font to use in the text field.
		/// </summary>
		public string font { get; private set; }
		#endregion

		#region METHODS
		// --------------------------------------------------------------
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="font"></param>
		/// <param name="size"></param>
		public TextFormat(string font, ushort size)
		{
			this.font = font;
			this.size = size;
		}
		
		#endregion
	}
}
