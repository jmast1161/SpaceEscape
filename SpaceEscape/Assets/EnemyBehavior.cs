using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float x = 0;
    private float y = 0;
    private int moveSpeed = 2;
    
    Vector2 velocity;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {        
        _rb = this.GetComponent<Rigidbody2D>();
        x = Random.Range(-1f, 1f);    
        y = Random.Range(-1f, 1f); 
        direction = new Vector2(x, y);
        _rb.velocity =  direction * moveSpeed;
        GameEvents.Current.OnPlayerFuelPickup += OnPlayerFuelPickup;
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(9, 10);
    }

    // Update is called once per frame
    void Update()
    { 
        velocity = _rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        var circleCollider = this.GetComponent<CircleCollider2D>();
        if (col.gameObject.name == "Background")
        {
            direction = Vector2.Reflect(velocity.normalized, col.contacts[0].normal);
            _rb.velocity = direction * moveSpeed;     
        }
    }

    private void OnPlayerFuelPickup()
    {
        moveSpeed += 1;
        _rb.velocity = direction * moveSpeed;
    }
}
