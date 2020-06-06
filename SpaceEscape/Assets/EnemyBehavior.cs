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

    // Start is called before the first frame update
    void Start()
    {        
        _rb = this.GetComponent<Rigidbody2D>();
        x = Random.Range(-1f, 1f);    
        y = Random.Range(-1f, 1f); 
        _rb.velocity = new Vector2(x, y) * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    { 
        velocity = _rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Background")
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
    
            Vector3 contactPoint = col.contacts[0].point;
            Vector3 center = GetComponent<CircleCollider2D>().bounds.center;

            var dir = Vector3.Reflect(velocity.normalized, col.contacts[0].normal);
            _rb.velocity = dir * Mathf.Max(moveSpeed, 0f);     
        }

        if(col.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<CircleCollider2D>());            
        }
    }
}
