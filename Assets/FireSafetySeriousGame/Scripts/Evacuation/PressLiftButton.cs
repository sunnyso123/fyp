using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PressLiftButton : MonoBehaviour
{
    private Timer TimerScript;
    private GameManager GameManagerScript;
    private Counter CounterScript;
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        GameObject counter = GameObject.Find("Counter");
        CounterScript = counter.GetComponent<Counter>();
        GameObject gameManager = GameObject.Find("GameManager");
        GameManagerScript = gameManager.GetComponent<GameManager>();
        GameObject timer = GameObject.Find("Timer");
        TimerScript = timer.GetComponent<Timer>();
        TimerScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CounterScript.isMistake == 3) //Mistake 3
        {
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("You should not use the lift!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if (interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            CounterScript.isMistake = 3;
        }
    }
}
