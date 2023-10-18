using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Objectselector: MonoBehaviour
{

    public GameObject menuPanel; // Reference to your menu panel in the Canvas.
    private bool isMenuOpen = false;
    
    private GameObject selctbl;
    private bool flogselect=true;
    public Text text;
    private Name namecomponet;
    public Button Enter;
    void Start()
    {
        // Ensure the menuPanel is initially disabled.
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Check for mouse click (you can use other input methods too).
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse cursor position.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent<Name>(out namecomponet))
                {


                    // Check if the ray hits the object with this script.
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
        SceneManager.LoadScene(level);
    }

    public void Defalt()
    {
        Debug.Log("ok");
        selctbl.transform.DOScale(new Vector3(selctbl.transform.localScale.x - 0.005f, selctbl.transform.localScale.y - 0.005f, selctbl.transform.localScale.z - 0.005f),0.2f);
      
    }
}
