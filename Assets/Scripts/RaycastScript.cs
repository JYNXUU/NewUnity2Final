using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class RaycastScript : MonoBehaviour
{
    public bool RedBlock;
    public bool BlueBlock;
    public float RaycastDist;
    public Animator door1;
    public Animator door2;
    public GameObject doorButton;
    public GameObject messageText;

    // Start is called before the first frame update
    void Start()
    {
        messageText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (RedBlock && BlueBlock)
        {
            doorButton.GetComponent<Renderer>().material.color = Color.green;
            messageText.SetActive(true);
        }
        else
        {
            doorButton.GetComponent<Renderer>().material.color = Color.red;
            messageText.SetActive(false);
        }

        Debug.DrawRay(this.transform.position, this.transform.forward * 10, Color.green);
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, RaycastDist))
        {
            if (hit.collider.tag == "DoorButton" && RedBlock && BlueBlock)
            {
                messageText.SetActive(true);
            }
            else
            {
                messageText.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, RaycastDist))
            {
                Debug.Log(hit.collider.gameObject.name + " is the object out raycast hit");

                if (hit.collider.tag == "DoorButton" && RedBlock && BlueBlock)
                {
                    door1.SetTrigger("OpenLeft");
                    door2.SetTrigger("OpenRight");
                }
            }
        }
    }
}
