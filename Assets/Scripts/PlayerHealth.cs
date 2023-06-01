using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{


    public float health = 30.0f;
    private float startHealth;

    // Start is called before the first frame update
    void Start()
    {
        startHealth = health;
    }


    public void Damaged(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        SceneManager.LoadScene(0);
    }
}
