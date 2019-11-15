using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FINAL : MonoBehaviour
{
    public GameObject painelDev;
    
    void Start()
    {
        StartCoroutine(Reiniciar());
    }

    IEnumerator Reiniciar()
    {
        yield return new WaitForSeconds(50f);
        SceneManager.LoadScene("Cena 1 Menu");
    }

    public void chamarMenu()
    {
        StartCoroutine(menu());
    }

    IEnumerator menu()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Cena 1 Menu");
    }


    public void chamarDev()
    {
        if (painelDev.activeInHierarchy)
        {
            painelDev.SetActive(false);
        }
        else
        {
            painelDev.SetActive(true);
        }
    }

}
