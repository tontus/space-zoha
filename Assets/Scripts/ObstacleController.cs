using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
	private float rotateAngle;
	public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		float probability = Random.Range(0.000001f,1);
		float randomSize;
		Debug.Log(probability);
		if(probability <= .11){
			randomSize = Random.Range(1.9f,3);
			transform.localScale = new Vector3 (randomSize,randomSize,1);
		}
		else{
			randomSize = Random.Range(.7f,1.8f);
			transform.localScale = new Vector3 (randomSize,randomSize,1);
		}
		rotateAngle = Random.Range(-90,90);
		transform.Rotate(new Vector3(0,0,rotateAngle));
		rb2d.mass = randomSize * 1.5f;
		rb2d.drag = randomSize;

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,0,rotateAngle) * Time.deltaTime);
	}
}
