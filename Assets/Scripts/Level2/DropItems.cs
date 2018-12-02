using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour {
	const int ItemCount = 3;
	public bool DontDisplayItem;
	public GameObject[] items = new GameObject[ItemCount];
	private int DropCount = 0;//an item appear everytime player clicks
	private bool NeedFreeze = false;//if NeedFreeze == true, none of items can be triggered
	// Use this for initialization
	void Start () {
		 if(DontDisplayItem){
			foreach(GameObject item in items){
				item.SetActive(false);
			}
		}
		
	}
	
	private void OnMouseDown(){
		
		if(DropCount<ItemCount){
			Debug.Log("OnMouseDown().");
			items[DropCount++].SetActive(true);
			}
	}

	// Update is called once per frame
	void Update () {
		foreach(GameObject item in items){
			if(!item.GetComponent<BoxCollider2D>().enabled){
				NeedFreeze = true;
			}
		}
		if(NeedFreeze){
			this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			foreach(GameObject item in items){
				//turn off box collider
				item.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}
}
