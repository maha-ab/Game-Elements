using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip tvNoise,
                     tvTurnOnOFF,
                      doorUnlock,
                     waterDrop,
                     mateilDoorOpen,
                     mateilDoorClose,
                     pol,
                     windowNoise,
                     nightSound,
                     kidsToy;

    public AudioSource audioSource2D,
                       tvAudioSource;
                      // sinkAudioSorce,
                   // fridgeAudioSource;


   /* public void GirlScrem()
    {

    }*/

    public void DoorUnlock()
    {
        audioSource2D.PlayOneShot(doorUnlock);
    }

    public void LockerDoorOpen()
    {
        audioSource2D.PlayOneShot(mateilDoorOpen);
    }

    public void LockerDoorClose()
    {
        audioSource2D.PlayOneShot(mateilDoorClose);
    }

    public void TvOpen()
    {
        audioSource2D.PlayOneShot(tvTurnOnOFF);
        StartCoroutine("TvNoise");
    }
    public void TvClose()
    {
        audioSource2D.PlayOneShot(tvTurnOnOFF);
        StartCoroutine(Cc());

    }

    IEnumerator TvNoise()
    {
        yield return new WaitForSeconds(0.2f);
        tvAudioSource.PlayOneShot(tvNoise);
       
    }
    IEnumerator Cc()
    {
        yield return new WaitForSeconds(0.2f);
        tvAudioSource.Stop();
    }

}
