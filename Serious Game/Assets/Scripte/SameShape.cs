using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class SameShape : MonoBehaviour
{

    [SerializeField] GameObject[] symboles;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject OkButten,YesButten,NoButten;
    [SerializeField] Text notice,recordTV;
    [SerializeField] int record = 0;
    private int priv,next;

    private GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        priv = UnityEngine.Random.Range(0, symboles.Length);
        insta(priv, new Vector3(0f, 0f, 0f));
    }
    
    public void firstOK() 
    {
        next = UnityEngine.Random.Range(0, symboles.Length);
        notice.text = "؟ﺖﺳﺍ ﺮﺑﺍﺮﺑ ﻞﺒﻗ ﺩﺎﻤﻧ ﺎﺑ ﺩﺎﻤﻧ ﻦﯾﺍ";
        insta(next, new Vector3(target.transform.position.x+1.5f, 0f, 0f));
        OkButten.SetActive(false);
        YesButten.SetActive(true);
        NoButten.SetActive(true);

    }

    public void Yes()
    {
        if (priv==next)
        {
            record++;
        }
        else
        {
            record--;
        }
        recordTV.text = record.ToString();
        Debug.Log(record);
        priv = next;
        next = UnityEngine.Random.Range(0, symboles.Length);
        notice.text = "؟ﺖﺳﺍ ﺮﺑﺍﺮﺑ ﻞﺒﻗ ﺩﺎﻤﻧ ﺎﺑ ﺩﺎﻤﻧ ﻦﯾﺍ";
        insta(next, new Vector3(target.transform.position.x + 1.5f, 0f, 0f));
    }

    public void No()
    {
        if (priv != next)
        {
            record++;
        }
        else
        {
            record--;
        }
        recordTV.text = record.ToString();
        Debug.Log(record);
        priv = next;
        next = UnityEngine.Random.Range(0, symboles.Length);
        notice.text = "؟ﺖﺳﺍ ﺮﺑﺍﺮﺑ ﻞﺒﻗ ﺩﺎﻤﻧ ﺎﺑ ﺩﺎﻤﻧ ﻦﯾﺍ";
        insta(next, new Vector3(target.transform.position.x + 1.5f, 0f, 0f));
    }

    private void insta(int index, Vector3 pos)
    {
        target = Instantiate(symboles[index], pos, Quaternion.identity);
        camera.transform.position = new Vector3(target.transform.position.x,
            camera.transform.position.y, camera.transform.position.z);
        transform.DOMove(new Vector3(target.transform.position.x,
            camera.transform.position.y, camera.transform.position.z), 1);
    }

}
