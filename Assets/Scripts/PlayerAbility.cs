using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{

    [SerializeField] GameObject swarmPrefab = null;
    [SerializeField] ParticleSystem swarmBurst = null;

    [SerializeField] int manaCost = 15;
    [SerializeField] float refreshTime = 1f;

    PlayerMana _playerMana;

    float refreshTimer = 0;

    void Start()
    {
        _playerMana = this.gameObject.GetComponent<PlayerMana>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && refreshTimer > refreshTime)
        {
            if (_playerMana.playerMana >= manaCost)
            {
                SpawnSwarm();
                swarmBurst.Play();
                _playerMana.SubtractMana(manaCost);
                refreshTimer = 0;
            } else if (_playerMana.manaPackReserve > 0)
            {
                _playerMana.ReEquipMana();
                SpawnSwarm();
                _playerMana.SubtractMana(manaCost);
                refreshTimer = 0;
            }
        }
        refreshTimer += Time.deltaTime;
    }

    void SpawnSwarm()
    {
        GameObject newInstance = Instantiate(swarmPrefab, transform.position, transform.rotation);
        Destroy(newInstance, 30f);
    }

}
