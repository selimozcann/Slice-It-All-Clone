using System.Collections;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip sliceClip;

    public void OnStopShot(bool isMute)
    {
        audioSource.mute = isMute;
    }
    public void OnSliceSound()
    {
        StartCoroutine(OnSliceSoundCoroutine());
    }
    private IEnumerator OnSliceSoundCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        OnStopShot(false);
        audioSource.clip = sliceClip;
        audioSource.Play();
    }
    public void OnSoundPlay()
    {
        OnSliceSound();
    }
}
