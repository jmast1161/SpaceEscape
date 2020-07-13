using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private int moveSpeed = 5;
    private bool shieldActive = false;
    private AudioSource caughtAudioSource;
    private bool gameOver = false;
    private bool paused = false;

    private void Start()
    {        
        GameEvents.Current.OnPlayerItemPickup += OnPlayerItemPickup;
        GameEvents.Current.OnGameOver += OnGameOver;
        GameEvents.Current.OnPaused += OnPaused;
        caughtAudioSource = GetComponent<AudioSource>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<BackgroundMusicBehavior>().PlayMusic();
    }

    private void OnPaused()
    {
        paused = !paused;
    }

    private void OnGameOver()
    {
        gameOver = true;
    }

    private void Update()
    {
        if (!gameOver && !paused)
        {
            RotateSprite();
            MoveSprite();
        }
    }

    private void MoveSprite()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            if (shieldActive)
            {
                shieldActive = false;
                var spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                GameEvents.Current.GameOver();
            }

            caughtAudioSource.Play();
        }
    }

    private void OnPlayerItemPickup(ItemBehavior item)
    {
        if(item.ItemSpawnType == ItemType.Shield)
        {
            shieldActive = true;
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
}
