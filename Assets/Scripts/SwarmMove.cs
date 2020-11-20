using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMove : MonoBehaviour
{

    [SerializeField] float detectionRange = 5f;
    [SerializeField] float swarmSpeed = 1.5f;
    
    bool enemyEncountered = false;
    GameObject enemy;
    Rigidbody rb;
    float enemyCheckTimer = 0f;
    float enemyCheckTime = .25f;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!enemyEncountered)
        {
            Vector3 moveDirection = transform.forward * swarmSpeed;
            rb.AddForce(moveDirection);
            enemyCheckTimer += Time.deltaTime;

            if (enemyCheckTimer >= enemyCheckTime)
            {
                EnemyCheck();
            }
        } 
        else
        {
            UnityEngine.Debug.Log("Enemy Check Successful");
            //stick to enemy
        }
    }

    void EnemyCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Enemy")
            {
                enemy = hitCollider.gameObject;
                enemyEncountered = true;
            }
        }
    }

}
