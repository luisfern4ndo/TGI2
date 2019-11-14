using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;

public class AudioProximity : MonoBehaviour
{
    public Transform target;
    public AudioSource sound;
    public float distance = 0.3f;
    public float volume = 0.03f;
    public float distanceNotPlay = 5f;


    void Start()
    {

        StartCoroutine(AdjustVolume());

    }

    IEnumerator AdjustVolume()
    {

        

        while (true)
        {
            
            if (sound.isPlaying)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (distanceToTarget > distanceNotPlay)
                 {
                    sound.volume = 0f;
                 }
                  else
                  {
                    if (distanceToTarget < distance)
                     {
                        distanceToTarget = distance;
                     }


                    sound.volume = volume / distanceToTarget;

                   
                  }
                yield return new WaitForSeconds(0.5f);
            }
            
        }

    }
}
