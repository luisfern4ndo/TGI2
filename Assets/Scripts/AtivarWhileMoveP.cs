using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarWhileMoveP : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    public bool ativar;
    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
        ativar = false;
    }

    void Update()
    {

        if (ativar)
        {

            if (transform.position == pos1.position)
            {
                nextPos = pos2.position;
            }
            if (transform.position == pos2.position)
            {
                nextPos = pos1.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos() //linha mostrando caminho que será percorrido
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

}
