using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    

    public float speed = 1.5f;

    void Update()
    {
       
            transform.position += transform.right * speed * Time.deltaTime;
            //Vector3 localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
        //transform.rotation = Quaternion.LookRotation(localVelocity);


    }


    void OnCollisionEnter(Collision collision)
    {

    }
}
