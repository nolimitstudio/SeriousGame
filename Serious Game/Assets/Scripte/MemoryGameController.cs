using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameController : MonoBehaviour
{
    public List<GameObject> objectNames; // Add the names of the objects you want to control
    public float sequenceDelay = 1.0f; // Time delay between object activations

    private List<GameObject> sequence = new List<GameObject>();
    private int currentIndex = 0;
    private bool playerTurn = false;
    private bool gameOver = false;

    public GameObject panel;
    public Text text;

    public AudioSource[] audioSources;
     

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        playerTurn = false;
        sequence.Clear();
        currentIndex = 0;
        gameOver = false;
        
        panel.SetActive(false);
        StartCoroutine(PlaySequence());
    }

    private IEnumerator PlaySequence()
    {
        for (int i = 0; i < Random.Range(2, objectNames.Count); i++)
        {

            int randomIndex = Random.Range(0, objectNames.Count);
            GameObject randomObjectName = objectNames[randomIndex];

            sequence.Add(randomObjectName);
            audioSources[randomIndex].Play();

            GameObject obj = randomObjectName;
            obj.GetComponent<SpriteRenderer>().color = Color.green;
            yield return new WaitForSeconds(sequenceDelay);
            obj.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(sequenceDelay);

        }
        playerTurn = true;
        gameOver = false;
    }

    private void Update()
    {
        if (playerTurn )
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hit = Physics2D.OverlapPoint(mousePos);

                if (hit != null)
                {
                    GameObject hitObjectName = hit.gameObject;
                    audioSources[int.Parse(hitObjectName.gameObject.name)].Play();
                    if (hitObjectName == sequence[currentIndex])
                    {
                        hitObjectName.GetComponent<SpriteRenderer>().color = Color.green;
                        currentIndex++;
                        

                        if (currentIndex == sequence.Count)
                        {
                            playerTurn = false;
                            Invoke("shopanel", 0.3f);

                        }
                    }
                    else
                    {
                        hitObjectName.GetComponent<SpriteRenderer>().color = Color.red;
                        Invoke("shopanel", 0.3f);
                        playerTurn = false;
                        gameOver = true;
                    }
                }
            }
        }
    }



    public  void shopanel()
    {
        panel.SetActive(true);
        if (gameOver)
        {
            text.text = "GAMEover";
        }
        else
        {
            text.text = "GAMEwin";

        }
        for (int i = 0; i < objectNames.Count; i++)
        {
            objectNames[i].GetComponent<SpriteRenderer>().color = Color.white;
        }

    }


    public void  gaemreset()
    {
        StartGame();


    }
}
