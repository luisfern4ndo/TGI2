using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

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
        if (Input.GetKeyDown(KeyCode.R) && m1 && m2 && m3)
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Inicio");
        
    }
}