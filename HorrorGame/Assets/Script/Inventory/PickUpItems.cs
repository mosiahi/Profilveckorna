using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public InventoryObjects inventory;

   
    public void UseItem()
    {
        inventory.Container[0].myItem.UseItem();
        inventory.Container[0].myAmount -= 1;
    }
    public void Update()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (inventory.Container[i].myItem == null)
            {
                inventory.Container.RemoveAt(i);
            }
            if (inventory.Container[0].myAmount <= 0)
            {
                inventory.Container.RemoveAt(0);
            }
        }
    }





}
