using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillWater : MonoBehaviour
{
    public ParticleSystem waterParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        {
            waterParticle.Play();
        }
        else
        {
            waterParticle.Stop();
        }
    }
}
