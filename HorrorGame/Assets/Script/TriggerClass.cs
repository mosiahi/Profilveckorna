using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerClass : MonoBehaviour
{
    public bool TriggerComplete = false;
    public Collider2D myCollider;
    public int TriggerId;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void myUpdate();
    public abstract void myOnTriggerCheck(Collider2D collision);

    /// <summary>
    /// Set in start
    /// </summary>
    protected void SetCollider()
    {
        myCollider = GetComponent<Collider2D>();
    }

    protected bool RightTrigger(Collider2D collision)
    {
        if (collision.GetComponent<TriggerClass>() && myCollider)
        {
            if (collision.GetComponent<TriggerClass>().TriggerId == myCollider.GetComponent<TriggerClass>().TriggerId)
            {
                return true;
            }
        }
        return false;
    }
}
