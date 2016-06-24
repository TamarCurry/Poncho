using Poncho.Framework;
using Poncho.Display;
using System;
using Poncho.Text;

namespace Poncho.Interfaces
{
	/// <summary>
	/// Interface for the main game handler.
	/// </summary>
	public interface IGameApp : IDisposable
	{
		#region GETTERS & SETTERS

		/// <summary>
		/// Current FPS of the game.
		/// </summary>
		int fps { get; }

		/// <summary>
		/// Number of milliseconds that have passed since the game started.
		/// </summary>
		int time { get; }

		/// <summary>
		/// Number of milliseconds that have passed since the last frame was rendered.
		/// </summary>
		int deltaTimeMs { get; }

		/// <summary>
		/// Controls how often the FPS is updated.
		/// </summary>
		int fpsInterval { get; set; }

		/// <summary>
		/// Number of seconds that have passed since the last frame was rendered.
		/// </summary>
		float deltaTime { get; }

		/// <summary>
		/// Reference to the stage.
		/// </summary>
		Stage stage { get; }

		/// <summary>
		/// Handler for audio.
		/// </summary>
		IAppAudio audio { get; }

		/// <summary>
		/// Handler for images.
		/// </summary>
		IAppImages images { get; }

		#endregion

		#region METHODS

		/// <summary>
		/// Called when the game is ready to start.
		/// </summary>
		void Start();

		/// <summary>
		/// Adds a delegate to be called on the update loop.
		/// </summary>
		/// <param name="onUpdate"></param>
		/// <param name="add"></param>
		void Subscribe(UpdateDelegate onUpdate, bool add);

		/// <summary>
		/// Loads and registers a font and retrieves a text format for the font at the specified size.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		TextFormat GetTextFormat(string path, ushort size);

		/// <summary>
		/// Loads and registers a font using the given name and retrieves a text format for the font at the specified size.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		TextFormat GetTextFormat(string path, string name, ushort size);
		
		#endregion
	}
}
