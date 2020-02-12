using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : ItemClass
{
    [SerializeField] string Name, Description;
    [SerializeField] GameObject DoorToOpen;
    public bool OpenDoor = false;
    float TimeToOpenDoor;
    // Start is called before the first frame update
    void Start()
    {
        DoorToOpen.GetComponent<KeyCollison>().SetKeyScript = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(OpenDoor == true)
        {
            TimeToOpenDoor += Time.deltaTime;
            if (TimeToOpenDoor >= 10)
            {
                TimeToOpenDoor = 0;
                OpenDoor = false;
            }
        }
    }

    public override void UseItem()
    {
        OpenDoor = !OpenDoor;
    }
}
