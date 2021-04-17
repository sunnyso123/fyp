using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HandleOverloadCircuit : MonoBehaviour
{
    private Counter CounterScript;
    public ParticleSystem smokeParticle;
    private Interactable interactable;
    private FixedJoint fixedJoint;
    private Timer TimerScript;
    private GameManager GameManagerScript;
    private const int maxp = 4;

   

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        fixedJoint = gameObject.GetComponent<FixedJoint>();

        GameObject counter = GameObject.Find("Counter");
        CounterScript = counter.GetComponent<Counter>();
        GameObject gameManager = GameObject.Find("GameManager");
        GameManagerScript = gameManager.GetComponent<GameManager>();
        GameObject timer = GameObject.Find("Timer");
        TimerScript = timer.GetComponent<Timer>();
        TimerScript.enabled = false;

        PlayerPrefs.SetInt("flag", 0);
        PlayerPrefs.SetInt("isMistake", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (CounterScript.flag == 1 && CounterScript.counter >= maxp) //Correct
        {
            PlayerPrefs.SetInt("flag", CounterScript.flag);
            Debug.Log("You have removed all the overheating plug!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
        if (CounterScript.isMistake == 1) //Mistake 1
        {
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("Something should have been turned off before removing the plugs!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (CounterScript.flag == 1 && other.gameObject.tag != "Socket") 
        {           
            smokeParticle.Stop();
            CounterScript.add();
        }
    }

    private void OnParticleCollision(GameObject other) //Mistake 2
    {
        CounterScript.isMistake = 2;
        PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
        Debug.Log("You should not pour water into the overloading circuit!");
        TimerScript.enabled = true;
        if (TimerScript.end)
        {
            GameManagerScript.changeScene("FinishMenu");
        }

    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //Grab the object
        if (interactable.attachedToHand == null && grabType != GrabTypes.None && CounterScript.flag == 1)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            fixedJoint.connectedBody = null;
        }
        //Release the object
        else if (isGrabEnding)
        {
            Destroy(fixedJoint);
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
        if (interactable.attachedToHand == null && grabType != GrabTypes.None && CounterScript.flag != 1)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            fixedJoint.connectedBody = null;
            CounterScript.isMistake = 1;
        }
        else if (isGrabEnding)
        {
            Destroy(fixedJoint);
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }

}
