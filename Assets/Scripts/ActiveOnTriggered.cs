using UnityEngine;

public class ActiveOnTriggered : MonoBehaviour
{
    public GameObject objectToActivate;
    public int desactivateObject = 0;
    public string tagWichTrigger = "Player";
    public string tagThingToActivate = "Doors";

    private void OnTriggerEnter(Collider other)
    {
        //If the tagWichTrigger trigger the collider
        if (other.gameObject.CompareTag(tagWichTrigger))
        {
            // If thing to activate is a door
            if (tagThingToActivate == "Doors")
            {
                objectToActivate.GetComponent<OpenDoors>().UpperHeight();   
            }
        }
        else
        {
            Debug.Log("Wrong Tag to activate the thing, GameObject tag :"+other.gameObject.tag+", Tag wich trigerred : "+tagWichTrigger);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        //If the tagWichTrigger trigger the collider
        if (other.gameObject.CompareTag(tagWichTrigger) && desactivateObject != 0)
        {
            // If thing to activate is a door
            if (tagThingToActivate == "Doors")
            {
                objectToActivate.GetComponent<OpenDoors>().LowerHeight();
            }
        }
        else
        {
            Debug.Log("Wrong Tag to activate the thing, GameObject tag :"+other.gameObject.tag+", Tag wich trigerred : "+tagWichTrigger);
        }
    }
}