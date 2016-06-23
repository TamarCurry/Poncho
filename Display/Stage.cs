namespace Poncho.Display
{
	public class Stage : DisplayObjectContainer
	{
		public static Stage instance { get; private set; }

		public override string name {get { return "stage"; }}

		// --------------------------------------------------------------
		public Stage()
		{
			if(instance != null) { }
			instance = this;
			parentable = false;
		}
	}
}
