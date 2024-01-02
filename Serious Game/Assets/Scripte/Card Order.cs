using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardOrder : MonoBehaviour
{

    public GameObject[] Cards;
    private GameObject [] iCards= new GameObject[3];
    private int indax=0;
     private int inday=0;

    // Start is called before the first frame update
    void Start()
    {
        creator();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.WorldToScreenPoint(Input.mousePosition), Vector2.zero); \
        if (hit.collider != null)
        {
            Debug.LogError(hit.collider);
            if (hit.collider.gameObject== iCards[inday])
            {
                inday++;
                Debug.LogError(hit.collider.gameObject == iCards[inday]);
            }
            else
            {

            }
        }
    }
    public void creator()
    {
       GameObject s = Instantiate(Cards[Random.Range(0, 10)], new Vector3(0, 10, 0), 
            Quaternion.identity);
        s.transform.DOLocalMoveY(-20, 5.0f);
        iCards[indax]= s;
        indax++;
        if (indax==3)
        {
            indax = 0;
            return;
        }
        else
        {
            Invoke("creator", 5F);
        }
    }



}
