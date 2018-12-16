using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//这个脚本由于在点击时改变同一物体的状态
//如果物品是CantRepeat的，意味着不能够状态往返
//如果物品是Locked的，意味着物品由于一些原因不能打开，并会发送系统提示

public class ChangeStateOnClick : MonoBehaviour {
	[Tooltip("Can state changed reversly")]
	public bool CantRepeat;
	public bool Locked = false;
	public string LockedAnnoucement;
	public GameObject SystemMessageBox;
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

	private void Unlocked(){
		Locked = false;
	}

	private void OnMouseDown(){
		if(Locked){
			SystemMessageBox.GetComponent<Text>().text = LockedAnnoucement;
			SystemMessageBox.SendMessage("Display");
		}
		else{
			states[ClickCount % ItemCount].SetActive(false);
			ClickCount ++;
			states[ClickCount % ItemCount].SetActive(true);
			if(CantRepeat){
		 		this.GetComponent<BoxCollider2D>().enabled=false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
