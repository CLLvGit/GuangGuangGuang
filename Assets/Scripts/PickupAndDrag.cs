using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 处理物品点击拾取和拖拽放置
/// </summary>
public class PickupAndDrag : MonoBehaviour {
    //拖拽相关
    private bool Picked = false;
    private bool isDraging = false;
    private Vector3 lastMousePosition = Vector3.zero;
    //缩放相关
    private Vector3 InitScale;
    public Vector3 ToolBarScale = new Vector3 (1f, 1f, 1f); //物体进入道具栏的缩放系数，需要手动调整设置
    //目标位置
    public static int TargetNum = 1; //物体可以拖入的目标位置的个数
    public GameObject[] Target = new GameObject[TargetNum]; //存储每个目标位置
    private static GameObject TriggerTarget = null; //当前进入的目标位置
    private static bool TriggerEnter = false;//是否进入目标位置
    
	// Use this for initialization
	void Start () {
        Picked = false;
        isDraging = false;
        lastMousePosition = Vector3.zero;
        this.transform.parent = GameObject.Find("Room").transform;
        InitScale = this.transform.localScale;
        foreach (GameObject target in Target)
            if (target == null)
                Debug.Log("道具的目标位置未设置");
        if (this.GetComponent<Rigidbody2D>() == null)
            Debug.Log("请给物体添加刚体Rigidbody2D并且禁止重力！");
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    public bool EventCanTrigger() //用于在事件触发函数中调用，返回true时可以触发事件，防止在拖拽时直接触发事件
    {
        return !isDraging;
    }
    private void OnTriggerEnter2D(Collider2D other) //当物体拖动进入目标位置时设置相关参数
    {
        foreach (GameObject target in Target )
        {
            if(other.gameObject == target )
            {
                TriggerTarget = other.gameObject;
                TriggerEnter = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //当物体脱离目标位置时重置相关参数
    {
        if (collision.gameObject == TriggerTarget)
        {
            TriggerTarget = null;
            TriggerEnter = false;
        }
    }
    private void OnMouseDown()
    {
        //点击时，如果不在道具栏，拾取物品，并设置缩放系数
        if (Picked)
            return;
        GameObject.Find("ToolBar").GetComponent<ToolBar>().EnterToolBar(this.gameObject, ToolBarScale);
    }

    private void OnMouseDrag()
    {
        //是否拖拽
        isDraging = true;
        if(Picked)
            this.transform.localScale = InitScale;
    }

    private void OnMouseUp()
    {
        isDraging = false;
        lastMousePosition = Vector3.zero;
        if (!Picked)//不再道具栏
        {           
            Picked = true;
        }
        else//已经在道具栏
        {
            //如果进入了目标位置，则停在此处，否在回到道具栏
            if (TriggerEnter) 
            {
                GameObject.Find("ToolBar").GetComponent<ToolBar>().OutToolBar(this.gameObject);
                this.transform.position =new Vector3 ( TriggerTarget.transform.position.x, TriggerTarget.transform.position.y, -5);              
                Picked = false;
            }
            else
            {
                GameObject.Find("ToolBar").GetComponent<ToolBar>().OutToolBar(this.gameObject);
                GameObject.Find("ToolBar").GetComponent<ToolBar>().EnterToolBar(this.gameObject, ToolBarScale);              
            }
        }
    }
    public void Draging()
    {
        //拖拽处理
        if (lastMousePosition != Vector3.zero)
        {
            Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
            this.transform.position += offset;
        }
        lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Update()
    {
        if (Picked && isDraging)
        {
            Draging();
        }
    }
    
}
