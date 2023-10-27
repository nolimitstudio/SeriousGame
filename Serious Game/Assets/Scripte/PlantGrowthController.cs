using System;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlantGrowthController : MonoBehaviour
{
    public Button waterButton;
    public Text cooldownText;
    public float cooldownDuration = 120f; // Cooldown duration in seconds
    public int remainingAcreage = 100; // Remaining acreage to water
    public int waterned;



    private int frestclik=0;

    private DateTime lastClickTime;


    public GameManager GameManager;

    public string kayname;
    

    private void Start()
    {
        waterButton.onClick.AddListener(OnWaterButtonClick);
        LoadLastClickTime();
        UpdateButtonState();
        frestclik = PlayerPrefs.GetInt("frestclik", 0);

       

    }

    private void OnWaterButtonClick()
    {

      
            if (frestclik == 0)
            {

            }
            else
            {

                GameManager.XPGoldResource(50);

            }
            float randomCooldown = UnityEngine.Random.Range(2 * 3600, 6 * 3600);
            lastClickTime = DateTime.Now.AddSeconds(randomCooldown);
            PlayerPrefs.SetString(kayname, lastClickTime.ToString("O"));
            PlayerPrefs.Save();
            remainingAcreage -= 10;
            UpdateButtonState();
            PlayerPrefs.SetInt("frestclik", 2);


       
       
    }
      
     

    private void LoadLastClickTime()
    {
        if (PlayerPrefs.HasKey(kayname))
        {
            lastClickTime = DateTime.Parse(PlayerPrefs.GetString(kayname));
        }
    }
    private void Update()
    {
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        TimeSpan timePassed = DateTime.Now - lastClickTime;
        float timePassedInSeconds = (float)timePassed.TotalSeconds;
        if (timePassedInSeconds >= cooldownDuration)
        {
            waterButton.interactable = true;
            cooldownText.text = ".ﺪﯿﻫﺪﺑ ﺏﺁ ﺍﺭ ﻞﮔ ";
        }
        else
        {
          //  waterButton.interactable = false;
            float timeRemainingInSeconds = cooldownDuration - timePassedInSeconds;
            TimeSpan timeRemaining = TimeSpan.FromSeconds(timeRemainingInSeconds);
            cooldownText.text = $" :ﯽﻫﺩ ﺏﺁ ﻥﺎﻣﺯ  {timeRemaining.Hours:D2}:{timeRemaining.Minutes:D2}:{timeRemaining.Seconds:D2}";
        }
    }
}