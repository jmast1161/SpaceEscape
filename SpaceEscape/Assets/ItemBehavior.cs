using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Undefined = 0,
    PauseTimer = 1,
    Shield = 2,
    EnemySpeedDown = 3,
}

public class ItemBehavior : MonoBehaviour
{
    private float x = 0;
    private float y = 0;
    private ItemType itemSpawnType = ItemType.Undefined;

    public ItemType ItemSpawnType { get { return itemSpawnType; } }
    
    public void Spawn()
    {
        x = Random.Range(-3, 3);    
        y = Random.Range(-2, 2); 
        transform.position = new Vector2(x, y);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        itemSpawnType = (ItemType) Random.Range(1, 4);
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Player")
        {   
            GameEvents.Current.PlayerItemPickup(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            GameEvents.Current.EnemyItemPickup();
        }
    }
}
