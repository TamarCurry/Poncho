namespace Poncho.Display
{
	public class Stage : DisplayObject
	{
		public static Stage instance { get; private set; }
		
		// --------------------------------------------------------------
		public Stage() : base()
		{
			if(instance != null) { }
			instance = this;
		}
	}
}
