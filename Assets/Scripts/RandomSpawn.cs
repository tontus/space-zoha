using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

	public GameObject[] collectables;
	public GameObject[] obstacles;
	
	private int maxPickup;
	private int minPickup;
	
	void Start () {
		SpawnCollectables();
		
	}
	 /// <summary>
	/// LateUpdate is called every frame, if the Behaviour is enabled.
	/// It is called after all Update functions have been called.
	/// </summary>
	void Update()
	{
		SpawnCollectables();
		SpawnObstacles();
		DestroyCollectables();
		DestroyObstacles();

	}

	void SpawnCollectables(){
		int collectableCount;
		GameObject[] all;
		all = GameObject.FindGameObjectsWithTag("Collectable");
		int i = 0;
		collectableCount = 20 - all.Length;
		while(i<collectableCount){
			int x = Random.Range(-50,50);
			int y = Random.Range(-30,30);
			while(x > -37 && x < 37 && y > -18 && y < 18){
				x = Random.Range(-50,50);
				y = Random.Range(-30,30);
			}
			Instantiate(collectables[Mathf.Abs(Random.Range(0,6))], new Vector3(transform.position.x + x, transform.position.y + y, 0), Quaternion.identity);
			i++;
		}
	}

	void DestroyCollectables(){
		GameObject[] all;
		all = GameObject.FindGameObjectsWithTag("Collectable");
		int i = 0;
		while(i < all.Length){
			Vector3 pos = all[i].transform.position;
			if (Mathf.Abs(transform.position.x - pos.x) > 50 || Mathf.Abs(transform.position.y - pos.y) > 30){
				Destroy(all[i].transform.parent.gameObject);
			}
			i++;
		}
	}
	void SpawnObstacles(){
		int obstacleCount;
		GameObject[] all;
		all = GameObject.FindGameObjectsWithTag("Obstacle");
		int i = 0;
		obstacleCount = 5 - all.Length;
		while(i<obstacleCount){
			int x = Random.Range(-50,50);
			int y = Random.Range(-30,30);
			while(x > -37 && x < 37 && y > -18 && y < 18){
				x = Random.Range(-50,50);
				y = Random.Range(-30,30);
			}
			Instantiate(obstacles[Mathf.Abs(Random.Range(0,4))], new Vector3(transform.position.x + x, transform.position.y + y, 0), Quaternion.identity);
			i++;
		}
	}

	void DestroyObstacles(){
		GameObject[] all;
		all = GameObject.FindGameObjectsWithTag("Obstacle");
		int i = 0;
		while(i < all.Length){
			Vector3 pos = all[i].transform.position;
			if (Mathf.Abs(transform.position.x - pos.x) > 50 || Mathf.Abs(transform.position.y - pos.y) > 30){
				Destroy(all[i]);
			}
			i++;
		}
	}
	
	

}
