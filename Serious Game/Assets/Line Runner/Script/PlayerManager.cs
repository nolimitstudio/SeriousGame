using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RareCoders
{

    public class PlayerManager : MonoBehaviour
    {
        #region Private Variables
        private float currentPosition;

        public float speed;

        public float maxSpeed = 5f;

        WaitForSeconds _waitTime;

        Coroutine speedCoroutine;

        Vector3 _scale;

        Vector3 _position;

        public UIController _uiController;

        public GameObject crashEffect;

        

        [SerializeField]

        Camera _cam;



        bool lerpBG = false;

        float _time = 0f;
        #endregion

        private void OnEnable()
        {
            _cam = Camera.main;
            //TheGlobals.playingMode = true;
            _waitTime = new WaitForSeconds(1f);
        }

        private void Update()
        {
            if (TheGlobals.playingMode)
            {
                DetectInput();

            }
        }

        // Update is called once per frame
        //void FixedUpdate()
        //{
        //    if (TheGlobals.playingMode)
        //    {
        //        currentPosition = transform.localPosition.y;
        //        currentPosition = currentPosition + Time.deltaTime * speed;
        //        transform.localPosition = new Vector3(transform.localPosition.x, currentPosition, transform.localPosition.z);
        //    }
        //}

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                TheGlobals.sManager.allAudio[2].Play();
                crashEffect.transform.position = transform.position;
                crashEffect.SetActive(true);
                Camera.main.GetComponent<CameraShake>().ShakeCamera(0.4f);
                _uiController.GameOver();
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 9)
            {
                TheGlobals.sManager.allAudio[1].Play();
                collision.gameObject.SetActive(false);
                lerpBG = true;
            }
        }

        void DetectInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InversePlayer();
            }
        }

        void InversePlayer()
        {
            _scale = transform.localScale;

            _position = transform.position;

            _scale.x = _scale.x * -1;

            _position.x = _position.x * -1;

            transform.localScale = _scale;

            transform.localPosition = _position;
        }

        public void SpeedIncrement()
        {
            speedCoroutine = StartCoroutine(speedManager());
        }

        public void StopIncrement()
        {
            StopCoroutine(speedCoroutine);
        }

        IEnumerator speedManager()
        {
            yield return _waitTime;

            if (speed < maxSpeed)
            {
                speed += 0.05f;
            }
            Debug.Log("Playing Mode " + TheGlobals.playingMode);

            if (TheGlobals.playingMode)
            {
                speedCoroutine = StartCoroutine(speedManager());
            }
        }
    }
}