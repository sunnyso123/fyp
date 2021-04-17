using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TurnOnOff : MonoBehaviour
{
    private Counter CounterScript;
    private Interactable interactable;
    private bool switchStatus = true;
    private const int maxs = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject counter = GameObject.Find("Counter");
        CounterScript = counter.GetComponent<Counter>();
        interactable = GetComponent<Interactable>();

    }

    void Update()
    {
        if (CounterScript.counter == maxs)
        {
            CounterScript.counter = 0;
            CounterScript.flag = 1;
            Debug.Log("All the switches have been turned off");
        }
    }

    // Update is called once per frame
    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if (interactable.attachedToHand == null && grabType != GrabTypes.None && gameObject.tag == "Switch" && switchStatus)//turn off
        {
            switchStatus = false;
            transform.Rotate(65, 0, 0);
            CounterScript.add();

        }
        else if (interactable.attachedToHand == null && grabType != GrabTypes.None && gameObject.tag == "Switch" && !switchStatus)//turn on
        {
            switchStatus = true;
            transform.Rotate(-65, 0, 0);
            CounterScript.minus();
        }
    }
}
