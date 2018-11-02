using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Close : MonoBehaviour {
    public GameObject Bulb;
    public GameObject CupBoard_Open;
    public GameObject CupBoard_Close;
    public enum State { Open, Close };
    public State StartStates;
    private bool Open;

    private void Switch(bool s)
    {
        CupBoard_Close.SetActive(s);
        CupBoard_Open.SetActive(!s);
        Open = s;
        if (Bulb != null && Bulb .transform .parent == this.transform)
            Bulb.SetActive(!s);
    }
	// Use this for initialization
	void Start () {
        if (StartStates == State.Open)
            Switch(false);
        else
            Switch(true);
    }
    
    private void OnMouseDown()
    {
        if(Open)
        {
            Switch(false);
        }
        else
        {
            Switch(true);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    
}
