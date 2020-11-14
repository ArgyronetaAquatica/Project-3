using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmDamage : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Bees encountered something");

        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage();
        }
    }

}
