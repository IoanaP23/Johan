using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public ParticleSystem dust;

    private Rigidbody2D rb;
    public float moveSpeed = 10;
    private float moveInputX;

    public float jumpForce;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Animator animator;

    private float jumpTimeCounter;
    [SerializeField] public float jumpTime;
    private bool isJumping;
    private bool spacePressed;
    public bool canJump = true;

    private int totalJumps = 1;
    private int jumpsLeft;

    private int hasJumped = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        PlayerInput();
        MovePlayer();

        animator.SetInteger("moveSpeed", (int) moveInputX);

        if (Input.GetKeyDown(KeyCode.I))
        {
            totalJumps++;
            ResetJumps();
        }

        if (Input.GetKeyDown(KeyCode.K) && totalJumps > 1)
        {
            totalJumps--;
            ResetJumps();
        }
    }
    
    void PlayerInput()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");

        if(moveInputX < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if(moveInputX > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            jumpsLeft--;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce / 15;

            
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    void MovePlayer()
    {
        rb.transform.position += new Vector3(moveInputX * moveSpeed * Time.deltaTime, 0, 0);
        //If space is pressed, jump
        
    }
    public void MiniJump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    void CreateDust()
    {
        dust.Play();
    }

    public void SetJumpFlag(bool flag)
    {
        canJump = flag;
    }

    public void ResetJumps()
    {
        jumpsLeft = totalJumps;
    }
}
