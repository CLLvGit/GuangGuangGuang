using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//这个脚本的作用是在点击有碰撞体道具时显示相应的系统提示
//显示的形式和字体大小对齐是由SystemMessageBox决定的，这个可能需要后期修改

public class SystemAnnouncement : MonoBehaviour {
	public string SystemAnnoucement;
	public GameObject SystemMessageBox;

	// Use this for initialization
	void Start () {
		
	}

	private void OnMouseDown(){
			SystemMessageBox.GetComponent<Text>().text = SystemAnnoucement;
			SystemMessageBox.SendMessage("Display");
		}

	
	// Update is called once per frame
	void Update () {
		
	}
}
