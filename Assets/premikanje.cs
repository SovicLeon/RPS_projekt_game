using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class premikanje : MonoBehaviour
{
    private float nextActionTime = 1.0f;
    public float speed = 2.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime += 2;
            speed = -speed;
            rb.velocity = new Vector2(speed, 0);
        }
    }
}
