using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float x = 0;
    private float y = 0;
    private int moveSpeed = 15;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-1f, 1f);    
        y = Random.Range(-1f, 1f); 
        direction = new Vector3(x, y, 0); 
    }

    // Update is called once per frame
    void Update()
    {    
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
    
        if (screenPos.y <= 0 || screenPos.y >= Screen.height)
        {
            direction = new Vector3(x, -y, 0);
        }    
        else if(screenPos.x <= 0 || screenPos.x >= Screen.width) 
        {      
            direction = new Vector3(-x, y, 0);
        }
        
        //transform.Translate (direction * Time.deltaTime * moveSpeed, Space.World); 
    }
}
