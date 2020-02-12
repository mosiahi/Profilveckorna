using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    public List<MissonObjective> myMissons = new List<MissonObjective>();
    public int MissonIndex;
    [SerializeField] Text myTextToShowObjective;
    // Start is called before the first frame update
    void Start()
    {
        
        myMissons[MissonIndex].GiveTriggersIDs();
    }

    // Update is called once per frame
    void Update()
    {
        if(MissonIndex < myMissons.Count && MissonIndex >= 0)
        {
            myMissons[MissonIndex].MissonUpdate();
            myTextToShowObjective.text = myMissons[MissonIndex].MissonText;
            if (myMissons[MissonIndex].MissonComplete)
            {
                MissonIndex++;
                if (MissonIndex < myMissons.Count && MissonIndex >= 0) myMissons[MissonIndex].GiveTriggersIDs();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MissonIndex < myMissons.Count && MissonIndex >= 0)
        {
            myMissons[MissonIndex].MissionTriggerCheck(collision);
        }
    }
}
