using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using System.Threading;

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
    public GameManager GameManager;
    public SceneSwitcher SceneSwitcher;
    public Text gold;
    public Text water;
    public GameObject scenobj;

    public string roomgame1;
    public string roomgame2;
    public string roomgame3;

    private bool racsting = true;
     

    void Start()
    {
        Minui.SetActive(true);

        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }
     private  bool  ismouseoverui()
    {

        return EventSystem.current.IsPointerOverGameObject();
    }

    void Update()
    {
        if (ismouseoverui())
        {
        }else
        {



            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity ))
                {
                    if (hit.collider.gameObject.TryGetComponent<Name>(out namecomponet))
                    {
                        selctbl = hit.collider.gameObject;
                        selctbl.transform.DOScale(new Vector3(selctbl.transform.localScale.x + 0.005f, selctbl.transform.localScale.y + 0.005f, selctbl.transform.localScale.z + 0.005f), 0.2f);
                        text.text = namecomponet.OB_Name;
                        if (namecomponet.actevobje)
                        {
                            gold.text = namecomponet.gold.ToString();
                            water.text = namecomponet.Water.ToString();
                            scenobj.SetActive(true);
                        }
                        else
                        {
                            scenobj.SetActive(false);
                        }
                       
                        ToggleMenu();
                        Invoke("Defalt", 0.3f);
                    }
                    else
                    {
                        menuPanel.SetActive(false);
                    }

                }
            }


            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

                //if (Physics.Raycast(ray, out hit))
                //{


                //    if ()
                //    {

                //    }
                //    else
                //    {

                //        if (flogselect)
                //        {

                //            if (hit.collider.gameObject.TryGetComponent<Name>(out namecomponet))
                //            {




                //                selctbl = hit.collider.gameObject;

                //                selctbl.transform.DOScale(new Vector3(selctbl.transform.localScale.x + 0.005f, selctbl.transform.localScale.y + 0.005f, selctbl.transform.localScale.z + 0.005f), 0.2f);

                //                text.text = namecomponet.OB_Name;

                //                ToggleMenu();
                //                Invoke("Defalt", 0.3f);
                //                flogselect = false;



                //            }
                //        }

                //        else if (isMenuOpen)
                //        {

                //            ToggleMenu();
                //            flogselect = true;

                //        }

                //    }

                //}




        }
    }

    void ToggleMenu()
    {
        menuPanel.SetActive(true);
        if (namecomponet.actevobje == true )
        {
            Enter.gameObject.SetActive(true);
             Enter.onClick.AddListener(delegate () { LoadSGame(namecomponet.Roomgoname); });
        }
        else
           {
               Enter.gameObject.SetActive(false);
            }




            //isMenuOpen = !isMenuOpen;
            //   menuPanel.SetActive(isMenuOpen); 
            //    if(!isMenuOpen)
            //     return;

            //if (menuPanel != null)
            //{
            //    if ( namecomponet.actevobje== true &&!(namecomponet== null))
            //    {

            //        Enter.gameObject.SetActive(true);
            //        Enter.onClick.AddListener(delegate () { LoadSGame(namecomponet.Roomgoname); });
            //    }
            //    else
            //    {
            //        Enter.gameObject.SetActive(false);
            //    }


            //}

    }
    public void LoadSGame(string level)
    {



        if (namecomponet.Roomgoname == Relaxing)
        {
            if (GameManager.goldresource > namecomponet.gold&& GameManager.waterresource> namecomponet.Water)
            {
                Debug.Log(level + Relaxing);
                CMRelaxing.gameObject.SetActive(true);
                mincamra.gameObject.SetActive(false);
                riaxing_ui.gameObject.SetActive(true);
                minigamepanel.SetActive(false);
                Minui.SetActive(false);
                GameManager.ModifyGoldResource(GameManager.goldresource - namecomponet.gold);
                GameManager.ModifyWaterResource(GameManager.waterresource - namecomponet.Water);
            }
           
           
        }
        else if (namecomponet.Roomgoname == bomgrde)
        {
            if (GameManager.goldresource > namecomponet.gold && GameManager.waterresource > namecomponet.Water)
            {
                bomgarde_camera.gameObject.SetActive(true);
                mincamra.gameObject.SetActive(false);
                bomgrdeui.gameObject.SetActive(true);
                minigamepanel.SetActive(false);
                Minui.SetActive(false);
                GameManager.ModifyGoldResource(GameManager.goldresource - namecomponet.gold);
                GameManager.ModifyWaterResource(GameManager.waterresource - namecomponet.Water);
            }

        }
        else if (namecomponet.Roomgoname == koche)
        {
            if (GameManager.goldresource > namecomponet.gold && GameManager.waterresource > namecomponet.Water)
            {
                koche_camera.gameObject.SetActive(true);
                mincamra.gameObject.SetActive(false);
                koche_ui.gameObject.SetActive(true);
                minigamepanel.SetActive(false);
                Minui.SetActive(false);
                GameManager.ModifyGoldResource(GameManager.goldresource - namecomponet.gold);
                GameManager.ModifyWaterResource(GameManager.waterresource - namecomponet.Water);
            }
        }
        else if (level == minigame)
        {
         
            minigamepanel.SetActive(true);
        }
        else
        {
            if (GameManager.goldresource > namecomponet.gold && GameManager.waterresource > namecomponet.Water)
            {
                SceneSwitcher.sceneToLoad = level;
                SceneSwitcher.LoadScene();
                Minui.SetActive(false);
                GameManager.ModifyGoldResource(GameManager.goldresource - namecomponet.gold);
                GameManager.ModifyWaterResource(GameManager.waterresource - namecomponet.Water);
            }


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
