using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GetKey : MonoBehaviour
{
    private Interactable interactable;
    public bool gotKey = false;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if (interactable.attachedToHand == null && grabType != GrabTypes.None && gameObject.tag == "Key")
        {
            gotKey = true;
            Debug.Log("You got the key!");
            Destroy(gameObject);
        }
        else if (isGrabEnding)
        {
            gotKey = false;
        }
    }
}
