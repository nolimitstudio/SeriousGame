using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 
    public Text waterText;
    public Text goldText;

    private float sundVolume = 1.0f;
    private int waterresource = 100;
    private int goldresource = 0;
    private int XPresource = 0;


    private void Start()
    {
        waterresource = PlayerPrefs.GetInt("Water", 0);
        goldresource = PlayerPrefs.GetInt("Gold", 0);
        XPresource = PlayerPrefs.GetInt("XP", 0);
        //ModifyWaterResource(savedWater);
        //ModifyGoldResource(savedGold);
        UpdateResourceUI();
    }

  

    public void AdjustSoundVolume(float volumeChange)
    {
        sundVolume += volumeChange;
        sundVolume = Mathf.Clamp(sundVolume, 0.0f, 1.0f);
        


    }

    public void ModifyWaterResource(int amount)
    {
        waterresource += amount;
        waterresource = Mathf.Max(0, waterresource);
        UpdateResourceUI();

        PlayerPrefs.SetInt("Water", waterresource);
    }

    public void ModifyGoldResource(int amount)
    {
        goldresource += amount;
        goldresource = Mathf.Max(0, goldresource);
        UpdateResourceUI();

        PlayerPrefs.SetInt("Gold", goldresource);
    }
     public  void XPGoldResource(int amount)
    {
        XPresource += amount;
        XPresource = Mathf.Max(0, XPresource);
        UpdateResourceUI();

        PlayerPrefs.SetInt("XP", XPresource);

    }

    private void UpdateResourceUI()
    {
        if (waterText == null || goldText == null)
        {

        } else
        {
            waterText.text =  waterresource.ToString();
            goldText.text =   goldresource.ToString();
        }
    }
}
