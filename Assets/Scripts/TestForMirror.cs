using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用于测试事件触发，待删除
/// </summary>
public class TestForMirror : MonoBehaviour {
    public static int TargetNum = 2;
    public GameObject[] Target = new GameObject[TargetNum];
	// Use this for initialization
	void Start () {
        foreach (GameObject target in Target)
            if (target == null)
                Debug.Log("道具的目标位置未设置");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //手指松开时（即不再拖拽物体时）再触发，避免拖拽时经过物体直接触发
        if (this.GetComponent<PickupAndDrag>().EventCanTrigger() == false)
            return;

        if (collision.gameObject == Target[0])
            GameManager.gm.GameWin();
        else if (collision.gameObject == Target[1])
            GameManager.gm.GameFaild();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
