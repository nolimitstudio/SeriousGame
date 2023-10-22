using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 lastMousePos;

    public float cameraSpeed = 5.0f;

    public float xmaxRange = 10.0f;
    public float zmaxRange = 10.0f;
    public float xmaxRangeDOwn = 10.0f;
    public float zmaxRangeDown = 10.0f;
     private void FixedUpdate()
    {
        //if (gameObject.transform.position.x>= xmaxRange)
        //{
        //    gameObject.transform.position = new Vector3(xmaxRange, gameObject.transform.position.y, gameObject.transform.position.z);
        //}
        //else if(gameObject.transform.position.x <= xmaxRangeDOwn)
        //{
        //    gameObject.transform.position = new Vector3(xmaxRangeDOwn, gameObject.transform.position.y, gameObject.transform.position.z);
        //}
        //else if (gameObject.transform.position.z >= zmaxRange)
        //{
        //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zmaxRange);
        //}
        //else if (gameObject.transform.position.z <= zmaxRangeDown)
        //{
        //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zmaxRangeDown);
        //}
     
    }
    void Update()
    {
        // Handle mouse input
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePos;

            // Move the camera based on mouse input
            Vector3 cameraPosition = transform.position;
            cameraPosition.x -= deltaMouse.x * cameraSpeed * Time.deltaTime;
            cameraPosition.z -= deltaMouse.y * cameraSpeed * Time.deltaTime;
            gameObject.transform.position = new Vector3(Mathf.Clamp(cameraPosition.x, xmaxRangeDOwn, xmaxRange), transform.position.y, Mathf.Clamp(cameraPosition.z, zmaxRangeDown, zmaxRange));
            //transform.position = cameraPosition;

            lastMousePos = Input.mousePosition;
        }
    }
}
