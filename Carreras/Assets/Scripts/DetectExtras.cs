using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectExtras : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerEnter(Collider col)
    {
         if (col.tag =="Extra" && gameObject.tag=="Player")
         {
             GameControl.timeRemaining = GameControl.timeRemaining + 10;
             Destroy(col.gameObject);
             Debug.Log("ExtraTime");
         }
         else if (col.tag == "Middle" && gameObject.tag == "Player")
         {
             GameControl.wayPointMiddle = true;
             Debug.Log("MiddlePoint");
         }
         // Otherwise if the player manages to shoot himself...
         else if (col.tag == "Meta" && gameObject.tag == "Player")
         {
             GameControl.wayPointMeta = true;
             Debug.Log("MetaPoint");
         }

        /*if (col.tag == "Player" && gameObject.tag == "Extra")
        {
            GameControl.timeRemaining = GameControl.timeRemaining + 10;
            Destroy(col.gameObject);
            Debug.Log("ExtraTime");
        }
        else if (col.tag == "Player" && gameObject.tag == "Middle")
        {
            GameControl.wayPointMiddle = true;
            Debug.Log("MiddlePoint");
        }
        // Otherwise if the player manages to shoot himself...
        else if (col.tag == "Player" && gameObject.tag == "Meta")
        {
            GameControl.wayPointMeta = true;
            Debug.Log("MetaPoint");
        }*/
    }
}
