using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}
	
	public void Unlocked(){
		this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
