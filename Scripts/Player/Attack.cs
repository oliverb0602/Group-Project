using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool AttackState = false;
    public GameObject Weapon;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackStateChecker();
        WeaponSwing();
    }



    public void AttackStateChecker()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AttackState = true;
            WeaponDraw();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AttackState = false;
            WeaponSheath();
        }
    }

    void WeaponDraw()
    {
        Weapon.SetActive(true);
    }

   void WeaponSheath()
    {
        Weapon.SetActive(false);
    }

    void WeaponSwing()
    {
        if (AttackState == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //animation for weapon swings
            Debug.Log("swish");
        }
    }


}
