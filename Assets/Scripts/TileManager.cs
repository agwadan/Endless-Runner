using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour{

    public GameObject [] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 10.0f;
    private int amtOfTilesOnScreen = 7;

    void Start(){
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amtOfTilesOnScreen ; i++){//------------------------- Spawning the first set of 7 tiles.
            SpawnTile();
        }
    }

    void Update(){
        if(playerTransform.position.z > (spawnZ - amtOfTilesOnScreen * tileLength)){
            SpawnTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1){ //----------------------------- Function to spawn tiles.
        GameObject go;
        go = Instantiate (tilePrefabs[0]) as GameObject;
        go.transform.SetParent (transform);//------------------------------------ Setting the new tile to the position of it's parent which is the tile manager.
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ = spawnZ + tileLength;
    }
}
