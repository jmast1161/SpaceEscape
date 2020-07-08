using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPopulatorBehavior : MonoBehaviour
{
    GameObject _fuel = null;
    GameObject _item = null;
    private AudioSource audioSource;
    private float populatorTimer = 0;
    private int fuelPickupCount = 0;
    private bool itemSpawned = false;
    private bool itemFuelPairExists = false;

    // Start is called before the first frame update
    void Start()
    {
        _fuel = GameObject.Find("Fuel");
        _item = GameObject.Find("Item");
        _item.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        GameEvents.Current.OnPlayerFuelPickup += OnPlayerFuelPickup;
        GameEvents.Current.OnPlayerItemPickup += OnPlayerItemPickup;
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
            _fuel.SetActive(true);            
            SpawnItem();
        }
    }

    private void OnPlayerFuelPickup()
    {
        audioSource.Play();
        _fuel.SetActive(false);
        itemFuelPairExists = false;
        StartFuelRespawnTimer();
        ++fuelPickupCount;
    }

    private void OnPlayerItemPickup(ItemBehavior item)
    {
        audioSource.Play();
        _item.SetActive(false);
        itemSpawned = false;
    }

    private void OnEnemyFuelPickup()
    {
        audioSource.Play();
        _fuel.SetActive(false);
        StartFuelRespawnTimer();
    }

    private void StartFuelRespawnTimer()
    {
        populatorTimer = 2.0f;
    }

    private void SpawnItem()
    {
        if(fuelPickupCount % 3 == 0 && fuelPickupCount > 0 && !itemSpawned && !itemFuelPairExists)
        {
            var script = _item.GetComponent<ItemBehavior>();
            if(script != null)
            {
                script.Spawn();
                _item.SetActive(true);
                itemSpawned = true;
                itemFuelPairExists = true;
            }
        }
    }
}
