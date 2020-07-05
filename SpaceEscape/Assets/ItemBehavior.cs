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
    private ItemType  itemType = ItemType.Undefined;    
    
    public void Spawn()
    {
        x = Random.Range(-3, 3);    
        y = Random.Range(-2, 2); 
        transform.position = new Vector2(x, y);  
        
        //randomize item type here
        itemType = ItemType.PauseTimer;
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Player")
        {   
            GameEvents.Current.PlayerItemPickup();
        }

        if (col.gameObject.name == "Enemy")
        {
            GameEvents.Current.EnemyItemPickup();
        }
    }
}
