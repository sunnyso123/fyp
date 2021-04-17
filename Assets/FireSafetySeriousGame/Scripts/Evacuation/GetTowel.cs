using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GetTowel : MonoBehaviour
{
    private Interactable interactable;
    public bool gotTowel = false;
    public bool wetTowel = false;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void OnParticleCollision(GameObject other)
    {
        wetTowel = true;
        Debug.Log("The towel is wet!");
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if (interactable.attachedToHand == null && grabType != GrabTypes.None && gameObject.tag == "Towel")
        {
            gotTowel = true;
            Debug.Log("You got the towel!");
            Destroy(gameObject);
            //hand.AttachObject(gameObject, grabType);
            //hand.HoverLock(interactable);
        }
        else if (isGrabEnding)
        {
            //hand.DetachObject(gameObject);
            //hand.HoverUnlock(interactable);
            gotTowel = false;
        }
    }
}
