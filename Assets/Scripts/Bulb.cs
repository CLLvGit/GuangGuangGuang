using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour {
    public GameObject Bulb_On;
    public GameObject Bulb_OFF;
    public GameObject Target;
    public GameObject Bulb_Bad;
    private bool state;
	// Use this for initialization
	void Start () {
        state = false;
        Switch(state);
        Bulb_Bad.SetActive(true);
       
	}
	private void Switch(bool state)
    {
        Bulb_On.SetActive(state);
        Bulb_OFF.SetActive(!state);
    }
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        //手指松开时（即不再拖拽物体时）再触发，避免拖拽时经过物体直接触发
        if (this.GetComponent<PickupAndDrag>().EventCanTrigger() == false)
            return;
        if (collision.gameObject == Target)
        {
            state = true;
            Switch(state);
            Bulb_Bad.SetActive(false);
            GameManager.gm.GameWin();
        }

    }
    void Update () {
		
	}
}
