using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 movementVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public bool move = false;


    [SerializeField] float speed = 3f;

    private void Start() {
        EnablePlayerMovment();
    }
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector.x != 0 && movementVector.y != 0) {
            lastHorizontalVector = movementVector.x;
            lastVerticalVector = movementVector.y;
            if (move == false) {
                move = true;
            }
        } else if (movementVector.x != 0) {
            lastHorizontalVector = movementVector.x;
            lastVerticalVector = 0.0f;
            if (move == false) {
                move = true;
            }
        } else if (movementVector.y != 0) {
            lastVerticalVector = movementVector.y;
            lastHorizontalVector = 0.0f;
            if (move == false) {
                move = true;
            }
        }

        movementVector *= speed;

        rgbd2d.velocity = movementVector;
    }

    private void OnEnable() {
        PlayerHealth.OnPlayerDeath += DisablePlayerMovment;
    }
    private void OnDisable() {
        PlayerHealth.OnPlayerDeath -= DisablePlayerMovment;
    }
    private void DisablePlayerMovment(){
        rgbd2d.bodyType= RigidbodyType2D.Static;
    }
     private void EnablePlayerMovment(){
        rgbd2d.bodyType= RigidbodyType2D.Dynamic;
    }
}
