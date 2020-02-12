using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForIfNoteRead : TriggerClass
{
    [SerializeField] Note myNote;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void myUpdate()
    {
        if (myNote.HasBeenRead)
        {
            TriggerComplete = true;
        }
    }
    public override void myOnTriggerCheck(Collider2D collision)
    {
        
    }
}
