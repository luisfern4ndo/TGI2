using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   
    public GameObject pauseMenu, pauseButton;
    public bool m1;
    public bool m2;
    public bool m3;

    private void Start()
    {
        m1 = true;
        m2 = true;
        m3 = true;
       
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pauseButton && m1 && m2 && m3)
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
