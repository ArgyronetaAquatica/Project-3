using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMove : MonoBehaviour
{

    bool enemyEncountered = false;

    GameObject enemy = null;

    void Update()
    {
        if (!enemyEncountered)
        {
            transform.Translate(transform.forward * Time.deltaTime);
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
