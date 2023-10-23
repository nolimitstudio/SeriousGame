using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RareCoders
{
    public class SpikeSpawner : MonoBehaviour
    {
        public GameObject[] _obstacles;

        public GameObject[] colorChangerObj;

        public float startingPos;

        int currentDirection, lastDirection;

        public xDirection[] xDir;

        public float minY, maxY;

        Vector2 finalPosition;

        public int lastObsIndex;

        public int lastClrChngrIndex;

        Transform lastObject;

        float previousY;

        int directionCount;
        int _randObstacle;

        bool IsLastObjColorChanger = false;

        Vector3 _scale;

        // Start is called before the first frame update
        void Start()
        {
            InitialSpawn();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                ReArrangeObstacle(collision.gameObject);
            }
        }

        void InitialSpawn()
        {
            for (int i = 0; i < _obstacles.Length; i++)
            {
                ChooseDirection();
                _obstacles[i].transform.localPosition = SetThePosition(i);

                _scale = _obstacles[i].transform.localScale;

                _scale.x = xDir[currentDirection]._scaleX;

                _obstacles[i].transform.localScale = _scale;

            }
            lastObsIndex = _obstacles.Length - 1;

        }

        void ChooseDirection()
        {
            currentDirection = Random.Range(0, 2);

            if (lastDirection == currentDirection)
            {
                directionCount++;
                if (directionCount > 1)
                {
                    if (currentDirection == 1)
                        currentDirection = 0;
                    else
                        currentDirection = 1;
                }
            }
            else
            {
                directionCount = 0;
            }
        }

        Vector2 SetThePosition(int index)
        {
            if (index != 0)
            {
                finalPosition.x = Random.Range(xDir[currentDirection].minX,
                    xDir[currentDirection].maxX);
                float previousY = lastObject.localPosition.y;
                if (lastDirection == currentDirection)
                {
                    finalPosition.y = previousY + Random.Range(0.8f, maxY);
                }
                else
                {
                    finalPosition.y = previousY + Random.Range(minY, maxY);
                }

            }
            else
            {
                finalPosition.x = Random.Range(xDir[currentDirection].minX,
                    xDir[currentDirection].maxX);
                finalPosition.y = startingPos;
            }

            lastDirection = currentDirection;

            lastObject = _obstacles[index].transform;

            return finalPosition;
        }

        public void ReArrangeObstacle(GameObject currentObj)
        {
            _randObstacle = Random.Range(1, 100);

            if (_randObstacle % 5 == 0)
            {
                GenerateColorChanger(currentObj);
            }
            else
            {
                GenerateObstacle(currentObj);
            }
        }

        void GenerateObstacle(GameObject currentObj)
        {
            ChooseDirection();

            finalPosition.x = Random.Range(xDir[currentDirection].minX,
                    xDir[currentDirection].maxX);

            float previousY = lastObject.localPosition.y;

            if (!IsLastObjColorChanger)
            {
                if (lastDirection == currentDirection)
                {
                    finalPosition.y = previousY + Random.Range(minY, maxY);
                }
                else
                {
                    finalPosition.y = previousY + Random.Range(3.2f, 4.2f);
                }
            }
            else
            {
                finalPosition.y = previousY + Random.Range(5f, 7f);
            }

            IsLastObjColorChanger = false;

            lastObsIndex = System.Array.IndexOf(_obstacles, currentObj);

            _obstacles[lastObsIndex].transform.localPosition = finalPosition;

            _scale = _obstacles[lastObsIndex].transform.localScale;

            _scale.x = xDir[currentDirection]._scaleX;

            _obstacles[lastObsIndex].transform.localScale = _scale;

            lastObject = currentObj.transform;

            lastDirection = currentDirection;
        }

        void GenerateColorChanger(GameObject currentObj)
        {
            finalPosition.x = Random.Range(0, 1) == 0 ? 0.6f : -0.6f;
            float previousY = lastObject.localPosition.y;
            finalPosition.y = previousY + Random.Range(3f, 5f);
            Debug.Log("Color changer position : " + finalPosition);
            colorChangerObj[lastClrChngrIndex].transform.localPosition = finalPosition;
            colorChangerObj[lastClrChngrIndex].SetActive(true);
            lastObject = colorChangerObj[lastClrChngrIndex].transform;

            lastClrChngrIndex++;

            if (lastClrChngrIndex >= colorChangerObj.Length)
            {
                lastClrChngrIndex = 0;
            }

            GenerateObstacle(currentObj);
        }
    }

    [System.Serializable]
    public struct xDirection
    {
        public float minX;
        public float maxX;

        public float _scaleX;
    }
}
