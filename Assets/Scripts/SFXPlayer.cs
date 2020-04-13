using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioClip Dig;
    public AudioClip DigFinish;
    public AudioClip Coin;
    public AudioClip Die;

    public AudioSource audio_F;

    public void SoundManager_F(string audioName)
    {

        if (audioName == "Dig")
        {
            audio_F.PlayOneShot(Dig);
        }

        if (audioName == "DigFinish")
        {
            audio_F.PlayOneShot(DigFinish);
        }

        if (audioName == "Coin")
        {
            audio_F.PlayOneShot(Coin);
        }

        if (audioName == "Die")
        {
            audio_F.PlayOneShot(Die);
        }
    }
}
