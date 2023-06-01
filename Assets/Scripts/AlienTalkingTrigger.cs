using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTalkingTrigger : MonoBehaviour
{
    public GameObject talkingUI;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            talkingUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            talkingUI.SetActive(false);
        }
    }
}
