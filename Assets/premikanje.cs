using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class premikanje : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            rb.velocity = direction.normalized * speed;
        }
    }
}