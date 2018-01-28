using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour {


    // C#
    public GameObject exclamationPrefab;
    private Transform exclamation;
    public bool exclamationActive = true;
    public GameObject explosionEffect;

    // Use this for initialization
    void Start () {
        exclamation = Instantiate(exclamationPrefab.transform, this.transform.position + new Vector3(0,3,0), transform.rotation,this.transform);
        exclamation.transform.localScale = Vector3.one * 0.2f;
    }
    

    public float speed = 1.5f;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        exclamation.gameObject.SetActive(exclamationActive);

    }

     void OnCollisionEnter(Collision collision)
    { 

        GameObject other = collision.gameObject;

        if (other.tag == "Rock")
        {
            GameObject explosionParticle = Instantiate(explosionEffect, this.transform.position, Quaternion.identity) as GameObject;
            explosionParticle.SetActive(true);
            Destroy(explosionParticle, 3);
            // Parece ñapa, mirar si se puede borrar de otra forma
            this.gameObject.SetActive(false);
        }
    
    }

}
