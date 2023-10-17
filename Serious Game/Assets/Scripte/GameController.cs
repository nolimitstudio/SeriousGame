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
    private void Start()
    {
      
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
        Textpanel.text = store_game_find[crantstore];
        panelfind.SetActive(true);
        crantstore++;
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
