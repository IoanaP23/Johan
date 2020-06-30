using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    bool alive = true;
    bool moveLeft = true;

    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alive == true)
        {
            Move();
        }
    }
    public void Dead()
    {
        alive = false;
        anim.SetTrigger("Dead");
        Destroy(gameObject, 0.25f);
    }
    void Move()
    {
        if (moveLeft)
        {
            rb.velocity = new Vector2(-3 * moveSpeed * Time.deltaTime, 0);
        }
        else
        {
            rb.velocity = new Vector2(3 * moveSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Reverse")
        {
            moveLeft = !moveLeft;
        }
    }
}
