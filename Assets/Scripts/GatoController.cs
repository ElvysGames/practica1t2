using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    public GameObject rightBullet;
    public GameObject leftBullet;
    private GameController _game;
    public float velocidad  = 7;
    public float salto  = 40;
    private const string tagMoneda1 = "Coin1";
    private const string tagMoneda2 = "Coin2";
    private const string tagMoneda3 = "Coin3";
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        _game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Estado", 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y); 
            sr.flipX = false;
            animator.SetInteger("Estado",1); 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y); 
            sr.flipX = true; 
            animator.SetInteger("Estado",1); 
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            animator.SetInteger("Estado",2); 
        }   
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetInteger("Estado",3); 
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            var bullet = sr.flipX ? leftBullet : rightBullet;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = rightBullet.transform.rotation;
            Instantiate(bullet, position, rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(tagMoneda1))
        {
            Destroy(collider.gameObject);
            _game.PlusMoneda1(1);
        }
        if (collider.gameObject.CompareTag(tagMoneda2))
        {
            Destroy(collider.gameObject);
            _game.PlusMoneda2(1);
        }
        if (collider.gameObject.CompareTag(tagMoneda3))
        {
            Destroy(collider.gameObject);
            _game.PlusMoneda3(1);
        }
    }
}