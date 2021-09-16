using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameController _game;
    public float velocidad  = 7;
    private SpriteRenderer sr;
    private const string tagEnemigo = "Enemy";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _game = FindObjectOfType<GameController>();
        
        sr = GetComponent<SpriteRenderer>();
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.flipX)
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
        }else
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.CompareTag(tagEnemigo))
        {
            Destroy(other.gameObject);
            _game.PlusScore(10);
        }
        
    }
}