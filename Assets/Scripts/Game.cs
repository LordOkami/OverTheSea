using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    // C#
    public GameObject boatPrefab;

    void Start()
    {
        for (int y = 0; y < 10; y++)
        {

            Vector2 newPosition = (Vector2.one*10) + Random.insideUnitCircle * 30;

            Transform tempObj = Instantiate(boatPrefab.transform, new Vector3(newPosition.x, 0, newPosition.y), Quaternion.Euler(0, Random.Range(0, 360), 0));
            GameObject taget = tempObj.Find("Target").gameObject;
            taget.transform.position = new Vector3(Random.Range(10, 30), 0, Random.Range(10, 30));


        }
    }
}
