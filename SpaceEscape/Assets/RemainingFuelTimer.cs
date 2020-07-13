using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class RemainingFuelTimer : MonoBehaviour
{
    private float remainingFuel = 5;
    private float pauseTimer = 0;
    private Text fuelText;
    private bool fuelTimerPaused = false;
    private bool gameOver = false;
    private bool paused = false;

    void Start()
    {
        gameOver = false;
        fuelText = GetComponent<Text>();        
        fuelText.text = "Remaining Fuel: " + Mathf.Round(remainingFuel);        
        GameEvents.Current.OnPlayerFuelPickup += OnPlayerFuelPickup;
        GameEvents.Current.OnPlayerItemPickup += OnPlayerItemPickup;
        GameEvents.Current.OnGameOver += OnGameOver;
        GameEvents.Current.OnPaused += OnPaused;
        transform.position = Camera.main.ViewportToWorldPoint(new UnityEngine.Vector3(0.15f, 0.1f, 12f));
    }

    private void OnPaused()
    {
        paused = !paused;
    }

    private void OnGameOver()
    {
        gameOver = true;
    }

    void Update()
    {
        if (!gameOver && !paused)
        {
            if (remainingFuel > 0 && !fuelTimerPaused)
            {
                remainingFuel -= Time.deltaTime;
                fuelText.text = "Remaining Fuel: " + Mathf.Round(remainingFuel);
            }
            else if (remainingFuel <= 0)
            {
                GameEvents.Current.GameOver();
            }

            if (pauseTimer > 0 && fuelTimerPaused)
            {
                pauseTimer -= Time.deltaTime;
                if (pauseTimer <= 0)
                {
                    fuelTimerPaused = false;
                    fuelText.color = Color.white;
                }
            }
        }
    }
    
    private void OnPlayerFuelPickup()
    {
        remainingFuel += 3;
        fuelText.text = "Remaining Fuel: " + Mathf.Round(remainingFuel);
    }

    private void OnPlayerItemPickup(ItemBehavior item)
    {
        if(item.ItemSpawnType == ItemType.PauseTimer)
        {
            fuelTimerPaused = true;
            pauseTimer = 3;
            fuelText.color = Color.yellow;
        }
    }
}
