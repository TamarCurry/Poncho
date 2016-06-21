using Poncho.Framework;
using Poncho.Display;
using Poncho.Geom;
using System;
using Poncho.Text;

namespace Poncho.Interfaces
{
	public interface IGameApp : IDisposable
	{
		int fps { get; }
		int time { get; }
		int deltaTimeMs { get; }
		int fpsInterval { get; set; }
		float deltaTime { get; }
		Stage stage { get; }
		void Start();
		void Subscribe(UpdateDelegate onUpdate, bool add);
		TextFormat GetTextFormat(string path, ushort size);
		TextFormat GetTextFormat(string path, string name, ushort size);
		Image GetImage(string path);
		Image GetImage(string path, Pivot pivot);
		Image GetImage(string path, string name);
		Image GetImage(string path, ImageRect rect);
		Image GetImage(string path, string name, Pivot pivot);
		Image GetImage(string path, ImageRect rect, Pivot pivot);
		Image GetImage(string path, string name, ImageRect rect);
		Image GetImage(string path, string name, ImageRect rect, Pivot pivot);
	}
}
