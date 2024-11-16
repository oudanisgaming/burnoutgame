using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pencil;
    [SerializeField]
    private GameObject negativeItem; // Add the negative item prefab

    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(pencil, posToSpawn, Quaternion.identity);

            // Spawn a negative item at random intervals
            if (Random.Range(0, 2) == 0) // 50% chance to spawn
            {
                Vector3 negativePosToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
                Instantiate(negativeItem, negativePosToSpawn, Quaternion.identity);
            }

            yield return new WaitForSeconds(5.0f); // Adjust spawn rate as needed
        }
    }

    public void FullPoints()
    {
        _stopSpawning = true;
    }
}
