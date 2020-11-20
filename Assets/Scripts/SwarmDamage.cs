using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmDamage : MonoBehaviour
{

    public int damageMax = 10;
    public float timerMax = 3f;
    
    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Bees encountered something");

        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

        if(enemyHealth != null)
        {
            StartCoroutine(DamageSequence(enemyHealth));
            UnityEngine.Debug.Log("Enemy encountered");
        }
    }

    IEnumerator DamageSequence(EnemyHealth enemyHealth)
    {
        while (enemyHealth.health > 0)
        {
            enemyHealth.TakeDamage(damageMax);
            UnityEngine.Debug.Log(enemyHealth.health);
            yield return new WaitForSeconds(timerMax);
        }
    }

}
