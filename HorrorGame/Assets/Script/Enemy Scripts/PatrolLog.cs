using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;
    public bool myValue = false;

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                anim.SetBool("wakeUp", true);
            }
        }

        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);

                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
            }
            else
            {
                ChangeGoal();
            }

        }

    }
    public void ChangeGoal()
    {
        if (currentPoint == 0)
        {
            myValue = false;
        }
        if (currentPoint == path.Length - 1)
        {
            myValue = true;
            currentPoint -= 1;
            currentGoal = path[currentPoint];
        }
        else if (myValue == true)
        {
            currentPoint -= 1;
            currentGoal = path[currentPoint];
        }

        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
