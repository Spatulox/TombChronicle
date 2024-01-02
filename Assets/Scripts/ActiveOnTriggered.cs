using UnityEngine;

public class ActiveOnTriggered : MonoBehaviour
{
    public GameObject objectToActivate;
    //public int desactivateObject = 0;
    public string tagWichTrigger = "Player";
    public string tagThingToActivate = "VDoors";

    private void OnTriggerEnter(Collider other)
    {
        //If the tagWichTrigger trigger the collider
        if (other.gameObject.CompareTag(tagWichTrigger))
        {
            // If thing to activate is a door
            if (tagThingToActivate == "VDoors")
            {
                objectToActivate.GetComponent<OpenVerticalDoors>().UpperHeight();   
            }
            if (tagThingToActivate == "LDoors")
            {
                objectToActivate.GetComponent<OpenLateralDoors>().OpenDoors();   
            }
        }
        else
        {
            Debug.Log("Wrong Tag to activate the thing, GameObject tag :"+other.gameObject.tag+", Tag wich trigerred : "+tagWichTrigger);
        }
    }
    
    /*
    private void OnTriggerExit(Collider other)
    {
        //If the tagWichTrigger trigger the collider
        if (other.gameObject.CompareTag(tagWichTrigger) && desactivateObject != 0)
        {
            // If thing to activate is a door
            if (tagThingToActivate == "VDoors")
            {
                objectToActivate.GetComponent<OpenVerticalDoors>().LowerHeight();
            }
            if (tagThingToActivate == "LDoors")
            {
                objectToActivate.GetComponent<OpenLateralDoors>().CloseDoors();
            }
        }
        else
        {
            Debug.Log("Wrong Tag to activate the thing, GameObject tag :"+other.gameObject.tag+", Tag wich trigerred : "+tagWichTrigger+" or the object is desactivate the return to the ground");
        }
    }
    */
}