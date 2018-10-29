using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// 游戏UI的一些函数
/// </summary>
public class UIFun : MonoBehaviour {
    public static UIFun ui;

    private GameObject Room = null;
    public float MoveDistance = 4f;
    public int MinRoom = 1;
    public int StartRoom = 1;
    public int MaxRoom = 7;

    public GameObject FaildMenu;
    public GameObject WinMenu;

    private static int RoomNow;
	// Use this for initialization
	void Start () {
        if (ui == null)
            ui = this.GetComponent<UIFun>();
        if(FaildMenu != null)
            FaildMenu.SetActive(false);
        if(WinMenu != null)
            WinMenu.SetActive(false);
        if (GameManager.gm != null)
        {
            StartRoom = GameManager.gm.StartRoom;
            MinRoom = GameManager.gm.MinRoom;
            MaxRoom = GameManager.gm.MaxRoom;
        }

        Room = GameObject.Find("Room");
        RoomNow = StartRoom;
        for(int i = 1; i < RoomNow; i++)
        {
            Room.transform.Translate(-MoveDistance, 0, 0);
        }
		//进行UI初始化设置
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowFaildMenu()
    {
        FaildMenu.SetActive(true);
        WinMenu.SetActive(false);
    }
    public void ShowWinMenu()
    {
        FaildMenu.SetActive(false);
        WinMenu.SetActive(true);
    }
    public void StartButton()
    {
        //activate first level
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
        if (RoomNow < MaxRoom)
        {
            Room.transform.Translate(-MoveDistance, 0, 0);
            RoomNow++;
        }
    }
    public void LeftButton()
    {
        if (RoomNow > MinRoom)
        {
            Room.transform.Translate(MoveDistance, 0, 0);
            RoomNow--;
        }
    }
}
