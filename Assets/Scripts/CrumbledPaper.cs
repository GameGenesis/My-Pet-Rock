using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CrumbledPaper : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
    }
}
