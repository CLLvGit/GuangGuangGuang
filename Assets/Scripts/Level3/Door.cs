using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public GameObject door;

    private void OnMouseDown()
    {
        Debug.Log("Door opened.");
        door.GetComponent<AudioSource>().Play();
        Invoke("GetOut", 0.5f);
    }

    void GetOut()
    {
        SceneManager.LoadScene("Level_3_outdoor");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
