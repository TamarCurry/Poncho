using Poncho.Audio;

namespace Poncho.Interfaces
{
	/// <summary>
	/// Interface for an audio handler class.
	/// </summary>
	public interface IAppAudio
	{
		/// <summary>
		/// Pauses all sound effects.
		/// </summary>
		void PauseSfx();

		/// <summary>
		/// Pauses music.
		/// </summary>
		void PauseMusic();

		/// <summary>
		/// Pauses all audio.
		/// </summary>
		void PauseAll();

		/// <summary>
		/// Resumes music.
		/// </summary>
		void ResumeMusic();

		/// <summary>
		/// Resumes all sound effects.
		/// </summary>
		void ResumeSfx();

		/// <summary>
		/// Resumes all audio.
		/// </summary>
		void ResumeAll();

		/// <summary>
		/// Stops music.
		/// </summary>
		void StopMusic();

		/// <summary>
		/// Stops all sound effects.
		/// </summary>
		void StopSfx();

		/// <summary>
		/// Stops all audio.
		/// </summary>
		void StopAll();

		/// <summary>
		/// Loads an audio file and caches it.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="name"></param>
		void LoadAudio(string path, string name);

		/// <summary>
		/// Plays the specified music.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		AudioSettings PlayMusic(string name);

		/// <summary>
		/// Loads and plays the specified music.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		AudioSettings PlayMusic(string path, string name);

		/// <summary>
		/// Plays the specified sound effect.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		AudioSettings PlaySfx(string name);
		
		/// <summary>
		/// Loads and plays the specified sound effect.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		AudioSettings PlaySfx(string path, string name);

		/// <summary>
		/// Fades out the music currently playing and fades in another music track.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		AudioSettings CrossfadeMusic(string name, int durationMs);

		/// <summary>
		/// Fades out the music currently playing and loads and fades in another music track.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		AudioSettings CrossfadeMusic(string path, string name, int durationMs);
	}
}
