﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHoleController : MonoBehaviour {

	// Use this for initialization

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag ("Collectable") || other.gameObject.CompareTag ("BlackHole")){
			Destroy(other.gameObject);
		}
	}

	
}
