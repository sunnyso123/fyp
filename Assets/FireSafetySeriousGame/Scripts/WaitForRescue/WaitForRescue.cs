using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class WaitForRescue : MonoBehaviour
{
    private Timer TimerScript;
    private GameManager GameManagerScript;
    private Counter CounterScript;
    private Interactable interactable;

    private GetTowel getTowel;
    public bool gotTowel, wetTowel, nearWindow = false;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        getTowel = GameObject.Find("Towel").GetComponent<GetTowel>();
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
        gotTowel = getTowel.gotTowel;
        wetTowel = getTowel.wetTowel;
        if (CounterScript.flag == 1 && gotTowel && wetTowel && nearWindow) //Correct
        {
            PlayerPrefs.SetInt("flag", CounterScript.flag);
            Debug.Log("You are waiting for rescue!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
        else if (gotTowel && wetTowel && nearWindow) //Mistake 1
        {
            CounterScript.isMistake = 1;
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("You didn't close all the door!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu"); 
            }
        }
        else if (CounterScript.flag == 1 && gotTowel && nearWindow) //Mistake 2
        {
            CounterScript.isMistake = 2;
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("You didn't bring a wet towel!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu"); 
            }
        }
        else if (gotTowel && nearWindow) //Mistake 3
        {
            CounterScript.isMistake = 3;
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("You didn't close all the door and bring a wet towel!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
        else if (CounterScript.flag == 1 && nearWindow) //Mistake 2
        {
            CounterScript.isMistake = 2;
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("You didn't bring a wet towel!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
        else if (nearWindow) //Mistake 3
        {
            CounterScript.isMistake = 3;
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("You didn't close all the door and bring a wet towel!");
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

        //Grab the object
        if (interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            nearWindow = true;
        }
    }
}
