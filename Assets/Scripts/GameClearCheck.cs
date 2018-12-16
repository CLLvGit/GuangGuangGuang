using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//几关的写法都不太一样就又自己写了一个
//现在通关要做的事情有点多又写在好几个脚本里
//试试能不能用这个整合一下

//假设通关条件是某个GameObject被激活

public class GameClearCheck : MonoBehaviour {
	public GameObject GameClearObject;
	public float WaitTillClear = 2f;

	IEnumerator SetClear() {
		yield return new WaitForSeconds(WaitTillClear);
		this.SendMessage("GameWin");
	}

	// Use this for initialization
	void Start () {
		
	}

	private void GameClear(){
		this.SendMessage("SpritesChange");
		this.SendMessage("Block");
		StartCoroutine("SetClear");
	}
	
	// Update is called once per frame
	void Update () {
		if(GameClearObject.activeSelf) GameClear();
	}
}
