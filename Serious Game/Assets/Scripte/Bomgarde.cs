using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
public class Bomgarde : MonoBehaviour
{
    [SerializeField] string[] ENWORD;
    [SerializeField] string[] faWORd;
    [SerializeField] GameObject tutralpanel;
    [SerializeField] Text entext1;
    [SerializeField] Text fatext2;
    [SerializeField] Text entext3;
    [SerializeField] Text fatext4;
    [SerializeField] Text entext5;
    [SerializeField] Text fatext6;
    [SerializeField] GameObject qusshin;
    private bool tutral=true;
    private int moving=0;


    [SerializeField] Text qusshintext;

    [SerializeField] Button qusshintextbtn1;
    [SerializeField] Button qusshintextbtn2;
    [SerializeField] Button qusshintextbtn3;
    [SerializeField] GameObject Alart;
    [SerializeField] GameManager gameManager;
    private int x;
    private void Start()
    {
        tutralpanel.SetActive(false);
        qusshin.SetActive(false);
        qusshintextbtn1.onClick.AddListener(delegate () { bt1(); });
        qusshintextbtn2.onClick.AddListener(delegate () { bt2(); });
        qusshintextbtn3.onClick.AddListener(delegate () { bt3(); });
        starttutral();
        Alart.SetActive(false);

    }

      public  void  bt1()
    {
        if (qusshintextbtn1.GetComponentsInChildren<Text>()[0].text == faWORd[x])
        {
            btnclike();
        }else
        {
            Alart.SetActive(true);
            Invoke("starttimer", 0.3f);
        }


    }
    public void bt2()
    {
        if (qusshintextbtn2.GetComponentsInChildren<Text>()[0].text == faWORd[x])
        {
            btnclike();
        }
        else
        {
            Alart.SetActive(true);
            Invoke("starttimer", 0.3f);
        }

    }
    public void bt3()
    {
        if (qusshintextbtn3.GetComponentsInChildren<Text>()[0].text == faWORd[x])
        {
            btnclike();
        }
        else
        {
            Alart.SetActive(true);
            Invoke("starttimer", 0.3f);
        }

    }
     public  void   starttimer()
    {
        Alart.SetActive(false);

    }



    private void Update()
    {
       
    }

    private void Advance()
    {
       
        
    }

    private void ShowQuestion()
    {
        tutralpanel.SetActive(false);
        x = Random.Range(moving - 3, moving);
        qusshintext.text = " ﺖﺴﯿﭼ ﻪﻤﻠﮐ ﻦﯾﺍ ﯽﻨﻌﻣ  " + "  " + ENWORD[x];
        if (Random.Range(0,2)==1)
        {
            qusshintextbtn1.GetComponentsInChildren<Text>()[0].text = faWORd[moving - 2];
            qusshintextbtn2.GetComponentsInChildren<Text>()[0].text = faWORd[moving - 1];
            qusshintextbtn3.GetComponentsInChildren<Text>()[0].text = faWORd[x];
        }
        else
        {
            qusshintextbtn1.GetComponentsInChildren<Text>()[0].text = faWORd[moving - 2];
            qusshintextbtn2.GetComponentsInChildren<Text>()[0].text = faWORd[x];
            qusshintextbtn3.GetComponentsInChildren<Text>()[0].text = faWORd[moving - 1];
        }

        tutral = true;
        qusshin.SetActive(true);
    }


    public void starttutral()
    {
        if (moving< ENWORD.Length-3)
        {
            qusshin.SetActive(false);
            tutralpanel.SetActive(true);
            entext1.text = ENWORD[moving];
            fatext2.text = faWORd[moving];
            moving++;

            entext3.text = ENWORD[moving];
            fatext4.text = faWORd[moving];
            moving++;

            entext5.text = ENWORD[moving];
            fatext6.text = faWORd[moving];
            moving++;

            tutral = false;

        }else
        {
            qusshintext.text = " ﯼﺩﺍﺩ ﺏﺍﻮﺟ ﺍﺭ ﺕﻻﺍﻮﺳ ﯽﻣﺎﻤﺗ ﯽﻟﺎﻋ ";
            qusshintextbtn1.gameObject.SetActive(false);
            qusshintextbtn2.gameObject.SetActive(false);
            qusshintextbtn3.gameObject.SetActive(false);
            gameManager.XPGoldResource(300);

        }

    }




    public   void btnclike()
    {
        if (tutral)
        {
            starttutral();
        }
        else
        {
            ShowQuestion();
        }
    }

   
      
}