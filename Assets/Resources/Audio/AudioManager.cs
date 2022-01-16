using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioList;
    private AudioSource source;
    private int currentClip;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        // PLAY AT START
        
    }
    public string GetCurrentClipInfo()
    {
        AudioClip clip = audioList[currentClip];
        return clip.name;
    }

    public void PlayClip()
    {
        if(source.isPlaying)
        {
            StopClip();
            return;
        }
        currentClip--;
        if(currentClip < 0)
        {
            currentClip = audioList.Length - 1;
        }
        StartCoroutine(WaitForAudioEnd());
        NextClip();
    }

    IEnumerator WaitForAudioEnd()
    {
        // If we are playing
        while(source.isPlaying)
        {
            yield return null;
        }
    }

    public void NextClip()
    {
        source.Stop();
        currentClip++;
        if(currentClip > audioList.Length-1)
        {
            currentClip = 0;
        }
        source.clip = audioList[currentClip];
        source.Play();
        StartCoroutine(WaitForAudioEnd());
    }

    public void PreviousClip()
    {
        source.Stop();
        currentClip--;
        if (currentClip < 0)
        {
            currentClip = audioList.Length - 1;
        }
        source.clip = audioList[currentClip];
        source.Play();
        StartCoroutine(WaitForAudioEnd());
    }

    public void PauseClip()
    {
        if(source.isPlaying)
        {
            source.Pause();
            StopCoroutine("WaitForAudioEnd");
        } else
        {
            source.Play();
            StartCoroutine(WaitForAudioEnd());
        }
        
    }

    public void StopClip()
    {
        StopCoroutine("WaitForAudioEnd");
        if (source.isPlaying)
        {
            source.Stop();
        }
    }

}
