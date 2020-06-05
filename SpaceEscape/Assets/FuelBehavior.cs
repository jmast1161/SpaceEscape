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
        x = Random.Range(-3, 3);    
        y = Random.Range(-2, 2); 
        transform.position = new Vector2(x, y);  
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector2(x, y), Space.World);      
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Player")
        {
            //Physics2D.IgnoreCollision(col.collider, GetComponent<PolygonCollider2D>());  

            x = Random.Range(-3, 3);    
            y = Random.Range(-2, 2); 
            transform.position = new Vector2(x, y); 
        }

        if (col.gameObject.name == "Enemy")
        {
            //Physics2D.IgnoreCollision(col.collider, GetComponent<PolygonCollider2D>());  

            x = Random.Range(-3, 3);    
            y = Random.Range(-2, 2); 
            transform.position = new Vector2(x, y); 
        }
    }
}
