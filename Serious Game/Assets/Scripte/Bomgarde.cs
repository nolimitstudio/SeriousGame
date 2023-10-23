using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bomgarde : MonoBehaviour
{
    public GameObject[] panels;      // An array of panel GameObjects
    public Text questionText;        // Text component to display questions
    public Button nextButton;        // Button to advance to the next panel or question
    private int currentPanelIndex;   // Index of the currently displayed panel
    private string[] questions;      // Array of questions
    private int currentQuestionIndex; // Index of the current question

    private bool buttonPressed;      // Flag to check if the button is pressed

    private void Start()
    {
        currentPanelIndex = 0;
        currentQuestionIndex = 0;
        buttonPressed = false;

        // Assign your questions to the questions array
        questions = new string[]
        {
            "Question 1",
            "Question 2",
            "Question 3"
            // Add more questions as needed
        };

        // Set up a button click event to handle panel and question progression
        nextButton.onClick.AddListener(Advance);
    }

    private void Update()
    {
        // Check if the button is released
        if (buttonPressed && !nextButton.interactable)
        {
            buttonPressed = false;
            Advance();
        }
    }

    private void Advance()
    {
        if (currentPanelIndex < panels.Length)
        {
            // Hide the current panel
            if (currentPanelIndex > 0)
            {
                panels[currentPanelIndex - 1].SetActive(false);
            }

            // Show the next panel
            panels[currentPanelIndex].SetActive(true);

            currentPanelIndex++;

            if (currentPanelIndex == panels.Length)
            {
                // All panels have been displayed, show questions
                ShowQuestion();
            }
        }
        else if (currentQuestionIndex < questions.Length)
        {
            // Display the next question
            ShowQuestion();
        }
        else
        {
            // All panels and questions have been displayed
            Debug.Log("Game completed.");
        }
    }

    private void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            // Display the next question
            questionText.text = questions[currentQuestionIndex];
            currentQuestionIndex++;
        }
        else
        {
            // All questions answered, perform some action (e.g., go to the end screen).
            Debug.Log("All questions answered. End of the game.");
        }
    }
}