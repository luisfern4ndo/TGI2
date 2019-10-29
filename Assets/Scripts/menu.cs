using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public void chamaCena()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cena 2 Historia");
    }
    public void sairJogo()
    {
        Application.Quit();
    }
}
