using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Threading;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static AudioManager instance;

	public AudioMixerGroup mixerGroup;
	public Sound[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}
	void Start()
    {
		Play("MainMusic");
    }
	void Update()
    {
        foreach (Sound s in sounds)
		{
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			if (PauseMenu.Paused)
			{
				s.source.pitch = 0.8f;
				s.source.volume = 0.8f;
			}
			else
			{
				s.source.pitch = 1f;
				s.source.volume = 1f;
			}
			if (Player.GameOver || Moto.GameOver)
            {
				Time.timeScale = 0.5f;
				s.source.pitch = 0.7f;
				s.source.volume -= 0.1f;
			}
		}
	}
	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		//s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		//s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
		s.source.Play();
	}
	public void Pause()
	{
        foreach (Sound s in sounds)
        {
			s.source.mute = true;
        }
    }

    public void Continue()
    {
        foreach (Sound s in sounds)
        {
            s.source.mute = false;
        }
    }

    public void Stop(string sound)
	{
		Destroy(gameObject);
	}
}
