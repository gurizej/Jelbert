using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitOfDeath : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float playerPosX = player.transform.position.x;
        transform.position = new Vector3(playerPosX, -7, 0);
    }
}
