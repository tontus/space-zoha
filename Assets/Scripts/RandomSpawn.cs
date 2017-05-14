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
		Vector2[] positions = new Vector2[4];
		for(i=0; i< all.Length;i++){
			positions[i] = all[i].transform.position;
		}
		Debug.Log(all.Length);

		bool tag;
		bool[] flag = new bool[4];
		for(i=0; i< all.Length;i++){
			flag[i] = true;
		}
		while(i < holeCount){
			int x = Random.Range(-50,50);
			int y = Random.Range(-30,30);
			int j = 0;
			
			for (j = 0; j < all.Length; j++)
				if (Vector2.Distance(positions[j],new Vector2(transform.position.x +x, transform.position.y + y)) <30)
					break;
			
			
			if(j==all.Length)
				{
					
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
