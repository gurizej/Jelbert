using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    GameObject parent;
    public Animator parentAnimator;
    public float swordScore = 0f;

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
            Destroy(other.gameObject);
            addToScore();
        }
    }

    void addToScore() {
        swordScore = swordScore + 10;
    }
}
