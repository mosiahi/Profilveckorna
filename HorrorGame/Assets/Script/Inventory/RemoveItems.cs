using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItems : MonoBehaviour
{
    public InventoryObjects inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory.Container[0].myAmount -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
