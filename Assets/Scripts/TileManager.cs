using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour{

    public GameObject [] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = -6.0f;//------------------------------------------- The value is negative so the camera doesn't see the empty space at the beginning of the run.
    private float tileLength = 10.0f;
    private float safeZone = 15.0f;
    private int amtOfTilesOnScreen = 7;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;//------------------------------------- List to hold the tiles currently on display.

    void Start(){
        activeTiles     = new List<GameObject>();//--------------------------------- Before using a list in c#, it has to be instantiated.
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amtOfTilesOnScreen ; i++){//------------------------- Spawning the first set of 7 tiles.
            if(i < 3){
                SpawnTile(0);
            } else {
                SpawnTile();
            }
        }
    }

    void Update(){
        if(playerTransform.position.z - safeZone > (spawnZ - amtOfTilesOnScreen * tileLength)){
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1){ //----------------------------- Function to spawn tiles.
        GameObject go;

        if(prefabIndex == -1){
             go = Instantiate (tilePrefabs[RandomPrefabIndex()]) as GameObject;
        } else {
             go = Instantiate (tilePrefabs[prefabIndex]) as GameObject;
        }
       
        go.transform.SetParent (transform);//------------------------------------ Setting the new tile to the position of it's parent which is the tile manager.
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add (go); //------------------------------------------------- Adding the gameObject to the list of active tiles.
    }

    private void DeleteTile(){
        Destroy (activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex(){
        if(tilePrefabs.Length <=1){ //------------------------------------------- Returning one prefab if it's the only one in the list.
                return 0;
            }

            int randomIndex = lastPrefabIndex;
            while(randomIndex == lastPrefabIndex){ //--------------------------- If the random index chosen is the same as the previous, the while loop is repeated.
                randomIndex = Random.Range (0, tilePrefabs.Length); //---------- Getting a random index from the list of tiles available as prefabs.
            }

            lastPrefabIndex = randomIndex;
            
        

        return randomIndex;
    }
}