using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : ItemClass
{
    [SerializeField] string Name, Description;
    [SerializeField] GameObject DoorToOpen;
    public bool OpenDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        DoorToOpen.GetComponent<KeyCollison>().SetKeyScript = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void UseItem()
    {
        OpenDoor = true;
    }
}
