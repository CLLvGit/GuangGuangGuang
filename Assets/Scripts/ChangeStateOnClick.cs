﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateOnClick : MonoBehaviour {
	[Tooltip("Can state changed reversly")]
	public bool Locked;
	public static int ItemCount;
	[Tooltip("Element [0] is the default state")]
	[SerializeField]
	public GameObject[] states = new GameObject[ItemCount];
	private int ClickCount = 0;

	// Use this for initialization
	void Start () {
		ItemCount = states.Length;
		states[ClickCount].SetActive(true);
		for(int i = ClickCount + 1;i < ItemCount; i++){
			states[i].SetActive(false);
		}
	}

	private void OnMouseDown(){
		states[ClickCount % ItemCount].SetActive(false);
		ClickCount ++;
		states[ClickCount % ItemCount].SetActive(true);
		if(Locked){
		 	this.GetComponent<BoxCollider2D>().enabled=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
