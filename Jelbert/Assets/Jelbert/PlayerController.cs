using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 3;
    private float jumpInput;
    private float moveInput;

    private Rigidbody2D rb;
    //public Rigidbody2D groundRigidBody; //May need this in the future

    private bool facingRight = true;
    private bool isGrounded = false;

    public Animator animator;

    private GameObject sword;
    private float oldPos;
    private bool isNotDead = true;
    public GameObject mainCam;

    void Start() {
        rb= GetComponent<Rigidbody2D>();
        sword = GetSword();
        oldPos = this.transform.position.x - 8;
    }

    GameObject GetSword() {
        sword = this.transform.GetChild (0).gameObject;
        return sword;
    }

    void Update() {
        if(isNotDead) {
            moveInput = Input.GetAxis("Horizontal");
            jumpInput = Input.GetAxis("Vertical");
            
            float yDir = rb.velocity.y;
            if (jumpInput > 0 && isGrounded) {
                yDir = speed + 2;
                isGrounded = false;
            } 
            
            //So you cant move back
            if (this.transform.position.x >= mainCam.transform.position.x-9 || moveInput > 0) {
                rb.velocity = new Vector2(moveInput * speed, yDir);
            } else {
                rb.velocity = new Vector2(0 * speed, yDir);
            }
            
            //Strike
            if (Input.GetKeyDown("space") && jumpInput > 0) {
                AirStrike();
            } else if (Input.GetKeyDown("space")) {
                Strike();
            } else if (jumpInput > 0) {
                animator.SetBool("Jump", true);
            }

            //Animation
            if(moveInput == 0 && jumpInput == 0) {
                animator.SetFloat("PlayerSpeed", 0);
            } else if (moveInput != 0 && jumpInput == 0) {
                animator.SetFloat("PlayerSpeed", 1);
            } 
            
            if (facingRight == false && moveInput > 0) {
                Flip();
            } else if (facingRight == true && moveInput < 0) {
                Flip();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "World") {
            isGrounded = true;
            animator.SetBool("Jump", false);
        }else if (other.gameObject.tag == "Enemy" && !sword.activeInHierarchy) {
            isNotDead = false;
            //Animation resets
            animator.SetFloat("PlayerSpeed", 0);
            animator.SetBool("Jump", false);
            animator.SetBool("JumpSlash", false);
            //Movement Reset
            rb.velocity = new Vector2(0, speed + 2);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            InvokeRepeating("mainMenu", 2f, 0f);
        }else if (other.gameObject.tag == "Pit") {
            isNotDead = false;
            animator.SetFloat("PlayerSpeed", 0);
            rb.velocity = new Vector2(0, 0);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            InvokeRepeating("mainMenu", 2f, 0f);
        }
    }

    void mainMenu() {
        SceneManager.LoadScene("Menu");
    }

    void Strike() {
        sword.SetActive(true);
        animator.SetBool("Slash", true);
    }

    void AirStrike() {
        sword.SetActive(true);
        animator.SetBool("JumpSlash", true);
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public Animator GetAnimator() {
        return animator;
    }

}
