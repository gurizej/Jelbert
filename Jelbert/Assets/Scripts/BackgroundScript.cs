using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    public GameObject camera;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float camXpos = camera.transform.position.x;
        this.gameObject.transform.position = new Vector3(camXpos, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}
