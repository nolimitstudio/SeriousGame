using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchCard : MonoBehaviour
{
    public Button [] button;
    public Sprite [] Image1;
    public Sprite Defalt;
    public int[] p= new int[24];
    public bool[] finds= new bool [24];
    int x = -1;
    int y = -1;
    int record=0;
    public Text rec;
    private float countdownTime = 5.0f; // Set your desired countdown time in seconds
    private float currentTime;
    private bool restgame=true;
    public Text countdownText;
    private int paressBtn=0;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
          //  button[i].image.sprite = Defalt;
            p[i] = UnityEngine.Random.Range(0, 10);
            button[i].image.sprite = Image1[p[i]];
            finds[i] = false;
        }
        currentTime = countdownTime;
        
    }

   

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0 )
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();
          
            }
        else
        {
           
            countdownTime = 30.0f;
            currentTime = countdownTime;
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateCountdownText();
                if (restgame)
                {
                    for (int i = 0; i < button.Length; i++)
                    {
                        button[i].image.sprite = Defalt;
                    }
                    restgame = false;
                }
            }
            else
            {
                
                currentTime = 0;
                // Optional: Call a function or perform an action when the countdown reaches zero
            }
        }
    }
    public void choose(int name)
    {
        if (paressBtn == 2)
        {
            paressBtn = 0;
            
            Invoke("setdefalt", 0.05f);
        }
        else
        {
            paressBtn++;
            button[name].image.sprite = Image1[p[name]];
           
            if (x < 0)
            {
                x = name;
                Debug.Log("x= " + button[x].image.sprite.name);
            }
            else if (x >= 0)
            {
                y = name;
                Debug.Log("y= " + button[y].image.sprite.name);
                if (button[x].image.sprite.name == button[y].image.sprite.name)
                {
                    Invoke("setdefalt", 0.05f);
                    paressBtn = 0;
                    finds[x]=true; finds[y]=true;
                    record++;
                }
                else
                {
                    record--;
                }
                x = -1; y = -1;
                rec.text = "ﺯﺎﯿﺘﻣﺍ: " + record.ToString();
            }
        }

    }
     public void setdefalt()
    {
        for (int i = 0; i < button.Length; i++)
        {
            if (!finds[i])
            button[i].image.sprite = Defalt;
        }

    }
    void UpdateCountdownText()
    {
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = seconds.ToString();
    }
}
