using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_6_Dad : MonoBehaviour {
    public GameObject dadInit;
    public GameObject dadMagic;
    public GameObject dadWhat;

    private int ToolsGot;
    private bool GotChopstick;
    public float WaitGameWinTime;
    public float WaitDoMagicTime;
	// Use this for initialization
    IEnumerator WaitGameWin() {
		yield return new WaitForSeconds(WaitGameWinTime);
        GameWin();
	}
    IEnumerator WaitDoMagic() {
		yield return new WaitForSeconds(WaitDoMagicTime);
        DoMagic();
	}

	void Start () {
        ToolsGot = 0;
        GotChopstick = false;
        dadInit.SetActive(true);
        dadMagic.SetActive(false);
        dadWhat.SetActive(false);
	}
	public void GetTool()
    {
        ToolsGot++;
        this.GetComponent<AudioSource>().Play();
        Debug.Log("ToolsGot = " + ToolsGot);
        if (ToolsGot == 3)
        {
            GameObject chopstick = GameObject.Find("chopstickToPick");
            if (chopstick)
                Destroy(chopstick);
            Debug.Log("Win!!!!");
            //Invoke("DoMagic", 0.5f);
            StartCoroutine("WaitDoMagic");
            StartCoroutine("WaitGameWin");
            //Invoke("GameWin", 6.5f);
        }
    }
    public void GetChopstick()
    {
        ToolsGot = -100;
        Debug.Log("Lose!!!");
        Invoke("QuestionMark", 0.5f);
        Invoke("GameFaild", 3.5f);
    }
    private void DoMagic()
    {
        GameObject hat = GameObject.Find("hat");
        if (hat)
            Destroy(hat);
        GameObject glass = GameObject.Find("glass");
        if (glass)
            Destroy(glass);
        GameObject magicstick = GameObject.Find("magicstickToPick");
        if (magicstick)
            Destroy(magicstick);

        
        dadInit.SetActive(false);
        dadMagic.SetActive(true);
    }
    private void QuestionMark()
    {
        GameObject magicstick = GameObject.Find("magicstickToPick");
        if (magicstick)
            Destroy(magicstick);

        dadInit.SetActive(false);
        dadWhat.SetActive(true);
    }
    private void GameWin()
    {
        GameObject.Find("ChangeSprite").GetComponent<ChangeSprite>().SpritesChange();
        GameManager.gm.GameWin();
    }
    private void GameFaild()
    {

        GameManager.gm.GameFaild();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
