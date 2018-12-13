using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_6_getTool : MonoBehaviour {
    private GameObject Daddy;
    private bool Got; //是否已经获得

    public GameObject Target;
    public bool Chopstick;
	// Use this for initialization
	void Start () {
        Daddy = GameObject.Find("Daddy");
        Got = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Got)
            return;
        //手指松开时（即不再拖拽物体时）再触发，避免拖拽时经过物体直接触发
        if (this.GetComponent<PickupAndDrag>().EventCanTrigger() == false)
            return;
        if (collision.gameObject == Target)
        {
            Destroy(this.GetComponent<PickupAndDrag>());
            if (!Chopstick) //这个道具不是筷子
                Daddy.GetComponent<Level_6_Dad>().GetTool();
            else //这个道具是筷子
                Daddy.GetComponent<Level_6_Dad>().GetChopstick();
            Got = true;
        }
    }
}
