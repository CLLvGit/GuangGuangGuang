using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    private int placed = 0;
    public bool can_place = true;
    public GameObject window;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (placed == 0)
        {
            if (!can_place) return;
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
            if (placed == 2) window.SetActive(true);
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Car get in-------------------------");
        if (collision.gameObject.name == "car")
            can_place = false;
        if (this.GetComponent<PickupAndDrag>() != null)
            this.GetComponent<PickupAndDrag>().TriggerEnter = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Car get out------------------------");
        if (collision.gameObject.name == "car")
            can_place = true;
        if (this.GetComponent<PickupAndDrag>() != null)
            this.GetComponent<PickupAndDrag>().TriggerEnter = true;
    }

    void Level_finished()
    {
        if (placed == 1) GameManager.gm.GameFaild();
        if (placed == 2)
        {
            GameManager.gm.GameWin();
        }

    }

    // Use this for initialization
    void Start () {
        window.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
