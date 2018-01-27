using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        // Parece ñapa, mirar si se puede borrar de otra forma
        other.SetActive(false);
    }
}
