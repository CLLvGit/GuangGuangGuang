using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb_Bad : MonoBehaviour {
    public GameObject Bulb_On;
    public GameObject Bulb_OFF;
    private bool state = true; // true when light is on
    public float MaxFlickTime;
    public float MinFlickTime;
    public float MaxPauseTime;
    public float MinPauseTime;
    private float FlickTime;// FlickTime ∈ random[MinFlickTime,MaxFlickTime]
    private float PauseTime;// PauseTime ∈ random[MinPauseTime,MaxPauseTime]
    private float TimeCount;
    private int FlickCount;// how many times has it already flicked
    public int FlickCountLimit = 2;// how many times it flicks in each circle 
    public  bool Fix = false;
    // Use this for initialization
    void Start () {
        //state = false;
        TimeCount = 0;
        FlickTime = Random.Range(MinFlickTime, MaxFlickTime);
        PauseTime = Random.Range(MinPauseTime, MaxPauseTime);
        FlickCount = 1;
    }

    public void Fixed()
    {
        Fix = true;
        Bulb_On.SetActive(true);
        Bulb_OFF.SetActive(false);
        //Switch();
    }
    private void Switch()
    {
        state = !state;
        Bulb_On.SetActive(state);
        Bulb_OFF.SetActive(!state);
    }
    // Update is called once per frame
    void Update()
    {
        if (Fix)
            return;
        if(!state && FlickCount == 0){
            TimeCount += Time.deltaTime;
            if (TimeCount >= PauseTime)
            {
                TimeCount = 0f;
                Switch();
                PauseTime = Random.Range(MinPauseTime, MaxPauseTime);
                //Debug.Log(FlickCount);
                FlickCount ++;
            }
        }
        else if(FlickCount != 0){
            TimeCount += Time.deltaTime;
            if (TimeCount >= FlickTime)
            {
                TimeCount = 0f;
                Switch();
                FlickTime = Random.Range(MinFlickTime, MaxFlickTime);
                FlickCount ++;
                //Debug.Log(FlickCount);
                // SwtichCount is equl to FlickCount * 2
                if(FlickCount == FlickCountLimit * 2) FlickCount = 0;
            }
        }
    }
}
