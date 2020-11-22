using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmDisperse : MonoBehaviour
{

    [SerializeField] ParticleSystem particlesToDisable = null;

    AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void Disperse()
    {
        particlesToDisable.Stop();
        audioSource.Stop();
    }

}
