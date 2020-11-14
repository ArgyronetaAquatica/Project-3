using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMove : MonoBehaviour
{

    [SerializeField] Transform playerTransform = null;

    Vector3 playerForward;

    bool enemyEncountered = false;

    GameObject enemy = null;

    void Start()
    {
        playerForward = playerTransform.forward;
    }

    void Update()
    {
        if (!enemyEncountered)
        {
            transform.Translate(playerForward * Time.deltaTime);
        }
        else
        {
            transform.position = enemy.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            UnityEngine.Debug.Log("Enemy found");
            enemyEncountered = true;
            enemy = other.gameObject;
        }
    }

}
