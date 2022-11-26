using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //use, AudioManager.manager.Play("string") or AudioManager.manager.PlayOneShot("string") to play audio in script
    public Sound[] sounds;

    public static AudioManager manager;


    void Awake()
    {
        if (AudioManager.manager == null)
        {
            AudioManager.manager = this;
        }
        else
        {
            Destroy(this);
        }


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
    }

    void Start()
    {
        //add when you get themesong audio
        //Play(name of theme)
    }

    //sound cant be overriden
    public void Play(string name)
    {
        //finds sound with name param inside of sounds list and sets it to variabel s
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    //sound can be overriden
    public void PlayOneShot(string name)
    {
        //finds sound with name param inside of sounds list and sets it to variabel s
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.PlayOneShot(s.clip);
    }
}
