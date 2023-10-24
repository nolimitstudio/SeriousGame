using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RareCoders
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        GameObject MenuPanel;

        [SerializeField]
        Text ScoreText;

        [SerializeField]
        public Image Sound;

        [SerializeField]
        public Image Music;

        [SerializeField]
        AudioClip gameplayMusic;

        private float timer;
        private int score;

        IEnumerator WaitAndLoadScene()
        {
            yield return new WaitForSeconds(0.8f);
            RestartGame();
        }

        private void Update()
        {
            if (TheGlobals.playingMode)
            {
                timer += Time.deltaTime;

                if (timer > 1f)
                {
                    CalculateScore();
                }
            }
        }

        void CalculateScore()
        {
            score += 1;

            //We only need to update the text if the score changed.
            ScoreText.text = score.ToString();
          
            //Reset the timer to 0.
            timer = 0;
        }

        public void PlayClickAudio(int index)
        {
            TheGlobals.sManager.allAudio[index].Play();
        }

        public void StartTheGame()
        {
            MenuPanel.SetActive(false);
            TheGlobals.playingMode = true;

            //playerManager.playerRB.gravityScale = -1f;
        }

        public void GameOver()
        {
            //Time.timeScale = 0f;
            Debug.Log(score/2);
              Debug.Log((score / 10) / score);
            PlayerPrefs.SetInt("Water", (score / 2));
            if (score > GamePreferences.HighScore)
            {
                GamePreferences.HighScore = GamePreferences.LastScore;
            }

            TheGlobals.playingMode = false;
            StartCoroutine(WaitAndLoadScene());
        }

        public void RestartGame()
        {
            //Time.timeScale = 1f;
            TheGlobals.playingMode = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}