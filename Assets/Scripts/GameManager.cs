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
    private static GameState gamestate = GameState.Playing;
    public int StartRoom = 1;
    public int MinRoom = 1;
    public int MaxRoom = 7;
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
        gamestate = GameState.Win;
        levelManager.LevelCleared(level_index);
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
        gamestate = GameState.Faild;
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
            GameObject.Find("ChangeSprite").GetComponent<ChangeSprite>().SpritesChange();
        }

	}
}
