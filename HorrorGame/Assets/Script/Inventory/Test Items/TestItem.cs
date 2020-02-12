using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : ItemClass
{
    [SerializeField] string Name, Description;
    [SerializeField] float AmountToRestore;
    Player Player;
    FloatValue PlayerHpFloatValue;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ItemName = Name;
        ItemDescription = Description;
        PlayerHpFloatValue = Player.currentHealth;
        PlayerHpFloatValue.RuntimeValue -= 3;
    }

    // Update is called once per frame
    //public void Awake ()
    //{
    //    type = ItemType.Medkit;
    //}

    public override void UseItem()
    {
        PlayerHpFloatValue.RuntimeValue += AmountToRestore;
        if (PlayerHpFloatValue.RuntimeValue > PlayerHpFloatValue.initialValue)
        {
            PlayerHpFloatValue.RuntimeValue = PlayerHpFloatValue.initialValue;
        }
    }
}
