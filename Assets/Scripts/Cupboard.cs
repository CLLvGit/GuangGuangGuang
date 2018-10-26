using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour {
    public GameObject Bulb;
    public GameObject CupBoard_Open;
    public GameObject CupBoard_Close;
    private bool Open;
	// Use this for initialization
	void Start () {
        CupBoard_Close.SetActive(true);
        CupBoard_Open.SetActive(false);
        Open = false;
        Bulb.SetActive(false);
    }
    private void OnMouseDown()
    {
       if(!Open)
        {
            CupBoard_Close.SetActive(false);
            CupBoard_Open.SetActive(true);
            Open = true;
            Bulb.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    
}
