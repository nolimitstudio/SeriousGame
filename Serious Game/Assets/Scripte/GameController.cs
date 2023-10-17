using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text tutorialText;
    public Button understandButton;
    public Button nextButton;
    public GameObject[] tutorialObjects;
    public Text delayedText;
    public GameObject delayedPanel;
    public float delayDuration = 3.0f;
    private float delayTimer = 0.0f;
    private bool isDelayActive = false;
    private int currentStep = 0;
    private bool isTutorialCompleted = false;

    private string[] tutorialSteps = {
        "Step 1: Click the red ball to continue.",
        "Step 2: Click the green cube to continue.",
        // Add more steps as needed
    };

    private void Start()
    {
        tutorialText.gameObject.SetActive(false);
        understandButton.onClick.AddListener(OnUnderstandButtonClick);
        nextButton.onClick.AddListener(ShowTutorialPanel);
        delayedPanel.SetActive(false);
    }

    private void ShowTutorialPanel()
    {
        if (currentStep < tutorialSteps.Length)
        {
            tutorialText.gameObject.SetActive(true);
            tutorialText.text = tutorialSteps[currentStep];

            if (isDelayActive)
            {
                delayedPanel.SetActive(true);
                delayedText.text = "Next step will begin in: " + Mathf.Ceil(delayDuration - delayTimer);
            }
        }
    }

    private void OnUnderstandButtonClick()
    {
        if (isTutorialCompleted)
        {
            return; // Don't continue if the tutorial is completed.
        }

        currentStep++;
        if (currentStep < tutorialSteps.Length)
        {
            ShowTutorialPanel();
            StartDelayTimer();
        }
        else
        {
            tutorialText.text = "Tutorial Complete!";
            isTutorialCompleted = true;
            isDelayActive = false;
            delayedPanel.SetActive(false);
        }
    }

    private void StartDelayTimer()
    {
        isDelayActive = true;
        delayTimer = 0.0f;
        InvokeRepeating("UpdateDelayTimer", 0.0f, 1.0f);
    }

    private void UpdateDelayTimer()
    {
        delayTimer += 1.0f;
        if (delayTimer >= delayDuration)
        {
            isDelayActive = false;
            CancelInvoke("UpdateDelayTimer");
        }
        else
        {
            delayedText.text = "Next step will begin in: " + Mathf.Ceil(delayDuration - delayTimer);
        }
    }

    private void Update()
    {
        if (isTutorialCompleted)
        {
            return; // Don't check for object clicks if the tutorial is completed.
        }

        if (currentStep < tutorialSteps.Length)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == tutorialObjects[currentStep])
                    {
                        OnUnderstandButtonClick();
                    }
                }
            }
        }
    }
}
