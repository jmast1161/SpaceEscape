using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Current { get; private set; }

    private void Awake() 
    {
        Current = this;   
    }
    
    public event Action OnPlayerFuelPickup;

    public void PlayerFuelPickup()
    {
        if(OnPlayerFuelPickup != null)
        {
            OnPlayerFuelPickup();
        }
    }
}
