using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZohaController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	public Animator zohaAnim;
	private Vector2 lastVelocity;
	private Vector2 lastAcc;
	private int count;
	// public Text countText;
	// public Text winText;
	
	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		SetCountText ();
		// winText.text = "";
		// speed = 10.0f;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		zohaAnim.SetBool("ZohaIdle",true);
		lastVelocity = new Vector2(0,0);
		
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		
		// float moveHorizontal = Input.acceleration.x;
		// float moveVertical = Input.acceleration.y;
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		
		rb2d.AddForce (movement * speed);

		Vector2 acc = (rb2d.velocity - lastVelocity) / Time.deltaTime;

		if(acc.magnitude > lastAcc.magnitude){
			zohaAnim.SetBool("ZohaIdle",false);
			zohaAnim.SetBool("ZohaRunning",true);
		}
		else if(acc.magnitude < lastAcc.magnitude){
			zohaAnim.SetBool("ZohaIdle",true);
			zohaAnim.SetBool("ZohaRunning",false);
		}
		lastVelocity = rb2d.velocity;
		lastAcc = acc;
		
	}
	
	void Update()
	{
		 transform.up = rb2d.velocity;
		// transform.rotation = Quaternion.LookRotation(rb2d.velocity);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			Destroy(other.gameObject);
			count++;
			SetCountText ();
		} 
		if (other.gameObject.CompareTag ("Hole")) {
			
			// StartCoroutine(Example());
			
			gameObject.SetActive (false);
		
			
			if (count >= 11){
				// winText.color = Color.blue;
				// winText.text = "You Win!!";
				StoreHighscore(count);

			}
				
			else{
				// winText.color = Color.red;
				// winText.text = "Game Over";
				StoreHighscore(count);
			}
				
			
			
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
