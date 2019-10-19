using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirINT : MonoBehaviour
{
    public GameObject caixaINT;
    public float add = 0.3f;

    void Start()
    {
        caixaINT = GameObject.FindGameObjectWithTag("boxINT");
    }


    void Update()
    {
        transform.position = new Vector3(caixaINT.transform.position.x, caixaINT.transform.position.y + add, caixaINT.transform.position.z);
    }
}