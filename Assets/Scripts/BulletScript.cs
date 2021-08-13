using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 15f;
    public int damage = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                collision.GetComponent<PlayerScript>().ReduceHealth(damage);
                SelfKill();
                break;
            case "Obstacle":

                SelfKill();
                break;
        }
    }

    private void SelfKill()
    {
        Destroy(gameObject);
    }
}
