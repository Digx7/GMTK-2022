using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;

    public Vector2 spawnPoint;
    public Vector2 offset;

    public int amountToSpawn;

    public void Spawn(){
      for(int i =0; i < amountToSpawn; ++i){
        GameObject spawned = Instantiate(objectsToSpawn[Random.Range(0,objectsToSpawn.Count)],this.transform);
        spawned.GetComponent<RectTransform>().anchoredPosition += spawnPoint + (offset * i);
      }
    }
}
