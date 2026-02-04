using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BucketController : MonoBehaviour
{
    public float movementSpeed = 6f;
    private Rigidbody2D rb;
    

    [SerializeField] private int score;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //float moveX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveX * movementSpeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.A) || left) 
        { 
            transform.Translate(Vector3.left * movementSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || right)
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }


        if (transform.position.x > 8.6f)
        {
            transform.position = new Vector3(-8.6f,transform.position.y,0);
        }
        else if(transform.position.x < -8.6f)
        {
            transform.position = new Vector3(8.6f, transform.position.y,0);
        }

       
        
    }
    public bool left, right;
    public void Left()
    {
        left=true;
    }

    public void Right()
    {
        right=true;
    }
    public void Stop()
    {
        left = false;
        right = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "fruit")
        {
            ScoreScript.scorePoint += 1;

            FindObjectOfType<AudioManager>().Play("Catch");
            if (collision.tag == "fruit")
            {
                Destroy(collision.gameObject);  
                // Destroy the fruit
            }
        }
    }
    
}
