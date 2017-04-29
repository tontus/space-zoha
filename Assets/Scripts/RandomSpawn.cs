using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

	public GameObject[] collectables;
	public GameObject blackHole;
	private int maxPickup;
	private int minPickup;
	private int holeCount;
	void Start () {
		SpawnCoin();
		
	}
	 /// <summary>
	/// LateUpdate is called every frame, if the Behaviour is enabled.
	/// It is called after all Update functions have been called.
	/// </summary>
	void Update()
	{
		SpawnCoin();
		DestroyCoin();
		SpawnHole();
		DestroyHole();

	}

	void SpawnCoin(){
		GameObject[] all;
		all = GameObject.FindGameObjectsWithTag("Collectable");
		int i = 0;
		holeCount = 30 - all.Length;
		while(i<holeCount){
			int x = Random.Range(-50,50);
			int y = Random.Range(-30,30);
			while(x > -37 && x < 37 && y > -18 && y < 18){
				x = Random.Range(-50,50);
				y = Random.Range(-30,30);
			}
			// Instantiate(pickup, new Vector3(transform.position.x + x, transform.position.y + y, 0), Quaternion.identity);
			i++;
		}
	}

	void DestroyCoin(){
		GameObject[] all;
		all = GameObject.FindGameObjectsWithTag("Collectable");
		int i = 0;
		while(i < all.Length){
			Vector3 pos = all[i].transform.position;
			if (Mathf.Abs(transform.position.x - pos.x) > 50 || Mathf.Abs(transform.position.y - pos.y) > 30){
				Destroy(all[i]);
			}
			i++;
		}
	}
	
	void SpawnHole(){
		GameObject[] all;
		all = GameObject.FindGameObjectsWithTag("BlackHole");
		int i = 0;
		holeCount = 4 - all.Length;
		while(i<holeCount){
			int x = Random.Range(-50,50);
			int y = Random.Range(-30,30);
			while(x > -37 && x < 37 && y > -18 && y < 18){
				x = Random.Range(-50,50);
				y = Random.Range(-30,30);
			}
			Instantiate(blackHole, new Vector3(transform.position.x + x, transform.position.y + y, 0), Quaternion.identity);
			i++;
		}
	}
	void DestroyHole(){
		GameObject[] all;
		all = GameObject.FindGameObjectsWithTag("BlackHole");
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
