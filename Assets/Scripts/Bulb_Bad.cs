using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb_Bad : MonoBehaviour {
    public GameObject Bulb_On;
    public GameObject Bulb_OFF;
    public GameObject Mask;
    private bool state;
    public float MaxFlickTime = 3f;
    public float MinFlickTime = 1f;
    private float FlickTime;
    private float TimeCount;
    // Use this for initialization
    void Start () {
        state = false;
        TimeCount = 0;
        FlickTime = Random .Range(MinFlickTime, MaxFlickTime);
        Switch(state);
    }
    private void Switch(bool state)
    {
        Bulb_On.SetActive(state);
        Bulb_OFF.SetActive(!state);
        if (state)
            Mask.SetActive(false);
        else
        {
            Mask.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update () {
        TimeCount += Time.deltaTime;
		if(TimeCount >= FlickTime)
        {
            TimeCount = 0f;
            state = !state;
            Switch(state);
            FlickTime = Random.Range(MinFlickTime, MaxFlickTime);
        }
	}
}
