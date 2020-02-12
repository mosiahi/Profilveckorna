using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObjects : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemClass _myItem, int _myAmount, int _myId)
    {
        bool tempHasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            //if (Container[i].myItem == _myItem)
            //{
            //    Container[i].AddAmount(_myAmount);
                
            //    tempHasItem = true;
            //    break;
            //}
        }
        if (!tempHasItem)
        {
            Container.Add(new InventorySlot(_myItem, _myAmount, _myId));
            _myId++;
        }
    }

    [System.Serializable]
    public class InventorySlot
    {
        public ItemClass myItem;
        public int myAmount;
        public int myId = 0;
        public InventorySlot(ItemClass _myItem, int _myAmount, int _myId)
        {
            myItem = _myItem;
            myAmount = _myAmount;
            myId = _myId;
        }
        public void AddAmount(int Value)
        {
            myAmount += Value;
        }

    }
}
