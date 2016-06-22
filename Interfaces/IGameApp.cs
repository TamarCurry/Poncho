using Poncho.Framework;
using Poncho.Display;
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
		IAppAudio audio { get; }
		IAppImages images { get; }
		void Start();
		void Subscribe(UpdateDelegate onUpdate, bool add);
		TextFormat GetTextFormat(string path, ushort size);
		TextFormat GetTextFormat(string path, string name, ushort size);
	}
}
