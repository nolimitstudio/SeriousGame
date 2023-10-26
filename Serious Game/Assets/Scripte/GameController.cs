using AppAdvisory.MathGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class GameController : MonoBehaviour
{
  
    public GameObject storetutral;

    private int crantstore = 0;

    public Sprite[] image;
    public Image Image;

    /// //////////////////////////////////////////////////

    public string[] store_game_find;
    public GameObject panelfind;
    public Text  Textpanel;

    /// //////////////////////////////////////
    public GameObject[] Objects;
    public GameManager gameManager;
    private void Start()
    {
        crantstore = PlayerPrefs.GetInt("EVENT", 0);
        if (crantstore==0)
        {

        }else
        {
            for (int i = 0; i < crantstore; i++)
            {
                Objects[i].SetActive(false);

            }
        }
     
       
    }

    public void ShowTutorialPanel()
    {
        storetutral.SetActive(true);
        Image.gameObject.SetActive(true);
        Textpanel.gameObject.SetActive(false);
        if (crantstore <= image.Length)
        {
            Image.sprite = image[crantstore];

        }


    }

    public void OnUnderstandButtonClick()
    {
        storetutral.SetActive(false);
        panelfind.SetActive(false);
        Image.gameObject.SetActive(false);
        Textpanel.gameObject.SetActive(true);
    }

   

    public   void objectfind()
    {
        switch (crantstore)
        {
            case 0:
                gameManager.ModifyWaterResource(100);
                gameManager.XPGoldResource(50);
                break;
            case 1:
                gameManager.ModifyGoldResource(100);
                gameManager.XPGoldResource(60);
                break;
            case 2:
                gameManager.ModifyGoldResource(110);
                gameManager.XPGoldResource(70);
                break;
            case 3:
                gameManager.ModifyGoldResource(120);
                gameManager.XPGoldResource(80);
                break;
            case 4:
                gameManager.ModifyGoldResource(150);
                gameManager.XPGoldResource(100);
                break;
            default:
                break;
        }
        panelfind.SetActive(true);
        Image.gameObject.SetActive(false);
        Textpanel.text = store_game_find[crantstore];

        if (!(crantstore== image.Length))
        {
            crantstore++;
        }
      
        PlayerPrefs.SetInt("EVENT", crantstore);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject== Objects[crantstore])
                {
                    Objects[crantstore].SetActive(false);  
                    objectfind();
                     Debug.Log(hit.collider.gameObject);
                }
            }

        }
    }


}
