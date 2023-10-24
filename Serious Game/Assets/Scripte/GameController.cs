using AppAdvisory.MathGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public string[] store_game;
    public GameObject storetutral;
    public Text Textstore;
    private int crantstore = 0;

    /// //////////////////////////////////////////////////

    public string[] store_game_find;
    public GameObject panelfind;
    public Text Textpanel;

    /// //////////////////////////////////////
    public GameObject[] Objects;
    public GameManager gameManager;
    private void Start()
    {
        crantstore = PlayerPrefs.GetInt("EVENT", 0);
        for (int i = 0; i < crantstore; i++)
        {
            Objects[i].SetActive(false);

        }
    }

    public void ShowTutorialPanel()
    {
        storetutral.SetActive(true);
        if (crantstore <= store_game.Length)
        {
            Textstore.text = store_game[crantstore];

        }


    }

    public void OnUnderstandButtonClick()
    {
        storetutral.SetActive(false);
        panelfind.SetActive(false);
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
      
        Textpanel.text = store_game_find[crantstore];
        panelfind.SetActive(true);
        crantstore++;
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
