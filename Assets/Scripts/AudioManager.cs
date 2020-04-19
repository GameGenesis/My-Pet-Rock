using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource[] droplets;

    [SerializeField] float minTimeBtwDroplets = 0.3f;
    [SerializeField] float maxTimeBtwDroplets = 8f;

    float timeBtwDroplets;
    float time = 3;

    [SerializeField] AudioSource[] spookyWhisperSounds;
    [SerializeField] float minTimeBtwWhisper = 30f;
    [SerializeField] float maxTimeBtwWhisper = 45f;

    float timeBtwWhisper;
    float time2 = 37.5f;

    void Start()
    {
        timeBtwDroplets = Random.Range(minTimeBtwDroplets, maxTimeBtwDroplets);
        timeBtwWhisper = Random.Range(minTimeBtwWhisper, maxTimeBtwWhisper);
    }

    void Update()
    {

        if (time <= 0)
        {
            time = timeBtwDroplets;
            int dropletIndex = Random.Range(0, droplets.Length - 1);
            droplets[dropletIndex].pitch = Random.Range(0.1f, 3f);
            droplets[dropletIndex].Play();
            timeBtwDroplets = Random.Range(minTimeBtwDroplets, maxTimeBtwDroplets);
        }
        else
        {
            time -= Time.deltaTime;
        }

        if (time2 <= 0)
        {
            time2 = timeBtwWhisper;
            PlayHorrorSound();
            timeBtwWhisper = Random.Range(minTimeBtwWhisper, maxTimeBtwWhisper);
        }
        else
        {
            time2 -= Time.deltaTime;
        }
    }

    public void PlayHorrorSound()
    {
        spookyWhisperSounds[Random.Range(0, spookyWhisperSounds.Length - 1)].Play();
    }
}
