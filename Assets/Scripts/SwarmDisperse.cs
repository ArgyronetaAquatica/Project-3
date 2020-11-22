using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmDisperse : MonoBehaviour
{

    [SerializeField] ParticleSystem particlesToDisable = null;

    public void Disperse()
    {
        particlesToDisable.Stop();
    }

}
