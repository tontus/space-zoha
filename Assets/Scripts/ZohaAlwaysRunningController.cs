using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZohaAlwaysRunningController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	// private int count;
	// public Text countText;
	// public Text winText;
	
	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
		// count = 0;
		SetCountText ();
		// winText.text = "";
		// speed = 10.0f;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		
		// float moveHorizontal = Input.acceleration.x;
		// float moveVertical = Input.acceleration.y;
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		
		rb2d.AddForce (movement * speed); 
		
	}
	
	void Update()
	{
		 transform.up = rb2d.velocity;
		// transform.rotation = Quaternion.LookRotation(rb2d.velocity);
	}

	// void OnTriggerEnter2D(Collider2D other) {
	// 	if (other.gameObject.CompareTag ("Collectable")) {
	// 		Destroy(other.gameObject);
	// 		count++;
	// 		SetCountText ();
	// 	} 
	// 	if (other.gameObject.CompareTag ("BlackHole")) {
			
	// 		// StartCoroutine(Example());
			
	// 		gameObject.SetActive (false);
		
			
	// 		if (count >= 11){
	// 			// winText.color = Color.blue;
	// 			// winText.text = "You Win!!";
	// 			StoreHighscore(count);

	// 		}
				
	// 		else{
	// 			// winText.color = Color.red;
	// 			// winText.text = "Game Over";
	// 			StoreHighscore(count);
	// 		}
				
			
			
	// 	}
	// }

	 void StoreHighscore(int newHighscore){
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighscore > oldHighscore)
			PlayerPrefs.SetInt("highscore", newHighscore);
 	}

	void SetCountText(){
		// countText.text = "Count " + count.ToString ();
//		if (count >= 12) {
//			winText.text = "You Win!!!"; 
//		}
	}
}

