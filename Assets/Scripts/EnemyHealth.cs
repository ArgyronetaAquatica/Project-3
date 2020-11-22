using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public int health = 100;

    [SerializeField] Slider enemyHealthSlider = null;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
        }
        UnityEngine.Debug.Log(health);
        enemyHealthSlider.value = health;
    }

}
