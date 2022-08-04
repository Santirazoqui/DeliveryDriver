using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;
    float baseMoveSpeed;
    [SerializeField] float slowSpeed;
    [SerializeField] float boostSpeed;

    void Start() 
    {
        baseMoveSpeed = moveSpeed;
    }

    void Update() 
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
        if(moveSpeed > baseMoveSpeed)
        {
            moveSpeed -= 0.01f;
        }

        if(moveSpeed < baseMoveSpeed)
        {
            moveSpeed += 0.1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "SpeedUp")
        {
            moveSpeed = boostSpeed;
        }
    }
}
