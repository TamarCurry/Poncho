using Poncho.Audio;

namespace Poncho.Interfaces
{
	public interface IAppAudio
	{
		void PauseSfx();
		void PauseMusic();
		void PauseAll();
		void ResumeMusic();
		void ResumeSfx();
		void ResumeAll();
		void StopMusic();
		void StopSfx();
		void StopAll();
		void LoadAudio(string path, string name);
		AudioSettings PlayMusic(string name);
		AudioSettings PlayMusic(string path, string name);
		AudioSettings PlaySfx(string name);
		AudioSettings PlaySfx(string path, string name);
		AudioSettings CrossfadeMusic(string name, int durationMs);
		AudioSettings CrossfadeMusic(string path, string name, int durationMs);
	}
}
