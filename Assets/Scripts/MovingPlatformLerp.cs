using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLerp : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;

    public float speed = 1.0f;
    public float distance = 1.0f;
    public float startTime;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distMoved = Mathf.PingPong(Time.time - startTime, distance / speed);
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, distMoved / distance);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = null;
        }
    }
}
