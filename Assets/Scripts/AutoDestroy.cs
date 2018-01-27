using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public float lifetime = 3;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
