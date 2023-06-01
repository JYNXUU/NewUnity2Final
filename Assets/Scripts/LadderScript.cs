using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public Transform playerController;
    bool insideLadder;
    public float ladderHeight = 3.3f;
    public PlayerController playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerController>();
        insideLadder = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Ladder")
        {
            playerInput.enabled = false;
            insideLadder = !insideLadder;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            playerInput.enabled = true;
            insideLadder = !insideLadder;
        }
    }

    void Update()
    {
        if(insideLadder && Input.GetKey("w"))
        {
            playerController.transform.position += Vector3.up / ladderHeight;
        }
    }
}
