using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class WeaponScript : MonoBehaviour
{
    public float weaponDamage = 10.0f;
    public float weaponRange = 50.0f;
    public float hitForce = 200.0f;
    public float fireRate = 20.0f;
    public float nextFire = 0f;

    public GameObject door;

    public AudioSource shootsound;

    public Camera fpCamera;
  //  private AudioSource js;
   // public AudioClip jumpscare;

    private void Start()
    {
       // js = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(fpCamera.transform.position, fpCamera.transform.forward * 10, Color.green);

        if (Input.GetButtonDown("Fire2") && Time.time >= nextFire)
        {
            //cooldown
            nextFire = Time.time + 1.0f / fireRate;
            Shoot();
            shootsound.Play();
        }

        //HORROR GAME STUFF
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Open the starting door
            OpenDoor();
        }

        RaycastHit hit;

       // if(Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, weaponRange))
      //  {
          //  if (hit.collider.gameObject.tag == "Enemy")
                //apply damage
             //   if (hit.collider != null && !js.isPlaying)
              //  {
                //    Debug.Log("Jumpscare Triggered");
                   // js.PlayOneShot(jumpscare);
              //  }
       // }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, weaponRange))
        {
            if(hit.transform.gameObject.tag == "Enemy")
            {
                //apply damage
                if(hit.rigidbody != null)
                {
                    hit.transform.gameObject.GetComponent<EnemyHealth>().DamageEnemy(weaponDamage);
                   // hit.rigidbody.AddForce(-hit.normal * hitForce);
                    Debug.Log("Enemy was hit");
                }
            }

        }
    }

    void OpenDoor()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, weaponRange))
        {
            if (hit.transform.gameObject.tag == "EntryDoor")
            {
                //Open the door or im gonna throw rocks through your window
                if (hit.rigidbody != null)
                {
                    Debug.Log("Touched the door");

                    door.GetComponent<HG_OpenDoor>().OpenDoor();

                   // Destroy(GameObject.Find("InstructionText"));
                    
                }
            }

        }
    }

    void Jumpscare()
    {
        //sound stuff here
    }
}
