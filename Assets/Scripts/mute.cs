using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute : MonoBehaviour
{
    public static bool ativado;

    public bool isMute;
    void Start()
    {
        ativado = true;
        if(AudioListener.volume == 0)
        {
            isMute = true;
        }
    }
    void Update()
    {
       

        if (isMute)
        {
            GetComponent<Animator>().SetBool("Som", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Som", true);
        }

        if (Input.GetKeyDown(KeyCode.S) && ativado)
        {
            Mute();
        }

    }    

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
}
