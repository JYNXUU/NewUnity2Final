using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour
{
    GameObject gm;
    public AudioClip keyget;

    private void Awake()
    {
        gm = GameObject.Find("GameManager");
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           gm.GetComponent<GameManager>().KeyCollected();
           Destroy(gameObject);
            Debug.Log("Key Collected");
            AudioSource.PlayClipAtPoint(keyget, transform.position);
        }
    }


}
