using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour {

	public static AudioManager instance;
	public Image soundIMG;
	public Sound[] sounds;

	void Awake ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		} else if (instance == null)
		{
			instance = this;
			
		}
		else
        {
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.outputAudioMixerGroup = s.mixer;
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
		
		
	}
	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Stop();
	}
	public void onToggleSound(bool offSound) 
	{
		if (offSound == true) {
			soundIMG.color = new Color(1f, 0f, 0f, 1f);
		}
		if (offSound == false)
		{
			soundIMG.color = new Color(1f,1f,1f,1f);
		}


	}

}
