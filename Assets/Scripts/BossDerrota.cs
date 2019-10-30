using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDerrota : MonoBehaviour
{
    public bool derrotado;
    public GameObject blood;


    void Start()
    {
        derrotado = false;
    }
    void Update()
    {
        if (derrotado)
        {
            gameObject.SetActive(false);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }
}
