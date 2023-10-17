using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Objectselector: MonoBehaviour
{

    public GameObject menuPanel; // Reference to your menu panel in the Canvas.
    private bool isMenuOpen = false;
    public GameObject O_form;
    public GameObject O_Game;
     public GameObject O_Hadeobject;
    private GameObject selctbl;
    private bool flogselect=true;
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
                // Check if the ray hits the object with this script.
                if (hit.collider.gameObject == O_form)
                {
                    if (flogselect)
                    {
                        selctbl = hit.collider.gameObject;

                        selctbl.transform.DOScale(new Vector3(selctbl.transform.localScale.x + 0.5f, selctbl.transform.localScale.y + 0.5f, selctbl.transform.localScale.z + 0.5f), 0.2f);

                        ToggleMenu();
                        Invoke("Defalt", 0.3f);
                        flogselect = false;
                    }
                }
                else if (isMenuOpen)
                {
                    // If the menu is open and you click anywhere else, close it.
                    ToggleMenu();
                    flogselect = true;
                }
            }
            if (hit.collider.gameObject == O_Hadeobject)
            {
                Debug.Log("objectfind");
            }
        }
    }

    void ToggleMenu()
    {
        if (menuPanel != null)
        {
            isMenuOpen = !isMenuOpen;
            menuPanel.SetActive(isMenuOpen);

        }

    }

    public void Defalt()
    {
        selctbl.transform.DOScale(new Vector3(selctbl.transform.localScale.x - 0.5f, selctbl.transform.localScale.y - 0.5f, selctbl.transform.localScale.z - 0.5f),0.2f);
      
    }
}
