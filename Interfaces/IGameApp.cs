using Poncho.Framework;
using Poncho.Display;
using Poncho.Geom;
using System;

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
		ITextureImage GetImage(string path);
		ITextureImage GetImage(string path, Pivot pivot);
		ITextureImage GetImage(string path, string name);
		ITextureImage GetImage(string path, ImageRect rect);
		ITextureImage GetImage(string path, string name, Pivot pivot);
		ITextureImage GetImage(string path, ImageRect rect, Pivot pivot);
		ITextureImage GetImage(string path, string name, ImageRect rect);
		ITextureImage GetImage(string path, string name, ImageRect rect, Pivot pivot);
	}
}
