using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour {

    // C#
    public Transform prefab;

    void Start()
    {
        for (int y = 0; y < 30; y++)
        {

            Vector2 newPosition = (Vector2.one*10) + Random.insideUnitCircle * 30;

            Transform tempObj = Instantiate(prefab, new Vector3(newPosition.x, 0, newPosition.y), Quaternion.Euler(0, Random.Range(0, 360), 0));

        }
    }
}
