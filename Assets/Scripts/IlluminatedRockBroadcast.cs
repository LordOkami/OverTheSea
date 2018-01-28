using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluminatedRockBroadcast : MonoBehaviour {


	Transform light;
	Transform rock;
	float dot;
	// Use this for initialization
	void Start () {
		light = GameObject.Find("Luz Giratoria").transform;
		rock = GameObject.Find("rock").transform;
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
    var pos = transform.position;
    if(Physics.Raycast(light.position, light.forward, out hit, 100)) {
			Transform hitted = hit.collider.gameObject.transform;
      Debug.DrawRay(hitted.position, hitted.up*10, Color.green);
    }

	}
}
