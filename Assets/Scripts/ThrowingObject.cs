using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingObject : MonoBehaviour
{
    public Transform destinationObj;
    bool pickedUp = false;
    public int damage = 10;
    public float throwForce = 10f;
    public AudioSource pickupsound;
    Vector3 startPos;

    private void OnMouseDown()
    {
        startPos = transform.position;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;

        this.transform.position = destinationObj.position;
        this.transform.parent = GameObject.Find("ObjHolder").transform;

        pickedUp = true;

        pickupsound.Play();
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;

        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = destinationObj.forward * throwForce;
        StartCoroutine(CheckCollision());
        pickedUp = false;
    }
    /*public GameObject this;
    public KeyCode throwKey = KeyCode.E;
    public float throwForce = 10f;
    public int damage = 10;
    private IEnumerator collisionCoroutine;

    // Update is called once per frame
    void Update()
    {
        // If the input key is pressed and the object is not null
        if (Input.GetKeyDown(throwKey) && this != null)
        {
            this.transform.parent = null;
            this.GetComponent<Rigidbody>().velocity = transform.forward * throwForce;
            collisionCoroutine = CheckCollision();
            StartCoroutine(collisionCoroutine);
        }
    }
*/
    private IEnumerator CheckCollision()
    {
        yield return null;
        Collider collider = this.GetComponent<Collider>();
        collider.isTrigger = true;

        while (this != null && this.transform.position.y > 0)
        {
            // Get all the colliders that overlap with the object's collider
            Collider[] overlaps = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy", "Ground"));

            // For each overlapping collider
            foreach (Collider overlap in overlaps)
            {
                // If it is an enemy
                if (overlap.CompareTag("Enemy"))
                {
                    collider.isTrigger = false;
                    this.gameObject.transform.position = startPos;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    // Deal damage to the enemy
                    overlap.GetComponent<EnemyHealth>().DamageEnemy(damage);
                    
                    // Destroy the object and stop the coroutine
                     Destroy(this);
                    StopCoroutine(CheckCollision());
                    break;
                }

                if (overlap.CompareTag("Ground"))
                {
                    collider.isTrigger = false;
                    StopCoroutine(CheckCollision());
                    break;
                }
            }

            yield return null;
        }
        StopCoroutine(CheckCollision());
    }
}
