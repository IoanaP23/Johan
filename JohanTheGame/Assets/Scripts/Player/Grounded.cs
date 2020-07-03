using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    Movement plMove;
    bool timerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        plMove = GetComponentInParent<Movement>();
        Physics2D.IgnoreLayerCollision(12, 11);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            plMove.isGrounded = true;
            plMove.ResetJumps();
            plMove.SetIsJumpingAnimator(false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            plMove.isGrounded = false;
        }
    }

    
}
