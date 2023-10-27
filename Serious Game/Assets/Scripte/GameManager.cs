using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 
    public Text waterText;
    public Text goldText;
    public Text danesh;
    public Slider SliderVolume;

    private float sundVolume = 1.0f;
    public int waterresource = 100;
    public int goldresource = 0;
    public int XPresource = 0;

    public AudioSource [] audioSources;
    public GameObject sting;

    public  CameraController controller;
    public GameObject alartdeilog;

    public bool introscen;
    private void Start()
    {
        waterresource = PlayerPrefs.GetInt("Water", 0);
        goldresource = PlayerPrefs.GetInt("Gold", 0);
        XPresource = PlayerPrefs.GetInt("XP", 0);
 	        UpdateResourceUI();
        if (introscen)
        {
            sting.SetActive(false);
            alartdeilog.SetActive(false);
            Invoke("alart", 1f);
         
           
            SliderVolume.value = PlayerPrefs.GetFloat("sund", 1f);
        }
       

        audioSources = FindObjectsOfType<AudioSource>();
        if (audioSources== null)
        {

        }
        else
        {
            for (int i = 0; i < audioSources.Length; i++)
            {

                audioSources[i].volume = PlayerPrefs.GetFloat("sund", 1f);
            }


        }
    }
     public  void alart()
    {
        if (PlayerPrefs.GetInt("alart",0)==0)
        {
            alartdeilog.SetActive(true);
            controller.enabled = !alartdeilog.active;
            PlayerPrefs.SetInt("alart", 5);
        }else
        {
        

        }

    }
    public  void andrstandclick()
    {
        alartdeilog.SetActive(false);
        controller.enabled = !alartdeilog.active;


    }


    public void AdjustSoundVolume()
    {
        sundVolume += SliderVolume.value;
        sundVolume = Mathf.Clamp(sundVolume, 0.0f, 1.0f);
        PlayerPrefs.SetFloat("sund", sundVolume);
        if (audioSources == null)
        {

        }
        else
        {
            for (int i = 0; i < audioSources.Length; i++)
            {

                audioSources[i].volume = PlayerPrefs.GetFloat("sund", 1f);
            }


        }
       

    }


      public  void openstingpanel()
    {
        sting.SetActive(!sting.active);
        controller.enabled = !sting.active;

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
        if (waterText == null || goldText == null|| danesh==null)
        {

        } else
        {
            danesh.text = XPresource.ToString();
            waterText.text =  waterresource.ToString();
            goldText.text =   goldresource.ToString();
        }
    }
}
