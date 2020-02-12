using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] MissonsContainer myMissionContainer;
    List<MissonObjective> myMissons = new List<MissonObjective>();
    public int MissonIndex;
    [SerializeField] Text myTextToShowObjective;
    // Start is called before the first frame update
    void Start()
    {
        myMissons = myMissionContainer.missons;
        for (int i = 0; i < myMissons.Count; i++)
        {
            myMissons[i].OtherWayToResetTriggers();
        }
        MissonIndex = myMissionContainer.myMissionIndex;
        if (MissonIndex < myMissons.Count && MissonIndex >= 0)
            myMissons[MissonIndex].GiveTriggersIDs();
        for (int i = 0; i < myMissons.Count; i++)
        {
            myMissons[i].GiveTriggersRealTrigger();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MissonIndex < myMissons.Count && MissonIndex >= 0)
        {
            myMissons[MissonIndex].MissonUpdate();
            myTextToShowObjective.text = myMissons[MissonIndex].MissonText;
            if (myMissons[MissonIndex].MissonComplete)
            {
                MissonIndex++;
                myMissionContainer.myMissionIndex++;
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

    private void OnApplicationQuit()
    {
        myMissionContainer.myMissionIndex = 0;
        for (int i = 0; i < myMissionContainer.missons.Count; i++)
        {
            myMissionContainer.missons[i].MissonComplete = false;
        }
        for (int i = 0; i < myMissons.Count; i++)
        {
            myMissons[i].ResetTriggers();
        }
    }

}
