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

   

}
