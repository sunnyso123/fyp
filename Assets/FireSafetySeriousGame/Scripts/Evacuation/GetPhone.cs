using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GetPhone : MonoBehaviour
{
    private Interactable interactable;
    public bool gotPhone = false;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if (interactable.attachedToHand == null && grabType != GrabTypes.None && gameObject.tag == "Phone")
        {
            gotPhone = true;
            Debug.Log("You got the smartphone!");
            Destroy(gameObject);
        }
        else if (isGrabEnding)
        {
            gotPhone = false;
        }
    }
}
