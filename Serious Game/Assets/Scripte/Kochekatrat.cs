using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Kochekatrat : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject videoPanel;
    public GameObject questionPanel;
    public Text questionText;
    public Button[] answerButtons;
    public VideoPlayer videoPlayer;

    private int currentQuestionIndex = 0;
    private bool videoPlayed = false;

    private string[] questions = {
        "What is 2 + 2?",
        "What is the capital of France?",
        "Which planet is known as the 'Red Planet'?"
    };

    private string[][] answers = {
        new string[] { "3", "4", "5" },
        new string[] { "Berlin", "Madrid", "Paris" },
        new string[] { "Mars", "Jupiter", "Venus" }
    };

    private int[] correctAnswers = { 1, 2, 0 }; // Index of the correct answers

    private void Start()
    {
        // Initialize the game by showing the start panel
        startPanel.SetActive(true);
        videoPanel.SetActive(false);
        questionPanel.SetActive(false);
    }

    public void PlayVideo()
    {
        startPanel.SetActive(false);
        videoPanel.SetActive(true);
        videoPlayer.Play();
        videoPlayed = true;

        // Subscribe to the videoPlayer loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // This method is called when the video reaches its end
        ShowQuestions();
    }

    public void ShowQuestions()
    {
        if (videoPlayed)
        {
            videoPanel.SetActive(false);
            questionPanel.SetActive(true);
            ShowQuestion(currentQuestionIndex);
        }
        else
        {
            Debug.Log("You must watch the video first.");
        }
    }

    private void ShowQuestion(int questionIndex)
    {
        if (questionIndex < questions.Length)
        {
            questionText.text = questions[questionIndex];

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = answers[questionIndex][i];
            }
        }
        else
        {
            Debug.Log("All questions answered. Game Over!");
        }
    }

    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex == correctAnswers[currentQuestionIndex])
        {
            Debug.Log("Correct!");
            currentQuestionIndex++;
            ShowQuestion(currentQuestionIndex);
        }
        else
        {
            Debug.Log("Incorrect. Try again.");
        }
    }
}