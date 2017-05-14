using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rad1Controller : MonoBehaviour {

		// void OnTriggerEnter2D(Collider2D other)
		// {
			
		// 	if(other.gameObject.CompareTag("BlackHole")){
		// 		Debug.Log("a");
		// 		Destroy(this.transform.parent.gameObject);
		// 	}
		// }
		/// <summary>
		/// Sent when an incoming collider makes contact with this object's
		/// collider (2D physics only).
		/// </summary>
		/// <param name="other">The Collision2D data associated with this collision.</param>
		void OnCollisionEnter2D(Collision2D other)
		{
			if(other.gameObject.CompareTag("BlackHole")){
				Debug.Log("a");
				Destroy(this.transform.gameObject);
			}
		}
}
