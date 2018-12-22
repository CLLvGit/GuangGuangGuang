using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    private void OnMouseDown()
    {
        Debug.Log("Door opened.");
        SceneManager.LoadScene("Level_3_outdoor");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
