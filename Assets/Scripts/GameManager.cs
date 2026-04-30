using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting.Dependencies.NCalc;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject GameOverScreen;

   

    private void Awake()
    {
        isGameOver = false;
    }


    void Update()
    {
        if (isGameOver)
        {
            GameOverScreen.SetActive(true);
        }
    }

    public void Restart()
    {
      HealthManager.health = 3;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SimpleFade.Instance.LoadScene(1);
    }

    public void MainMenu()
    {
        SimpleFade.Instance.LoadScene(0);
    }

  


}
