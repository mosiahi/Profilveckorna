using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    Player ThePlayer;
    bool HasEnergyKick = false;
    bool IsResistingDMG = false;
    float CurrentTime;
    float CurrentTime2;
    float OriginalPlayerSpeed;
    [SerializeField] RectTransform EnergyBar;
    [SerializeField] float MaxSpeed;
    bool SeeEnergyBar = true;
    Color EnergyBarColor;
    // Start is called before the first frame update
    void Start()
    {
        ThePlayer = gameObject.GetComponent<Player>();
        OriginalPlayerSpeed = ThePlayer.speed;
        EnergyBarColor = EnergyBar.gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasEnergyKick)
        {
            CurrentTime-= Time.deltaTime;
            if(CurrentTime <= 0)
            {
                CurrentTime = 0;
                HasEnergyKick = false;
                ThePlayer.speed = OriginalPlayerSpeed;
                EnergyBar.gameObject.SetActive(true);
                EnergyBar.gameObject.GetComponent<Image>().color = EnergyBarColor;
            }
            if (ThePlayer.speed >= MaxSpeed - 4)
            {
                EnergyBar.gameObject.GetComponent<Image>().color = Color.red;
                if (SeeEnergyBar)
                {
                    SeeEnergyBar = false;
                    EnergyBar.gameObject.SetActive(false);
                }
                else
                {
                    SeeEnergyBar = true;
                    EnergyBar.gameObject.SetActive(true);
                }
            }

            if (ThePlayer.speed > MaxSpeed)
            {
                ThePlayer.Knock(0, 1000);
            }
        }

        if (IsResistingDMG)
        {
            CurrentTime2 -= Time.deltaTime;
            if(CurrentTime2 <= 0)
            {
                CurrentTime2 = 0;
                IsResistingDMG = false;
                ThePlayer.SetIsResistingDMG(false, 0);
            }
        }


        EnergyBar.sizeDelta = new Vector2(CurrentTime * 100, EnergyBar.sizeDelta.y);
    }

    public void StartEnergyKick(float aTimeToReach, float aSpeedIncrease)
    {
        if(CurrentTime < 0)
        {
            CurrentTime = 0;
        }
        CurrentTime += aTimeToReach;
        HasEnergyKick = true;
        ThePlayer.speed += aSpeedIncrease;
    }
    public void DamageResTimerStart(float duration, float DMGRes)
    {
        if(CurrentTime2 < 0)
        {
            CurrentTime2 = 0;
        }
        CurrentTime2 += duration;
        IsResistingDMG = true;
        ThePlayer.SetIsResistingDMG(true, DMGRes);
    }
}
