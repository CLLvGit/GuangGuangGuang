using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetToolsNotice : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        Invoke("HideThis", 1);
    }
    public void ChangeText(string s)
    {
        this.GetComponent<Text>().text = s;
    }
    private void HideThis()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
