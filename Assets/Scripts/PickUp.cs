using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("点击" + this.name);
        this.transform.parent = GameObject.Find("ToolBar").transform ;
        //在GameManager中添加一个变量保存道具栏的物品数量，用于控制道具在道具栏的位置
        //此处先直接将道具加入道具栏
        this.transform.position = GameObject.Find("target1").transform.position;
    
    }
}
