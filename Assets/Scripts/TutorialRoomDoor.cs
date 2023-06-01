using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class TutorialRoomDoor : MonoBehaviour
{
    public float RaycastDist;
    public Animator door;
    public GameObject doorButton;

    public AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(this.transform.position, this.transform.forward * 10, Color.green);
        RaycastHit hit;

        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, RaycastDist))
            {
                Debug.Log(hit.collider.gameObject.name + " is the object out raycast hit");

                if (hit.collider.tag == "DoorButton")
                {
                    door.SetBool("DoorOpen", true);
                    buttonSound.Play();
                }
            }
        }
    }
}

