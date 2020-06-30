using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    public EnemyBehaviour eB;
    // Start is called before the first frame update
    void Start()
    {
        //eB = GetComponentInParent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerHit")
        {
            Movement plMove = collision.GetComponentInParent<Movement>();
            plMove.MiniJump();
            eB.Dead();
        }
    }
}
