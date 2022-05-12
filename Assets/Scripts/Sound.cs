using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] stepClips;
    private AudioSource sourceRun;
    void Start()
    {
        sourceRun = GetComponent<AudioSource>();
    }

    public void PlaySoundRun(){
        sourceRun.PlayOneShot(stepClips[Random.Range(0, 2)]);
    }
}
