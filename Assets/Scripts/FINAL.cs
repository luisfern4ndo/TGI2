using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FINAL : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Reiniciar());
    }

    IEnumerator Reiniciar()
    {
        yield return new WaitForSeconds(35f);
        SceneManager.LoadScene("Cena 1 Menu");
    }
}
