using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeChopstick : MonoBehaviour {
    public GameObject[] Tools = new GameObject[3];
    public bool WithMagic;
    private int now = 0;
    private bool shaking;
    private float shakeInterval;
	// Use this for initialization
	void Start () {
        for(int i = 0; i< Tools.Length; i++)
        {
            GameObject t = Tools[i];
            if (t == null)
                Debug.Log(this.name + "摇晃道具未设置！");
            if (i != 0)
                t.SetActive(false);
        }
        Tools[now].SetActive(true);
        shaking = false;
        shakeInterval = 0;
	}
	
	// Update is called once per frame
	void Update () {
        shakeInterval += Time.deltaTime;
        if (shaking && shakeInterval >= 0.5f)
        {
            shakeInterval = 0;
            ShakeOneTime();
        }
	}
    private void ShakeOneTime()
    {
        Tools[now].SetActive(false);
        now = (now) % (Tools.Length-1) + 1;
        Tools[now].SetActive(true);
    }
    public void Shake()
    {
        shaking = true;
    }
    public void StopShake()
    {
        shaking = false;
        Tools[now].SetActive(false);
        now = 0;
        Tools[now].SetActive(true);
    }
    public bool GetTool(int times)
    {
        int i = Random.Range(1, 10);
        if (times == 5 && WithMagic)
            i = 1;
        if (i <= 2 && WithMagic)
        {
            Debug.Log("获得魔杖*1");
            return true;
            //GetMagic();
        }
        else
        {
            Debug.Log("获得筷子*1");
            //GetChopstick();
            return false;
        }
    }

}
