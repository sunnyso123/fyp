using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Evacuation : MonoBehaviour
{
    private Timer TimerScript;
    private GameManager GameManagerScript;
    private Counter CounterScript;
    private Interactable interactable;

    private GetKey getKey;
    private GetPhone getPhone;
    private GetTowel getTowel;

    public bool allThingsGot = false;
    public bool arrivedExit = false;
    public bool gotPhone, gotKey, gotTowel, wetTowel;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();

        getKey = GameObject.Find("Key").GetComponent<GetKey>();
        getPhone = GameObject.Find("Smartphone").GetComponent<GetPhone>();
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

    void Update()
    {
        gotKey = getKey.gotKey;
        gotPhone = getPhone.gotPhone;
        gotTowel = getTowel.gotTowel;
        wetTowel = getTowel.wetTowel;

        if (gotPhone == true && gotKey == true && gotTowel == true)
        {
            allThingsGot = true;
        }

        if (allThingsGot && arrivedExit && wetTowel) //Correct
        {
            CounterScript.flag = 1;
            PlayerPrefs.SetInt("flag", CounterScript.flag);
            Debug.Log("You have evacuated successfully!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
        else if (allThingsGot && arrivedExit && !wetTowel) //Mistake 1
        {
            CounterScript.isMistake = 1;
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("You did not bring a wet towel!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
        else if (!allThingsGot && arrivedExit) //Mistake 2
        {
            CounterScript.isMistake = 2;
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("You did not bring along with the key, phone and towel!");
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
            arrivedExit = true;
        }
    }

}
