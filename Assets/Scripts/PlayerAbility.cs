using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{

    [SerializeField] GameObject swarmPrefab = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnSwarm();
        }
    }

    void SpawnSwarm()
    {
        GameObject newInstance = Instantiate(swarmPrefab, transform.position, transform.rotation);
        Destroy(newInstance, 30f);
    }

}
