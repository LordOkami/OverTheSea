using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    private Light light;
    private int sign = 1;
	// Use this for initialization
	void Start () {
       light = this.GetComponent<Light>();
        light.intensity = Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update () {
        light.intensity+=0.1F * sign;
        if (light.intensity > 3)
        {
            sign = -1;
        }
        else if (light.intensity <= 0)
        {
            sign = 1;
        }
		
	}
}
