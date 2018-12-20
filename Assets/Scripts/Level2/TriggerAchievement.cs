using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAchievement : MonoBehaviour {
	public int AchievementNum;

	// Use this for initialization
	void Start () {
		
	}
	private void OnMouseDown(){
		GameManager.gm.UnlockAchievement(AchievementNum);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
