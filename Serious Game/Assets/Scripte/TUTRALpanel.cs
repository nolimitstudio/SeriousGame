using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TUTRALpanel : MonoBehaviour
{
    public GameObject punel;
    public int kay=0;
    void Start()
    {
        kay = PlayerPrefs.GetInt("kay", 0);
        if (kay==0)
        {
            punel.SetActive(true);
        }else
        {
            punel.SetActive(false);

        }
        
    }

 public  void  undrestand()
    {

        punel.SetActive(false);
        PlayerPrefs.SetInt("kay", 10);

    }
}
