using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePickup : MonoBehaviour
{
    public Transform destinationObj;
    bool pickedUp = false;

    public AudioSource pickupsound;

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;

        this.transform.position = destinationObj.position;
        this.transform.parent = GameObject.Find("ObjHolder").transform;

        pickedUp = true;

        pickupsound.Play();
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;

        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;

        pickedUp = false;
    }
}
