using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandleCigaretteEnd : MonoBehaviour
{
    private Counter CounterScript;
    private Timer TimerScript;
    private GameManager GameManagerScript;
    public ParticleSystem smokeParticle;
    private const int maxc = 2;


    void Start()
    {
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
        if (CounterScript.counter >= maxc) //Correct
        {
            CounterScript.flag = 1;
            PlayerPrefs.SetInt("flag", CounterScript.flag);
            Debug.Log("You have handled all the cigarette ends safely");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
        if (CounterScript.isMistake == 1) //Mistake
        {
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("You should not throw the cigarette on the trash bin!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ashtray")
        {           
            smokeParticle.Stop();           
            CounterScript.add();
        }
        
        if (other.gameObject.tag == "Trash")
        {
            CounterScript.isMistake = 1;
        }
    }

}
