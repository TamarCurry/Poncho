namespace Poncho.Audio
{
	public class AudioSettings
	{
		public string id;
		
		// --------------------------------------------------------------
		public int fadeDurationMs { get; private set; }
		public int panDurationMs { get; private set; }
		public int pitchDurationMs { get; private set; }
		public int fadeElapsedMs { get; private set; }
		public int panElapsedMs { get; private set; }
		public int pitchElapsedMs { get; private set; }
		public int timeUntilRepeatMs { get; private set; }
		public float startPan { get; private set; }
		public float endPan { get; private set; }
		public float startPitch { get; private set; }
		public float endPitch { get; private set; }
		public float startVolume { get; private set; }
		public float endVolume { get; private set; }

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
		
		// --------------------------------------------------------------
		public AudioSettings()
		{
			Reset();
		}
		
		// --------------------------------------------------------------
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
		public void Update()
		{
			int elapasedMs		= App.deltaTimeMs;
			fadeElapsedMs		+= elapasedMs;
			pitchElapsedMs		+= elapasedMs;
			panElapsedMs		+= elapasedMs;
			timeUntilRepeatMs	= timeUntilRepeatMs - elapasedMs > 0 ? timeUntilRepeatMs - elapasedMs : 0;
		}
		
		// --------------------------------------------------------------
		public AudioSettings fadeAudio(float startVolume, float endVolume, int durationMs)
		{
			this.startVolume = startVolume;
			this.endVolume = endVolume;
			fadeDurationMs = durationMs;
			fadeElapsedMs = 0;
			return this;
		}
		
		// --------------------------------------------------------------
		public AudioSettings fadeTo(float endVolume, int durationMs)
		{
			return fadeAudio(volume, endVolume, durationMs);
		}
		
		// --------------------------------------------------------------
		public AudioSettings fadeFrom(float startVolume, int durationMs)
		{
			return fadeAudio(startVolume, volume, durationMs);
		}
		
		// --------------------------------------------------------------
		public AudioSettings panAudio(float startPan, float endPan, int durationMs)
		{
			this.startPan = startPan;
			this.endPan = endPan;
			panDurationMs = durationMs;
			panElapsedMs = 0;
			return this;
		}
		
		// --------------------------------------------------------------
		public AudioSettings panTo(float endPan, int durationMs)
		{
			return panAudio(pan, endPan, durationMs);
		}
		
		// --------------------------------------------------------------
		public AudioSettings panFrom(float startPan, int durationMs)
		{
			return panAudio(startPan, pan, durationMs);
		}
		
		// --------------------------------------------------------------
		public AudioSettings pitchAudio(float startPitch, float endPitch, int durationMs)
		{
			this.startPitch = startPitch;
			this.endPitch = endPitch;
			pitchDurationMs = durationMs;
			pitchElapsedMs = 0;
			return this;
		}
		
		// --------------------------------------------------------------
		public AudioSettings pitchTo(float endPitch, int durationMs)
		{
			return pitchAudio(pitch, endPitch, durationMs);
		}
		
		// --------------------------------------------------------------
		public AudioSettings pitchFrom(float startPitch, int durationMs)
		{
			return pitchAudio(startPitch, pitch, durationMs);
		}
		
		// --------------------------------------------------------------
		public AudioSettings DisableRepeats(int durationMs)
		{
			timeUntilRepeatMs = durationMs;
			return this;
		}

		// --------------------------------------------------------------
		private float GetValue(float start, float target, float min, float max, int elapsed, int duration)
		{
			float diff = target - start;
			float percent = elapsed < duration ? (elapsed*1f/duration) : 1;
			float value = start+(diff*percent);
			if(value < min) value = min;
			if(value > max) value = max;
			return value;
		}
	}
}
