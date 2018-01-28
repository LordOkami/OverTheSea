using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;


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
            transform.parent.gameObject.SetActive(false);

            Text textobj = GameObject.Find("ScoreValue").GetComponent<Text>();

            int score = int.Parse(textobj.text);


            if (score <= -100)
            {
                SceneManager.LoadScene("Game Over", LoadSceneMode.Single);

            }
            else {
                textobj.text = (score -50) + "";
            }


        }

    }
    

}
