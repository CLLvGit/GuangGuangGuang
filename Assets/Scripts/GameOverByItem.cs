using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverByItem : MonoBehaviour {
	public GameObject target_item;
	public string SystemAnnoucement;
	public GameObject SystemMessageBox;

	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerEnter2D(Collider2D other){
		Debug.Log("<GameOverByItem.cs>: " + this.name + " Activated");
		if(target_item.GetComponent<BoxCollider2D>() == other){
			GameObject.Find("GameManager").SendMessage("SetFailed");
			other.gameObject.SetActive(false);
			SystemMessageBox.GetComponent<Text>().text = SystemAnnoucement;
			SystemMessageBox.SendMessage("Display");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
