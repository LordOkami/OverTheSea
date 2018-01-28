using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alaveo : MonoBehaviour {

    public float duration = 1.0F;
    public Light lt;
    public GameObject plano;

    void Start()
    {
        lt = GetComponent<Light>();
    }
    // Update is called once per frame 
    void Update()
    {
        plano.transform.Rotate(0, 0, Time.deltaTime * 3 * 45);
    }
}
