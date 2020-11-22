using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmDamage : MonoBehaviour
{

    public int damageMax = 15;
    public int damageMin = 5;
    public float timerMax = 2f;
    public float timerMin = .5f;

    EnemyHealth enemyHealth = null;
    SwarmDisperse swarmDisperse = null;

    void Start()
    {
        swarmDisperse = this.gameObject.GetComponent<SwarmDisperse>();
    }

    void OnTriggerEnter(Collider other)
    {
        //UnityEngine.Debug.Log("Bees encountered something");

        enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

        if(enemyHealth != null)
        {
            if(enemyHealth.health > 0)
            {
                StartCoroutine(DamageSequence(enemyHealth));
            }
            //UnityEngine.Debug.Log("Enemy encountered");
        }
    }

    IEnumerator DamageSequence(EnemyHealth enemyHealth)
    {
        while (enemyHealth.health > 0)
        {
            int damageAmount = Random.Range(damageMin, damageMax);
            float timerAmount = Random.Range(timerMin, timerMax);
            enemyHealth.TakeDamage(damageAmount);
            //UnityEngine.Debug.Log(enemyHealth.health);
            yield return new WaitForSeconds(timerAmount);
        }
        swarmDisperse.Disperse();
    }

}
