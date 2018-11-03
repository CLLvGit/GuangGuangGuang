using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具栏相关配置
/// </summary>
public class ToolBar : MonoBehaviour {
    private static int MaxToolNum = 4;
    private int ToolNum = 0;
    private static int[] ToolBasketNum = new int [MaxToolNum]; //Length = MaxToolNum
    public GameObject []ToolBasket = new GameObject [MaxToolNum];
    private GameObject[] ToolInToolBar = new GameObject[MaxToolNum];
    
	// Use this for initialization
	void Start () {
        foreach (GameObject temp in ToolBasket)
            if (temp == null)
                Debug.Log("道具栏未分配初始位置道具");
        for(int i = 0; i< MaxToolNum; i++)
        {
            ToolBasketNum[i] = 0;
        }
	}
    public void EnterToolBar(GameObject tool, Vector3 scale)
    {
        int i = 0;
        for(i = 0; i < MaxToolNum; i++)
        {
            if (ToolBasketNum[i] == 0)
            {
                tool.transform.localScale.Set(scale.x,scale.y,scale.z);
                tool.transform.parent = this.transform;
                tool.transform.position = ToolBasket[i].transform.position;
                ToolInToolBar[i] = tool;
                ToolBasketNum[i] = 1;
                //Debug.Log(scale + ";" + tool.transform.localScale + ";" + tool.transform.position);
                return;
            }
            
        }
        if (i == MaxToolNum)
            Debug.Log("道具栏满！");
    }
    public void OutToolBar(GameObject tool)
    {
        
        int i = 0;
        for (i = 0; i < MaxToolNum; i++)
        {
            if (ToolInToolBar[i] == tool)
            {
                tool.transform.parent = GameObject.Find("Room").transform;
                ToolBasketNum[i] = 0;
                ToolInToolBar[i] = null;
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
