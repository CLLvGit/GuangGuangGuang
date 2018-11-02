using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSucceed : MonoBehaviour {
    public GameObject changing;
    public GameObject happy;
    private void Happy()
    {
        changing.SetActive(false);
        happy.SetActive(true);
    }
    private void HideThis()
    {
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        changing.SetActive(true);
        happy.SetActive(false);
        Invoke("Happy", 1f);
        Invoke("HideThis", 3f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
