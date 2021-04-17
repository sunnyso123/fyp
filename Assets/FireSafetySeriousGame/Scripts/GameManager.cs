using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string previousScene;

    // Start is called before the first frame update
    void Start()
    {
        previousScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("previousScene", previousScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void quitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
