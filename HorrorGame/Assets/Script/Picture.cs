using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picture : ItemClass
{
    [SerializeField] string Name, Description;
    [SerializeField] GameObject Panel;
    [SerializeField] Transform Canvas;
    GameObject ClonePanel;

    // Start is called before the first frame update
    void Start()
    {
        ItemName = Name;
        ItemDescription = Description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UseItem()
    {
        ClonePanel = GameObject.Instantiate(Panel,Canvas );
       ClonePanel.SetActive(true);
        ClonePanel.GetComponentInChildren<Button>().onClick.AddListener(ExitPicture);
    }

    void ExitPicture()
    {
        Destroy(ClonePanel);
    }
}
