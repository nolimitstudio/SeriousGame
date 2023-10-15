using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TrainingManager : MonoBehaviour
{

    public Camera[] cameras;         
    public Text[] presentationTexts;
    public Button nextButton;
    public string nextSceneName = "MainGame"; 

    private int currentPresentationIndex = 0;
    private bool hasDisplayedPresentations = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PresentationsDisplayed"))
        {
            hasDisplayedPresentations = PlayerPrefs.GetInt("PresentationsDisplayed") == 1;
        }

        if (hasDisplayedPresentations)
        {
            
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].gameObject.SetActive(i == 0);
                presentationTexts[i].gameObject.SetActive(i == 0);
            }

            nextButton.onClick.AddListener(NextButtonClick);
        }
    }

    private void NextButtonClick()
    {
        if (!hasDisplayedPresentations)
        {
            
            cameras[currentPresentationIndex].gameObject.SetActive(false);
            presentationTexts[currentPresentationIndex].gameObject.SetActive(false);

            
            currentPresentationIndex++;

            if (currentPresentationIndex < cameras.Length)
            {
               
                cameras[currentPresentationIndex].gameObject.SetActive(true);
                presentationTexts[currentPresentationIndex].gameObject.SetActive(true);
            }
            else
            {
                
                SceneManager.LoadScene(nextSceneName);

                
                PlayerPrefs.SetInt("PresentationsDisplayed", 1);
            }
        }
    }
}
