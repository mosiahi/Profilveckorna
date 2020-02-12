using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MissionContainer", menuName = "MissonContainer")]
public class MissonsContainer : ScriptableObject
{
    public List<MissonObjective> missons = new List<MissonObjective>();
    public int myMissionIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
