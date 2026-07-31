using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource sfxSource;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip clearClip;
    [SerializeField] private AudioClip oneUpClip;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpClip);
    }

    public void PlayHit()
    {
        sfxSource.PlayOneShot(hitClip);
    }

    public void PlayClear()
    {
        sfxSource.PlayOneShot(clearClip);
    }

    public void Play1UP()
    {
        if (oneUpClip != null)
        {
            sfxSource.PlayOneShot(oneUpClip);
        }
    }
}