using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour {
    public GameObject home;

    private void OnMouseDown()
    {
        GameObject[] tmp = GameObject.Find("ToolBar").GetComponent<ToolBar>().ToolInToolBar;
        if (tmp[0] != null)
        {
            Door.fail = true;
            Debug.Log("You should not bring it home----------------");
        }
        Debug.Log("Go back home.");
        home.GetComponent<AudioSource>().Play();
        Invoke("GoHome", 0.5f);        
    }

    void GoHome()
    {
        SceneManager.LoadScene("Level_3");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
