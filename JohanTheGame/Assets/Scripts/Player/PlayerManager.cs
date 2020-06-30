using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerHealth plHealth;

    public SpriteRenderer rend;

    private int counter = 0;

    public float invulnTime = 1.2f;
    public int blinkTimes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBehaviour>())
        {
            ExecuteDamageProcedure();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ExecuteDamageProcedure();
        }
    }

    private void ExecuteDamageProcedure()
    {
        plHealth.TakeDamage();
        StartCoroutine(PlayerHit());
    }

    IEnumerator PlayerHit()
    {
        Physics2D.IgnoreLayerCollision(10, 11);
        yield return StartCoroutine(Blink(blinkTimes));
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    IEnumerator Blink(int times)
    {
        for(int i = 0; i < times; i++)
        {
            for (float f = 1; f > 0.25; f -= 0.05f)
            {
                Color c = rend.material.color;
                c.a = f;
                rend.material.color = c;
                counter++;
                yield return new WaitForSeconds(invulnTime / (30 * blinkTimes));
            }
            for (float f = rend.material.color.a; f <= 1; f += 0.05f)
            {
                Color c = rend.material.color;
                c.a = f;
                rend.material.color = c;
                counter++;
                yield return new WaitForSeconds(invulnTime / (30 * blinkTimes));
            }
            Debug.Log("Counter = " + counter);
        }
        //Debug.Log("Counter = " + counter);
        //for (float f = 1; f >= 0.25; f -= 0.05f)
        //{
        //    Color c = rend.material.color;
        //    c.a = f;
        //    rend.material.color = c;
        //    counter++;
        //    yield return new WaitForSeconds(invulnTime / 60);
        //}
        //Debug.Log("Counter = " + counter);
        //for (float f = rend.material.color.a; f <= 1; f += 0.05f)
        //{
        //    Color c = rend.material.color;
        //    c.a = f;
        //    rend.material.color = c;
        //    counter++;
        //    yield return new WaitForSeconds(invulnTime / 60);
        //}
        //Debug.Log("Counter = " + counter);
    }
}
