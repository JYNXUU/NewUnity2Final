using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinScript : MonoBehaviour
{
    GameObject gm;
   // public AudioClip valveSound;

    private void Awake()
    {
        gm = GameObject.Find("GameManager");
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           gm.GetComponent<GameManager>().CoinCollected();
        //AudioSource.PlayClipAtPoint(valveSound, transform.position);
           Destroy(gameObject);
        }
    }


}
