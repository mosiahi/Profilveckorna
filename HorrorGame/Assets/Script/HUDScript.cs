//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HUDscript : MonoBehaviour
//{

//    public Image[] healthImages;

//    private SpriteRenderer sr;

//    void Awake()
//    {
//        sr = GetComponent<SpriteRenderer>();
//    }

//    void Update()
//    {
//        float health = DyingImage();
//        if (health > 50f)
//        {
//            sr.sprite = HealthyImage;
//        }
//        else if (health > 10f)
//        {
//            sr.sprite = HurtImage;
//        }
//        else
//            sr.sprite = DyingImage;
//    }

//}
