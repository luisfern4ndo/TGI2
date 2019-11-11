using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public bool MonitorAtivado { get; set; }


    private void Start()
    {
        MonitorAtivado = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !MonitorAtivado)
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Cena 2 Jogo");

    }
}