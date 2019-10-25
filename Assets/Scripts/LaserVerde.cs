using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserVerde : MonoBehaviour
{ 
public float timer = 0.0f;
public float waitingTime =1.2f;
public GameObject laserAzul;
void Start()
    { 
       
    }
void Update()
{
        
    timer += Time.deltaTime;
    if (timer > waitingTime)
    {
        laserAzul.SetActive(true);
        gameObject.SetActive(false);
            timer = 0f;
    }
}  
}