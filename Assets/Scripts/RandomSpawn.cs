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
		collectableCount = 45 - all.Length;
		while(i<collectableCount){
			int x = Random.Range(-100,100);
			int y = Random.Range(-60,60);
			while(x > -50 && x < 50 && y > -25 && y < 25){
				x = Random.Range(-100,100);
				y = Random.Range(-60,60);
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
			if (Mathf.Abs(transform.position.x - pos.x) > 100 || Mathf.Abs(transform.position.y - pos.y) > 60){
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
		obstacleCount = 12 - all.Length;
		while(i<obstacleCount){
			int x = Random.Range(-100,100);
			int y = Random.Range(-60,60);
			while(x > -50 && x < 50 && y > -25 && y < 25){
				x = Random.Range(-100,100);
				y = Random.Range(-60,60);
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
			if (Mathf.Abs(transform.position.x - pos.x) > 100 || Mathf.Abs(transform.position.y - pos.y) > 60){
				Destroy(all[i]);
			}
			i++;
		}
	}
	
	

}
