using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReflect : MonoBehaviour
{
    Renderer mySR;
    int SLId;
    public bool HasLightOnIt = false;
    public bool DestroyAfterLightIsGone = false;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<Renderer>();
        SLId = mySR.sortingLayerID;
        HasLightOnIt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasLightOnIt)
        {
            mySR.sortingLayerID = SLId;
            if (DestroyAfterLightIsGone)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            HasLightOnIt = false;
        }
    }
}
