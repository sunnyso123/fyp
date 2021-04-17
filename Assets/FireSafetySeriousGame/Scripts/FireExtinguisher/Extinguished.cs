using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguished : MonoBehaviour
{
    public ParticleSystem flameParticle;
    public ParticleSystem blackSmokeParticle;

    private ParticleSystem.MainModule fpMain;
    private ParticleSystem.MainModule spMain;

    private CapsuleCollider cCollider;
    private Timer TimerScript;
    private GameManager GameManagerScript;
    private Counter CounterScript;

    // Start is called before the first frame update
    void Start()
    {
        fpMain = flameParticle.main;
        spMain = blackSmokeParticle.main;

        cCollider = gameObject.GetComponent<CapsuleCollider>();

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
        if (CounterScript.flag == 1)
        {
            PlayerPrefs.SetInt("flag", CounterScript.flag);
            Debug.Log("You have extinguished the fire!");
            TimerScript.enabled = true;
            if (TimerScript.end)
            {
                GameManagerScript.changeScene("FinishMenu");
            }
        }
        
    }

    private void OnParticleCollision(GameObject other)
    {
        cCollider.enabled = false;
        fpMain.startSize = new ParticleSystem.MinMaxCurve(2f, 4f);
        fpMain.startSize = new ParticleSystem.MinMaxCurve(1f, 3f);
        fpMain.startSize = new ParticleSystem.MinMaxCurve(0.5f, 2f);
        fpMain.startSize = new ParticleSystem.MinMaxCurve(0f);
        spMain.startSize = new ParticleSystem.MinMaxCurve(0f);

        GameObject.Find("FlameLight").SetActive(false);
        //blackSmokeParticle.Stop();
        //flameParticle.Stop();

        CounterScript.flag = 1;
    }

}
