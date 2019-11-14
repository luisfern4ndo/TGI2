using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;

public class AudioProximity : MonoBehaviour
{
    public Transform target;
    public AudioSource sound;
    public float distance = 0.2f;
    public float volume = 0.03f;


    void Start()
    {

        StartCoroutine(AdjustVolume());

    }

    IEnumerator AdjustVolume()
    {

        

        while (true)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (sound.isPlaying)
            {
               // if (distanceToTarget > 4.5f)
              //  {
                //    sound.volume = 0f;
               // }
              //  else
               // {
                    if (distanceToTarget < distance)
                    {
                        distanceToTarget = distance;

                    }


                    sound.volume = volume / distanceToTarget;

                    yield return new WaitForSeconds(0.5f);

               // }
            }
            
        }

    }
}
