using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        CheckifDead();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("AHHHHH");
            TakeDamage(10);
        }
    }

    void CheckifDead()
    {
        if (currentHealth <=0)
        {
            transform.position = new Vector3(46.5f,1.27f,31.4f);
            currentHealth = maxHealth;
            healthBar.SetHealth(maxHealth);
        }
    }
}
