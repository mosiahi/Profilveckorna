using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    [SerializeField] ItemClass item;
    [SerializeField] int n;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            item.UseItem();
        }
        if(item is Note)
        {
            n++;
        }
    }
}
