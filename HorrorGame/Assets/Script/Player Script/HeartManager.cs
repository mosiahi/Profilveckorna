using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    public Sprite FullHealth, Health2, Health3, Health4, Health5, NoHealth; 

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = FullHealth;
        }
    }
    public void UpdateHearts()
    {
        if (playerCurrentHealth.RuntimeValue == 6)
        {
            hearts[0].sprite = FullHealth;
        }
        else if (playerCurrentHealth.RuntimeValue == 5)
        {
            hearts[0].sprite = Health2;
        }
        else if (playerCurrentHealth.RuntimeValue == 4)
        {
            hearts[0].sprite = Health3;
        }
        else if (playerCurrentHealth.RuntimeValue == 3)
        {
            hearts[0].sprite = Health4;
        }
        else if (playerCurrentHealth.RuntimeValue == 2)
        {
            hearts[0].sprite = Health5;
        }
        else if (playerCurrentHealth.RuntimeValue == 1)
        {
            hearts[0].sprite = Health5;
        }
        else
        {
            hearts[0].sprite = NoHealth;
        }


        //float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        //for (int i = 0; i < heartContainers.initialValue; i++)
        //{
        //    if (i <= tempHealth - 1)
        //    {
        //        //Full Heart
        //        hearts[i].sprite = fullHeart;
        //    }
        //    else if (i >= tempHealth)
        //    {
        //        //Empty Heart
        //        hearts[i].sprite = emptyHeart;
        //    }
        //    //else if ()
        //    //{
        //    //    //A Quarter Of A Heart
        //    //    hearts[i].sprite = aQuarterOfAHeart;
        //    //}
        //    //else if ()
        //    //{
        //    //    //Three Quarters Of A Heart
        //    //    hearts[i].sprite = threeQuartersOfAHeart;
        //    //}
        //    else
        //    {
        //        //Half Full Heart
        //        hearts[i].sprite = halfFullHeart;
        //    }

        //}


        //public Sprite fullHeart;
        //public Sprite halfFullHeart;
        //public Sprite emptyHeart;
        //public Sprite aQuarterOfAHeart;
        //public Sprite threeQuartersOfAHeart;
    }
}
