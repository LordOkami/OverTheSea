using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    // C#
    public GameObject boatPrefab;
    public float spawnTime = 3f;

    void Start()
    {
      Debug.Log("STARTING SPAWNER");
      InvokeRepeating("SpawnBoat", spawnTime, spawnTime);
    }


    void SpawnBoat() {
      Debug.Log("spawning");
      float size = 40f;
      Vector3[] randomeVectors = new Vector3[4] {
        new Vector3(size, 0f, Random.Range(-size, size)),
        new Vector3(-size, 0f, Random.Range(-size, size)),
        new Vector3(Random.Range(-size, size), 0f, size),
        new Vector3(Random.Range(-size, size), 0f, -size)
      };

      int firstVector = Random.Range(0, 4);
      int secondVector = (Random.Range(0, 3) + 1 + firstVector) % 4;

      Vector3 originPos = randomeVectors[firstVector];
      Vector3 targetPos = randomeVectors[secondVector];

      Transform tempObj = Instantiate(boatPrefab.transform, originPos, Quaternion.Euler(0, Random.Range(0, 360), 0));
      GameObject target = tempObj.Find("Target").gameObject;
      target.transform.position = targetPos;
      tempObj.gameObject.SetActive(true);
    }
}
