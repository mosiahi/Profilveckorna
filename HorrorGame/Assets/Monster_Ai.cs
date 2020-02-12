using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Ai : MonoBehaviour
{
    private Transform myTarget;

    private Transform avoidTarget;

    public float mySpeed;
    //public float nextWayPointDistance = 3f;

    private void Start()
    {
        myTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, myTarget.position, mySpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, avoidTarget.position) < 4)
        {

        }
    }


}
