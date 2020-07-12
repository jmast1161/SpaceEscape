using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPopulatorBehavior : MonoBehaviour
{
    GameObject _fuel = null;
    GameObject _item = null;
    private AudioSource playerFuelPickupAudioSource;
    private AudioSource enemyFuelItemPickupAudioSource;
    private AudioSource playerItemPickupAudioSource;
    private float populatorTimer = 0;
    private int fuelPickupCount = 0;
    private bool itemSpawned = false;
    private bool itemFuelPairExists = false;

    void Start()
    {
        _fuel = GameObject.Find("Fuel");
        _item = GameObject.Find("Item");
        _item.SetActive(false);
        var audioSources = GetComponents<AudioSource>();
        playerFuelPickupAudioSource = audioSources[0];
        enemyFuelItemPickupAudioSource = audioSources[1];
        playerItemPickupAudioSource = audioSources[2];
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
        playerFuelPickupAudioSource.Play();
        _fuel.SetActive(false);
        itemFuelPairExists = false;
        StartFuelRespawnTimer();
        ++fuelPickupCount;
    }

    private void OnPlayerItemPickup(ItemBehavior item)
    {
        playerItemPickupAudioSource.Play();
        _item.SetActive(false);
        itemSpawned = false;
    }

    private void OnEnemyFuelPickup()
    {
        enemyFuelItemPickupAudioSource.Play();
        _fuel.SetActive(false);
        StartFuelRespawnTimer();
    }

    private void OnEnemyItemPickup()
    {
        enemyFuelItemPickupAudioSource.Play();
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
