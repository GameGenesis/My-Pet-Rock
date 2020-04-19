using UnityEngine;
using System.Collections;

public class WeightCollider : MonoBehaviour
{
    [SerializeField] GameObject weight;

    [SerializeField] float timeFlexibility = 0.5f;

    bool hasEntered;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasEntered && collision.CompareTag("Player"))
        {
            hasEntered = true;
            FindObjectOfType<AudioManager>().PlayHorrorSound();
            StartCoroutine(ThrowWeight());
        }
    }

    IEnumerator ThrowWeight()
    {
        yield return new WaitForSeconds(timeFlexibility);
        weight.SetActive(true);
        Destroy(gameObject);
    }
}
