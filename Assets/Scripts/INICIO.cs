using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class INICIO : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Iniciar());
        GameObject.Find("SkipButton").GetComponent<Button>().Select();
    }

    IEnumerator Iniciar()
    {
        yield return new WaitForSeconds(30f);
        SceneManager.LoadScene("Cena 3 Jogo");
    }

    public void btIniciar()
    {
        SceneManager.LoadScene("Cena 3 Jogo");
    }

}
