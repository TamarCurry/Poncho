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

		void PlayMusic(string name, float volume = 1, float endVolume = 1, int fadeTimeMs = 0,
			float pan = 0, float pitch = 0);

		void PlayMusic(string path, string name, float volume = 1, float endVolume = 1, int fadeTimeMs = 0,
			float pan = 0, float pitch = 0);

		void CrossfadeMusic(string name, int fadeTimeMs, float endVolume = 1, float pan = 0, float pitch = 0);

		void CrossfadeMusic(string path, string name, int fadeTimeMs, float endVolume = 1, float pan = 0, float pitch = 0);

		void PlaySfx(string path, string name, float volume = 1, float endVolume = 1, int fadeTimeMs = 0,
			float pan = 0, float pitch = 0, int timeUntilPlayAgain = 100);

		void PlaySfx(string name, float volume = 1, float endVolume = 1, int fadeTimeMs = 0, float pan = 0, float pitch = 0,
			int timeUntilPlayAgain = 100);

	}
}
