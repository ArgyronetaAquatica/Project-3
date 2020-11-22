using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmSound : MonoBehaviour
{

    [SerializeField] AudioClip buzzingSound = null;

    void Start()
    {
        AudioHelper.PlayClip2D(buzzingSound, .5f);
    }

}
