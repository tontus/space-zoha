using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnBlackhole : MonoBehaviour
{
    public GameObject blackHole;
    private Vector3 spawnPoint;
    float sizeOfHoleWidth;
    float sizeOfHoleLength;
    List<Vector3> SpotsTaken = new List<Vector3>();
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        GameObject[] all;
        all = GameObject.FindGameObjectsWithTag("BlackHole");
        if (all.Length < 4)
        {
            // InvokeRepeating("SpawnHole", 1, .5f);
            SpawnHole();
        }
		DestroyHole(all);
    }


    void SpawnHole()
    {

        spawnPoint.x = Random.Range(-50, 50);
        spawnPoint.y = Random.Range(-30, 30);
        spawnPoint.z = 0;
        while (spawnPoint.x > -37 && spawnPoint.x < 37 && spawnPoint.y > -18 && spawnPoint.y < 18)
        {
            spawnPoint.x = Random.Range(-50, 50);
            spawnPoint.y = Random.Range(-30, 30);
        }
		spawnPoint.x += transform.position.x;
		spawnPoint.y += transform.position.y;
        sizeOfHoleWidth = 20;
        sizeOfHoleLength = 20;
        foreach (Vector3 SpotTaken in SpotsTaken)
        {
            if (spawnPoint.x >= SpotTaken.x - sizeOfHoleWidth && spawnPoint.x <= SpotTaken.x + sizeOfHoleWidth)
            {
                if (spawnPoint.y >= SpotTaken.y - sizeOfHoleLength && spawnPoint.y <= SpotTaken.y + sizeOfHoleLength)
                {
                    SpawnHole(); //If the width or length is near another one of these objects, then it tries again
                    return;
                }
            }
        }
        SpotsTaken.Add(spawnPoint);


        Instantiate(blackHole, spawnPoint, Quaternion.identity);
        CancelInvoke();
    }
    void DestroyHole(GameObject[] all)
    {
        
        // while (i < all.Length)
        foreach (GameObject hole in all)
        {
            Vector3 pos = hole.transform.position;
            if (Mathf.Abs(transform.position.x - pos.x) > 50 || Mathf.Abs(transform.position.y - pos.y) > 30)
            {

                SpotsTaken.Remove(pos);
                Destroy(hole);
            }

        }
    }
}
