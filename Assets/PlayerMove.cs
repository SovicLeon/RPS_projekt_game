using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    Vector3 movementVector;
    public Animator animator;

    [SerializeField] float speed = 3f;

    // Start is called before the first frame update
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movementVector = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        movementVector *= speed;

        rgbd2d.velocity = movementVector;

        if (movementVector.magnitude > 0)
        {
            animator.SetBool("isBoosting", true);
        }
        else
        {
            animator.SetBool("isBoosting", false);
        }

    }
}
