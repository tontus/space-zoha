using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rad2controller : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
			if(other.gameObject.CompareTag ("BlackHole")){
				Destroy(other.gameObject);
				Debug.Log("adslkfj");
			}
		}
}
