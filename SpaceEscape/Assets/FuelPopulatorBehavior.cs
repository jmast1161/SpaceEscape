using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPopulatorBehavior : MonoBehaviour
{
    GameObject _fuelObject = null;
    private AudioSource audioSource;
    private float populatorTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _fuelObject = GameObject.Find("Fuel");
        audioSource = GetComponent<AudioSource>();
        GameEvents.Current.OnPlayerFuelPickup += OnPlayerFuelPickup;
        GameEvents.Current.OnEnemyFuelPickup += OnEnemyFuelPickup;
    }

    // Update is called once per frame
    void Update()
    {
        if(populatorTimer > 0)
        {
            populatorTimer -= Time.deltaTime;
        }
        else if(populatorTimer <= 0)
        {
            _fuelObject.SetActive(true);
        }
    }

    private void OnPlayerFuelPickup()
    {
        audioSource.Play();
        _fuelObject.SetActive(false);
        StartRespawnTimer();
    }

    private void OnEnemyFuelPickup()
    {
        audioSource.Play();
        _fuelObject.SetActive(false);
        StartRespawnTimer();
    }

    private void StartRespawnTimer()
    {
        populatorTimer = 2.0f;
    }
}
