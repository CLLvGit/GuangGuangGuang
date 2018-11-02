using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using System;



[System.Serializable]
public class level{
	private int _index;
	private bool _HasEntry;
	public void PlayerPrefsLevelLoader(int index, bool has_entry){
		_index = index;
		_HasEntry = has_entry;
	}
	public bool HasEntry(){
		return _HasEntry;
	}
	public int GetIndex(){
		return _index;
	}
	public void ActivateNextLevel(){
		_HasEntry = true;
	}
}
//Select Button according to the index of the level saved message
public class levelManager : MonoBehaviour {
	private Button check;
    //----------------------------------------------------------------------
	public const int level_count = 9; //ATTENTION NEED TO BE UPDATE MANUALLY
    //----------------------------------------------------------------------
	static public List<level> LevelList = new List<level>{};//loaed level message
	
	void Start () {
        //load progress from playerprefs
        //all information loaded into LevelList
        int progress = PlayerPrefs.GetInt("progress",1);
        int level_index;
        Debug.Log("LevelManager:(progress monitor)level_count:"+level_count);
        for(int i =0 ;i < level_count;i++){
            level_index = i + 1;
            level n = new level();
            if(i+1<=progress) n.PlayerPrefsLevelLoader(level_index,true);
            else n.PlayerPrefsLevelLoader(level_index,false);
            LevelList.Add(n);
        }
		for(int i = 0;i < level_count;i++){
			//FOR DEBUG: level progress monitor
			//Debug.Log(LevelList[i].GetIndex() + LevelList[i].HasEntry().ToString());
		}
		foreach (level l in LevelList){
			if(l.HasEntry()){
				//Cleared levels will become interactable (buttons)
				string index = "SelectButton" + l.GetIndex();
				if(GameObject.Find(index) == null) break;
				check = GameObject.Find(index).GetComponent<Button>();
				check.interactable = true;
			}
		}
	}

	static private void SaveProgress () { 
        //If new level cleared, update progress
		int progress = 1;
		for(int i = 0;i < level_count;i++){
            if(LevelList[i].HasEntry()) progress = LevelList[i].GetIndex();
            else break;
            //FOR DEBUG: level progress monitor
			//Debug.Log(LevelList[i].GetIndex() + LevelList[i].HasEntry().ToString());
		}
		PlayerPrefs.SetInt("progress",progress);
	}

	static public void LevelCleared(int current_level){ //activate next level entrance
		Debug.Log("level" + (current_level + 1) + "activated.");
		LevelList[current_level].ActivateNextLevel();// next level become active
		SaveProgress();
	}

	public void ResetProgress(){
        //FOR TEST: LEVEL MANAGER RESTART
		Debug.Log("ResetProgress.");
        int progress = 1;
        PlayerPrefs.SetInt("progress",progress);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
