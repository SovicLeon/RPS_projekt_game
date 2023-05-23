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

    public bool hasMovementSpeedPickup = false;
    private Quaternion targetRotation;
    public float rotationSpeed = 400f;

    private void Start() {
        EnablePlayerMovment();
    }
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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

        if (move)
        {
            float angle = Mathf.Atan2(lastVerticalVector, lastHorizontalVector) * Mathf.Rad2Deg;
            targetRotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
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

    public void ChangeSpeed(float newSpeed)
    {
        StartCoroutine(ChangeSpeedForDuration(newSpeed, 10f));
    }

    private IEnumerator ChangeSpeedForDuration(float newSpeed, float duration)
    {
        float originalSpeed = speed;
        speed = newSpeed;
        hasMovementSpeedPickup = true;
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
        hasMovementSpeedPickup = false;
    }

    public void UpgradeSpeed(float add)
    {
       speed += add;
    }
}
