using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool facingRight = true;
    private float moveInput;
    private Rigidbody2D rb;
    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        moveInput = 0.5f;
        InvokeRepeating("MoveEnemy", 0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        //Simulate movement
        if (facingRight == false && moveInput < 0) {
            Flip();
        } else if (facingRight == true && moveInput > 0) {
            Flip();
        }
    }

    void MoveEnemy() {
        moveInput *= -1.0f;
    }

    public void StopMoving() {
        moveInput = 0;
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
