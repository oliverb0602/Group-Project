using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawning : MonoBehaviour
{
    public float ZombieCount = 0;
    public float maxZombies = 50;
    public GameObject ZombiePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnZombies();
    }

    void spawnZombies()
    {
        float x = Random.Range((float)2, (float)198);
        float z = Random.Range((float)2, (float)198);
        if (ZombieCount != maxZombies)
        {
            Instantiate(ZombiePrefab, new Vector3(x, 1, z), Quaternion.identity);
            ZombieCount++;
        }
    }
}
