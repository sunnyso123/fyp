using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DoorGrabbable : MonoBehaviour
{
    public Transform handle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void HandHoverUpdate(Hand hand)
    {
        if (hand.IsGrabEnding(gameObject))
        {
            transform.position = handle.transform.position;
            transform.rotation = handle.transform.rotation;
        }

        Rigidbody rbhandle = handle.GetComponent<Rigidbody>();
        rbhandle.velocity = Vector3.zero;
        rbhandle.angularVelocity = Vector3.zero;
    }
}
