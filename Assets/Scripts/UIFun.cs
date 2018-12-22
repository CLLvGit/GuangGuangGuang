using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏UI的一些函数
/// </summary>
public class UIFun : MonoBehaviour
{
    public static UIFun ui;

    private GameObject Room = null;
    public float MoveDistance = 4f;
    public int MinRoom = 1;
    public int StartRoom = 1;
    public int MaxRoom = 7;

    public GameObject Title;
    public GameObject[] UIButtons = new GameObject[5];
    public GameObject DayButton;

    public GameObject FaildMenu;
    public GameObject WinMenu;
    public GameObject PauseMenu;
    public GameObject AchievementMenu;
    public GameObject left_button;
    public GameObject right_button;
    public GameObject PrevButton;
    public GameObject NextButton;
    //to get and set scroll bar position
    public RectTransform rtf;
    //to get a proper offset: cellsize.x + cell.spacing
    public GridLayoutGroup glg;
    public int level_chosen;
    private int progress;
    private float offset;
    private static int RoomNow;
    private int maxlevel = 6;

    private static string select;
    // Use this for initialization
    void Start()
    {
        if (ui == null)
            ui = this.GetComponent<UIFun>();
        if (FaildMenu != null)
            FaildMenu.SetActive(false);
        if (PauseMenu != null)
            PauseMenu.SetActive(false);
        if (WinMenu != null)
            WinMenu.SetActive(false);
        if (GameManager.gm != null)
        {
            StartRoom = GameManager.gm.StartRoom;
            MinRoom = GameManager.gm.MinRoom;
            MaxRoom = GameManager.gm.MaxRoom;
        }

        Room = GameObject.Find("Room");
        RoomNow = StartRoom;
        for (int i = 1; i < RoomNow; i++)
        {
            Room.transform.Translate(-MoveDistance, 0, 0);
        }
        //参数初始化
        //进行UI初始化设置
        //默认跳转到当前进度关卡
        if (glg)
        {
            offset = glg.cellSize.x + glg.spacing.x;
            progress = PlayerPrefs.GetInt("progress", 1);
            Debug.Log("level_chosen:" + progress);
            level_chosen = progress;
            //2018/12/20 ADD CHOOSE LEVEL LIMIT
            Vector3 position = rtf.anchoredPosition3D;
            position[0] -= offset * (level_chosen - 1);
            rtf.anchoredPosition3D = position;
        }
        if(left_button && right_button){
        if(RoomNow == MinRoom){
            left_button.SetActive(false);
        }
        else if (RoomNow == MaxRoom){
            right_button.SetActive(false);
        }}
        if(PrevButton && NextButton){
            NextButton.SetActive(false);
            if(level_chosen == 1) PrevButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int GetRoomNum()
    {
        return RoomNow;
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
    /* public void StartButton()
    {
        //activate first level
        Debug.Log("开始");
        //应该打开选关面板，暂时直接加载第一关
        SceneManager.LoadScene("Level_1");
    }*/

    public void AchievementButton()
    {
        Debug.Log("成就界面");
        AchievementMenu.SetActive(true);
    }
    public void CloseAchevement()
    {
        AchievementMenu.SetActive(false);
    }
    public void CloseButton()
    {
        Debug.Log("关闭");
        Application.Quit();
    }
    /*public void SelectMainButton(){
        SceneManager.LoadScene("SelectPage");
    }*/
    public void SelectButton()
    {
        select = "Level_" + level_chosen;
        Debug.Log("select " + select);
        Title.SetActive(false);
        for (int i = 0; i < 5; i++)
            UIButtons[i].SetActive(false);
        Invoke("BackgroundScale", 1.5f);
        //SceneManager.LoadScene(select);
        Invoke("SceneLoad", 5f);
    }
    private void BackgroundScale()
    {
        DayButton.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<CameraControl>().enabled = true;
    }
    private void SceneLoad()
    {
        SceneManager.LoadScene(select);
    }
    public void SettingButton()
    {
        Debug.Log("打开设置");
        //设置面板待完成
    }
    public void PauseButton()
    {
        Debug.Log("暂停");
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }
    public void ResumeButton()
    {
        Debug.Log("继续");
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }
    public void BackButton()
    {
        Time.timeScale = 1f;
        Debug.Log("返回");
        Destroy(GameObject.Find("BGM"));
        SceneManager.LoadScene("StartMenu");
    }
    public void NextLevelButton()
    {
        string name = SceneManager.GetActiveScene().name;
        string num = name.ToCharArray()[6].ToString();
        int n = int.Parse(num);
        n++;
        Debug.Log(n);
        if(n<=maxlevel) SceneManager.LoadScene("Level_" + n);
    }
    public void RightButton()
    {
        if (RoomNow < MaxRoom)
        {
            Room.transform.Translate(-MoveDistance, 0, 0);
            RoomNow++;
        }
        if(RoomNow == MaxRoom){
            right_button.SetActive(false);
        }
        left_button.SetActive(true);
    }
    public void LeftButton()
    {
        if (RoomNow > MinRoom)
        {
            Room.transform.Translate(MoveDistance, 0, 0);
            RoomNow--;
        }
        if(RoomNow == MinRoom){
            left_button.SetActive(false);
        }
        right_button.SetActive(true);
    }
    public void SwitchToNext()
    {
        Vector3 position = rtf.anchoredPosition3D;
        //Debug.Log("NEXT before: "+position);

        //display unfinished level but disabled
        //if(level_chosen == (levelManager.level_count)) return;

        //cannot display level that is unfinished

        if (level_chosen == progress) return;
        else position[0] = -((++level_chosen) - 1) * offset;
        // Debug.Log("NEXT after: "+position);
        rtf.anchoredPosition3D = position;
        if (level_chosen == progress) NextButton.SetActive(false);
        PrevButton.SetActive(true);
    }
    public void SwitchToPrev()
    {
        Vector3 position = rtf.anchoredPosition3D;
        //Debug.Log("PREV before: "+position);
        if (level_chosen <= 1) return;
        else position[0] = -((--level_chosen) - 1) * offset;
        //Debug.Log("PREV after: "+position);
        rtf.anchoredPosition3D = position;
        if (level_chosen <= 1) PrevButton.SetActive(false);
        NextButton.SetActive(true);
    }

}
