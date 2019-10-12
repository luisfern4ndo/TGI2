using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   
    public GameObject pauseMenu, pauseButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pauseButton)
        {
            Pausar();
        }

        if (Input.GetKeyDown(KeyCode.Space) && pauseMenu)
        {
            Continuar();
        }
    }
    public void Pausar()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;

        
    }
    public void Continuar()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;

    }
}
