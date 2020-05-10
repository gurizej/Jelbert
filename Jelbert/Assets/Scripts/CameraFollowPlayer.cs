using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public GameObject player;
    private float previousSpot;

    public AudioSource gameAudio;

    // Start is called before the first frame update
    void Start()
    {
        previousSpot = player.transform.position.x;
        float playerPosX = player.transform.position.x;
        transform.position = new Vector3(playerPosX, 0, -1);
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerPosX = player.transform.position.x;
        if (previousSpot < playerPosX){
            transform.position = new Vector3(playerPosX, 0, -1);
            previousSpot = playerPosX;
        }
        
    }

    public void stopMusic() {
        gameAudio.Stop();
    }
}
