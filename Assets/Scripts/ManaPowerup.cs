using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPowerup : MonoBehaviour
{

    [SerializeField] GameObject player = null;

    void OnTriggerEnter(Collider other)
    {
        PlayerMana playerMana = other.gameObject.GetComponent<PlayerMana>();
        if (playerMana != null)
        {
            //UnityEngine.Debug.Log("player found");
            playerMana.AddManaPack();
            //UnityEngine.Debug.Log(playerMana.manaPackReserve);
            Destroy(this.gameObject);
        }
    }

}
