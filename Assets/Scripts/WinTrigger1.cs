using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger1 : MonoBehaviour
{
    public AudioSource winSound;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(6);
        }
    }


}
