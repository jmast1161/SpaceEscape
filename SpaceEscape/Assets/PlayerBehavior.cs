using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private int moveSpeed = 5;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        RotateSprite();
        MoveSprite();
    }

    private void MoveSprite()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
    
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate (Vector2.up * Time.deltaTime * moveSpeed, Space.World); 
        }      
        
        if(Input.GetKey(KeyCode.RightArrow)) 
        {            
            transform.Translate (Vector2.right * Time.deltaTime * moveSpeed, Space.World);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate (Vector2.left * Time.deltaTime * moveSpeed, Space.World); 
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate (Vector2.down * Time.deltaTime * moveSpeed, Space.World); 
        }        
    }

    private void RotateSprite()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,45));
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,315));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            }
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,135));
            }         
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,225));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,0,180));                             
            }
        }        
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,90));      
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,270));
        }
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Background")
        {
            moveSpeed = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if (other.gameObject.name == "Background")
        {
            Vector3 contactPoint = other.contacts[0].point;
            Vector3 center = GetComponent<PolygonCollider2D>().bounds.center;

            bool right = contactPoint.x > center.x;
            bool top = contactPoint.y > center.y;

            if((!right && Input.GetKey(KeyCode.LeftArrow)) ||
               (right && Input.GetKey(KeyCode.RightArrow)) ||
               (top && Input.GetKey(KeyCode.UpArrow)) ||
               (!top && Input.GetKey(KeyCode.DownArrow)))
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = 5;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.name == "Background")
        {
            moveSpeed = 5;
        }
    }
}
