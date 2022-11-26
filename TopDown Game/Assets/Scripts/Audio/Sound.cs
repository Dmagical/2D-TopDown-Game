using UnityEngine.Audio;
using UnityEngine;

//allows for class to be seen in inspector
[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    //[Range()] shows a slider from indicated rnages in the inspector
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    //allthough var is public, "[HideInInspector]" makes it so it doesnt show in inspector
    [HideInInspector]
    public AudioSource source;




}
