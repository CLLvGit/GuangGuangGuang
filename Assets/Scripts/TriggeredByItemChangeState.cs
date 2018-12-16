using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredByItemChangeState : MonoBehaviour {
	public static int StateCount;
	public float WaitAnimaTime;
	private int TriggerState;
	private Collider2D InteratedCollider;
    public GameObject[] NeedItem = new GameObject[StateCount];
    public GameObject[] IntoState = new GameObject[StateCount];
	//会有这么一种情况：当一个角色离开这个场景时几个道具变成可交互的。
	//现在只实现了一个道具变成可交互
	public GameObject[] UnlockItem = new GameObject[StateCount];
	// Use this for initialization
	void Start () {
		if(!this.GetComponent<BoxCollider2D>()){
			Debug.Log("<TICS.cs>: " + this.name + " need a BoxCollider2D");
		}
		StateCount = NeedItem.Length;
		int i;
		// Hide all inactive states
		for(i = 0;i < StateCount; i++){
			// Debug.Log("<TICS.cs>: " + IntoState[i].name + " INACTIVE");
			IntoState[i].SetActive(false);
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other){
		Debug.Log("<TICS.cs>: " + this.name + " Activated");
		for(var i = 0;i < StateCount; i++){
			if(NeedItem[i].GetComponent<BoxCollider2D>() == other){
				// Debug.Log("trigger state:" + NeedItem[i].name);
				TriggerState = i; 
				if(UnlockItem[i]) UnlockItem[i].SendMessage("Unlocked");
				InteratedCollider = other;
				Invoke("HideAndRevealed",WaitAnimaTime);
				break;
			}
		}
	}
	private void HideAndRevealed(){
		// InteratedCollider.GetComponent<SpriteRenderer>().sprite = null;
		InteratedCollider.gameObject.SetActive(false);
		this.gameObject.SetActive(false);
		IntoState[TriggerState].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
