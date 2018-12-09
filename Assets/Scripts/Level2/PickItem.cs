using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour {
	public bool TrueItem;
	public bool EndGame;
	public float WaitAnimaTime;
	public float LastAnimaTime;
	//public GameObject Item;
	public GameObject Reaction;
	// Use this for initialization
	void Start () {
		
	}
	
	private void OnMouseDown(){
		this.GetComponent<SpriteRenderer>().sprite = null;
		this.GetComponent<BoxCollider2D>().enabled = false;
		Invoke("ShowReaction",WaitAnimaTime);
		if(EndGame){
		GameManager.gm.Block();
		Invoke("ItemGetGameClear",LastAnimaTime);}
	}

	private void ShowReaction(){
		Reaction.SetActive(true);
		if(TrueItem) GameObject.Find("GameManager").SendMessage("SpritesChange");
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
