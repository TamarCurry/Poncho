namespace Poncho.Display
{
	public class Stage : DisplayObject
	{
		public static Stage instance { get; private set; }

		public override string name {get { return "stage"; }}

		// --------------------------------------------------------------
		public Stage() : base()
		{
			if(instance != null) { }
			instance = this;
		}
	}
}
