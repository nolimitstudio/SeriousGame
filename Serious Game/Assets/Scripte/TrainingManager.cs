using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class TrainingManager : MonoBehaviour
{

    public Camera[] cameras;         
    public GameObject [] presentationTexts;
    public Button nextButton;
    public string nextSceneName = "MainGame"; 

    private int currentPresentationIndex = 0;
    private bool hasDisplayedPresentations = false;
    private int Moving = 0;
    private Camera Camera;
    public SceneSwitcher sceneSwitcher;
    private void Start()
    {
        if (PlayerPrefs.HasKey("PresentationsDisplayed"))
        {
            hasDisplayedPresentations = PlayerPrefs.GetInt("PresentationsDisplayed") == 1;
        }

        if (hasDisplayedPresentations)
        {
            sceneSwitcher.sceneToLoad = "Intro";
            sceneSwitcher.LoadScene();
        }
        else
        {
            
            //for (int i = 0; i < cameras.Length; i++)
            //{
            //    cameras[i].gameObject.SetActive(false);
            //    presentationTexts[i].SetActive(false);
            //}

            nextButton.onClick.AddListener(NextButtonClick);
            nextButton.gameObject.SetActive(false);
            Moving++;
           // Invoke("NextButtonClick", 3.3f);
            nextButton.gameObject.SetActive(true);

        }
    }

    private void NextButtonClick()
    {
        if (!hasDisplayedPresentations)
        {
           
            nextButton.gameObject.SetActive(true);
                cameras[currentPresentationIndex].gameObject.SetActive(false);


                presentationTexts[currentPresentationIndex].SetActive(false);

                currentPresentationIndex++;



                if (currentPresentationIndex < presentationTexts.Length)
                {


                    cameras[currentPresentationIndex].gameObject.SetActive(true);



                    presentationTexts[currentPresentationIndex].gameObject.SetActive(true);

                }
           
            else
            {
                PlayerPrefs.SetInt("PresentationsDisplayed", 1);
                sceneSwitcher.sceneToLoad = "Intro";
                sceneSwitcher.LoadScene();



            }
            //if (!(Moving==1))
            //{
            //    Moving++;
            //    Invoke("NextButtonClick", 3.3f);
            //}
            //else
            //{
               
            //}
        }
    }
}
