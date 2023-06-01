using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50.0f;
    private float startHealth;
    public GameObject healthBar;
    public Image healthbarGFX;

    public GameObject endDoor;

    public AudioClip deadsound;

    // Start is called before the first frame update
    void Start()
    {
        startHealth = health;
    }


    public void DamageEnemy(float damage)
    {
        health -= damage;

        healthbarGFX.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        AudioSource.PlayClipAtPoint(deadsound, transform.position);
        Destroy(healthBar);
        Destroy(gameObject);
        Destroy(endDoor);
        
    }


}
