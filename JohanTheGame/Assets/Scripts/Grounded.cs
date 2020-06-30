using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    Movement plMove;
    // Start is called before the first frame update
    void Start()
    {
        plMove = GetComponentInParent<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            plMove.isGrounded = true;
            plMove.ResetJumps();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            plMove.isGrounded = false;
        }
    }
}
