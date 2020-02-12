using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextFOrTime : TriggerClass
{
    bool WriteText = false;
    bool CanWriteText = true;
    bool FadeIn = true;
    [SerializeField] float TimeToShowText;
    float CurrentTime;
    [SerializeField] GameObject myTextObj;
    // Start is called before the first frame update
    void Start()
    {
        //SetCollider();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
    IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    public override void myUpdate()
    {
        if (CanWriteText)
        {
            if (WriteText)
            {
                myTextObj.SetActive(true);
                if (FadeIn)
                {
                    StartCoroutine(FadeTextToFullAlpha(1, myTextObj.GetComponent<Text>()));
                    FadeIn = false;
                }
                CurrentTime += Time.deltaTime;
                if (CurrentTime >= TimeToShowText)
                {
                    WriteText = false;
                    CanWriteText = false;
                    CurrentTime = 0;
                    StartCoroutine(FadeTextToZeroAlpha(1, myTextObj.GetComponent<Text>()));
                }
            }
        }
        if (myTextObj.GetComponent<Text>().color.a <= 0)
        {
            myTextObj.SetActive(false);
            TriggerComplete = true;
        }
    }
    public override void myOnTriggerCheck(Collider2D collision)
    {
        if (RightTrigger(collision))
        {
            WriteText = true;
        }
    }
}
