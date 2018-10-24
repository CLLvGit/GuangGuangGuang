using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFun : MonoBehaviour {
    public GameObject Room = null;
    public float MoveDistance = 4f;
    public int RoomNum = 7;
    private static int RoomNow;
	// Use this for initialization
	void Start () {
        RoomNow = 1;
		//进行UI初始化设置
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartButton()
    {
        Debug.Log("开始");
        //应该打开选关面板，暂时直接加载第一关
        SceneManager.LoadScene("Level_1");
    }
    public void CloseButton()
    {
        Debug.Log("关闭");
        Application.Quit();
    }
    public void SelectMainButton(){
        SceneManager.LoadScene("SelectPage");
    }
    public void SelectButton(int level){
        string select = "level_"+level;
        Debug.Log("select "+select);
        SceneManager.LoadScene(select);
    }
    public void SettingButton()
    {
        Debug.Log("打开设置");
        //设置面板待完成
    }
    public void BackButton()
    {
        Debug.Log("返回");
        SceneManager.LoadScene("StartMenu");
    }
    public void RightButton()
    {
        if (RoomNow < RoomNum)
        {
            Room.transform.Translate(-MoveDistance, 0, 0);
            RoomNow++;
        }
    }
    public void LeftButton()
    {
        if (RoomNow > 1)
        {
            Room.transform.Translate(MoveDistance, 0, 0);
            RoomNow--;
        }
    }
}
