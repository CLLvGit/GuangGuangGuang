using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSthOnClick : MonoBehaviour {
    public GameObject[] SthToShow = new GameObject[0];
    public GameObject[] SthToHide = new GameObject[0];
    // Use this for initialization
    void Start () {
        for (int i = 0; i < SthToShow.Length; i++)
        {
            GameObject sth = SthToShow[i];
            if (sth == null)
                Debug.Log(this.name + "未设置需要显示的物品！");
            sth.SetActive(false);
        }
        for (int i = 0; i < SthToHide.Length; i++)
        {
            GameObject sth = SthToHide[i];
            if (sth == null)
                Debug.Log(this.name + "未设置需要隐藏的物品！");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        for (int i = 0; i < SthToShow.Length; i++)
        {
            GameObject sth = SthToShow[i];
            sth.SetActive(true);
        }
        for (int i = 0; i < SthToHide.Length; i++)
        {
            GameObject sth = SthToHide[i];
            sth.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
