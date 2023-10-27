using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public GameObject player;
    public Text waterSource;
    public Text waterBalance;
    public Text timerText;

    public int totalAcreage = 400;
    public int remainingAcreage;
    public int acreageToWater;
    public int waterNeeded;
    public int waterSaved;

    private bool wateringComplete;
    private bool firstTime;
    private bool secondTime;
    private bool timeCompleted;

    private float timer;
    private float waterTimer;

    private void Start()
    {
        remainingAcreage = totalAcreage;
        wateringComplete = false;
        firstTime = false;
        secondTime = false;
        timeCompleted = false;
        waterTimer = 0f;
    }

    private void Update()
    {
        if (!timeCompleted)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F0");
        }

        if (!wateringComplete)
        {
            acreageToWater = Random.Range(1, remainingAcreage + 1);
            waterNeeded = acreageToWater * 10; //10 liters of water per acre
            waterSource.text = waterNeeded.ToString();

            if (waterSaved >= waterNeeded)
            {
                remainingAcreage -= acreageToWater;
                waterSaved -= waterNeeded;
                waterBalance.text = waterSaved.ToString();
                wateringComplete = true;
            }
        }

        if (wateringComplete && !firstTime)
        {
            waterTimer += Time.deltaTime;
            if (waterTimer >= 10f)
            {
                firstTime = true;
                waterTimer = 0f;
            }
        }

        if (wateringComplete && firstTime && !secondTime)
        {
            waterTimer += Time.deltaTime;
            if (waterTimer >= 10f)
            {
                secondTime = true;
                waterTimer = 0f;
            }
        }

        if (secondTime && !timeCompleted)
        {
            timeCompleted = true;
            wateringComplete = false;
        }
    }

    public void Water()
    {
        if (!wateringComplete)
        {
            waterSaved += 10; //Assuming the user waters 10 liters at a time
            waterBalance.text = waterSaved.ToString();
        }
    }
}