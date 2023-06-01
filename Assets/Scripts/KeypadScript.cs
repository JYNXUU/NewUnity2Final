using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class KeypadScript : MonoBehaviour
{
    public string password;
    public string enteredPW;
    public TMP_Text keypadDisplay;
    public int passDigits;
    public GameObject escapePod;
    public GameObject escapePodStand;

    public Camera cutsceneCam;
    public Camera playerCam;


    // Start is called before the first frame update
    void Start()
    {
        passDigits = password.Length;
        keypadDisplay.text = "Enter Keycode";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKey(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        //---------

        if(enteredPW.Length == passDigits)
        {
            if(enteredPW == password)
            {
                keypadDisplay.text = "Correct Passcode";

                //make cutscene stuff happen
                playerCam.enabled = false;
                cutsceneCam.enabled = true;
                Destroy(escapePodStand);
                escapePod.GetComponent<BoxCollider>().enabled = false;
                this.gameObject.SetActive(false);
            }
            else
            {
                keypadDisplay.text = "Incorrect Passcode";
                enteredPW = "";
            }
        }
    }

    public void ButtonNumber(string btnNum)
    {
        EnterCode(btnNum);
    }

    public void EnterCode(string keyEntered)
    {
        enteredPW += keyEntered;
        keypadDisplay.text = enteredPW;
    }
}
