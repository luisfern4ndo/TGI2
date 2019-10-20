using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   
    public GameObject pauseMenu, pauseButton;
    public static bool ativado;

    private void Start()
    {
        ativado = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pauseButton && ativado)
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
