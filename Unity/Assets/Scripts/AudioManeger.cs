using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManeger : MonoBehaviour {



	GameObject character;
	CharacterScript characterScript;

	// Audio sources objects
	/*GameObject enginesAudio;
	GameObject rotationAudio;*/
	GameObject playerAudio;

	// Audio sources components
	AudioSource characterAudioSource;
	/*AudioSource enginesAudioSource;
	AudioSource rotationAudioSource;
	AudioSource weaponAudioSource;*/

	// Audio clips
	//AudioClip song;

	// Audio instructions
	/*	// Engines
	bool enginesAudio_playing_loud;
	bool enginesAudio_playing_low;
	float enginesAudio_volume;
	float enginesAudio_volume_set;
		// Rotation
	bool rotationAudio_playing;
	float rotationAudio_volume;
	float rotationAudio_volume_set;*/

	void Awake (){
		//song = Resources.Load ("Rick Roll", typeof(AudioClip)) as AudioClip;
	}

	void Start () {
		character = GameObject.FindWithTag ("Player");
		characterScript = character.GetComponent<CharacterScript> ();
		playerAudio = character.transform.Find ("Player Audio").gameObject;


		//Audio Sources
		characterAudioSource = playerAudio.AddComponent<AudioSource> ();
//		enginesAudioSource = playerAudio.AddComponent<AudioSource> ();
//		rotationAudioSource = playerAudio.AddComponent<AudioSource> ();
//		weaponAudioSource = playerAudio.AddComponent<AudioSource>();

		// Audio instructions
			// Engines
//		enginesAudio_playing_loud = false;
//		enginesAudio_playing_low = false;
//		enginesAudio_volume = 0;
//		enginesAudio_volume_set = 0;
			// Rotation
//		rotationAudio_playing = false;
//		rotationAudio_volume = 0;
//		rotationAudio_volume_set = 0;



	}


//	void Update () {
//		AdjustVolumes ();
//		StopAudioSources ();
//	}

/*	public void AdjustVolumes() {	//	Fade in and out for audios
		if (enginesAudio_volume != enginesAudio_volume_set){	// Engine audio
			if(enginesAudio_volume > enginesAudio_volume_set){
				enginesAudio_volume = enginesAudio_volume - Time.deltaTime;
			}
			else{
				enginesAudio_volume = enginesAudio_volume + Time.deltaTime;
			}
		}
		enginesAudioSource.volume = enginesAudio_volume;
		if (rotationAudio_volume != rotationAudio_volume_set){	// Rotation audio
			if(rotationAudio_volume > rotationAudio_volume_set){
				rotationAudio_volume = rotationAudio_volume - Time.deltaTime * 2;
			}
			else{
				rotationAudio_volume = rotationAudio_volume + Time.deltaTime * 2;
			}
		}
		rotationAudioSource.volume = rotationAudio_volume;

	}

	public void StopAudioSources (){	//	Stop audio sources when their volumes reach zero
		if (enginesAudio_volume <= 0)
			enginesAudioSource.Stop ();
		if (rotationAudio_volume <= 0)
			rotationAudioSource.Stop ();
	}

	public void EnginesAudio (string instruction){
		if (instruction == "stop sound") {
			enginesAudio_playing_loud = false;
			enginesAudio_playing_low = false;
			enginesAudio_volume_set = 0;
		}
		if (instruction == "play sound, loud" && !enginesAudio_playing_loud) {
			if (enginesAudio_volume == 0)
				enginesAudio_volume = 0.1f;
			enginesAudioSource.clip = engines_thrust;
			enginesAudioSource.Play ();
			enginesAudio_playing_loud = true;
			enginesAudio_playing_low = false;
			enginesAudio_volume_set = 1;
		}
		if (instruction == "play sound, low" && !enginesAudio_playing_low) {
			if (enginesAudio_volume == 0)
				enginesAudio_volume = 0.1f;
			enginesAudioSource.clip = engines_thrust;
			enginesAudioSource.Play ();
			enginesAudio_playing_loud = false;
			enginesAudio_playing_low = true;
			enginesAudio_volume_set = 0.5f;
		}
	}

	public void RotationAudio(string instruction){
		if (instruction == "stop sound") {
			rotationAudio_playing = false;
			rotationAudio_volume_set = 0;
		}
		if (instruction == "play sound" && !rotationAudio_playing) {
			if (rotationAudio_volume == 0)
				rotationAudio_volume = 0.1f;
			rotationAudioSource.clip = rotation_sound;
			rotationAudioSource.Play ();
			rotationAudio_playing = true;
			rotationAudio_volume_set = 1;
		}
	}
	
	public void FirePrimary (){
		weaponAudioSource.PlayOneShot(fire_laser_gun, 0.25f);
	}
	
	public void WeaponPrimaryReload(){
		weaponAudioSource.PlayOneShot(reload_laser_gun, 0.25f);
	}
	
	public void FireSecondary (){
		weaponAudioSource.PlayOneShot(fire_hs_missile, 0.25f);
	}
	
	public void WeaponSecondaryReload(){
		weaponAudioSource.PlayOneShot(reload_hs_missile, 0.25f);
	}
	*/
	
	public void PlaySong(AudioClip clip){
		characterAudioSource.PlayOneShot(clip, 0.25f);
	}
}
