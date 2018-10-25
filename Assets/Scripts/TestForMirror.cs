using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForMirror : MonoBehaviour {
    public static int TargetNum = 1;
    public GameObject[] Target = new GameObject[TargetNum];
	// Use this for initialization
	void Start () {
        foreach (GameObject target in Target)
            if (target == null)
                Debug.Log("道具的目标位置未设置");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == Target[0])
            this.transform.Rotate(new Vector3(10, 1, 1), Space.Self);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
