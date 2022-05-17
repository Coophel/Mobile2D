using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
	// making singleton
	public static SoundManager Instance;

	public AudioMixer mixer;
	[SerializeField]
	private AudioClip[] bgSounds;
	[SerializeField]
	private AudioSource musicSource;

#region Unity Functions
	private void Start()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
			SceneManager.sceneLoaded += OnSceneLoaded;
		}
		else
			Destroy(gameObject);

		PlayBGSound(bgSounds[0]);
		BGSoundVolume(0f);
		SFXSoundVolume(0f);
	}

#endregion

#region Public Functions
	public void BGSoundVolume(float value)
	{
		mixer.SetFloat("BGSoundVolume", Mathf.Log10(value) * 20);
	}

	public void SFXSoundVolume(float value)
	{
		mixer.SetFloat("SFXSoundVolume", Mathf.Log10(value) * 20);
	}

	public void PlayBGSound(AudioClip clip)
	{
		musicSource.outputAudioMixerGroup = mixer.FindMatchingGroups("BackGround")[0];
		musicSource.clip = clip;
		musicSource.loop = true;
		musicSource.Play();
	}

	public void PlaySFXSound(string sfxName, AudioClip clip)
	{
		GameObject play = new GameObject(sfxName + "Sound");
		AudioSource audiosource = play.AddComponent<AudioSource>();
		audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
		audiosource.clip = clip;
		audiosource.Play();

		Destroy(play, clip.length);
	}
#endregion

#region Private Functions
	private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		Debug.Log(arg0.name + " Loaded");
		for (int i = 0; i < bgSounds.Length; i++)
		{
			if (arg0.buildIndex == i)
			{
				PlayBGSound(bgSounds[i]);
			}
		}
	}
#endregion
}
