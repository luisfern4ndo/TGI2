using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelDev : MonoBehaviour
{
    public GameObject painelDev;
    public void mostrarDev()
    {
        if (painelDev.activeInHierarchy) {
            painelDev.SetActive(false);
        }
        else { 
        painelDev.SetActive(true);
        }
    }
    
}
