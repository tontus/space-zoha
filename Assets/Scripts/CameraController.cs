using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public GameObject Zoha;
	private Vector3 offset;
	void Start () {
		offset = transform.position - Zoha.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Zoha.transform.position + offset;
	}
}
