using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{

    [SerializeField] GameObject swarmPrefab = null;

    [SerializeField] int manaCost = 15;

    PlayerMana playerManaComp;

    void Start()
    {
        playerManaComp = this.gameObject.GetComponent<PlayerMana>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (playerManaComp.playerMana >= manaCost)
            {
                SpawnSwarm();
                playerManaComp.SubtractMana(manaCost);
            } else if (playerManaComp.manaPackReserve > 0)
            {
                playerManaComp.ReEquipMana();
                SpawnSwarm();
                playerManaComp.SubtractMana(manaCost);
            }
        }
    }

    void SpawnSwarm()
    {
        GameObject newInstance = Instantiate(swarmPrefab, transform.position, transform.rotation);
        Destroy(newInstance, 30f);
    }

}
