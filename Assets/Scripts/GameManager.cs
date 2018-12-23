using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏UI初始化 & 流程控制
/// </summary>
public class GameManager : MonoBehaviour {
    public int level_index;
    public static GameManager gm;
    private enum GameState {Playing, Win, Faild };
    private bool StateLock = false;
    private static GameState gamestate = GameState.Playing;
    public int StartRoom = 1;
    public int MinRoom = 1;
    public int MaxRoom = 7;
    public GameObject AchieveObj;
	// Use this for initialization
	void Start () {
        if(gm == null)
            gm = this.GetComponent<GameManager>();
        SceneManager.LoadScene("PlayingMenu", LoadSceneMode.Additive);
        gamestate = GameState.Playing;

    }
    public int GetRoomNum()
    {
        return UIFun.ui.GetRoomNum();

    }
	public void GameWin()
    {
        if(!StateLock) gamestate = GameState.Win;
        StateLock = true;
        levelManager.LevelCleared(level_index);
    }
    public void UnlockAchievement(int num)
    {
        string AchieveName;
        AchieveName = "Achieve_" + num;
       
        if (PlayerPrefs.GetInt(AchieveName) != 1)
        {
            Debug.Log("解锁成就" + num);
            PlayerPrefs.SetInt(AchieveName, 1);
            if (AchieveObj == null)
                Debug.Log("成就显示物体未设置！");
            GameObject achieveobj = GameObject.Instantiate(AchieveObj, new Vector3(0, 2.65f, 0), new Quaternion());
            achieveobj.GetComponent<SetSprite>().ChangeSprite(num - 1);
        }
    }
    public void Block(){
        if(GameObject.Find("LeftButton")&&GameObject.Find("RightButton")){
            GameObject.Find("LeftButton").SetActive(false);
            GameObject.Find("RightButton").SetActive(false);
            }
    }
    public void Ready(){
        if(GameObject.Find("LeftButton")&&GameObject.Find("RightButton")){
            GameObject.Find("LeftButton").SetActive(true);
            GameObject.Find("RightButton").SetActive(true);
            }
    }
    public void GameFaild()
    {
        if(!StateLock) gamestate = GameState.Faild;
        StateLock = true;
    }
	// Update is called once per frame
	void Update () {
        if (gamestate == GameState.Faild)
        {
            UIFun.ui.ShowFaildMenu();
        }
        else if (gamestate == GameState.Win)
        {
            UIFun.ui.ShowWinMenu();
            if(GameObject.Find("ChangeSprite"))
            GameObject.Find("ChangeSprite").GetComponent<ChangeSprite>().SpritesChange();
        }

	}
}
