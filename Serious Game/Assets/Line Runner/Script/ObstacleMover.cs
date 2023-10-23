using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RareCoders
{
    public class ObstacleMover : MonoBehaviour
    {
        private float currentPosition;

        public float speed;

        UIController _UIController;

        private void OnEnable()
        {
            _UIController = FindObjectOfType<UIController>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (TheGlobals.playingMode)
            {
                currentPosition = transform.localPosition.y;
                currentPosition = currentPosition + Time.deltaTime * speed;
                transform.localPosition = new Vector3(transform.localPosition.x, currentPosition, transform.localPosition.z);
            }
        }
    }
}