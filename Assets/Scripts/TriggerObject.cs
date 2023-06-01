using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    [SerializeField]
    string objTag;
    public RaycastScript raycast;


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "RedBox")
        {
            Debug.Log(col.gameObject.tag + " entered the trigger");
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "RedBox")
        {
            raycast.RedBlock = true; 
        }
        if(col.gameObject.tag == "BlueBox")
        {
            raycast.BlueBlock = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "RedBox")
        {
            raycast.RedBlock = false;
        }
        if (col.gameObject.tag == "BlueBox")
        {
            raycast.BlueBlock = false;
        }
    }


}
