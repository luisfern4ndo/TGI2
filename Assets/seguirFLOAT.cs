using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirFLOAT : MonoBehaviour
{
    public GameObject caixaFLOAT;
    public float add = 0.3f;
    
    void Start()
    {
        caixaFLOAT = GameObject.FindGameObjectWithTag("boxFLOAT");
    }

   
    void Update()
    {
        transform.position = new Vector3 (caixaFLOAT.transform.position.x, caixaFLOAT.transform.position.y+add, caixaFLOAT.transform.position.z);
    }
}
