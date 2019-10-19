using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirSTR : MonoBehaviour
{
    public GameObject caixaSTR;
    public float add = 0.3f;

    void Start()
    {
        caixaSTR = GameObject.FindGameObjectWithTag("boxSTRING");
    }


    void Update()
    {
        transform.position = new Vector3(caixaSTR.transform.position.x, caixaSTR.transform.position.y + add, caixaSTR.transform.position.z);
    }
}
