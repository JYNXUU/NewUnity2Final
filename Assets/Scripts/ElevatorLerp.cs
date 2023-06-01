using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElevatorLerp : MonoBehaviour
{

    public GameObject obj;
    public Transform startPos;
    public Transform endPos;

    [SerializeField]
    float lerpTime = 1;
    public bool isActive;
    float currentLerpTime;


    // Start is called before the first frame update
    void Start()
    {
        currentLerpTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (isActive)
        {
            currentLerpTime += Time.deltaTime;

            float percent = currentLerpTime / lerpTime;

            obj.transform.position = Vector3.Lerp(startPos.position, endPos.position, percent);
        }
    }

    public void ActivateElevator()
    {
        isActive = !isActive;
        currentLerpTime = 0;
    }
}
