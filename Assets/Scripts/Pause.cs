using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject pauseMenu, pauseButton;
    public bool MonitorAtivado { get; set; }

    private void Start()
    {
        MonitorAtivado = false;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pauseButton && !MonitorAtivado)
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
        GameObject.Find("ResumeButton").GetComponent<Button>().Select();


    }
    public void Continuar()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;

    }

    public void chamarMenu()
    {
        SceneManager.LoadScene("Cena 1 Menu");
        Time.timeScale = 1;
    }
}
