using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour {

    private void OnMouseDown()
    {
        Debug.Log("Go back home.");
        SceneManager.LoadScene("Level_3");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
