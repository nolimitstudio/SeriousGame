using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Text waterText;
    public Text goldText;

    private float sundVolume = 1.0f;
    private int waterresource = 100;
    private int goldresource = 0;

    private void Start()
    {
        int savedWater = PlayerPrefs.GetInt("Water", 100);
        int savedGold = PlayerPrefs.GetInt("Gold", 0);
        //ModifyWaterResource(savedWater);
        //ModifyGoldResource(savedGold);
        UpdateResourceUI();
    }

    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void AdjustSoundVolume(float volumeChange)
    {
        sundVolume += volumeChange;
        sundVolume = Mathf.Clamp(sundVolume, 0.0f, 1.0f);
       
    }

    //public void ModifyWaterResource(int amount)
    //{
    //    waterresource += amount;
    //    waterresource = Mathf.Max(0, waterresource);
    //    UpdateResourceUI();
  
    //    PlayerPrefs.SetInt("Water", waterresource);
    //}

    //public void ModifyGoldResource(int amount)
    //{
    //    goldresource += amount;
    //    goldresource = Mathf.Max(0, goldresource);
    //    UpdateResourceUI();
       
    //    PlayerPrefs.SetInt("Gold", goldresource);
    //}

    private void UpdateResourceUI()
    {
        waterText.text = "Water: " + waterresource.ToString();
        goldText.text = "Gold: " + goldresource.ToString();
    }
}
