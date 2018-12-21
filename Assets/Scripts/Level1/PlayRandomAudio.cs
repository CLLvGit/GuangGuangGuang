using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour {
    public AudioClip [] Clips= new AudioClip[4];
	// Use this for initialization
	void Start () {
		
	}
    private void OnEnable()
    {
        int i = Random.Range(1, Clips.Length);
        this.GetComponent<AudioSource>().clip = Clips[i];
        this.GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
