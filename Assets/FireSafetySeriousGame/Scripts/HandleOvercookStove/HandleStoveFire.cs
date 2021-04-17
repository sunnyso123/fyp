using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleStoveFire : MonoBehaviour
{
    public ParticleSystem flameParticle;
    private ParticleSystem.MainModule pmain;
    private Timer TimerScript;
    private GameManager GameManagerScript;
    private Counter CounterScript;

    void Start()
    {
        pmain = flameParticle.main;
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
        if (CounterScript.flag == 1) //Correct
        {
            PlayerPrefs.SetInt("flag", CounterScript.flag);
            Debug.Log("You have extinguished the fire safely!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
        if (CounterScript.isMistake == 1) //Mistake1
        {
            PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
            Debug.Log("The lid is too small for extinguishing the fire!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    { 
        if (other.gameObject.tag == "Lid")
        {
            CounterScript.flag = 1;
            flameParticle.Stop();
            GameObject.Find("FlameLight").SetActive(false);         
        }
        else if (other.gameObject.tag == "SmallLid")
        {
            CounterScript.isMistake = 1;
        }
    }
    private void OnParticleCollision(GameObject other) //Mistake 2
    {
        pmain.startSpeed = new ParticleSystem.MinMaxCurve(7f);
        pmain.startSize = new ParticleSystem.MinMaxCurve(3f, 6f);
        CounterScript.isMistake = 2;
        PlayerPrefs.SetInt("isMistake", CounterScript.isMistake);
        Debug.Log("The fire becomes larger!");
        TimerScript.enabled = true;
        if (TimerScript.end)
        {
            GameManagerScript.changeScene("FinishMenu");
        }
    }

}
