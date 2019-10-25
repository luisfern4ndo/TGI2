using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativarInformativo : MonoBehaviour
{
    public float timer = 0.0f;
    public float waitingTime = 4.0f;
   
    void Start()
    {

    }
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            gameObject.SetActive(false);
            timer = 0f;
        }
    }
}
