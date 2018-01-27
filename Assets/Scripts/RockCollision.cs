using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour {

    GameObject explosion;
 
    void Start()
    {
        explosion = GameObject.Find("Explosion");
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        GameObject explosionParticle = Instantiate(explosion, collision.transform.position, Quaternion.identity) as GameObject;
        explosionParticle.SetActive(true);
        Destroy(explosionParticle, 3);
        // Parece ñapa, mirar si se puede borrar de otra forma
        other.SetActive(false);
    }
}
