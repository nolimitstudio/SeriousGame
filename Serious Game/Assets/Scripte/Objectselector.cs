using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Objectselector: MonoBehaviour
{

    public GameObject menuPanel; // Reference to your menu panel in the Canvas.
    private bool isMenuOpen = false;
    
    private GameObject selctbl;
    private bool flogselect=true;
    public Text text;
    private Name namecomponet;
    public Button Enter;
    public string Relaxing;
    public string bomgrde;
    public string koche;
    public string minigame;
    public Camera CMRelaxing;
    public Camera mincamra;
    public GameObject riaxing_ui;
    public GameObject Minui;
    public Camera bomgarde_camera;
    public GameObject bomgrdeui;
    public Camera koche_camera;
    public GameObject koche_ui;
    public GameObject minigamepanel;

    public SceneSwitcher SceneSwitcher;


    public string roomgame1;
    public string roomgame2;
    public string roomgame3;



    void Start()
    {
        Minui.SetActive(true);

        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.gameObject.TryGetComponent<Name>(out namecomponet))
                {
                    

                    
                    if (flogselect)
                    {
                        selctbl = hit.collider.gameObject;

                        selctbl.transform.DOScale(new Vector3(selctbl.transform.localScale.x + 0.005f, selctbl.transform.localScale.y + 0.005f, selctbl.transform.localScale.z + 0.005f), 0.2f);
                        
                        text.text = namecomponet.OB_Name;
                         
                        ToggleMenu();
                        Invoke("Defalt", 0.3f);
                        flogselect = false;
                    }
                }
                
                else if (isMenuOpen)
                {
                    ToggleMenu();
                    flogselect = true;

                }
                
            }
            



        }
    }

    void ToggleMenu()
    {
         isMenuOpen = !isMenuOpen;
            menuPanel.SetActive(isMenuOpen); 
             if(!isMenuOpen)
              return;

        if (menuPanel != null)
        {
            if ( namecomponet.actevobje== true &&!(namecomponet== null))
            {
               
                Enter.gameObject.SetActive(true);
                Enter.onClick.AddListener(delegate () { LoadSGame(namecomponet.Roomgoname); });
            }
            else
            {
                Enter.gameObject.SetActive(false);
            }
           

        }

    }
    public void LoadSGame(string level)
    {

        if (level == Relaxing)
        {
            Debug.Log(level + Relaxing);
            CMRelaxing.gameObject.SetActive(true);
            mincamra.gameObject.SetActive(false);
            riaxing_ui.gameObject.SetActive(true);
            minigamepanel.SetActive(false);
            Minui.SetActive(false);
        }
        else if (level == bomgrde)
        {
            bomgarde_camera.gameObject.SetActive(true);
            mincamra.gameObject.SetActive(false);
            bomgrdeui.gameObject.SetActive(true);
            minigamepanel.SetActive(false);
            Minui.SetActive(false);


        }
        else if (level == koche)
        {
            koche_camera.gameObject.SetActive(true);
            mincamra.gameObject.SetActive(false);
            koche_ui.gameObject.SetActive(true);
            minigamepanel.SetActive(false);
            Minui.SetActive(false);
        }
        else if (level == minigame)
        {
         
            minigamepanel.SetActive(true);
        }
        else
        {
            SceneSwitcher.sceneToLoad = level;
            SceneSwitcher.LoadScene();
            Minui.SetActive(false);


        }
        
    }

    public void bake()
    {

        CMRelaxing.gameObject.SetActive(false);
        mincamra.gameObject.SetActive(true);
        riaxing_ui.gameObject.SetActive(false);
        Minui.SetActive(true);
        koche_camera.gameObject.SetActive(false) ;
        koche_ui.SetActive(false) ;
        bomgarde_camera.gameObject.SetActive(false);
        bomgrdeui.SetActive(false) ;
        minigamepanel.SetActive(false);


    }

    public void Defalt()
    {
        Debug.Log("ok");
        selctbl.transform.DOScale(new Vector3(selctbl.transform.localScale.x - 0.005f, selctbl.transform.localScale.y - 0.005f, selctbl.transform.localScale.z - 0.005f),0.2f);
      

    }




     public  void roomclike1()
    {
        Minui.SetActive(false);
        SceneSwitcher.sceneToLoad = roomgame1;
        SceneSwitcher.LoadScene();
    
    }
    public void roomclike2()
    {
        Minui.SetActive(false);
        SceneSwitcher.sceneToLoad = roomgame2;
        SceneSwitcher.LoadScene();
       
    }
    public void roomclike3()
    {
        Minui.SetActive(false);
        SceneSwitcher.sceneToLoad = roomgame3;
        SceneSwitcher.LoadScene();
     
    }
}
