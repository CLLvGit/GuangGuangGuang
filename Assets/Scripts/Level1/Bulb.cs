using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour {
    public GameObject Bulb_OFF;
    public GameObject Target_Win;
    public GameObject Bulb_Bad;
    public GameObject ChangeFaild;
    public GameObject ChangeSucceed;
	// Use this for initialization
	void Start () {
        Bulb_OFF.SetActive(true);
        Bulb_Bad.SetActive(true);
       
	}

    private void ShowThis()
    {
        Bulb_OFF.SetActive(true);
                
    }
    private void Fixed()
    {
        Bulb_Bad.GetComponent<Bulb_Bad>().Fixed();
    }
    private void GameWin()
    {
        
        this.transform.parent = Target_Win.transform.parent;
        Bulb_Bad.SetActive(false);
        GameManager.gm.GameWin();
    }
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        //手指松开时（即不再拖拽物体时）再触发，避免拖拽时经过物体直接触发
        if (this.GetComponent<PickupAndDrag>().EventCanTrigger() == false)
            return;
        if (collision.gameObject == Target_Win)
        {
            if (GameManager.gm.GetRoomNum() == 1)
            {
                Bulb_OFF.SetActive(false);
                ChangeSucceed.SetActive(true);
                Invoke("Fixed", 1f);
                Invoke("GameWin", 3f);
            }
            else
            {
                Bulb_OFF.SetActive(false);
                ChangeFaild.SetActive(true);
                Invoke("ShowThis", 1f);
                this.GetComponent<PickupAndDrag>().PickThis();
            }
        }
        

    }
    void Update () {
		
	}
}
