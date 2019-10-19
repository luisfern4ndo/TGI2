using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirBOOL : MonoBehaviour
{
    public GameObject caixaBOOL;
    public float add = 0.3f;

    void Start()
    {
        caixaBOOL = GameObject.FindGameObjectWithTag("boxBOOL");
    }


    void Update()
    {
        transform.position = new Vector3(caixaBOOL.transform.position.x, caixaBOOL.transform.position.y + add, caixaBOOL.transform.position.z);
    }
}