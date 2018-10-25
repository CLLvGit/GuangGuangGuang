using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrag : MonoBehaviour {
    private bool Picked = false;
    private bool isDraging = false;
    private Vector3 lastMousePosition = Vector3.zero;
	// Use this for initialization
	void Start () {
        Picked = false;
        isDraging = false;
        lastMousePosition = Vector3.zero;

        this.transform.parent = GameObject.Find("Room").transform;
    }

    public void EnterToolBar()
    {
        this.transform.parent = GameObject.Find("ToolBar").transform;
        //在GameManager中添加一个变量保存道具栏的物品数量，用于控制道具在道具栏的位置
        //此处先直接将道具加入道具栏
        this.transform.position = GameObject.Find("target1").transform.position;
        
    }
    private void OnMouseDown()
    {
        if (Picked)
            return;

        EnterToolBar();
    }

    private void OnMouseDrag()
    {
        isDraging = true;
    }

    private void OnMouseUp()
    {
        isDraging = false;
        if (!Picked)
        {           
            Picked = true;
        }
        else
        {
            Debug.Log("UPUP");
            this.transform.parent = GameObject.Find("Room").transform;
            lastMousePosition = Vector3.zero;
            Picked = false;

        }
    }
    public void Draging()
    {
        if (lastMousePosition != Vector3.zero)
        {
            Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
            this.transform.position += offset;
        }
        lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Update()
    {
        if (Picked && isDraging)
        {
            Draging();
        }
    }
    
}
