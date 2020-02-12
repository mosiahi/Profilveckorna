using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissonObjective : MonoBehaviour
{
    public List<TriggerClass> myTriggers = new List<TriggerClass>();
    public bool MissonComplete = false;
    [TextArea(15, 20)]
    public string MissonText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MissonUpdate()
    {
        bool AllAreCompleted = true;
        for(int i = 0; i < myTriggers.Count; i++)
        {
            myTriggers[i].myUpdate();
            if (!myTriggers[i].TriggerComplete)
            {
                AllAreCompleted = false;
            }
        }
        if (AllAreCompleted)
        {
            MissonComplete = true;
        }
    }

    public void MissionTriggerCheck(Collider2D collision)
    {
        for(int i = 0; i < myTriggers.Count; i++)
        {
            myTriggers[i].myOnTriggerCheck(collision);
        }
    }

    public void GiveTriggersIDs()
    {
        for (int i = 0; i < myTriggers.Count; i++)
        {
            myTriggers[i].TriggerId = i + 1;
        }
    }
}
