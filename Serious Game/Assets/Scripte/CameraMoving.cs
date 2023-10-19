using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Cameramoving: MonoBehaviour
{
    public float xmaxRange = 10.0f;
    public float zmaxRange = 10.0f;
    public float xmaxRangeDOwn = 10.0f;
    public float zmaxRangeDown = 10.0f;
    private Vector3 Vector3_move;
    public float timer=0.1f;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (gameObject.transform.position.x>= xmaxRange)
        {
            Vector3_move = new Vector3(xmaxRange, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.DOMove(Vector3_move, timer);
        }
        else if(gameObject.transform.position.x <= xmaxRangeDOwn)
        {
            Vector3_move = new Vector3(xmaxRangeDOwn, gameObject.transform.position.y, gameObject.transform.position.z);gameObject.transform.DOMove(Vector3_move, timer);
        }
        else if (gameObject.transform.position.z >= zmaxRange)
        {
            Vector3_move = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zmaxRange);gameObject.transform.DOMove(Vector3_move, timer);
        }
        else if (gameObject.transform.position.z <= zmaxRangeDown)
        {
            Vector3_move = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zmaxRangeDown);gameObject.transform.DOMove(Vector3_move, timer);
        }
        
        // gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmaxRangeDOwn, xmaxRange), transform.position.y, Mathf.Clamp(transform.position.z, zmaxRangeDown, zmaxRange));
    }
}
