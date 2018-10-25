using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrag : MonoBehaviour {
    //拖拽相关
    private bool Picked = false;
    private bool isDraging = false;
    private Vector3 lastMousePosition = Vector3.zero;
    //缩放相关
    private Vector3 InitScale;
    public Vector3 ToolBarScale = new Vector3 (1f, 1f, 1f);
    //目标位置
    public static int TargetNum = 1;
    public GameObject[] Target = new GameObject[TargetNum];
    private static GameObject TriggerTarget = null;
    private static bool TriggerEnter = false;
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
    private void OnTriggerEnter2D(Collider2D other)
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == TriggerTarget)
            TriggerEnter = false;
    }
    private void OnMouseDown()
    {
        if (Picked)
            return;
        GameObject.Find("ToolBar").GetComponent<ToolBar>().EnterToolBar(this.gameObject, ToolBarScale);
    }

    private void OnMouseDrag()
    {
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
