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
        gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmaxRangeDOwn, xmaxRange), transform.position.y, Mathf.Clamp(transform.position.z, zmaxRangeDown, zmaxRange));
    }
}
