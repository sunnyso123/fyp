using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishMenu : MonoBehaviour
{
    private Counter CounterScript;
    public TextMeshProUGUI displayText;
    private string rScene;

    string hceCorrectText = "You have handled all the cigarette ends safely!";
    string hceMistakeText = "You should not throw the cigarette on the trash bin!";

    string hocCorrectText = "You have removed all the overheating plug!";
    string hocMistakeText1 = "Something should have been turned off before removing the plugs!";
    string hocMistakeText2 = "You should not pour water into the overloading circuit!";

    string evaCorrectText = "You have evacuated successfully!";
    string evaMistakeText1 = "You did not bring a wet towel!";
    string evaMistakeText2 = "You did not bring along with the key, phone and towel!";
    string evaMistakeText3 = "You should not use the lift!";

    string wfrCorrectText = "You are waiting for rescue!";
    string wfrMistakeText1 = "You didn't close all the door!";
    string wfrMistakeText2 = "You didn't bring a wet towel!";
    string wfrMistakeText3 = "You didn't close all the door and bring a wet towel!";

    string hosCorrectText = "You have extinguished the fire safely!";
    string hosMistakeText1 = "The lid is too small for extinguishing the fire!";
    string hosMistakeText2 = "The fire becomes larger!";

    string feCorrectText = "You have extinguished the fire safely!";

    // Start is called before the first frame update
    void Start()
    {
        GameObject counter = GameObject.Find("Counter");
        CounterScript = counter.GetComponent<Counter>();

        rScene = PlayerPrefs.GetString("previousScene");
        CounterScript.flag = PlayerPrefs.GetInt("flag");
        CounterScript.isMistake = PlayerPrefs.GetInt("isMistake");
    }

    // Update is called once per frame
    void Update()
    {
        if (rScene == "HandleCigaretteEnd") 
        {
            if (CounterScript.flag == 1)
            {
                displayText.faceColor = new Color32(0, 255, 0, 255); //Grren
                displayText.text = hceCorrectText.ToString();
            }
            else if (CounterScript.isMistake == 1)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255); //Red
                displayText.text = hceMistakeText.ToString();
            }
        }
        else if (rScene == "HandleOverloadCircuit")
        {
            if (CounterScript.flag == 1)
            {
                displayText.faceColor = new Color32(0, 255, 0, 255);
                displayText.text = hocCorrectText.ToString();
            }
            else if (CounterScript.isMistake == 1)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = hocMistakeText1.ToString();
            }
            else if (CounterScript.isMistake == 2)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = hocMistakeText2.ToString();
            }
        }
        else if (rScene == "Evacuation")
        {
            if (CounterScript.flag == 1)
            {
                displayText.faceColor = new Color32(0, 255, 0, 255);
                displayText.text = evaCorrectText.ToString();
            }
            else if (CounterScript.isMistake == 1)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = evaMistakeText1.ToString();
            }
            else if (CounterScript.isMistake == 2)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = evaMistakeText2.ToString();
            }
            else if (CounterScript.isMistake == 3)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = evaMistakeText3.ToString();
            }
        }
        else if (rScene == "WaitForRescue")
        {
            if (CounterScript.flag == 1)
            {
                displayText.faceColor = new Color32(0, 255, 0, 255);
                displayText.text = wfrCorrectText.ToString();
            }
            else if (CounterScript.isMistake == 1)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = wfrMistakeText1.ToString();
            }
            else if (CounterScript.isMistake == 2)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = wfrMistakeText2.ToString();
            }
            else if (CounterScript.isMistake == 3)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = wfrMistakeText3.ToString();
            }
        }
        else if (rScene == "HandleOvercookStove")
        {
            if (CounterScript.flag == 1)
            {
                displayText.faceColor = new Color32(0, 255, 0, 255);
                displayText.text = hosCorrectText.ToString();
            }
            else if (CounterScript.isMistake == 1)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = hosMistakeText1.ToString();
            }
            else if (CounterScript.isMistake == 2)
            {
                displayText.faceColor = new Color32(255, 0, 0, 255);
                displayText.text = hosMistakeText2.ToString();
            }
        }
        else if (rScene == "FireExtinguisher")
        {
            if (CounterScript.flag == 1)
            {
                displayText.faceColor = new Color32(0, 255, 0, 255);
                displayText.text = feCorrectText.ToString();
            }
        }
    }

    public void restartScene()
    {
        PlayerPrefs.SetInt("flag", 0);
        PlayerPrefs.SetInt("isMistake", 0);
        SceneManager.LoadScene(rScene);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
