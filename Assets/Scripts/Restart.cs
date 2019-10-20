using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public static bool ativado;


    private void Start()
    {
        ativado = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && ativado)
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Inicio");
        
    }
}