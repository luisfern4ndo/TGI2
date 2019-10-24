using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserM4 : MonoBehaviour
{
    public bool ativado;
    

    void Start()
    {
        ativado = true;
    }

    
    void Update()
    {
        
            gameObject.SetActive(ativado);

    }
}
