using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    private int placed = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (placed == 0)
        {
            if (this.GetComponent<PickupAndDrag>().EventCanTrigger() == false) return;            
            if (collision.gameObject.name == "Wrong_position")
            {
                Debug.Log("Wrong place");
                placed = 1;
                Destroy(this.GetComponent<PickupAndDrag>());
            }
            if (collision.gameObject.name == "Right_position")
            {
                Debug.Log("Right place");
                placed = 2;
                Destroy(this.GetComponent<PickupAndDrag>());
            }
        }
        else if (collision.gameObject.name == "car")
        {
            GameObject.Find("car").GetComponent<Car>().Park_Car();
            Invoke("Level_finished", 3);
        }        
    }

    void Level_finished()
    {
        if (placed == 1) GameManager.gm.GameFaild();
        if (placed == 2) GameManager.gm.GameWin();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
