using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingFuelTimer : MonoBehaviour
{
    private float remainingFuel = 5;
    private Text fuelText;

    // Start is called before the first frame update
    void Start()
    {
        fuelText = GetComponent<Text>();        
        fuelText.text = "Remaining Fuel: " + Mathf.Round(remainingFuel);        
        GameEvents.Current.OnPlayerFuelPickup += OnPlayerFuelPickup;
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingFuel > 0)
        {
            remainingFuel -= Time.deltaTime;
            fuelText.text = "Remaining Fuel: " + Mathf.Round(remainingFuel);
        }
    }
    
    private void OnPlayerFuelPickup()
    {
        remainingFuel += 2;
        fuelText.text = "Remaining Fuel: " + Mathf.Round(remainingFuel);
    }
}
