using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallSound : MonoBehaviour
{
    [SerializeField] private AudioClip _awake;
    [SerializeField] private AudioClip _collision;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundAwake()
    {
        _audioSource.PlayOneShot(_awake);
    }

    public void PlaySoundCollision()
    {
        _audioSource.PlayOneShot(_collision);
    }
}
