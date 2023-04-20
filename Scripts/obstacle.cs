using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private Vector2 direction;
    private float power;
    private Rigidbody2D rb;

    public bool breakable = false;
    public void setPower(float pw)
    {
        power = pw;
    }

    public void setDirection(Vector2 Dir)
    {
        direction = Dir;
    }

    public void setPandD(float pw, Vector2 Dir)
    {
        power = pw;
        direction = Dir;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("mouse") && breakable && !MouseBehaviour.instance.isHolding)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * power * (Time.fixedDeltaTime*100);
    }
}
