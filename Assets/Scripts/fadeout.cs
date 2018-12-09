using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fadeout : MonoBehaviour {
	float time = 0f;
	public float pausetime = 4f;
	public float fadetime = 1f;
	// Use this for initialization
	void Start () {
		
	}

	private void FadeOut(){
		time += Time.deltaTime;
		Text msg = this.GetComponent<Text>();
		Color color = msg.color;
		if(time > pausetime)
			color.a = Mathf.Lerp(1,0,(time - pausetime)/fadetime);
		msg.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		if(isActiveAndEnabled){
			FadeOut();
		}
	}
}
