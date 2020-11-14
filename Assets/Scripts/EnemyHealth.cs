using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health = 100;

    public void TakeDamage()
    {
        UnityEngine.Debug.Log("enemy has been damaged");
    }

}
