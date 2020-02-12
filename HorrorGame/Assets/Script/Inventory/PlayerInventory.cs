using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObjects inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        DisplayInventory.AccessCanPickUp = false;
        Debug.Log("Yes42342");

        var item = collision.GetComponent<InventoryItems>();
        if (item && inventory.Container.Count <= 12)
        {
            inventory.AddItem(item.myitem, 1, 0);
           
            Destroy(collision.gameObject);
        }
        DisplayInventory.AccessCanPickUp = true;
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        inventory.Container[0].myItem.UseItem();
    //    }
    //}
}
