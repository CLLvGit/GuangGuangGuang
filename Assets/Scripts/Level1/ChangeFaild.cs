using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFaild : MonoBehaviour {
    public  float speed = 1f;
    public float jumpheight = 1f;
    private bool up = true;

    private void HideThis()
    {
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        up = true;
        Invoke("HideThis", 1f);
    }
    
	// Update is called once per frame
	void Update () {
        if(up)
            this.transform.position += new Vector3(0, Time.deltaTime * speed,0);
        else
            this.transform.position -= new Vector3(0, Time.deltaTime * speed , 0);

        if (this.transform.position.y >= jumpheight)
            up = false;  
        else if (this.transform.position.y <= 0)
            up = true;

        
	}
}
