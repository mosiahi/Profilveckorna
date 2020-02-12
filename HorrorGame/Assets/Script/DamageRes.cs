using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRes : ItemClass
{
    [SerializeField] string Name, Description;
    [SerializeField] [Range(0, 1)] float Resistance;
    [SerializeField] float Duration;
    // Start is called before the first frame update
    void Start()
    {
        Resistance = 1 - Resistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UseItem()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Energy>().DamageResTimerStart(Duration, Resistance);
    }
}
