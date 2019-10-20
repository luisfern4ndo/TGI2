using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute : MonoBehaviour
{
    public bool m1;
    public bool m2;
    public bool m3;

    public bool isMute;
    void Start()
    {
        m1 = true;
        m2 = true;
        m3 = true;
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

        if (Input.GetKeyDown(KeyCode.S) && m1 && m2 && m3)
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
