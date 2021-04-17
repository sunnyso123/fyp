using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class FireExtinguisher : MonoBehaviour
{
    public SteamVR_Action_Boolean sprayAction;
    public ParticleSystem CO2Particle;
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (sprayAction[source].stateDown)
            {
                CO2Particle.Play();
            }
            else if (sprayAction[source].stateUp)
            {
                CO2Particle.Stop();
            }
            
        }
    }


}
