using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisions : MonoBehaviour
{
    public ZombieSpawning zombie;
    public float EnemyHealth = 20;
    public float PlayerDamage = 10;
    public Interaction player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetMouseButton(0))
            {
                GetComponent<BoxCollider>().enabled = true;
           
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
            }

    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerAttack(other);
        
    }


    void PlayerAttack(Collider other)
    {
        if (other.gameObject.tag == "Enemy" )
        {

            Debug.Log("Hitregistered");
            //EnemyHealth -= PlayerDamage;

            EnemyHealth -= PlayerDamage;


            if (EnemyHealth <= 0)
            {
                Destroy(other.gameObject);
                zombie.ZombieCount--;
                EnemyHealth = 20;
                player.quest.questTarget.currentNumber++;
                Debug.Log("Enemy destroyed");
            }

        }
    }

 
}
