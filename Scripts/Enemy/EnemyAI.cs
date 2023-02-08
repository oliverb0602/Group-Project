using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI
;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;



    float EnemymoveSpeed = 10f;
    public Transform player;
    void Start()
    {
        player = GameObject.Find("PlayerModel").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void Movement()
    {
        if (Vector3.Distance(player.position, transform.position) < 30f)
        {
            var step = EnemymoveSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        else
        {


            if (isWandering == false)
            {
                StartCoroutine(RandomGenerator());
            }
            if (isRotatingRight == true)
            {

                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            }
            if (isRotatingLeft == true)
            {

                transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            }
            if (isWalking == true)
            {

                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }


    IEnumerator RandomGenerator()
    {
        //change these numbers to change the properties of the AI
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 5);
        int walkTime = Random.Range(1, 10);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }



}