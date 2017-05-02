using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rad1controller : MonoBehaviour {

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag ("Collectable") || other.gameObject.CompareTag("Obstacle")){
			Destroy(other.gameObject);
		}
		if(other.gameObject.CompareTag ("Player")){
			yield return new WaitForSeconds(2);
			Debug.Log("done");
        // SceneManager.LoadScene("StartScene");
		}
	}
}
