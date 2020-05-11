using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    GameObject parent;
    public Animator parentAnimator;
    public float swordScore = 0f;

    public AudioSource swordSlashAudio;

    void Start() {
        parent = this.gameObject.transform.parent.gameObject;
    }

    void OnEnable() 
    {
        parentAnimator.SetBool("Slash", true);
        Invoke("SheathSword", 0.25f);
    }

    void OnDisable()
    {
        parentAnimator.SetBool("Slash", false);
        parentAnimator.SetBool("JumpSlash", false);
    }

    void SheathSword() {
        this.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            //Destroy(other.gameObject);
            addToScore();

            //Play sound
            other.gameObject.GetComponent<EnemyMovement>().PlayDeathSound();
            //Animation resets
            other.gameObject.GetComponent<EnemyMovement>().StopMoving();
            //Movement Reset 
            other.gameObject.GetComponent<Animator>().enabled = false;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 5);
            foreach(Collider2D c in other.gameObject.GetComponents<Collider2D>()) {
                c.enabled = false;
            }
            
        }
    }

    void addToScore() {
        swordScore = swordScore + 10;
    }
}
