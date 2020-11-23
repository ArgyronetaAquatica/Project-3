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
            //UnityEngine.Debug.Log("Enemy Check Successful");
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth.health > 0)
            {
                if (Mathf.Abs(enemy.transform.position.x - this.transform.position.x) > .2 || Mathf.Abs(enemy.transform.position.z - this.transform.position.z) > .2)
                {
                    MoveTowards(enemy);
                }
            } 
            else
            {
                enemyEncountered = false;
            }
        }
    }

    void EnemyCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Enemy")
            {
                EnemyHealth enemyHealth = hitCollider.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null && enemyHealth.health > 0)
                {
                    enemy = hitCollider.gameObject;
                    enemyEncountered = true;
                }
            }
        }
    }

    void MoveTowards(GameObject target)
    {
        Vector3 direction = target.transform.position - this.transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 1, 0f);
        Quaternion rotation = Quaternion.LookRotation(newDirection);
        rb.MoveRotation(rotation);
        rb.AddForce(transform.forward);
    }

}
