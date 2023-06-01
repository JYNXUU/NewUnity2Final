using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;

public class PatrolScript : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    bool arrived;
    bool patrolling;
    int destination;

    public float damage = 10f;
    public int enemyRange = 5;

    public Animator anim;

    public Transform eye;
    public Transform target;
    Vector3 lastPosition;

    public GameObject enemyVisionText;

    bool canHit = true;




// Start is called before the first frame update
void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolling = true;
        lastPosition = transform.position;
        StartCoroutine("GoToNextPatrolPoint");
        enemyVisionText.SetActive(false);
    }

    bool CanSeePlayer()
    {
        bool canSee = false;
        Ray ray = new Ray(eye.position, target.transform.position - eye.position);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform != target)
            {
                canSee = false;
                enemyVisionText.SetActive(false);
            }
            else
            {
                lastPosition = target.transform.position;
                canSee = true;
                enemyVisionText.SetActive(true);
            }
        }
        return canSee;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(agent.transform.position, agent.transform.forward * 5, Color.red);

        if (agent.pathPending)
        {
            return;
        }

        if (patrolling)
        {
            if(agent.remainingDistance < agent.stoppingDistance)
            {
                if (!arrived)
                {
                    arrived = true;
                    StartCoroutine("GoToNextPatrolPoint");
                }
            }
            else
            {
                arrived = false;
            }
        }

        if (CanSeePlayer())
        {
            agent.SetDestination(target.transform.position);
            patrolling = false;

            //attack check
            if(agent.remainingDistance < agent.stoppingDistance)
            {
                //attack
                anim.SetBool("Attack", true);

                //damage player
                DamagePlayer();
               
            }
            else
            {
                //no attack
                anim.SetBool("Attack", false);
            }
        }

        //goes back to patrol
        else
        {
            //set attack to false
            anim.SetBool("Attack", false);
            if (!patrolling)
            {
                agent.SetDestination(lastPosition);
                if(agent.remainingDistance < agent.stoppingDistance)
                {
                    patrolling = true;
                    StartCoroutine("GoToNextPatrolPoint");
                }
            }
        }

        anim.SetFloat("Moving", agent.velocity.sqrMagnitude);
    }

    IEnumerator GoToNextPatrolPoint()
    {
        if(waypoints.Length == 0)
        {
            yield break;
        }

        patrolling = true;
        yield return new WaitForSeconds(2.0f);

        arrived = false;
        agent.destination = waypoints[destination].position;
        destination = (destination + 1) % waypoints.Length;
    }


    private void DamagePlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(agent.transform.position, agent.transform.forward * 5, out hit, enemyRange))
        {
            if (hit.transform.gameObject.tag == "Player" && canHit)
            {
                //apply damage
                canHit = false;
                hit.transform.gameObject.GetComponent<PlayerHealth>().Damaged(damage);
                StartCoroutine(DamageCooldown());
                
            }

        }
    }

    IEnumerator DamageCooldown()
    {
       
        Debug.Log("Player was hit");
        yield return new WaitForSeconds(2.0f);
        canHit = true;
    }

}
