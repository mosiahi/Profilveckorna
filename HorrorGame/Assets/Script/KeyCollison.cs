using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollison : MonoBehaviour
{
    KeyScript myKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && myKey.OpenDoor)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && myKey.OpenDoor)
        {
            gameObject.SetActive(false);
        }
    }

    public KeyScript SetKeyScript { set => myKey = value; }
}
