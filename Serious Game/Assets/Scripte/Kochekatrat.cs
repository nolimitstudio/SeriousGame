using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Kochekatrat : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject videoPanel;
    public GameObject questionPanel;
    public Text questionText;

    public VideoPlayer videoPlayer;

    private int currentQuestionIndex = 0;
    private bool videoPlayed = false;

    public GameObject[] Qusithain;
    public GameObject NOTture;
    public GameManager GameManager;

    public GameObject sund;

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
        sund.SetActive(true);
        videoPlayed = true;

       
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        sund.SetActive(false);

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
       
        }
        else
        {
            NOTture.SetActive(true);
            Invoke("alart",0.3f);
        }
            
           
       
    }

     public void  voidxpsave()
    { GameManager.XPGoldResource(600); }

    public  void alart()
    {
        NOTture.SetActive(false);
    }
}