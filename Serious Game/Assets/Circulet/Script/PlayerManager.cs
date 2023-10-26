using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    GameObject crashParticle;

    UIController _uiController;



    private void OnEnable()
    {
        _uiController = FindObjectOfType<UIController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
        

            collision.gameObject.SetActive(false);
            
            crashParticle.transform.position = transform.position;
            crashParticle.SetActive(true);

            Camera.main.GetComponent<CameraShake>().ShakeCamera(0.6f);

            _uiController.GameOver();

            gameObject.SetActive(false);
        }

        if (collision.gameObject.layer == 9)
        {
            collision.enabled = false;
          
            collision.gameObject.GetComponent<AddInScore>().moveTowardsTarget = true;           
        }
    }
}
