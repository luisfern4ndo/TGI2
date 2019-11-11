using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
   // public float highPitchRange = 1.05f;
   // public float lowPitchRange = 95f;


    void Awake()
    {
        if (instance == null){
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

   // public void RandomPitch()
  //  {
  //      float randomPitch = Random.Range(lowPitchRange, highPitchRange);
   //     gameObject.GetComponent<AudioSource>().pitch = randomPitch;
  //  }

}
