using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Manager;

    public AudioSource clickSound;
    public AudioSource victorySound;

    private void Awake()
    {
        Manager = this;
    }

    public void PlayButtonSound()
    {
        clickSound.Play();
    }

    public void PlayVictorySound()
    {
        victorySound.Play();
    }
}