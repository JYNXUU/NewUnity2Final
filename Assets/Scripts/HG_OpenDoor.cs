using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HG_OpenDoor : MonoBehaviour
{

    public Animator anim;

    public void OpenDoor()
    {
        anim.SetBool("DoorOpen", true);
    }


}
