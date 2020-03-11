using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCAD : MonoBehaviour
{

    public GameObject map;
    public GameObject grid1;
    public GameObject grid2;
    public GameObject grid3;
    public GameObject player;

    public List<GameObject> mapPrefabs;
    //public List<GameObject> activeMaps;

    int mapLength = 52;
    int nextMapPlacement = 0;
    
    void Start()
    {
        //activeMaps = new List<GameObject>();
        mapPrefabs = new List<GameObject>();
        mapPrefabs.Add(grid1);
        mapPrefabs.Add(grid2);
        mapPrefabs.Add(grid3);

        float playerPosX = player.transform.position.x;
        transform.position = new Vector3(playerPosX-70, 0, -1);
        addAnotherMap(0);
    }

    void Update()
    {
        int randomIndex = randomPrefabIndex();
        float playerPosX = player.transform.position.x;
        transform.position = new Vector3(playerPosX-70, 0, -1);
        
        if (playerPosX > nextMapPlacement/2){
            addAnotherMap(randomIndex);
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(other.gameObject);
    }

    private int randomPrefabIndex()
    {
        int randomIndex = Random.Range(0, mapPrefabs.Count);
        return randomIndex;
    }

    void addAnotherMap(int randomIndex) {
        GameObject go = Instantiate(mapPrefabs[randomIndex]) as GameObject;
        go.transform.SetParent(map.transform);
        go.transform.position = new Vector2(nextMapPlacement, 0);
        nextMapPlacement = nextMapPlacement + mapLength;   
        //activeMaps.Add(go); 
        //deleteOldMap();  
    }

    //TODO: GURI memory management that deletes already passed activeMaps
    // void deleteOldMap() {
    //     Debug.Log(activeMaps.Count);
        
    //     if (activeMaps.Count > 2) {
    //         Destroy(activeMaps[0]);
    //         activeMaps.RemoveAt(0);
    //     }
    // }
}
