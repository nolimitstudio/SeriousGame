using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramoving: MonoBehaviour
{
    public float xmaxRange = 10.0f;
    public float zmaxRange = 10.0f;
    public float xmaxRangeDOwn = 10.0f;
    public float zmaxRangeDown = 10.0f;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (gameObject.transform.position.x>= xmaxRange)
        {
            gameObject.transform.position = new Vector3(xmaxRange, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if(gameObject.transform.position.x <= xmaxRangeDOwn)
        {
            gameObject.transform.position = new Vector3(xmaxRangeDOwn, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.z >= zmaxRange)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zmaxRange);
        }
        else if (gameObject.transform.position.z <= zmaxRangeDown)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zmaxRangeDown);
        }
        // gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmaxRangeDOwn, xmaxRange), transform.position.y, Mathf.Clamp(transform.position.z, zmaxRangeDown, zmaxRange));
    }
}
