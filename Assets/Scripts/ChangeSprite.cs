using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {
    public static int Num;
    public GameObject[] obj = new GameObject[Num];
    public Sprite[] sprite = new Sprite[Num];
	// Use this for initialization
	void Start () {
        Num = obj.Length;
	}
	public void SpritesChange()
    {
        int i;
        int level = GameObject.Find("GameManager").GetComponent<GameManager>().level_index;
        if(level == 2) Level2Special();
        for(i=0; i< Num; i++)
        {
            if (obj[i] && sprite[i])
            {
                obj[i].GetComponent<SpriteRenderer>().sprite = sprite[i];
                //Debug.Log("ChangeSprite :" + obj[i].name + " & " + sprite[i].name);
            }
        }
    }
	// Update is called once per frame
	void Update () {
      
	}

    private void Level2Special(){
        if( GameObject.Find("Television"))
        GameObject.Find("Television").SetActive(false);
        if( GameObject.Find("bookshelf"))
        GameObject.Find("bookshelf").SetActive(false);
    }
   
}
