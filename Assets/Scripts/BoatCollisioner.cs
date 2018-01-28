using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCollisioner : MonoBehaviour {


  
    public GameObject explosionEffect;

    void Start(){
	
    }



    void OnCollisionEnter(Collision collision)
    {

        GameObject other = collision.gameObject;

        if (other.tag == "Rock")
        {
            GameObject explosionParticle = Instantiate(explosionEffect, transform.position, Quaternion.identity) as GameObject;
            explosionParticle.SetActive(true);
            Destroy(explosionParticle, 3);
            // Parece ñapa, mirar si se puede borrar de otra forma
            this.gameObject.SetActive(false);
        }

    }
    

}
