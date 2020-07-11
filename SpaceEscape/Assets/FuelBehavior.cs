using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBehavior : MonoBehaviour
{
    private float x = 0;
    private float y = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetFuelPosition();
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Player")
        {
            SetFuelPosition();
            GameEvents.Current.PlayerFuelPickup();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            SetFuelPosition();
            GameEvents.Current.EnemyFuelPickup();
        }
    }

    private void SetFuelPosition()
    {
        x = Random.Range(-3, 3);
        y = Random.Range(-2, 2);
        transform.position = new Vector2(x, y);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
