using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class ZohaAlwaysRunningController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	private int count;
	// public Text countText;
	// public Text winText;
	
	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
		// rb2d.centerOfMass = transform.GetChild (0).gameObject.transform.position;
		// count = 0;
		SetCountText ();
		// winText.text = "";
		// speed = 10.0f;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
	}

	void FixedUpdate(){
		float moveHorizontal; 
		float moveVertical; 
		

		//for pc control
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
		//for sensor control
		moveHorizontal = Input.acceleration.x;
		moveVertical = Input.acceleration.y;
		//for mobile controller 
		moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		
		rb2d.AddForce (movement * speed); 
		
	}
	
	void Update()
	{
		 transform.up = rb2d.velocity;
		// transform.rotation = Quaternion.LookRotation(rb2d.velocity);
	}

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Collectable")) {
			Destroy(other.transform.parent.gameObject);
			count++;
			
		} 
	}

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

