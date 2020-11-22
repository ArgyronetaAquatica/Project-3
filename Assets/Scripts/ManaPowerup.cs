using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPowerup : MonoBehaviour
{

    [SerializeField] GameObject player = null;
    [SerializeField] AudioClip pickupSound = null;

    void OnTriggerEnter(Collider other)
    {
        PlayerMana playerMana = other.gameObject.GetComponent<PlayerMana>();
        if (playerMana != null)
        {
            //UnityEngine.Debug.Log("player found");
            playerMana.AddManaPack();
            AudioHelper.PlayClip2D(pickupSound, 1f);
            //UnityEngine.Debug.Log(playerMana.manaPackReserve);
            Destroy(this.gameObject,.5f);
        }
    }

}
