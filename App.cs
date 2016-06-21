using System;
using Poncho.Interfaces;
using Poncho.Display;
using Poncho.Framework;
using Poncho.Geom;
using Poncho.Text;

namespace Poncho
{
	public static class App
	{
		#region MEMBERS
		private static IGameApp _app;
		#endregion

		// --------------------------------------------------------------
		#region GETTERS
		public static int fps { get { return _app.fps; } }
		public static int time { get { return _app.time; } }
		public static int deltaTimeMs { get { return _app.deltaTimeMs; } }
		public static int fpsInterval { get { return _app.fpsInterval; } set { _app.fpsInterval = value; } }
		public static float deltaTime { get { return _app.deltaTime; } }
		public static Stage stage { get { return _app.stage; } }
		#endregion

		#region METHODS
		// --------------------------------------------------------------
		public static void Init(IGameApp app)
		{
			if(_app != null) return;
			_app = app;
			Run();
		}
		
		// --------------------------------------------------------------
		public static void Init<T>() where T : IGameApp
		{
			if(_app != null) return;
			_app = (IGameApp)Activator.CreateInstance(typeof(T));
			Run();
		}
		
		// --------------------------------------------------------------
		private static void Run()
		{
			using (_app) _app.Start();
		}
		
		// --------------------------------------------------------------
		public static void Subscribe(UpdateDelegate onUpdate, bool add) { _app.Subscribe(onUpdate, add); }
		public static Image GetImage(string path) { return _app.GetImage(path); }
		public static Image GetImage(string path, Pivot pivot) { return _app.GetImage(path, pivot); }
		public static Image GetImage(string path, string name) { return _app.GetImage(path, name); }
		public static Image GetImage(string path, ImageRect rect) { return _app.GetImage(path, rect); }
		public static Image GetImage(string path, string name, Pivot pivot) { return _app.GetImage(path, name, pivot); }
		public static Image GetImage(string path, ImageRect rect, Pivot pivot) { return _app.GetImage(path, rect, pivot); }
		public static Image GetImage(string path, string name, ImageRect rect) { return _app.GetImage(path, name, rect); }
		public static Image GetImage(string path, string name, ImageRect rect, Pivot pivot) { return _app.GetImage(path, name, rect, pivot); }
		public static TextFormat GetTextFormat(string path, ushort size){ return _app.GetTextFormat(path, size); }
		public static TextFormat GetTextFormat(string path, string name, ushort size){ return _app.GetTextFormat(path, name, size); }
		
		#endregion
	}
}
