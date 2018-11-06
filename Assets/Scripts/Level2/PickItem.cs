using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour {
	public bool TrueItem;
	public GameObject Item;
	public GameObject Reaction;
	// Use this for initialization
	void Start () {
		
	}
	
	private void OnMouseDown(){
		Item.GetComponent<SpriteRenderer>().sprite = null;
		Item.GetComponent<BoxCollider2D>().enabled = false;
		GameManager.gm.Block();
		Invoke("ShowReaction",1f);
		Invoke("ItemGetGameClear",3f);
	}

	private void ShowReaction(){
		Reaction.SetActive(true);
	}

	private void ItemGetGameClear(){
		if(TrueItem){
			GameManager.gm.GameWin();
		}
		else{
			GameManager.gm.GameFaild();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
