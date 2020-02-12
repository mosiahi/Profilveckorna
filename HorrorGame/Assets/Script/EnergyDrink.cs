using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : ItemClass
{
    [SerializeField] string Name, Description;
    [SerializeField] float DurationTime;
    [SerializeField] float SpeedIncreas;
    Energy PlayerEnergy;
    // Start is called before the first frame update
    void Start()
    {
        ItemName = Name;
        ItemDescription = Description;
        PlayerEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UseItem()
    {
        PlayerEnergy.StartEnergyKick(DurationTime, SpeedIncreas);
    }
}
