using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute : MonoBehaviour
{
    public bool MonitorAtivado { get; set; }

    public bool isMute;
    void Start()
    {
        MonitorAtivado = false;
        if (AudioListener.volume == 0)
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

        if (Input.GetKeyDown(KeyCode.S) && !MonitorAtivado)
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