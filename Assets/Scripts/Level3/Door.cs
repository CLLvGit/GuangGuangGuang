using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public GameObject door;
    public static bool fail = false;
    public GameObject mum;
    public GameObject roadblock;

    private void OnMouseDown()
    {
        Debug.Log("Door opened.");
        door.GetComponent<AudioSource>().Play();
        Invoke("GetOut", 0.5f);
    }

    void failure()
    {
        fail = false;
        GameManager.gm.GameFaild();
    }

    void GetOut()
    {
        SceneManager.LoadScene("Level_3_outdoor");
    }
    // Use this for initialization
    void Start () {
        if (!fail)
        {
            mum.SetActive(false);
            roadblock.SetActive(false);
        }
        else
        {
            mum.SetActive(true);
            roadblock.SetActive(true);
            Invoke("failure", 2f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
