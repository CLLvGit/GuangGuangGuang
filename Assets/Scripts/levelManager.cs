using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;


[System.Serializable]
public class level{
	private int _index;
	private bool _HasEntry;
	public void LevelLoader(string message){
		char[] separator = {' '};
		string[] values;//followed by order: (0)int: index(1-99) (1)bool: Has Cleared
		values = message.Split(separator);
		//Debug.Log(values[0] +"/" + values[1]);
		_index = Convert.ToInt32(values[0]);
		_HasEntry = Convert.ToBoolean(Convert.ToInt16(values[1]));
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
	static public List<level> LevelList = new List<level>{};//loaed level message
	
	void Start () {
		StreamReader sr = new StreamReader("Assets/Scripts/records.txt");//read saved data
		string line;
		while((line = sr.ReadLine())!=null){
			level n = new level();
			n.LevelLoader(line);
			LevelList.Add(n);
		}
		foreach (level l in LevelList){
			if(l.HasEntry()){
				//cleared levels will become interactable
				string index = "SelectButton" + l.GetIndex();
				if(GameObject.Find(index) == null) break;
				check = GameObject.Find(index).GetComponent<Button>();
				check.interactable = true;
			}
		}
		sr.Close();
	}

	static private void SaveProgress () { //row_num == level_index - 1
		FileStream fs = new FileStream("Assets/Scripts/records.txt", FileMode.Create,FileAccess.Write );
		StreamWriter sr = new StreamWriter(fs);//write saved data
		foreach (level l in LevelList){
			char entry;
			if(l.HasEntry()) entry = '1';
			else entry = '0';
			sr.WriteLine(l.GetIndex() + " " + entry);
		}
		sr.Close();
	}

	static public void LevelCleared(int current_level){ //activate next level entrance
		Debug.Log("level" + (current_level + 1) + "activated.");
		LevelList[current_level].ActivateNextLevel();// next level become active
		SaveProgress();
	}

	public void ResetProgress(){
		FileStream fs = new FileStream("Assets/Scripts/records.txt", FileMode.Create,FileAccess.Write );
		StreamWriter sr = new StreamWriter(fs);
		sr.WriteLine("1 1");
		for (int i = 2 ; i <= 9 ; i++){
			string line = i + " 0";
			sr.WriteLine(line);
		}
		sr.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
