using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingFuelTimer : MonoBehaviour
{
    private float remainingFuel = 5;
    private float pauseTimer = 0;
    private Text fuelText;
    private bool fuelTimerPaused = false;

    void Start()
    {
        fuelText = GetComponent<Text>();        
        fuelText.text = "Remaining Fuel: " + Mathf.Round(remainingFuel);        
        GameEvents.Current.OnPlayerFuelPickup += OnPlayerFuelPickup;
        GameEvents.Current.OnPlayerItemPickup += OnPlayerItemPickup;
    }

    void Update()
    {
        if(remainingFuel > 0 && !fuelTimerPaused)
        {
            remainingFuel -= Time.deltaTime;
            fuelText.text = "Remaining Fuel: " + Mathf.Round(remainingFuel);
        }

        if(pauseTimer > 0 && fuelTimerPaused)
        {
            pauseTimer -= Time.deltaTime;
            if(pauseTimer <= 0)
            {
                fuelTimerPaused = false;
            }
        }
    }
    
    private void OnPlayerFuelPickup()
    {
        remainingFuel += 5;
        fuelText.text = "Remaining Fuel: " + Mathf.Round(remainingFuel);
    }

    private void OnPlayerItemPickup(ItemBehavior item)
    {
        if(item.ItemSpawnType == ItemType.PauseTimer)
        {
            fuelTimerPaused = true;
            pauseTimer = 5;
        }
    }
}
