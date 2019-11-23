using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public GameObject sword;
    float oveallScoreForPlayerPos=0;
    float displayScore = 0;

    void Update()
    {
        if(oveallScoreForPlayerPos < player.position.x) {
            oveallScoreForPlayerPos = player.position.x;
        }

        displayScore = oveallScoreForPlayerPos + sword.GetComponent<Sword>().swordScore;

        scoreText.text = displayScore.ToString("0");

    }
}
