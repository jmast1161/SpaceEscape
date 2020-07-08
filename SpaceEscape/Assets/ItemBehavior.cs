using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Undefined = 0,
    PauseTimer = 1,
    Shield = 2,
    DeployEnemy = 3,
}

public class ItemBehavior : MonoBehaviour
{
    private float x = 0;
    private float y = 0;
    private ItemType itemSpawnType = ItemType.Undefined;
    public ItemType ItemSpawnType { get { return itemSpawnType; } }

    private void Start() 
    {
        itemSpawnType = ItemType.Undefined;
    }

    public void Spawn()
    {
        x = Random.Range(-3, 3);    
        y = Random.Range(-2, 2); 
        transform.position = new Vector2(x, y);  
        
        //randomize item type here
        var randomItem = Random.Range(1, 3);  // don't forget to change back to 1,4
        
        switch(randomItem)
        {
            case 1:
                itemSpawnType = ItemType.PauseTimer;
                break;
            case 2:
                itemSpawnType = ItemType.Shield;
                break;
            case 3:
                itemSpawnType = ItemType.DeployEnemy;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Player")
        {   
            GameEvents.Current.PlayerItemPickup(this);
        }

        if (col.gameObject.name == "Enemy")
        {
            GameEvents.Current.EnemyItemPickup();
        }
    }
}
