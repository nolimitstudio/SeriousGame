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
    public Camera CMRelaxing;
    public Camera mincamra;
    public GameObject riaxing_ui;
    public GameObject Minui;
    public Camera bomgarde_camera;
    public GameObject bomgrdeui;
    public Camera koche_camera;
    public GameObject koche_ui;


    void Start()
    {
        
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
                ToggleMenu();
                flogselect = true;
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
            if (namecomponet.actevobje && namecomponet!= null)
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
              Debug.Log(level+ Relaxing);
            CMRelaxing.gameObject.SetActive(true);
            mincamra.gameObject.SetActive(false);
            riaxing_ui.gameObject.SetActive(true);
            Minui.SetActive(false);
        }
         else  if (level == bomgrde)
        {
            bomgarde_camera.gameObject.SetActive(true);
            mincamra.gameObject.SetActive(false);
            bomgrdeui.gameObject.SetActive(true);
            Minui.SetActive(false);


        }
        else if (level== koche)
        {
            koche_camera.gameObject.SetActive(true);
            mincamra.gameObject.SetActive(false);
            koche_ui.gameObject.SetActive(true);
            Minui.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(level);
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


    }

    public void Defalt()
    {
        Debug.Log("ok");
        selctbl.transform.DOScale(new Vector3(selctbl.transform.localScale.x - 0.005f, selctbl.transform.localScale.y - 0.005f, selctbl.transform.localScale.z - 0.005f),0.2f);
      
    }
}
