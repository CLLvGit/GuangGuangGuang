using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fadeout : MonoBehaviour {
	public bool DisplayOn;
	private Text msg;
	private Color color;
	float time = 0f;
	public float pausetime = 4f;
	public float fadetime = 1f;
	// Use this for initialization
	void Start () {
		DisplayOn = false;
		msg = this.GetComponent<Text>();
		color = msg.color;
		color.a = 0f;
		msg.color = color;
	}

	private void Display(){
		Debug.Log("display_trigger");
		time = 0f;
		color.a = 1f;
		DisplayOn = true;
	}

	private void FadeOut(){
		time += Time.deltaTime;
		if(time > pausetime)
			color.a = Mathf.Lerp(1,0,(time - pausetime)/fadetime);
		msg.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		if(DisplayOn){
			FadeOut();
		}
		if(color.a == 0) DisplayOn = false;
	}
}
