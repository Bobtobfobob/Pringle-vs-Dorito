using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    public float speed;
    public int placement;
    private Rigidbody2D rb;
    public float LifeTime;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        switch (placement)
        {
            case 0:
                rb.velocity = new Vector2(0f, speed).normalized * speed;
                break;
            case 1:
                rb.velocity = new Vector2(speed, speed).normalized * speed;
                break;
            case 2:
                rb.velocity = new Vector2(-speed, speed).normalized * speed;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
