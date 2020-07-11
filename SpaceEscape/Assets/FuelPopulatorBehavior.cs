using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPopulatorBehavior : MonoBehaviour
{
    GameObject _fuel = null;
    GameObject _item = null;
    private AudioSource playerPickupAudioSource;
    private AudioSource enemyPickupAudioSource;
    private float populatorTimer = 0;
    private int fuelPickupCount = 0;
    private bool itemSpawned = false;
    private bool itemFuelPairExists = false;

    void Start()
    {
        _fuel = GameObject.Find("Fuel");
        _item = GameObject.Find("Item");
        _item.SetActive(false);
        playerPickupAudioSource = GetComponents<AudioSource>()[0];
        enemyPickupAudioSource = GetComponents<AudioSource>()[1];
        GameEvents.Current.OnPlayerFuelPickup += OnPlayerFuelPickup;
        GameEvents.Current.OnPlayerItemPickup += OnPlayerItemPickup;
        GameEvents.Current.OnEnemyFuelPickup += OnEnemyFuelPickup;
        GameEvents.Current.OnEnemyItemPickup += OnEnemyItemPickup;
    }

    void Update()
    {
        if(populatorTimer > 0)
        {
            populatorTimer -= Time.deltaTime;
        }
        else if(populatorTimer <= 0)
        {
            _fuel.SetActive(true);
            if (!itemSpawned)
            {
                SpawnItem();
            }
        }
    }

    private void OnPlayerFuelPickup()
    {
        playerPickupAudioSource.Play();
        _fuel.SetActive(false);
        itemFuelPairExists = false;
        StartFuelRespawnTimer();
        ++fuelPickupCount;
    }

    private void OnPlayerItemPickup(ItemBehavior item)
    {
        playerPickupAudioSource.Play();
        _item.SetActive(false);
        itemSpawned = false;
    }

    private void OnEnemyFuelPickup()
    {
        enemyPickupAudioSource.Play();
        _fuel.SetActive(false);
        StartFuelRespawnTimer();
    }

    private void OnEnemyItemPickup()
    {
        enemyPickupAudioSource.Play();
        _item.SetActive(false);
        itemSpawned = false;
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
