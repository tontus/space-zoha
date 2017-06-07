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

        spawnPoint.x = Random.Range(-70, 70);
        spawnPoint.y = Random.Range(-40, 40);
        spawnPoint.z = 0;
        if (spawnPoint.x > -47 && spawnPoint.x < 47 && spawnPoint.y > -28 && spawnPoint.y < 28)
        {
           SpawnHole();
           return;
        }
		spawnPoint.x += transform.position.x;
		spawnPoint.y += transform.position.y;
        sizeOfHoleWidth = 30;
        sizeOfHoleLength = 30;
        foreach (Vector3 SpotTaken in SpotsTaken)
        {
            if ((spawnPoint.x >= SpotTaken.x - sizeOfHoleWidth && spawnPoint.x <= SpotTaken.x + sizeOfHoleWidth))
            {
                if ((spawnPoint.y >= SpotTaken.y - sizeOfHoleLength && spawnPoint.y <= SpotTaken.y + sizeOfHoleLength))
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
            if (Mathf.Abs(transform.position.x - pos.x) > 70 || Mathf.Abs(transform.position.y - pos.y) > 40)
            {

                SpotsTaken.Remove(pos);
                Destroy(hole);
            }

        }
    }
}
