using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour
{
    [SerializeField]
    string objTag;

    public MovingPlatformLerp movingPlat;

    public AudioSource bruh;

    private void Start()
    {
        movingPlat = GetComponent<MovingPlatformLerp>();
        //movingPlat.enabled = false;
    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "RedBox")
        {
            Debug.Log(col.gameObject.tag + " entered the trigger");
            //movingPlat.enabled = true;
            bruh.Play();
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "RedBox")
        {
           // movingPlat.enabled = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "RedBox")
        {
           // movingPlat.enabled = false;
        }
    }


}
