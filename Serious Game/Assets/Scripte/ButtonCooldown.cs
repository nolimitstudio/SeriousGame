using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    public Button myButton;
    public Text cooldownText;

    private TimeSpan cooldownDuration = TimeSpan.FromMinutes(2);
    private DateTime lastClickTime;

    private void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
        LoadLastClickTime();
        UpdateButtonState();
    }

    private void OnButtonClick()
    {
        lastClickTime = DateTime.Now;
        PlayerPrefs.SetString("LastClickTime", lastClickTime.ToString("O"));
        PlayerPrefs.Save();
        UpdateButtonState();
    }

    private void LoadLastClickTime()
    {
        if (PlayerPrefs.HasKey("LastClickTime"))
        {
            lastClickTime = DateTime.Parse(PlayerPrefs.GetString("LastClickTime"));
        }
    }

    private void UpdateButtonState()
    {
        TimeSpan timePassed = DateTime.Now - lastClickTime;
        if (timePassed >= cooldownDuration)
        {
            myButton.interactable = true;
            cooldownText.text = "Button is ready!";
        }
        else
        {
            myButton.interactable = false;
            TimeSpan timeRemaining = cooldownDuration - timePassed;
            cooldownText.text = $"Button disabled for {timeRemaining.Hours:D2}:{timeRemaining.Minutes:D2}:{timeRemaining.Seconds:D2}";
        }
    }
}
