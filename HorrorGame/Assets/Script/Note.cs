using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : ItemClass
{
    [SerializeField] Text NoteText;
    [SerializeField] Button ExitButton;
    [SerializeField] GameObject ScrollArea;
    [SerializeField] string Name;
    [SerializeField] string Description = "Note to read from";
    public bool HasBeenRead = false;
    // Start is called before the first frame update
    void Start()
    {
        ItemName = Name;
        ItemDescription = Description;
        ExitButton.onClick.AddListener(ExitNote);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void UseItem()
    {
        ScrollArea.SetActive(true);
        ExitButton.gameObject.SetActive(true);
        NoteText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(NoteText.gameObject.GetComponent<RectTransform>().sizeDelta.x
            ,NoteText.preferredHeight);
        ScrollArea.GetComponentInChildren<Scrollbar>().value = 1;
    }

    void ExitNote()
    {
        ScrollArea.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        if (GameObject.Find("DiscardButton"))
        {
            GameObject.Find("DiscardButton").SetActive(false);
        }
        HasBeenRead = true;
    }


}


