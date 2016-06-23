namespace Poncho.Audio
{
	/// <summary>
	/// AudioSettings is used by other classes to determine how to alter audio.
	/// By itself, AudioSettings does nothing.
	/// </summary>
	public class AudioSettings
	{
		#region MEMBERS
		public string id;
		#endregion

		#region GETTERS AND SETTERS
		// --------------------------------------------------------------
		/// <summary>
		/// Duration for fading volume.
		/// </summary>
		public int fadeDurationMs { get; private set; }

		/// <summary>
		/// Duration for panning.
		/// </summary>
		public int panDurationMs { get; private set; }

		/// <summary>
		/// Duration for changing pitch
		/// </summary>
		public int pitchDurationMs { get; private set; }

		/// <summary>
		/// Elapsed time for fading.
		/// </summary>
		public int fadeElapsedMs { get; private set; }

		/// <summary>
		/// Elapsed time for panning.
		/// </summary>
		public int panElapsedMs { get; private set; }

		/// <summary>
		/// Elapsed time for changing the pitch.
		/// </summary>
		public int pitchElapsedMs { get; private set; }

		/// <summary>
		/// Time until the sound is allowed to be repeated.
		/// </summary>
		public int timeUntilRepeatMs { get; private set; }

		/// <summary>
		/// Starting value for panning.
		/// </summary>
		public float startPan { get; private set; }

		/// <summary>
		/// Ending value for panning.
		/// </summary>
		public float endPan { get; private set; }

		/// <summary>
		/// Starting value for the pitch.
		/// </summary>
		public float startPitch { get; private set; }

		/// <summary>
		/// Ending value for the pitch.
		/// </summary>
		public float endPitch { get; private set; }

		/// <summary>
		/// Starting value for the volume.
		/// </summary>
		public float startVolume { get; private set; }

		/// <summary>
		/// Ending value for the volume.
		/// </summary>
		public float endVolume { get; private set; }

		/// <summary>
		/// The current volume.
		/// </summary>
		public float volume
		{
			get { return GetValue(startVolume, endVolume, 0, 1, fadeElapsedMs, fadeDurationMs); }
			set {
				endVolume = value;
				if (endVolume < 0) endVolume = 0;
				if (endVolume > 1) endVolume = 1;
				fadeDurationMs = 0;
			}
		}

		/// <summary>
		/// The current pan.
		/// </summary>
		public float pan
		{
			get { return GetValue(startPan, endPan, -1, 1, panElapsedMs, panDurationMs); }
			set
			{
				endPan = value;
				if (endPan > 1) endPan = 1;
				if (endVolume < -1) endPan = -1;
				panDurationMs = 0;
			}
		}
		
		/// <summary>
		/// The current pitch.
		/// </summary>
		public float pitch
		{
			get { return GetValue(startPitch, endPitch, -1, 1, pitchElapsedMs, pitchDurationMs); }
			set
			{
				endPitch = value;
				if (endPitch > 1) endPitch = 1;
				if (endPitch < -1) endPitch = -1;
				pitchDurationMs = 0;
			}
		}
		#endregion

		#region METHODS
		// --------------------------------------------------------------

		/// <summary>
		/// Constructor.
		/// </summary>
		public AudioSettings()
		{
			Reset();
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Restores all values to their defaults.
		/// </summary>
		public void Reset()
		{
			fadeDurationMs		= 0;
			panDurationMs		= 0;
			pitchDurationMs		= 0;
			fadeElapsedMs		= 0;
			panElapsedMs		= 0;
			pitchElapsedMs		= 0;
			startPan			= 0;
			endPan				= 0;
			startPitch			= 0;
			endPitch			= 0;

			startVolume			= 1;
			endVolume			= 1;
			timeUntilRepeatMs	= 100;
		}

		// --------------------------------------------------------------
		/// <summary>
		/// Updates the values.
		/// </summary>
		public void Update()
		{
			int elapasedMs		= App.deltaTimeMs;
			fadeElapsedMs		+= elapasedMs;
			pitchElapsedMs		+= elapasedMs;
			panElapsedMs		+= elapasedMs;
			timeUntilRepeatMs	= timeUntilRepeatMs - elapasedMs > 0 ? timeUntilRepeatMs - elapasedMs : 0;
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Fades audio from one volume to another volume.
		/// </summary>
		/// <param name="startVolume"></param>
		/// <param name="endVolume"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings FadeAudio(float startVolume, float endVolume, int durationMs)
		{
			this.startVolume = startVolume;
			this.endVolume = endVolume;
			fadeDurationMs = durationMs;
			fadeElapsedMs = 0;
			return this;
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Fades audio to the specified volume.
		/// </summary>
		/// <param name="endVolume"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings FadeTo(float endVolume, int durationMs)
		{
			return FadeAudio(volume, endVolume, durationMs);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Fades audio from the specified volume.
		/// </summary>
		/// <param name="startVolume"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings FadeFrom(float startVolume, int durationMs)
		{
			return FadeAudio(startVolume, volume, durationMs);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Pans audio from one value to another.
		/// </summary>
		/// <param name="startPan"></param>
		/// <param name="endPan"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings PanAudio(float startPan, float endPan, int durationMs)
		{
			this.startPan = startPan;
			this.endPan = endPan;
			panDurationMs = durationMs;
			panElapsedMs = 0;
			return this;
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Pans audio to the specified value.
		/// </summary>
		/// <param name="endPan"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings PanTo(float endPan, int durationMs)
		{
			return PanAudio(pan, endPan, durationMs);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Pans audio from the specified value.
		/// </summary>
		/// <param name="startPan"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings PanFrom(float startPan, int durationMs)
		{
			return PanAudio(startPan, pan, durationMs);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Changes the pitch of the audio from one value to another.
		/// </summary>
		/// <param name="startPitch"></param>
		/// <param name="endPitch"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings PitchAudio(float startPitch, float endPitch, int durationMs)
		{
			this.startPitch = startPitch;
			this.endPitch = endPitch;
			pitchDurationMs = durationMs;
			pitchElapsedMs = 0;
			return this;
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Changes the pitch of the audio to the specified value.
		/// </summary>
		/// <param name="endPitch"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings PitchTo(float endPitch, int durationMs)
		{
			return PitchAudio(pitch, endPitch, durationMs);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Changes the pitch of the audio from the specified value to its current value.
		/// </summary>
		/// <param name="startPitch"></param>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings PitchFrom(float startPitch, int durationMs)
		{
			return PitchAudio(startPitch, pitch, durationMs);
		}
		
		// --------------------------------------------------------------
		/// <summary>
		/// Specifies how long to wait before the audio can be played again.
		/// Useful for preventing the same sound effect from stacking on top of each other too much.
		/// </summary>
		/// <param name="durationMs"></param>
		/// <returns></returns>
		public AudioSettings DisableRepeats(int durationMs)
		{
			timeUntilRepeatMs = durationMs;
			return this;
		}

		// --------------------------------------------------------------
		/// <summary>
		/// Returns an interpolated value based on the amount of time that has passed.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="target"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <param name="elapsed"></param>
		/// <param name="duration"></param>
		/// <returns></returns>
		private float GetValue(float start, float target, float min, float max, int elapsed, int duration)
		{
			float diff = target - start;
			float percent = elapsed < duration ? (elapsed*1f/duration) : 1;
			float value = start+(diff*percent);
			if(value < min) value = min;
			if(value > max) value = max;
			return value;
		}

		#endregion
	}
}
