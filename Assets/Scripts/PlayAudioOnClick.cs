using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private void OnMouseDown(){
		this.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
