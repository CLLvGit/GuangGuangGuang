using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSprite : MonoBehaviour {
    public GameObject Target;
    public Sprite[] sprites = new Sprite[6];
	// Use this for initialization
	void Start () {
        if (Target == null)
            Debug.Log(this.name + "Target物体未设置！");
        Debug.Log("创建物体 " + this.gameObject.name);
        Destroy(this.gameObject, 2f);
	}
	public void ChangeSprite(int i)
    {
        Target.GetComponent<SpriteRenderer>().sprite = sprites[i];
    }
	// Update is called once per frame
	void Update () {
		
	}
}
