using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOfItems : MonoBehaviour
{
    private List<ItemClass> itemList;
    public InventoryOfItems()
    {
        itemList = new List<ItemClass>();
       
    }

    public void AddItem(ItemClass item)
    {
        itemList.Add(item);
    }
}
