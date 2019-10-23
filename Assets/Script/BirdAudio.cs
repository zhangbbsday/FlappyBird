using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAudio : MonoBehaviour
{
    public AudioClip fly;
    public AudioClip point;
    public AudioClip hit;
    public AudioClip died;

    public static AudioSource AudioControl
    {
        get
        {
            if (audioControl == null)
            {
                GameObject obj = new GameObject("AudioControl");
                obj.AddComponent<AudioSource>();
                obj.AddComponent<BirdAudio>();
                audioControl = obj.GetComponent<AudioSource>();
            }
            return audioControl;
        }
    }
    private static AudioSource audioControl;
    void Start()
    {
        audioControl = GetComponent<AudioSource>();
    }
}
