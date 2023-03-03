using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    public GameObject Audio, audioMuted;
    public void Mute() 
    {
        audioMuted.SetActive(true);
        Audio.SetActive(false);
        AudioListener.pause = true;
    }

    public void OpenAudio() 
    {
        audioMuted.SetActive(false);
        Audio.SetActive(true);
        AudioListener.pause = false;
    }
}
