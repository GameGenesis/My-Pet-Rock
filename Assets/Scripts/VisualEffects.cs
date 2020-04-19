using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffects : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;

    [SerializeField] float minTimeBtwSpawn = 5f;
    [SerializeField] float maxTimeBtwSpawn = 20f;
    [SerializeField] float minXPos = -200;
    [SerializeField] float maxXPos = 200;

    float timeBtwSpawn;
    float time = 10;

    void Update()
    {
        timeBtwSpawn = Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn);

        if (time <= 0)
        {
            time = timeBtwSpawn;
            int prefabIndex = Random.Range(0, prefabs.Length - 1);

            Vector3 locationToSpawn = new Vector3(Random.Range(minXPos, maxXPos), 15, 0);

            GameObject prefab = Instantiate(prefabs[prefabIndex], locationToSpawn, Quaternion.Euler(0, 0, Random.Range(-359, 359)));
            Destroy(prefab, 20f);

        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
