using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weight : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();

        if (collision.collider.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collision.collider.CompareTag("Crate"))
        {
            Destroy(collision.gameObject);
        }
    }
}
