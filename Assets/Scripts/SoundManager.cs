using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [Header("-------------------Audio Clip--------------")]
    public AudioClip coins, swords, destroy , key ,soi , jup , kick , bump, background;
	[Header ("-------------------Audio Source--------------")]
	public AudioSource adisrc, bgAudioSource;
	// Use this for initialization
	void Start () {
		coins = Resources.Load<AudioClip>("Gamecoin");
		swords = Resources.Load<AudioClip>("Sword");
		destroy = Resources.Load<AudioClip>("RockCrash");
		key = Resources.Load<AudioClip> ("coin");
		soi = Resources.Load<AudioClip> ("fireball");
		jup = Resources.Load<AudioClip> ("jup");
		kick = Resources.Load<AudioClip> ("kick");
		bump = Resources.Load<AudioClip> ("bump");
		adisrc = GetComponent<AudioSource>();
        background = Resources.Load<AudioClip>("background"); // Load background music

        adisrc = GetComponent<AudioSource>();

        // Create a separate AudioSource for background music
        bgAudioSource = gameObject.AddComponent<AudioSource>();
        bgAudioSource.clip = background;
        bgAudioSource.loop = true; // Make it loop
        bgAudioSource.volume = 0.5f; // Adjust volume if needed
        bgAudioSource.Play(); // Start playing
    }

	public void Playsound(string clip)
	{
		switch (clip)
		{
		case "coins":
			adisrc.clip = coins;
			adisrc.PlayOneShot(coins, 0.6f);
			break;

		case "destroy":
			adisrc.clip = destroy;
			adisrc.PlayOneShot(destroy, 1f);
			break;

		case "sword":
			adisrc.clip = swords;
			adisrc.PlayOneShot(swords, 1f);
			break;
		case "key":
			adisrc.clip = key;
			adisrc.PlayOneShot(key, 0.6f);
			break;
		case "soi":
			adisrc.clip = soi;
			adisrc.PlayOneShot(soi, 0.6f);
			break;
		case "jup":
			adisrc.clip = jup;
			adisrc.PlayOneShot(jup, 1f);
			break;
		case "kick":
			adisrc.clip = kick;
			adisrc.PlayOneShot(kick, 0.6f);
			break;
		case "bump":
			adisrc.clip = bump;
			adisrc.PlayOneShot(bump, 0.6f);
			break;

		}
	}
}
