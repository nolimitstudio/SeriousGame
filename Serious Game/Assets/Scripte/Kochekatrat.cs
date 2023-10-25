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

    public GameObject[] Qusithain;
    public GameObject NOTture;
    public GameManager GameManager;

    private void Start()
    {
       
        startPanel.SetActive(true);
        videoPanel.SetActive(false);
        questionPanel.SetActive(false);
    }

    public void PlayVideo()
    {
        startPanel.SetActive(false);
        videoPanel.SetActive(false);
        videoPlayer.Play();
        videoPlayed = true;

       
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
     
        ShowQuestions();
    }

    public void ShowQuestions()
    {
        if (videoPlayed)
        {
            videoPanel.SetActive(false);
         
            ShowQuestion(currentQuestionIndex);
        }
        else
        {
           
        }
    }

    private void ShowQuestion(int questionIndex)
    {
        if (questionIndex < Qusithain.Length)
        {
            Qusithain[questionIndex].SetActive(true);
        }
        else
        {
            Debug.Log("All questions answered. Game Over!");
        }
    }

    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex==1)
        {
            currentQuestionIndex++;
            ShowQuestion(currentQuestionIndex);
            GameManager.XPGoldResource(600);
        }
        else
        {
            NOTture.SetActive(true);
            Invoke("alart",0.3f);
        }
            
           
       
    }


    public  void alart()
    {
        NOTture.SetActive(false);
    }
}